using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using GanaderaChan.Dominio;

namespace GanaderaChan.Presentacion
{
    public partial class FormVentas : Form
    {
        private List<Venta> VENTAS = new List<Venta>();
        private Venta ventaActual;

        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            PoblarCategoriasChanchitos();
            LimpiarCamposEntrada();
        }

        //TODO: Implementar el método PoblarCategoriasChanchitos()
        //para llenar el ComboBox cboCategoria con las opciones de
        //categorías de chanchitos y sus precios utilizando Dictionary.
        Dictionary<string, int> opcionesChanchitos = new Dictionary<string, int>
       {
                { "Lechón (Hasta 15 kg) - $ 45.000", 45000 },
                { "Cerdito de Recría (15 - 40 kg) - $ 75.000", 75000 },
                { "Cerdo de Engorde (40 - 100 kg) - $ 120.000", 120000 },
                { "Reproductor Selección - $ 180.000", 180000 }
        };

        private void PoblarCategoriasChanchitos()
        {
            cboCategoria.DataSource = new BindingSource(opcionesChanchitos, null);
            cboCategoria.DisplayMember = "Key";
            cboCategoria.ValueMember = "Value";
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            //TODO: Validar que los campos no estén vacíos y que la cantidad sea un número válido
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del cliente.", "Ingreso de nombre cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();

                return;
            }

            if (string.IsNullOrWhiteSpace(txtRut.Text))
            {
                MessageBox.Show("Debe ingresar el rut del cliente.", "Ingreso de rut cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRut.Focus();

                return;
            }

            if (cboCategoria.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una categoría de cerdos.", "Selección categoría cerdos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategoria.Focus();

                return;
            }

            int cantidadChanchitos = 0;

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad de chanchitos.", "Ingreso de cantidad chanchitos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();

                return;
            }
            else if (!int.TryParse(txtCantidad.Text, out cantidadChanchitos) || cantidadChanchitos <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida de chanchitos.", "Ingreso de cantidad chanchitos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();

                return;
            }

            //TODO: Capturar los datos del formulario.
            string cliente = txtCliente.Text;
            string rut = txtRut.Text;
            string categoriaChanchito = cboCategoria.Text;
            int precioChanchito = (int)cboCategoria.SelectedValue;
            string formaPago = rdbTransferencia.Checked ? rdbTransferencia.Text : rdbEfectivo.Text;

            //TODO: Crear un objeto Venta
            ventaActual = new Venta(
                cliente,
                rut,
                categoriaChanchito,
                precioChanchito,
                cantidadChanchitos, // Viene de la linea 74, ya que lo uso para el TryParse y lo convierto a Int.
                formaPago
            );

            int subtotal = ventaActual.CalcularSubtotal();
            int montoIva = ventaActual.CalcularMontoIva();
            int totalPagar = ventaActual.CalcularTotalPagar();

            //TODO: Agregar objeto Venta a la lista VENTAS.
            VENTAS.Add(ventaActual);

            //TODO: Actualizar el Listado de ventas en la interfaz de usuario
            ActualizarHistorialVentas();
            ActualizarMetricasGlobales();

            string pantallaRespuesta = $"¡VENTA REGISTRADA CON ÉXITO EN GANADERA CHAN!\n\n" +
                                        $"Cliente: {cliente}\n" +
                                        $"Rut: {rut}\n" +
                                        $"Categoría: {categoriaChanchito}\n" +
                                        $"Cantidad: {cantidadChanchitos} unidad(es)\n" +
                                        $"Forma de Pago: {formaPago}\n" +
                                        $"Subtotal Neto: {subtotal:N0}\n" +
                                        $"Monto IVA (19%): {montoIva:N0}\n" +
                                        $"Total a Pagar: ${totalPagar:N0}\n\n" +
                                        $"El registro ha sido almacenado correctamente en la lista VENTAS.";

            //TODO: Mostrar mensaje de éxito con los detalles de la venta registrada.
            // Utilice pantallaRespuesta como el contenido del mensaje y "Respuesta de Registro - Ganadera Chan" como el título del MessageBox.
            MessageBox.Show(pantallaRespuesta, "Respuesta de Registro - Ganadera Chan", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCamposEntrada();
        }

        //TODO: Implementar el método ActualizarHistorialVentas()
        //para actualizar la lista de ventas en la interfaz de usuario.
        private void ActualizarHistorialVentas()
        {
            lstVentas.DataSource = null;
            lstVentas.DataSource = VENTAS;
        }

        //TODO: Implementar el método ActualizarMetricasGlobales()
        //para actualizar las métricas globales en la interfaz de usuario.
        private void ActualizarMetricasGlobales()
        {
            int totalRecaudado = 0;
            int chanchitosVendidos = 0;
            int transaccionesRegistradas = 0;

            foreach (var venta in VENTAS)
            {
                totalRecaudado += venta.CalcularTotalPagar();
                chanchitosVendidos += venta.Cantidad;
                transaccionesRegistradas++;
            }

            lblTotalRecaudado.Text = $"${totalRecaudado:N0}";
            lblTotalChanchitos.Text = $"{chanchitosVendidos} unidad(es)";
            lblCantidadVentas.Text = $"{transaccionesRegistradas} registro(s)";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposEntrada();
        }

        //TODO: Implementar el método LimpiarCamposEntrada()
        private void LimpiarCamposEntrada()
        {
            txtCliente.Clear();
            txtRut.Clear();

            if (cboCategoria.Items.Count > 0) cboCategoria.SelectedIndex = -1;

            txtCantidad.Clear();
            txtCliente.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir de la aplicación de ventas de Ganadera Chan?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
