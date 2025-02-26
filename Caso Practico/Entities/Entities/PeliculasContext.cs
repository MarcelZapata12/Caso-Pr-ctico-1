using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class PeliculasContext : DbContext
{
    public PeliculasContext()
    {
    }

    public PeliculasContext(DbContextOptions<PeliculasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Parametro> Parametros { get; set; }

    public virtual DbSet<Programa> Programas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Marcel\\MSSQLSERVER01;Database=Peliculas;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parametro>(entity =>
        {
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Programa>(entity =>
        {
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.CategoriaNavigation).WithMany(p => p.ProgramaCategoriaNavigations)
                .HasForeignKey(d => d.Categoria)
                .HasConstraintName("FK_Parametros_categorias");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.ProgramaTipoNavigations)
                .HasForeignKey(d => d.Tipo)
                .HasConstraintName("FK__Parametros_tipos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
