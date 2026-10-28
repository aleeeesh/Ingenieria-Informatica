using System;
using System.Collections.Generic;

namespace APILogin.Models;

public partial class Usuario
{
    public string NomUsuario { get; set; } = null!;

    public int IdPersona { get; set; }

    public int IdEstado { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
