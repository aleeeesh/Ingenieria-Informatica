namespace PizzeriaBellaItalia.Dominio
{
    public class PedidoPizza
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string TamanoNombre { get; set; } = string.Empty;
        public int PrecioTamano { get; set; }
        public int Cantidad { get; set; } = 1;
        public string TipoMasa { get; set; } = "Tradicional";
        public bool TieneQuesoExtra { get; set; }
        public int TotalPagar { get; set; }

        private const double TASA_IVA = 0.19;

        public PedidoPizza() { }

        public PedidoPizza(string cliente, string telefono, string tamanoNombre, int precioTamano, int cantidad, string tipoMasa, bool tieneQuesoExtra)
        {
            Cliente = cliente;
            Telefono = telefono;
            TamanoNombre = tamanoNombre;
            PrecioTamano = precioTamano;
            Cantidad = cantidad;
            TipoMasa = tipoMasa;
            TieneQuesoExtra = tieneQuesoExtra;
            TotalPagar = CalcularTotal();
        }

        public PedidoPizza(int id, string cliente, string telefono, string tamanoNombre, int precioTamano, int cantidad, string tipoMasa, bool tieneQuesoExtra)
            : this(cliente, telefono, tamanoNombre, precioTamano, cantidad, tipoMasa, tieneQuesoExtra)
        {
            Id = id;
        }

        public int CalcularSubtotal()
        {
            int subtotalBase = PrecioTamano * Cantidad;
            if (TieneQuesoExtra) subtotalBase += (1500 * Cantidad);
            return subtotalBase;
        }

        public int CalcularTotal()
        {
            int subtotal = CalcularSubtotal();
            int iva = (int)(subtotal * TASA_IVA);
            return subtotal + iva;
        }

        public override string ToString()
        {
            return $"{Cliente} ({Telefono}) | {Cantidad} x {TamanoNombre} -> Total: $ {TotalPagar:N0} CLP";
        }
    }
}