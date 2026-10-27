using System;
using System.Collections.Generic;
using System.Text;

namespace GanaderaChan.Dominio;

internal class Venta
{
    public string Cliente { get; set; } = string.Empty;
    public string Rut { get; set; } = string.Empty;
    public string CategoriaChanchito { get; set; } = string.Empty;
    public int PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
    public string FormaPago { get; set; } = "Efectivo";

    private const double TASA_IVA = 0.19;

    public Venta() { }

    public Venta(string cliente, string rut, string categoriaChanchito, int precioUnitario, int cantidad)
    {
        Cliente = cliente;
        Rut = rut;
        CategoriaChanchito = categoriaChanchito;
        PrecioUnitario = precioUnitario;
        Cantidad = cantidad;
    }

    public Venta(string cliente, string rut, string categoriaChanchito, int precioUnitario, int cantidad, string formaPago)
        : this(cliente, rut, categoriaChanchito, precioUnitario, cantidad)
    {
        FormaPago = formaPago;
    }

    //TODO : Implementar el método CalcularSubtotal
    public int CalcularSubtotal()
    {
        return (PrecioUnitario * Cantidad);
    }

    //TODO: Implementar el método CalcularMontoIva
    public int CalcularMontoIva()
    {
        int subtotal = CalcularSubtotal();
        return  (int) (subtotal * TASA_IVA);

    }

    //TODO: Implementar el método CalcularTotalPagar
    public int CalcularTotalPagar()
    {
        int subtotal = CalcularSubtotal();
        int montoIva = CalcularMontoIva();

        return subtotal + montoIva;
    }

    //TODO: Implementar el método ToString para mostrar la informacion de la venta en el ListBox lstVentas
    //Incluir el cliente, rut, forma de pago y total a pagar.
    public override string ToString()
    {
        int totalPagar = CalcularTotalPagar();

        return $"Cliente: {Cliente} | Rut: {Rut} | Forma de pago: {FormaPago} | Total a pagar: {totalPagar:N0}";
    }

}
