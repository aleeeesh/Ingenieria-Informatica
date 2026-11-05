using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APILogin.Models;

public partial class Persona
{
    [JsonIgnore]
    public int IdPersona { get; set; }

    public string NomPersona { get; set; } = null!;

    public string ApePersona { get; set; } = null!;

    public int Edad { get; set; }

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
