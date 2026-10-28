using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APILogin.Models;

public partial class Estado
{
    [JsonIgnore]
    public int IdEstado { get; set; }

    public string NomEstado { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
