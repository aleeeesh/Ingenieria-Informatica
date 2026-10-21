using System;
using System.Collections.Generic;
using System.Text;

namespace BellaItalia
{
    public class PedidoPizza
    {
        public string Cliente { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string TamanoNombre { get; set; } = string.Empty;
        public int PrecioBaseTamano { get; set; }
        public string MasaNombre { get; set; } = string.Empty;
        public int RecargoMasa { get; set; }

        public bool QuesoExtra { get; set; }
        public bool Pepperoni { get; set; }
        public bool Champinones { get; set; }
        public bool Aceitunas { get; set; }
        public bool Tocino { get; set; }

        public bool EsDelivery { get; set; }
        public bool AplicaConvenioEstudiante { get; set; }

        private const int PRECIO_INGREDIENTE_EXTRA = 800;
        private const int RECARGO_DELIVERY = 2000;
        private const double TASA_DESCUENTO = 0.10;
        private const double TASA_IVA = 0.19;

        // Constructores sobrecargados
        public PedidoPizza() { }

        public PedidoPizza(string cliente, string telefono, string tamanoNombre, int precioBaseTamano, string masaNombre, int recargoMasa)
        {
            Cliente = cliente;
            Telefono = telefono;
            TamanoNombre = tamanoNombre;
            PrecioBaseTamano = precioBaseTamano;
            MasaNombre = masaNombre;
            RecargoMasa = recargoMasa;
        }

        public PedidoPizza(
            string cliente, string telefono, string tamanoNombre, int precioBaseTamano,
            string masaNombre, int recargoMasa, bool quesoExtra, bool pepperoni,
            bool champinones, bool aceitunas, bool tocino, bool esDelivery, bool aplicaConvenioEstudiante)
            : this(cliente, telefono, tamanoNombre, precioBaseTamano, masaNombre, recargoMasa)
        {
            QuesoExtra = quesoExtra;
            Pepperoni = pepperoni;
            Champinones = champinones;
            Aceitunas = aceitunas;
            Tocino = tocino;
            EsDelivery = esDelivery;
            AplicaConvenioEstudiante = aplicaConvenioEstudiante;
        }

        public int ContarIngredientesExtra()
        {
            int total = 0;
            if (QuesoExtra) total++;
            if (Pepperoni) total++;
            if (Champinones) total++;
            if (Aceitunas) total++;
            if (Tocino) total++;
            return total;
        }

        public int CalcularSubtotalPizza()
        {
            return PrecioBaseTamano + RecargoMasa + (ContarIngredientesExtra() * PRECIO_INGREDIENTE_EXTRA);
        }

        public int CalcularMontoDescuento()
        {
            return AplicaConvenioEstudiante ? (int)(CalcularSubtotalPizza() * TASA_DESCUENTO) : 0;
        }

        public int CalcularCostoDelivery()
        {
            return EsDelivery ? RECARGO_DELIVERY : 0;
        }

        public int CalcularNetoAfecto()
        {
            return (CalcularSubtotalPizza() - CalcularMontoDescuento()) + CalcularCostoDelivery();
        }

        public int CalcularMontoIva()
        {
            return (int)(CalcularNetoAfecto() * TASA_IVA);
        }

        public int CalcularTotalPagar()
        {
            return CalcularNetoAfecto() + CalcularMontoIva();
        }

        // Sobrescritura clave para renderizar en ListBox
        public override string ToString()
        {
            string tipoAtencion = EsDelivery ? "Delivery" : "Retiro";
            return $"{Cliente} | {TamanoNombre} ({MasaNombre}) [{tipoAtencion}] -> $ {CalcularTotalPagar():N0} CLP";
        }
    }
}
