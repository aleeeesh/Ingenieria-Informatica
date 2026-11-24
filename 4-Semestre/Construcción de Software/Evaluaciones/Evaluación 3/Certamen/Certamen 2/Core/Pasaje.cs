namespace StarOne.Core;

public class Pasaje
{
    public Pasaje(int vueloSeleccionado, string asiento, string rut, bool aplicaDescuentoRut)
    {
        VueloSeleccionado = vueloSeleccionado;
        Asiento = asiento;
        Rut = rut;
        AplicaDescuentoRut = aplicaDescuentoRut;
    }

    public string Rut { get; set; }
    public string NombreCompleto { get; set; }= string.Empty;
    public int Edad { get; set; }
    public int IDVuelo { get; set; }
    public string Origen { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
         
    public string Asiento { get; }= string.Empty;
    public decimal PrecioBase { get; set; }
    public decimal PorcentajeDescuento { get; set; }
    public bool AplicaDescuentoRut { get; }
    public decimal MontoDescuento { get; set; } = 0m;
    public decimal ValorFinal { get; set; }
    public int VueloSeleccionado { get; }

    internal decimal CalcularMontoDescuento(decimal PorcentajeDescuento)
    {
       MontoDescuento = PrecioBase * PorcentajeDescuento / 100;
        return MontoDescuento;
    }
    public decimal CalcularValorFinal()
    {
        ValorFinal = PrecioBase - CalcularMontoDescuento(PorcentajeDescuento);
        return ValorFinal;
    }

   
}
