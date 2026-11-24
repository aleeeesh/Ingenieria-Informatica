using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using TechRepair.AccesoDatos;
using TechRepair.Dominio;

namespace TechRepair
{
    public partial class FormOrdenes : Form
    {
        private OrdenServicioDAO ordenDAO = new OrdenServicioDAO();
        private OrdenServicio? ordenTemporal;
        private int idOrdenSeleccionada = 0;

        public FormOrdenes()
        {
            InitializeComponent();
        }

        private void FormOrdenes_Load(object sender, EventArgs e)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            // TODO 7: Validar ConexionBD.ProbarConexion() y actualizar lblEstadoConexion (texto y color).
            if (ConexionBD.ProbarConexion())
            {
                lblEstadoConexion.Text = "Estado SQL: Conectado";
                lblEstadoConexion.ForeColor = Color.Green;
            } else
            {
                lblEstadoConexion.Text = "Estado SQL: Error de conexión";
                lblEstadoConexion.ForeColor = Color.Red;
            }

            PoblarTiposEquipo();
            PoblarServiciosBase();
            CargarGrillaOrdenes();
            EstablecerModoInsercion();
        }

        private void PoblarTiposEquipo()
        {
            cboTipoEquipo.Items.Clear();
            cboTipoEquipo.Items.Add("Notebook");
            cboTipoEquipo.Items.Add("PC Escritorio");
            cboTipoEquipo.Items.Add("Consola (+$3.000)");
            cboTipoEquipo.Items.Add("All-in-One (+$3.000)");
            cboTipoEquipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoEquipo.SelectedIndex = 0;
        }

        private void PoblarServiciosBase()
        {
            var servicios = new Dictionary<string, int>
            {
                { "Mantención Preventiva - $ 15.000", 15000 },
                { "Formateo + Respaldo - $ 20.000", 20000 },
                { "Reparación Placa Madre - $ 35.000", 35000 },
                { "Upgrade RAM / SSD - $ 12.000", 12000 }
            };

            cboServicioBase.DataSource = new BindingSource(servicios, null);
            cboServicioBase.DisplayMember = "Key";
            cboServicioBase.ValueMember = "Value";
            cboServicioBase.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarGrillaOrdenes()
        {
            // TODO 8: Obtener DataTable desde ordenDAO.ObtenerOrdenesDataTable(),
            // asignarlo a dgvOrdenes.DataSource y llamar a CalcularMetricas(dt).

            DataTable dt = ordenDAO.ObtenerOrdenesDataTable();
            dgvOrdenes.DataSource = dt;
            CalcularMetricas(dt);
        }

        private void CalcularMetricas(DataTable dt)
        {
            int totalAcumulado = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalAcumulado += Convert.ToInt32(row["Total"]);
            }

            lblTotalRecaudado.Text = $"$ {totalAcumulado:N0} CLP";
            lblCantidadOrdenes.Text = $"{dt.Rows.Count} orden(es)";

            if (dt.Rows.Count != 0)
            {
                int promedio = totalAcumulado / dt.Rows.Count;
                lblPromedioVenta.Text = $"$ {promedio:N0} CLP";
            }
            else
            {
                lblPromedioVenta.Text = "$ 0 CLP";
            }
        }

        private OrdenServicio ConstruirOrdenDesdeUI()
        {
            OrdenServicio orden = new OrdenServicio();
            orden.Cliente = txtCliente.Text.Trim();
            orden.Telefono = txtTelefono.Text.Trim();
            orden.TipoEquipo = cboTipoEquipo.Text;
            orden.ServicioBase = cboServicioBase.Text;
            orden.LimpiezaProfunda = chkLimpiezaProfunda.Checked;
            orden.CambioPasta = chkCambioPasta.Checked;
            orden.InstalacionSoftware = chkInstalacionSoftware.Checked;
            orden.RespaldoDatos = chkRespaldoDatos.Checked;
            orden.EsDomicilio = rdbDomicilio.Checked;
            orden.EsClienteFrecuente = chkClienteFrecuente.Checked;
            return orden;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            ordenTemporal = ConstruirOrdenDesdeUI();

            if (idOrdenSeleccionada == 0)
            {
                btnGuardarSQL.Enabled = true;
            }

            lblSubtotalValor.Text = $"Subtotal Servicio: ${ordenTemporal.CalcularSubtotalServicio():N0} CLP";
            lblDescuentoValor.Text = $"Descuento (15%): ${ordenTemporal.CalcularMontoDescuento():N0} CLP";
            lblDomicilioValor.Text = $"Recargo Domicilio: ${ordenTemporal.CalcularCostoDomicilio():N0} CLP";
            lblIvaValor.Text = $"IVA (19%): ${ordenTemporal.CalcularMontoIva():N0} CLP";
            lblTotalValor.Text = $"TOTAL A PAGAR: ${ordenTemporal.CalcularTotalPagar():N0} CLP";
        }

        private void btnGuardarSQL_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            var nuevaOrden = ConstruirOrdenDesdeUI();

            if (ordenDAO.InsertarOrden(nuevaOrden))
            {
                MessageBox.Show("¡Orden registrada exitosamente en SQL Server Express!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrillaOrdenes();
                LimpiarInterfaz();
            } else
            {
                MessageBox.Show("Ocurrió un error al intentar guardar la orden.", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrdenes.Rows[e.RowIndex].Cells["Id"].Value != null)
            {
                idOrdenSeleccionada = Convert.ToInt32(dgvOrdenes.Rows[e.RowIndex].Cells["Id"].Value);

                OrdenServicio? orden = ordenDAO.ObtenerOrdenPorId(idOrdenSeleccionada);

                if (orden != null)
                {
                    txtCliente.Text = orden.Cliente;
                    txtTelefono.Text = orden.Telefono;

                    cboTipoEquipo.Text = orden.TipoEquipo;
                    cboServicioBase.Text = orden.ServicioBase;

                    chkLimpiezaProfunda.Checked = orden.LimpiezaProfunda;
                    chkCambioPasta.Checked = orden.CambioPasta;
                    chkInstalacionSoftware.Checked = orden.InstalacionSoftware;
                    chkRespaldoDatos.Checked = orden.RespaldoDatos;

                    rdbTaller.Checked = !orden.EsDomicilio;
                    rdbDomicilio.Checked = orden.EsDomicilio;

                    chkClienteFrecuente.Checked = orden.EsClienteFrecuente;

                    lblSubtotalValor.Text = $"Subtotal Servicio: ${orden.CalcularSubtotalServicio():N0} CLP";
                    lblDescuentoValor.Text = $"Descuento (15%): ${orden.CalcularMontoDescuento():N0} CLP";
                    lblDomicilioValor.Text = $"Recargo Domicilio: ${orden.CalcularCostoDomicilio():N0} CLP";
                    lblIvaValor.Text = $"IVA (19%): ${orden.CalcularMontoIva():N0} CLP";
                    lblTotalValor.Text = $"TOTAL A PAGAR: ${orden.CalcularTotalPagar():N0} CLP";

                    lblModo.Text = $"Modo: EDICIÓN (Orden ID #{idOrdenSeleccionada})";

                    btnGuardarSQL.Enabled = false;
                    btnModificarSQL.Enabled = true;
                    btnEliminarSQL.Enabled = true;

                }
            } else
            {
                LimpiarInterfaz();
            }
        }

        private void btnModificarSQL_Click(object sender, EventArgs e)
        {
            if (idOrdenSeleccionada <= 0)
            {
                MessageBox.Show("Seleccione una orden de la tabla para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarFormulario()) return;

            OrdenServicio? ordenEditada = ConstruirOrdenDesdeUI();
            ordenEditada.Id = idOrdenSeleccionada;

            lblSubtotalValor.Text = $"Subtotal Servicio: ${ordenEditada.CalcularSubtotalServicio():N0} CLP";
            lblDescuentoValor.Text = $"Descuento (15%): ${ordenEditada.CalcularMontoDescuento():N0} CLP";
            lblDomicilioValor.Text = $"Recargo Domicilio: ${ordenEditada.CalcularCostoDomicilio():N0} CLP";
            lblIvaValor.Text = $"IVA (19%): ${ordenEditada.CalcularMontoIva():N0} CLP";
            lblTotalValor.Text = $"TOTAL A PAGAR: ${ordenEditada.CalcularTotalPagar():N0} CLP";

            if (ordenDAO.ActualizarOrden(ordenEditada))
            {
                MessageBox.Show($"¡Orden #{idOrdenSeleccionada} actualizada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrillaOrdenes();
                LimpiarInterfaz();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el registro.", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminarSQL_Click(object sender, EventArgs e)
        {
            if (idOrdenSeleccionada <= 0)
            {
                MessageBox.Show("Seleccione una orden de la tabla para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Está seguro de eliminar permanentemente la Orden #{idOrdenSeleccionada}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                if (ordenDAO.EliminarOrden(idOrdenSeleccionada))
                {
                    MessageBox.Show("Orden eliminada de la base de datos.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrillaOrdenes();
                    LimpiarInterfaz();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscarCliente.Text.Trim();

                DataTable dtFiltrada = ordenDAO.BuscarOrdenesPorCliente(filtro);
                dgvOrdenes.DataSource = dtFiltrada;

                CalcularMetricas(dtFiltrada);
            } catch(Exception)
            {
                Console.WriteLine("Error inesperado.");
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Nombre del cliente y teléfono son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                return false;
            }
            return true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarInterfaz();
        }

        private void LimpiarInterfaz()
        {
            txtCliente.Clear();
            txtTelefono.Clear();

            lblSubtotalValor.Text = "Subtotal Servicio: 0 CLP";
            lblDescuentoValor.Text = "Descuento (15%): 0 CLP";
            lblDomicilioValor.Text = "Recargo Domicilio: 0 CLP";
            lblIvaValor.Text = "IVA (19%): 0 CLP";
            lblTotalValor.Text = "TOTAL A PAGAR: 0 CLP";

            chkLimpiezaProfunda.Checked = false;
            chkCambioPasta.Checked = false;
            chkInstalacionSoftware.Checked = false;
            chkRespaldoDatos.Checked = false;
            rdbDomicilio.Checked = false;
            chkClienteFrecuente.Checked = false;
            rdbTaller.Checked = true;

            if (cboTipoEquipo.Items.Count > 0) cboTipoEquipo.SelectedIndex = 0;
            if (cboServicioBase.Items.Count > 0) cboServicioBase.SelectedIndex = 0;

            ordenTemporal = null;
            EstablecerModoInsercion();
            txtCliente.Focus();
        }

        private void EstablecerModoInsercion()
        {
            idOrdenSeleccionada = 0;
            lblModo.Text = "Modo: NUEVO REGISTRO";
            btnGuardarSQL.Enabled = true;
            btnModificarSQL.Enabled = false;
            btnEliminarSQL.Enabled = false;
        }
    }
}