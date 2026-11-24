namespace API_CAMIONES.Filtros
{

    public class CrearConductor
    {
        public required string NombreCompleto { get; set; }
        public required int IdEstado { get; set; }
    }

    public class ObtenerConductores
    {
        public required int IdConductor { get; set; }
        public required string NombreCompleto { get; set; }
        public required string Estado { get; set; }
    }

    public class EstadoConductor
    {
        public required int IdConductor { get; set; }
    }
}
