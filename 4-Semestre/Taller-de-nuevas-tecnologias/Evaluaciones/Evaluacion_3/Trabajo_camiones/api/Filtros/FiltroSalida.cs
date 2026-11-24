namespace API_CAMIONES.Filtros
{
    public class RegistrarSalida
    {
        public required DateOnly Fecha { get; set; }
        public required int IdPlanta { get; set; }
        public required string Camion { get; set; }
        public required int IdConductor { get; set; }
    }

    public class ObtenerSalidas
    {
        public int IdSalida { get; set; }
        public required DateOnly Fecha { get; set; }
        public required string Planta { get; set; }
        public required string Camion { get; set; }
        public required string Conductor { get; set; }
        public required string Estado { get; set; }
        public required string Usuario { get; set; }
    }

    public class RetornarSalida
    {
        public required int IdSalida { get; set; }
    }
}
