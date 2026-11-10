
using PizzeriaBellaItalia.AccesoDatos;
using PizzeriaBellaItalia.Dominio;
using System.Data;
using System.Globalization;

namespace PizzeriaBellaItalia
{
    public partial class FormPizzeriaCRUD : Form
    {
        private PedidoDAO pedidoDAO = new PedidoDAO();
        private int idPedidoSeleccionado = 0; // 0 = Modo Nuevo Registro; >0 = Modo Edición

        public FormPizzeriaCRUD()
        {
            InitializeComponent();
        }

        private void FormPizzeriaCRUD_Load(object sender, EventArgs e)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            if (ConexionBD.ProbarConexion())
            {
                lblEstadoConexion.Text = "● Estado SQL Express: Conectado (PizzeriaDB)";
                lblEstadoConexion.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblEstadoConexion.Text = "● Estado SQL Express: Error de Conexión";
                lblEstadoConexion.ForeColor = System.Drawing.Color.Red;
            }

            PoblarTamanios();
            CargarGrillaPedidos();
            EstablecerModoInsercion();
        }

        private void PoblarTamanios()
        {
            var tamanios = new System.Collections.Generic.Dictionary<string, int>
            {
                { "Personal (4 Cortes) - $ 5.900", 5900 },
                { "Mediana (8 Cortes) - $ 8.900", 8900 },
                { "Familiar (12 Cortes) - $ 12.900", 12900 },
                { "XL Fiesta (16 Cortes) - $ 15.900", 15900 }
            };

            cboTamano.DataSource = new BindingSource(tamanios, null);
            cboTamano.DisplayMember = "Key";
            cboTamano.ValueMember = "Value";
            cboTamano.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarGrillaPedidos()
        {
            DataTable dt = pedidoDAO.ObtenerPedidosDataTable();
            dgvPedidos.DataSource = dt;
            CalcularMetricas(dt);
        }

        private void CalcularMetricas(DataTable dt)
        {
            int totalAcumulado = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalAcumulado += Convert.ToInt32(row["Total"]);
            }
            txtRecaudacionTotal.Text = $"$ {totalAcumulado:N0} CLP";
            txtCantidadPedidos.Text = $"{dt.Rows.Count} pedido(s)";
        }

        // C1: CREAR (INSERT)
        /*private void btnGuardarSQL_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            string cliente = txtCliente.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string tamanoTexto = cboTamano.Text;
            int precioTamano = (int)cboTamano.SelectedValue;
            int cantidad = int.Parse(txtCantidad.Text.Trim());
            bool quesoExtra = chkQuesoExtra.Checked;

            PedidoPizza nuevoPedido = new PedidoPizza(cliente, telefono, tamanoTexto, precioTamano, cantidad, "Tradicional", quesoExtra);

            if (pedidoDAO.InsertarPedido(nuevoPedido))
            {
                MessageBox.Show("¡Pedido de pizza registrado exitosamente en SQL Server Express!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrillaPedidos();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar guardar el pedido.", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        // C2: CARGAR SELECCIÓN PARA EDICIÓN
        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPedidos.Rows[e.RowIndex].Cells["Id"].Value != null)
            {
                idPedidoSeleccionado = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["Id"].Value);
                PedidoPizza? p = pedidoDAO.ObtenerPedidoPorId(idPedidoSeleccionado);

                if (p != null)
                {
                    txtCliente.Text = p.Cliente;
                    txtTelefono.Text = p.Telefono;
                    /*lblModo.Text = $"Modo: EDICIÓN (Pedido ID #{idPedidoSeleccionado})";
                    btnGuardarSQL.Enabled = false;
                    btnModificarSQL.Enabled = true;
                    btnEliminarSQL.Enabled = true;*/
                }
            }
        }

        // C3: ACTUALIZAR (UPDATE)
        /*private void btnModificarSQL_Click(object sender, EventArgs e)
        {
            if (idPedidoSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione primero un pedido de la tabla para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarFormulario()) return;

            string cliente = txtCliente.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string tamanoTexto = cboTamano.Text;
            int precioTamano = (int)cboTamano.SelectedValue;
            int cantidad = int.Parse(txtCantidad.Text.Trim());
            bool quesoExtra = chkQuesoExtra.Checked;

            PedidoPizza pedidoEditado = new PedidoPizza(idPedidoSeleccionado, cliente, telefono, tamanoTexto, precioTamano, cantidad, "Tradicional", quesoExtra);

            if (pedidoDAO.ActualizarPedido(pedidoEditado))
            {
                MessageBox.Show($"¡Pedido #{idPedidoSeleccionado} actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrillaPedidos();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el registro.", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // C4: ELIMINAR (DELETE)
        private void btnEliminarSQL_Click(object sender, EventArgs e)
        {
            if (idPedidoSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un pedido de la tabla para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Está seguro de eliminar permanentemente el Pedido #{idPedidoSeleccionado}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                if (pedidoDAO.EliminarPedido(idPedidoSeleccionado))
                {
                    MessageBox.Show("Pedido eliminado de la base de datos.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrillaPedidos();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // C5: BÚSQUEDA DINÁMICA (READ FILTERED)
        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarCliente.Text.Trim();
            DataTable dtFiltrada = pedidoDAO.BuscarPedidosPorCliente(filtro);
            dgvPedidos.DataSource = dtFiltrada;
            CalcularMetricas(dtFiltrada);
        }*/

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Nombre del cliente y teléfono son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                return false;
            }

            /*if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un entero positivo mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.SelectAll();
                txtCantidad.Focus();
                return false;
            }*/

            return true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCliente.Clear();
            txtTelefono.Clear();
            //txtCantidad.Text = "1";
            chkQuesoExtra.Checked = false;
            if (cboTamano.Items.Count > 0) cboTamano.SelectedIndex = 0;
            EstablecerModoInsercion();
            txtCliente.Focus();
        }

        private void EstablecerModoInsercion()
        {
            idPedidoSeleccionado = 0;
            /*lblModo.Text = "Modo: NUEVO REGISTRO";
            btnGuardarSQL.Enabled = true;
            btnModificarSQL.Enabled = false;
            btnEliminarSQL.Enabled = false;*/
        }
    }
}