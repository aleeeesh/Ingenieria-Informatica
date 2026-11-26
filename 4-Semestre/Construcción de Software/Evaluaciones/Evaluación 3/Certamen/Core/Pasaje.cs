namespace StarOne.Core;

public class Pasaje
{
    public string Rut { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public int Edad { get; set; }
    public int IDVuelo { get; set; }
    public string Origen { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public string Asiento { get; } = string.Empty; // Dejar como int? asi viene de la BD
    public decimal PrecioBase { get; set; }
    public decimal PorcentajeDescuento { get; set; }
    public bool AplicaDescuentoRut { get; }
    public decimal MontoDescuento { get; set; } = 0m;
    public decimal ValorFinal { get; set; }
    public int VueloSeleccionado { get; }

    /*public Pasaje(int vueloSeleccionado, string asiento, string rut, bool aplicaDescuentoRut)
    {
        VueloSeleccionado = vueloSeleccionado;
        IDVuelo = vueloSeleccionado;
        Asiento = asiento;
        Rut = rut;
        AplicaDescuentoRut = aplicaDescuentoRut;
    }*/

    public Pasaje(string nombre, string rut, int edad, int idVuelo, string origen, string destino, string asiento, decimal precioBase, bool aplicaDescuentoRut)
    {
        NombreCompleto = nombre;
        Rut = rut;
        Edad = edad;
        IDVuelo = idVuelo;
        VueloSeleccionado = idVuelo;
        Origen = origen;
        Destino = destino;
        Asiento = asiento.Trim();
        PrecioBase = precioBase;
        AplicaDescuentoRut = aplicaDescuentoRut;

        CalcularValorFinal();
    }

    internal decimal CalcularPorcentajeDescuento()
    {
        if (!AplicaDescuentoRut)
        {
            PorcentajeDescuento = 0m;
        } else
        {
            int ultimoDigito = int.TryParse(Rut.Split("-")[1], out int dv) ? dv : 0;

            PorcentajeDescuento = 10 + ultimoDigito;
        }

        return PorcentajeDescuento;
    }

    internal decimal CalcularMontoDescuento(decimal PorcentajeDescuento)
    {
        MontoDescuento = PrecioBase * PorcentajeDescuento / 100;
        return MontoDescuento;
    }
    public decimal CalcularValorFinal()
    {
        CalcularPorcentajeDescuento();
        ValorFinal = PrecioBase - CalcularMontoDescuento(PorcentajeDescuento);
        return ValorFinal;
    }
}