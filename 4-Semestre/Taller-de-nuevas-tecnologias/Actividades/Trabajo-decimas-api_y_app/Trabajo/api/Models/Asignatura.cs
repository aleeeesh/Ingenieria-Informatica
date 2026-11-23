using System;
using System.Collections.Generic;

namespace API_NOTAS.Models;

public partial class Asignatura
{
    public int IdAsignatura { get; set; }

    public string? NomAsignatura { get; set; }

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
