using System;
using System.Collections.Generic;

namespace API_NOTAS.Models;

public partial class Nota
{
    public int IdNota { get; set; }

    public decimal? Nota1 { get; set; }

    public int? NNota { get; set; }

    public int CodAlumno { get; set; }

    public int IdAsignatura { get; set; }

    public virtual Alumno CodAlumnoNavigation { get; set; } = null!;

    public virtual Asignatura IdAsignaturaNavigation { get; set; } = null!;
}
