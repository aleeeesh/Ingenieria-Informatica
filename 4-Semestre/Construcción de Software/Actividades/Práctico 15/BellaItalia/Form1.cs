using System.Globalization;

namespace BellaItalia
{
    public partial class FormTallerPizzeria : Form
    {
        private readonly List<PedidoPizza> historialPedidos = new List<PedidoPizza>();

        public FormTallerPizzeria()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            PoblarComboBoxesConDiccionarios();
            LimpiarFormulario();
            ActualizarMetricasJornada();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Validación de entradas obligatorias
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, ingrese un número telefónico de contacto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }
            else if (!int.TryParse(txtTelefono.Text, out int telefono))
            {
                MessageBox.Show("Por favor, ingrese un número telefónico de contacto válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }


            if (cboTamano.SelectedValue == null || cboMasa.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione el tamaño y tipo de masa.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string nombreTamano = cboTamano.Text;
            int precioBaseTamano = (int)cboTamano.SelectedValue;

            string nombreMasa = cboMasa.Text;
            int recargoMasa = (int)cboMasa.SelectedValue;

            // Instanciación del objeto de Dominio
            PedidoPizza pedido = new PedidoPizza(
                txtCliente.Text.Trim(),
                txtTelefono.Text.Trim(),
                nombreTamano,
                precioBaseTamano,
                nombreMasa,
                recargoMasa,
                chkQuesoExtra.Checked,
                chkPepperoni.Checked,
                chkChampinones.Checked,
                chkAceitunas.Checked,
                chkTocino.Checked,
                rdbDelivery.Checked,
                chkConvenioEstudiante.Checked
            );

            // Entrega y descuento
            double subtotal = pedido.CalcularSubtotalPizza();
            double montoDescuento = pedido.CalcularMontoDescuento();
            double costoDelivery = pedido.CalcularCostoDelivery();
            double montoIva = pedido.CalcularMontoIva();

            double totalPagar = pedido.CalcularTotalPagar();

            // Renderizar resultados financieros formateados en CLP
            txtSubtotalValor.Text = $"${subtotal:N2} CLP";

            txtDescuentoValor.Text = $"-${montoDescuento:N2} CLP";
            txtDescuentoValor.ForeColor = Color.Red;
            txtDescuentoValor.Left = 191;

            txtDeliveryValor.Text = $"+${costoDelivery:N2} CLP";
            txtDeliveryValor.Left = 191;

            txtIvaValor.Text = $"+${montoIva:N2} CLP";
            txtIvaValor.Left = 191;

            txtTotalValor.Text = $"${totalPagar:N2} CLP";

            btnConfirmar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            txtTelefono.Clear();
            cboTamano.SelectedIndex = 1;
            cboMasa.SelectedIndex = 0;

            chkQuesoExtra.Checked = false;
            chkPepperoni.Checked = false;
            chkChampinones.Checked = false;
            chkAceitunas.Checked = false;
            chkTocino.Checked = false;

            rdbRetiro.Checked = true;
            chkConvenioEstudiante.Checked = false;

            LimpiarFormulario();
            txtCliente.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Reinstanciar el pedido actual
            PedidoPizza pedidoConfirmado = new PedidoPizza(
                txtCliente.Text.Trim(),
                txtTelefono.Text.Trim(),
                cboTamano.Text,
                (int)cboTamano.SelectedValue,
                cboMasa.Text,
                (int)cboMasa.SelectedValue,
                chkQuesoExtra.Checked,
                chkPepperoni.Checked,
                chkChampinones.Checked,
                chkAceitunas.Checked,
                chkTocino.Checked,
                rdbDelivery.Checked,
                chkConvenioEstudiante.Checked
            );

            // 1. Agregar a la lista
            historialPedidos.Add(pedidoConfirmado);

            // 2. Refrescar el ListBox
            lstHistorial.DataSource = null;
            lstHistorial.DataSource = historialPedidos;

            // 3. Actualizar resumen de la jornada
            ActualizarMetricasJornada();

            MessageBox.Show("Pedido registrado exitosamente en el historial de la sesión.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }

        private void btnReiniciarJornada_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "¿Desea reiniciar la jornada?",
                "Jornada",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                lstHistorial.Items.Clear();
                txtRecaudacionTotal.Text = "$0 CLP";
                txtCantidadPedidos.Text = "0";
                txtPromedioVenta.Text = "$0 CLP";
            }
        }

        private void PoblarComboBoxesConDiccionarios()
        {
            // Diccionario 1: Tamaños de Pizza
            Dictionary<string, int> opcionesTamano = new Dictionary<string, int>
            {
                { "Personal (1 Persona)", 5000 },
                { "Mediana (2 a 3 Personas)", 8500 },
                { "Familiar (4 a 5 Personas)", 12000 }
            };

            cboTamano.DataSource = new BindingSource(opcionesTamano, null);
            cboTamano.DisplayMember = "Key";
            cboTamano.ValueMember = "Value";
            cboTamano.DropDownStyle = ComboBoxStyle.DropDownList;

            // Diccionario 2: Tipos de Masa
            Dictionary<string, int> opcionesMasa = new Dictionary<string, int>
            {
                { "Masa Tradicional (Sin Recargo)", 0 },
                { "Masa Delgada (Sin Recargo)", 0 },
                { "Borde de Queso (+$1.500)", 1500 }
            };

            cboMasa.DataSource = new BindingSource(opcionesMasa, null);
            cboMasa.DisplayMember = "Key";
            cboMasa.ValueMember = "Value";
            cboMasa.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ActualizarMetricasJornada()
        {
            int totalVentas = historialPedidos.Sum(p => p.CalcularTotalPagar());
            int cantidadPedidos = historialPedidos.Count;
            double promedioVenta = cantidadPedidos > 0 ? historialPedidos.Average(p => p.CalcularTotalPagar()) : 0;

            txtRecaudacionTotal.Text = $"$ {totalVentas:N0} CLP";
            txtCantidadPedidos.Text = $"{cantidadPedidos} pedidos";
            txtPromedioVenta.Text = $"$ {promedioVenta:N0} CLP";
        }

        private void LimpiarFormulario()
        {
            txtCliente.Clear();
            txtTelefono.Clear();

            if (cboTamano.Items.Count > 0) cboTamano.SelectedIndex = 0;
            if (cboMasa.Items.Count > 0) cboMasa.SelectedIndex = 0;

            chkQuesoExtra.Checked = false;
            chkPepperoni.Checked = false;
            chkChampinones.Checked = false;
            chkAceitunas.Checked = false;
            chkTocino.Checked = false;

            rdbRetiro.Checked = true;
            chkConvenioEstudiante.Checked = false;

            txtSubtotalValor.Text = "$0 CLP";
            txtDescuentoValor.Text = "$0 CLP";
            txtDescuentoValor.ForeColor = Color.Black;
            txtDescuentoValor.Left = 197;
            txtDeliveryValor.Text = "$0 CLP";
            txtDeliveryValor.Left = 197;
            txtIvaValor.Text = "$0 CLP";
            txtIvaValor.Left = 197;
            txtTotalValor.Text = "$0 CLP";

            btnConfirmar.Enabled = false;
            txtCliente.Focus();
        }
    }
}
