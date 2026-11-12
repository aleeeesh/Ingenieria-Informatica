namespace PizzeriaBellaItalia.Dominio;

public class PedidoPizza
{
    public int Id { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string TamanoNombre { get; set; } = string.Empty;
    public int PrecioTamano { get; set; }
    public int CantidadIngredientes { get; set; } = 1;
    public string TipoMasa { get; set; } = "Tradicional";

    public bool TieneDescuento { get; set; } = false;

    public bool EsDelivery { get; set; } = false;

    public int TotalPagar { get; internal set; }
    public int PrecioBaseTamano { get; internal set; }
    public string MasaNombre { get; internal set; } = string.Empty;
    public int RecargoMasa { get; internal set; }

    public bool AplicaConvenioEstudiante { get; internal set; }

    private const double TASA_IVA = 0.19;

    public PedidoPizza() { }

    public PedidoPizza(string cliente, string telefono, string tamanoNombre, int precioTamano, int cantidad, string tipoMasa)
    {
        Cliente = cliente;
        Telefono = telefono;
        TamanoNombre = tamanoNombre;
        PrecioBaseTamano = precioTamano;
        TipoMasa = tipoMasa;
        CantidadIngredientes = cantidad;

        RecargoMasa = CalcularRecargoMasa(tipoMasa);
        TotalPagar = CalcularTotal();
    }

    public PedidoPizza(int id, string cliente, string telefono, string tamanoNombre, int precioTamano, int cantidad, string tipoMasa,)
        : this(cliente, telefono, tamanoNombre, precioTamano, cantidad, tipoMasa)
    {
        Id = id;
    }

    private int CalcularRecargoMasa(string tipoMasa)
    {
        switch (tipoMasa)
        {
            case "Borde de Queso":
                return 1500;
            default:
                return 0;
        }
    }

    internal int CalcularSubtotal()
    {
        int subtotalBase = PrecioTamano;
        subtotalBase += (1500 * CantidadIngredientes);
        return subtotalBase;
    }

    internal int CalcularTotal()
    {
        int subtotal = CalcularSubtotal();
        int iva = CalcularMontoIva(subtotal);
        return subtotal + iva;
    }


    internal decimal CalcularMontoDescuento()
    {
        if (TieneDescuento)
        {
            return CalcularSubtotal() * 0.10m; // 10% de descuento
        }
        else
        {
            return 0;
        }
    }

    internal int CalcularCostoDelivery()
    {
        if (EsDelivery)
        {
            return 2000; // Costo fijo de delivery
        }
        else
        {
            return 0;
        }
    }

    internal int CalcularMontoIva(int v)
    {
        return (int)(v * TASA_IVA);
    }
}
