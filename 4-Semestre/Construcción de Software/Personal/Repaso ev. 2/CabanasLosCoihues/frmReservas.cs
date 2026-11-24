using CabañaCoihues;
using System.Globalization;

namespace CabanasLosCoihues
{
    public partial class frmReservas : Form
    {
        private List<Reserva> historialReservas = new List<Reserva>();
        Reserva reservaActual;

        public frmReservas()
        {
            InitializeComponent();
        }

        private void frmReservas_Load(object sender, EventArgs e)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            PoblarComboBoxes();
            LimpiarFormulario();
            ActualizarMetricas();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre.", "Selección nombre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();

                return;
            }


            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Debe ingresar el teléfono.", "Selección teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();

                return;
            } else if (!int.TryParse(txtTelefono.Text, out int telefono) || telefono <= 0 || txtTelefono.Text.Length != 9)
            {
                MessageBox.Show("Ingrese un teléfono válido", "Selección teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();

                return;
            }


            if (cboCabana.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una cabaña", "Selección cabaña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCabana.Focus();

                return;
            }

            if (cboTemporada.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una temporada", "Selección temporada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTemporada.Focus();

                return;
                }

                var noches = 0;

            if (string.IsNullOrWhiteSpace(txtNoches.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad de noches.", "Error noches", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoches.Focus();

                return;
            } else if (!int.TryParse(txtNoches.Text, out noches) || noches <= 0)
            {
                MessageBox.Show("Ingrese un cantidad de noches válida", "Error noches", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoches.Focus();

                return;
            }

            reservaActual = new Reserva(
                txtNombre.Text,
                txtTelefono.Text,
                cboCabana.Text,
                (int)cboCabana.SelectedValue,
                cboTemporada.Text,
                (int)cboTemporada.SelectedValue,
                noches,
                chkSocio.Checked,
                chkTinaja.Checked,
                chkLena.Checked,
                chkMascota.Checked,
                chkDesayuno.Checked,
                chkKayak.Checked,
                rdbTraslado.Checked
            );

            int subtotal = reservaActual.CalcularSubtotal();
            int cantidadAdiciones = reservaActual.ContarAdicionales();
            int descuento = reservaActual.CalcularDescuento();
            int recargo = reservaActual.CalcularRecargoModalidad();
            int netoAfecto = reservaActual.CalcularNetoAfecto();
            int iva = reservaActual.CalcularIva();
            int total = reservaActual.CalcularTotal();

            lblSubtotal.Text = $"${subtotal:N0}";
            lblAdicionales.Text = cantidadAdiciones.ToString();
            lblDescuento.Text = $"-${descuento:N0}";
            lblRecargo.Text = $"${recargo:N0}";
            lblNeto.Text = $"${netoAfecto:N0}";
            lblIva.Text = $"${iva:N0}";
            lblTotal.Text = $"${total:N0}";

            btnConfirmar.Enabled = true;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            historialReservas.Add(reservaActual);

            lstReservas.DataSource = null;
            lstReservas.DataSource = historialReservas;

            MessageBox.Show("La reserva ha sido confirmada.", "Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ActualizarMetricas();
            LimpiarFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Se reiniciará la jornada y se borrará el historial", "¿Reiniciar jornada?", MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                lstReservas.DataSource = null;
                historialReservas.Clear();

                lblTotalRecaudado.Text = "Total recaudado: $0";
                lblCantidad.Text = "Reservas confirmadas: 0";
                lblPromedio.Text = "Promedio por reserva: $0";

                LimpiarFormulario();
            }
        }

        private void PoblarComboBoxes()
        {
            // Diccionario: Cabaña
            Dictionary<string, int> opcionesCabana = new Dictionary<string, int>
            {
                {"Cóndor (2 personas)", 48000},
                {"Pudú (4 personas)", 69000},
                {"Puma (6 personas)", 94000},
                {"Lago Premium (8 personas)", 128000}
            };

            cboCabana.DataSource = new BindingSource(opcionesCabana, null);
            cboCabana.DisplayMember = "Key";
            cboCabana.ValueMember = "Value";
            cboCabana.DropDownStyle = ComboBoxStyle.DropDownList;

            // Diccionario: Temporada
            Dictionary<string, int> opcionesTemporada = new Dictionary<string, int>
            {
                {"Temporada Baja", 0},
                {"Temporada Media", 14000},
                {"Temporada Alta", 26000},
                {"Fiestas Patrias y Año Nuevo", 38000}
            };

            cboTemporada.DataSource = new BindingSource(opcionesTemporada, null);
            cboTemporada.DisplayMember = "Key";
            cboTemporada.ValueMember = "Value";
            cboTemporada.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtNoches.Clear();

            chkSocio.Checked = false;

            if (cboCabana.Items.Count > 0) cboCabana.SelectedIndex = -1;
            if (cboTemporada.Items.Count > 0) cboTemporada.SelectedIndex = -1;

            chkTinaja.Checked = false;
            chkLena.Checked = false;
            chkMascota.Checked = false;
            chkDesayuno.Checked = false;
            chkKayak.Checked = false;

            rdbRetiro.Checked = true;

            lblSubtotal.Text = "$0";
            lblAdicionales.Text = "0";
            lblDescuento.Text = "-$0";
            lblRecargo.Text = "$0";
            lblNeto.Text = "$0";
            lblIva.Text = "$0";
            lblTotal.Text = "$0";

            btnConfirmar.Enabled = false;
            txtNombre.Focus();
        }

        private void ActualizarMetricas()
        {
            int totalRecaudado = 0;
            int cantidadReservas = 0;

            foreach (var reserva in historialReservas)
            {
                totalRecaudado += reserva.CalcularTotal();
                cantidadReservas++;
            }

            double promedio = (cantidadReservas > 0) ? ((double) totalRecaudado / cantidadReservas) : 0;

            lblTotalRecaudado.Text = $"Total recaudado: ${totalRecaudado:N0}";
            lblCantidad.Text = $"Reservas confirmadas: {cantidadReservas}";
            lblPromedio.Text = $"Promedio por reserva: ${promedio:N0}";
        }
    }
}
