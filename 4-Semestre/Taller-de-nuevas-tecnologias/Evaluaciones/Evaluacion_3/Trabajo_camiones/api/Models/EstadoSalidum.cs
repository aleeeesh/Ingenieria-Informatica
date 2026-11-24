using System;
using System.Collections.Generic;

namespace API_CAMIONES.Models;

public partial class EstadoSalidum
{
    public int IdEstadoSalida { get; set; }

    public string NomEstadoSalida { get; set; } = null!;

    public virtual ICollection<Salidum> Salida { get; set; } = new List<Salidum>();
}
