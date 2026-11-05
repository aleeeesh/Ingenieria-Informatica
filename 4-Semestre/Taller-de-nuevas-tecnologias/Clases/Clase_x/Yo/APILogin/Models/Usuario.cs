using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APILogin.Models;

public partial class Usuario
{
    public string NomUsuario { get; set; } = null!;

    public int IdPersona { get; set; }

    public int IdEstado { get; set; }

    [JsonIgnore]
    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
