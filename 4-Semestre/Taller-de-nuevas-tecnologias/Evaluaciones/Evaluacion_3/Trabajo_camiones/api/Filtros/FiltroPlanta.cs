namespace API_CAMIONES.Filtros
{
    public class CreaPlanta
    {
        public required string Nombre { get; set; }
    }

    public class ObtenerPlantas
    {
        public required int IdPlanta { get; set; }
        public required string Nombre { get; set; }
    }
}
