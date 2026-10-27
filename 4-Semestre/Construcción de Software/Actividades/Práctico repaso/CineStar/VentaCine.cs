using System;

namespace CineStar.Dominio
{
    public class VentaCine
    {
        // Propiedades auto-implementadas de la entidad
        public string Cliente { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public string Pelicula { get; set; } = string.Empty;
        public int PrecioEntrada { get; set; }
        public int CantidadEntradas { get; set; }
        public string ComboSnack { get; set; } = string.Empty;
        public int PrecioSnack { get; set; }
        public bool EsSocioCineClub { get; set; }

        // Constantes de negocio
        private const double TASA_DESCUENTO_SOCIO = 0.15; // 15% descuento a socios
        private const double TASA_IVA = 0.19;             // 19% IVA Chile

        // --------------------------------------------------------------------
        // CONSTRUCTORES (SOBRECARGA / OVERLOADING)
        // --------------------------------------------------------------------
        public VentaCine() { }

        public VentaCine(string cliente, string rut, string pelicula, int precioEntrada, int cantidadEntradas)
        {
            Cliente = cliente;
            Rut = rut;
            Pelicula = pelicula;
            PrecioEntrada = precioEntrada;
            CantidadEntradas = cantidadEntradas;
        }

        public VentaCine(string cliente, string rut, string pelicula, int precioEntrada, int cantidadEntradas,
                         string comboSnack, int precioSnack, bool esSocioCineClub)
            : this(cliente, rut, pelicula, precioEntrada, cantidadEntradas)
        {
            ComboSnack = comboSnack;
            PrecioSnack = precioSnack;
            EsSocioCineClub = esSocioCineClub;
        }

        // --------------------------------------------------------------------
        // MÉTODOS PUROS DE CÁLCULO
        // --------------------------------------------------------------------
        public int CalcularSubtotalEntradas()
        {
            return PrecioEntrada * CantidadEntradas;
        }

        public int CalcularSubtotalSnacks()
        {
            return PrecioSnack;
        }

        public int CalcularSubtotalBruto()
        {
            return CalcularSubtotalEntradas() + CalcularSubtotalSnacks();
        }

        public int CalcularMontoDescuento()
        {
            return EsSocioCineClub ? (int)(CalcularSubtotalBruto() * TASA_DESCUENTO_SOCIO) : 0;
        }

        public int CalcularNetoAfecto()
        {
            return CalcularSubtotalBruto() - CalcularMontoDescuento();
        }

        public int CalcularMontoIva()
        {
            return (int)(CalcularNetoAfecto() * TASA_IVA);
        }

        public int CalcularTotalPagar()
        {
            return CalcularNetoAfecto() + CalcularMontoIva();
        }

        public override string ToString()
        {
            return $"{Cliente} ({Rut}) | {CantidadEntradas}x {Pelicula} + {ComboSnack} -> $ {CalcularTotalPagar():N0} CLP";
        }
    }
}