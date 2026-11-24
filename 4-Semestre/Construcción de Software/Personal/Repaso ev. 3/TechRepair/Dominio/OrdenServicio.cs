namespace TechRepair.Dominio
{
    public class OrdenServicio
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string TipoEquipo { get; set; } = "Notebook";
        public string ServicioBase { get; set; } = "Mantención Preventiva";
        public double TotalPagar { get; set; } = 0;

        // Adicionales ($5.000 c/u)
        public bool LimpiezaProfunda { get; set; }
        public bool CambioPasta { get; set; }
        public bool InstalacionSoftware { get; set; }
        public bool RespaldoDatos { get; set; }

        // Modalidad y descuento
        public bool EsDomicilio { get; set; }
        public bool EsClienteFrecuente { get; set; }

        private const double PRECIO_MANTENCION = 15000.0;
        private const double PRECIO_FORMATEO = 20000.0;
        private const double PRECIO_REPARACION_PLACA = 35000.0;
        private const double PRECIO_UPGRADE = 12000.0;

        private const double RECARGO_CONSOLA_AIO = 3000.0;
        private const double PRECIO_ADICIONAL = 5000.0;
        private const double RECARGO_DOMICILIO = 4000.0;
        private const double TASA_DESCUENTO = 0.15; // 15% cliente frecuente
        private const double TASA_IVA = 0.19;       // 19% IVA

        public int ContarAdicionales()
        {
            int contador = 0;
            if (LimpiezaProfunda) contador++;
            if (CambioPasta) contador++;
            if (InstalacionSoftware) contador++;
            if (RespaldoDatos) contador++;
            return contador;
        }

        public double CalcularCostoAdicionales()
        {
            return ContarAdicionales() * PRECIO_ADICIONAL;
        }

        public double CalcularSubtotalServicio()
        {
            double valorServicio = 0;
            double recargoEquipo = 0;

            if (ServicioBase.Contains("Mantención"))
                valorServicio = PRECIO_MANTENCION;
            else if (ServicioBase.Contains("Formateo"))
                valorServicio = PRECIO_FORMATEO;
            else if (ServicioBase.Contains("Placa"))
                valorServicio = PRECIO_REPARACION_PLACA;
            else if (ServicioBase.Contains("Upgrade"))
                valorServicio = PRECIO_UPGRADE;

            if (TipoEquipo.Contains("Consola") || TipoEquipo.Contains("All-in-One"))
                recargoEquipo = RECARGO_CONSOLA_AIO;

            return valorServicio + recargoEquipo + CalcularCostoAdicionales();
        }

        public double CalcularMontoDescuento()
        {
            if (EsClienteFrecuente)
                return CalcularSubtotalServicio() * TASA_DESCUENTO;
            return 0;
        }

        public double CalcularCostoDomicilio()
        {
            return EsDomicilio ? RECARGO_DOMICILIO : 0;
        }

        public double CalcularNetoAfecto()
        {
            return CalcularSubtotalServicio() - CalcularMontoDescuento() + CalcularCostoDomicilio();
        }

        public double CalcularMontoIva()
        {
            return Math.Round(CalcularNetoAfecto() * TASA_IVA);
        }

        public double CalcularTotalPagar()
        {
            return CalcularNetoAfecto() + CalcularMontoIva();
        }
    }
}