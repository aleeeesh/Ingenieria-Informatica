namespace PizzeriaBellaItalia.Dominio
{
    public class PedidoPizza
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string TamanoNombre { get; set; } = string.Empty;
        public int RecargoTamano { get; set; }
        public string MasaNombre { get; set; } = string.Empty;
        public int RecargoMasa { get; set; }

        public bool QuesoExtra { get; set; }
        public bool PepperoniExtra { get; set; }
        public bool ChampinonesExtra { get; set; }
        public bool AceitunasExtra { get; set; }
        public bool TocinoExtra { get; set; }

        public bool EsDelivery { get; set; }
        public bool AplicaConvenioEstudiante { get; set; }

        public int Subtotal { get; internal set; }
        public int Descuento { get; internal set; }
        public int RecargoDelivery { get; internal set; }
        public int MontoIva { get; internal set; }
        public int TotalPagar { get; internal set; }

        private const int PRECIO_INGREDIENTE_EXTRA = 800;
        private const int RECARGO_DELIVERY = 2000;
        private const double TASA_DESCUENTO = 0.10;
        private const double TASA_IVA = 0.19;

        
        public PedidoPizza() { }

        public PedidoPizza(int id, string cliente, string telefono, string tamanoNombre, int recargoTamano, string masaNombre, int recargoMasa)
        {
            Id = id;
            Cliente = cliente;
            Telefono = telefono;
            TamanoNombre = tamanoNombre;
            RecargoTamano = recargoTamano;
            MasaNombre = masaNombre;
            RecargoMasa = recargoMasa;
        }

        public PedidoPizza(
            string cliente, string telefono, string tamanoNombre, int recargoTamano,
            string masaNombre, int recargoMasa, bool quesoExtra, bool pepperoni,
            bool champinones, bool aceitunas, bool tocino, bool esDelivery, bool aplicaConvenioEstudiante)
            : this(cliente, telefono, tamanoNombre, recargoTamano, masaNombre, recargoMasa)
        {
            QuesoExtra = quesoExtra;
            PepperoniExtra = pepperoni;
            ChampinonesExtra = champinones;
            AceitunasExtra = aceitunas;
            TocinoExtra = tocino;
            EsDelivery = esDelivery;
            AplicaConvenioEstudiante = aplicaConvenioEstudiante;

            Subtotal = CalcularSubtotal();
            Descuento = CalcularMontoDescuento();
            RecargoDelivery = CalcularCostoDelivery();
            MontoIva = CalcularMontoIva();
            TotalPagar = CalcularTotalPagar();
        }

        private int ContarIngredientesExtra()
        {
            int total = 0;

            if (QuesoExtra) total++;
            if (PepperoniExtra) total++;
            if (ChampinonesExtra) total++;
            if (AceitunasExtra) total++;
            if (TocinoExtra) total++;

            return total;
        }

        internal int CalcularSubtotal()
        {
            return RecargoTamano + RecargoMasa + (ContarIngredientesExtra() * PRECIO_INGREDIENTE_EXTRA);
        }

        internal int CalcularMontoDescuento()
        {
            return AplicaConvenioEstudiante ? (int)(CalcularSubtotal() * TASA_DESCUENTO) : 0;
        }

        internal int CalcularCostoDelivery()
        {
            return EsDelivery ? RECARGO_DELIVERY : 0;
        }

        private int CalcularNetoAfecto()
        {
            return (CalcularSubtotal() - CalcularMontoDescuento()) + CalcularCostoDelivery();
        }

        internal int CalcularMontoIva()
        {
            return (int)(CalcularNetoAfecto() * TASA_IVA);
        }

        internal int CalcularTotalPagar()
        {
            return CalcularNetoAfecto() + CalcularMontoIva();
        }
    }
}
