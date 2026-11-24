using System;
using System.Collections.Generic;

namespace API_CAMIONES.Models;

public partial class Camion
{
    public string CodCamion { get; set; } = null!;

    public int IdPlanta { get; set; }

    public int IdEstado { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Plantum IdPlantaNavigation { get; set; } = null!;

    public virtual ICollection<Salidum> Salida { get; set; } = new List<Salidum>();
}
