namespace API_CAMIONES.Filtros
{

    public class CrearCamion
    {
        public required string CodCamion { get; set; }
        public required int IdPlanta { get; set; }
        public required int IdEstado { get; set; }
    }
    public class ObtenerCamiones
    {
        public required string CodCamion { get; set; }
        public required string Planta { get; set; }
        public required string Estado { get; set; }
    }

    public class CamionPlanta
    {
        public required int IdPlanta { get; set; }
    }

    public class EstadoCamion
    {
        public required string CodCamion { get; set; }
    }
}
