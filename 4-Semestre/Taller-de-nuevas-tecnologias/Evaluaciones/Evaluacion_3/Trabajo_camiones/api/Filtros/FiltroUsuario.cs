namespace API_CAMIONES.Filtros
{
    public class CrearUsuario
    {
        public required string Usuario { get; set; }
        public required string NombreCompleto { get; set; }
        public required string Contrasena { get; set; }
    }

    public class ObtenerSesion
    {
        public required string Usuario { get; set; }
        public required string Contrasena { get; set; }
    }

    public class ObtenerUsuarios
    {
        public string? Usuario { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Estado { get; set; }
    }

    public class EstadoUsuario
    {
        public required string Usuario { get; set; }
    }
}