using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Programa
{
    public int ProgramaId { get; set; }

    public string? Nombre { get; set; }

    public int? Tipo { get; set; }

    public int? Categoria { get; set; }

    public virtual Parametro? CategoriaNavigation { get; set; }

    public virtual Parametro? TipoNavigation { get; set; }
}
