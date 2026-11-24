using System;
using System.Collections.Generic;
using System.Text;

namespace CabañaCoihues
{
    public class Reserva
    {
        // Atributos
        public string Nombre { get; set; } = String.Empty;
        public string Telefono { get; set; } = String.Empty;
        public string Cabana { get; set; } = String.Empty;
        public string Temporada { get; set; } = String.Empty;
        public int PrecioNoche { get; set; } = 0;
        public int CargoTemporada { get; set; } = 0;
        public int Noches { get; set; } = 0;
        public bool EsSocio { get; set; }
        public bool Tinaja { get; set; }
        public bool Lena { get; set; }
        public bool Mascota { get; set; }
        public bool Desayuno { get; set; }
        public bool Kayak { get; set; }
        public bool ConTraslado { get; set; }

        // Constantes
        private const int PRECIO_TINAJA = 27500;
        private const int PRECIO_LENA = 6500;
        private const int PRECIO_MASCOTA = 9500;
        private const int PRECIO_DESAYUNO = 12000;
        private const int PRECIO_KAYAK = 17500;
        private const int RECARGO_TRASLADO = 15000;
        private const double TASA_DESCUENTO = 0.10;
        private const double TASA_IVA = 0.19;

        // Constructores
        public Reserva() { } // Contructor vacio
        public Reserva(string nombre, string telefono, string cabana, int precioNoche, string temporada, int cargoTemporada, int noches) // Constructor parcial
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Cabana = cabana;
            this.PrecioNoche = precioNoche;
            this.Temporada = temporada;
            this.CargoTemporada = cargoTemporada;
            this.Noches = noches;
        }

        public Reserva(string nombre, string telefono, string cabana, int precioNoche, string temporada, int cargoTemporada, int noches, bool esSocio, bool tinaja, bool lena, bool mascota, bool desayuno, bool kayak, bool conTraslado) : this(nombre, telefono, cabana, precioNoche, temporada, cargoTemporada, noches) // Constructor completo
        {
            this.EsSocio = esSocio;
            this.Tinaja = tinaja;
            this.Lena = lena;
            this.Mascota = mascota;
            this.Desayuno = desayuno;
            this.Kayak = kayak;
            this.ConTraslado = conTraslado;
        }

        // Métodos
        public int ContarAdicionales()
        {
            var adicionales = 0;

            if (Tinaja) adicionales++;
            if (Lena) adicionales++;
            if (Mascota) adicionales++;
            if (Desayuno) adicionales++;
            if (Kayak) adicionales++;

            return adicionales;
        }

        public int CalcularSubtotal()
        {
            int tinaja = Tinaja ? PRECIO_TINAJA : 0;
            int lena = Lena ? PRECIO_LENA : 0;
            int mascota = Mascota ? PRECIO_MASCOTA : 0;
            int desayuno = Desayuno ? PRECIO_DESAYUNO : 0;
            int kayak = Kayak ? PRECIO_KAYAK : 0;

            return (PrecioNoche * Noches) + CargoTemporada + (tinaja + lena + mascota + desayuno + kayak);
        }

        public int CalcularDescuento()
        {
            int subtotal = CalcularSubtotal();

            return EsSocio ? (int) (subtotal * TASA_DESCUENTO) : 0;
        }

        public int CalcularRecargoModalidad()
        {
            return ConTraslado ? RECARGO_TRASLADO : 0;
        }

        public int CalcularNetoAfecto()
        {
            int subtotal = CalcularSubtotal();
            int descuento = CalcularDescuento();
            int recargoModalidad = CalcularRecargoModalidad();

            return subtotal - descuento + recargoModalidad;
        }

        public int CalcularIva()
        {
            int netoAfecto = CalcularNetoAfecto();

            return (int)(netoAfecto * TASA_IVA);
        }

        public int CalcularTotal()
        {
            int netoAfecto = CalcularNetoAfecto();
            int IVA = CalcularIva();

            return netoAfecto + IVA;
        }

        // Sobreescritura de ToString()
        public override string ToString()
        {
            int Total = CalcularTotal();

            return $"Reserva: {Nombre} | {Cabana} | {Noches} noche(s) | Total: ${Total:N0} CLP";
        }
    }
}
