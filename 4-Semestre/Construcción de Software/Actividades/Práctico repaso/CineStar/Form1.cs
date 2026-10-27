using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using CineStar.Dominio;

namespace CineStar.Presentacion
{
    public partial class FormCine : Form
    {
        // Colección principal de almacenamiento en memoria
        private List<VentaCine> VENTAS = new List<VentaCine>();

        public FormCine()
        {
            InitializeComponent();
        }

        private void FormCine_Load(object sender, EventArgs e)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            PoblarComboBoxesConDiccionarios();
            LimpiarFormulario();

            // Vincular eventos de botones
            btnRegistrar.Click += new EventHandler(btnRegistrar_Click);
            btnLimpiar.Click += new EventHandler(btnLimpiar_Click);
            btnSalir.Click += new EventHandler(btnSalir_Click);
        }

        private void PoblarComboBoxesConDiccionarios()
        {
            // 1. Películas disponibles (Key: Nombre, Value: Precio Entrada)
            Dictionary<string, int> opcionesPeliculas = new Dictionary<string, int>
            {
                { "Avatar: El Camino del Agua (2D) - $ 4.500", 4500 },
                { "Oppenheimer (3D IMAX) - $ 6.500", 6500 },
                { "Super Mario Bros (2D) - $ 4.000", 4000 },
                { "Spider-Man: Across the Spider-Verse - $ 5.000", 5000 }
            };

            cboPelicula.DataSource = new BindingSource(opcionesPeliculas, null);
            cboPelicula.DisplayMember = "Key";
            cboPelicula.ValueMember = "Value";
            cboPelicula.DropDownStyle = ComboBoxStyle.DropDownList;

            // 2. Combos de Snacks (Key: Nombre, Value: Precio Combo)
            Dictionary<string, int> opcionesSnacks = new Dictionary<string, int>
            {
                { "Sin Snack Adicional", 0 },
                { "Combo 1: Popcorn Mediano + Bebida - $ 5.500", 5500 },
                { "Combo 2: Popcorn Grande + 2 Bebidas - $ 8.500", 8500 },
                { "Combo Familiar: 2 Popcorn + 4 Bebidas + Dulces - $ 14.000", 14000 }
            };

            cboSnack.DataSource = new BindingSource(opcionesSnacks, null);
            cboSnack.DisplayMember = "Key";
            cboSnack.ValueMember = "Value";
            cboSnack.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones de campos de texto obligatorios
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("El campo 'Nombre del Cliente' es obligatorio.",
                                "Validación de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRut.Text))
            {
                MessageBox.Show("El campo 'RUT del Cliente' es obligatorio.",
                                "Validación de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRut.Focus();
                return;
            }

            // 2. Validaciones de ComboBox
            if (cboPelicula.SelectedValue == null || cboSnack.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una película y una opción de snack.",
                                "Validación de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Validación de Cantidad de Entradas (Número Entero con int.TryParse)
            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidadEntradas) || cantidadEntradas <= 0)
            {
                MessageBox.Show("La 'Cantidad' de entradas debe ser un número entero mayor a 0.",
                                "Validación de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.SelectAll();
                txtCantidad.Focus();
                return;
            }

            // 4. Instanciación del objeto VentaCine utilizando Constructor Completo
            string cliente = txtCliente.Text.Trim();
            string rut = txtRut.Text.Trim();
            string peliculaTexto = cboPelicula.Text;
            int precioEntrada = (int)cboPelicula.SelectedValue;
            string snackTexto = cboSnack.Text;
            int precioSnack = (int)cboSnack.SelectedValue;
            bool esSocio = chkSocio.Checked;

            VentaCine venta = new VentaCine(cliente, rut, peliculaTexto, precioEntrada, cantidadEntradas,
                                          snackTexto, precioSnack, esSocio);

            // 5. Almacenamiento en la lista VENTAS
            VENTAS.Add(venta);

            // 6. Refresco de ListBox y actualización de métricas con ciclo foreach (Sin LINQ)
            ActualizarListBoxVentas();
            CalcularMetricasSinLinq();

            // 7. Pantalla de Respuesta / Confirmación
            string confirmacion = $"¡VENTA REGISTRADA CON ÉXITO!" +
                                  $"Cliente: {venta.Cliente} ({venta.Rut})" +
                                  $"Película: {venta.Pelicula}" +
                                  $"Entradas: {venta.CantidadEntradas} x $ {venta.PrecioEntrada:N0} = $ {venta.CalcularSubtotalEntradas():N0}" +
                                  $"Snack: {venta.ComboSnack} ($ {venta.CalcularSubtotalSnacks():N0})" +
                                  $"Subtotal Bruto: $ {venta.CalcularSubtotalBruto():N0}" +
                                  $"Descuento Socio (15%): - $ {venta.CalcularMontoDescuento():N0}" +
                                  $"IVA (19%): + $ {venta.CalcularMontoIva():N0}" +
                                  $"TOTAL A PAGAR: $ {venta.CalcularTotalPagar():N0} CLP" +
                                  $"Registro añadido a la lista VENTAS.";

            MessageBox.Show(confirmacion, "Comprobante de Venta - CineStar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }

        private void ActualizarListBoxVentas()
        {
            lstVentas.DataSource = null;
            lstVentas.DataSource = VENTAS;
        }

        private void CalcularMetricasSinLinq()
        {
            int totalRecaudado = 0;
            int totalEntradas = 0;

            // Recorrido explícito con ciclo foreach tradicional (sin LINQ)
            foreach (VentaCine v in VENTAS)
            {
                totalRecaudado += v.CalcularTotalPagar();
                totalEntradas += v.CantidadEntradas;
            }

            lblTotalRecaudado.Text = $"Total Recaudado: $ {totalRecaudado:N0} CLP";
            lblTotalEntradas.Text = $"Total Entradas Vendidas: {totalEntradas} ticket(s)";
            lblCantidadVentas.Text = $"Transacciones Procesadas: {VENTAS.Count} registro(s)";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCliente.Clear();
            txtRut.Clear();
            txtCantidad.Clear();
            chkSocio.Checked = false;
            if (cboPelicula.Items.Count > 0) cboPelicula.SelectedIndex = 0;
            if (cboSnack.Items.Count > 0) cboSnack.SelectedIndex = 0;
            txtCliente.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar el sistema de venta de CineStar?",
                                                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}