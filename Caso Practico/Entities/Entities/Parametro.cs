using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Parametro
{
    public int ParametroId { get; set; }

    public byte[] Descripcion { get; set; } = null!;

    public virtual ICollection<Programa> ProgramaCategoriaNavigations { get; set; } = new List<Programa>();

    public virtual ICollection<Programa> ProgramaTipoNavigations { get; set; } = new List<Programa>();
}
