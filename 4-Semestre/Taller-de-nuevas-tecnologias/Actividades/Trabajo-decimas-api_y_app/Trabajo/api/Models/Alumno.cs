using System;
using System.Collections.Generic;

namespace API_NOTAS.Models;

public partial class Alumno
{
    public int CodAlumno { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
