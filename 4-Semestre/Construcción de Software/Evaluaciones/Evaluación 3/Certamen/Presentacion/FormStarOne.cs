using StarOne.Core;
using StarOne.Datos;
using System.Data;
using Microsoft.Data.SqlClient;

namespace StarOne.GUI
{
    public partial class FormStarOne : Form
    {
        // Instancia de la Capa de Acceso a Datos
        private PasajeDAO pasajeDAO;
        private VueloDAO vueloDAO;

        public FormStarOne()
        {
            InitializeComponent();
            pasajeDAO = new PasajeDAO();
            vueloDAO = new VueloDAO();

        }

        #region Eventos del Formulario

        private void FormStarOne_Load(object sender, EventArgs e)
        {
            CargarComboVuelos();
            CargarGrillaPasajes();
            ActualizarMetricas();
            LimpiarFormulario();
        }

        #endregion

        #region Métodos de Carga y Data Binding

        /// <summary>
        /// Pobla el ComboBox de Vuelos utilizando los datos de la tabla Vuelos.
        /// </summary>
        private void CargarComboVuelos()
        {
            try
            {
                DataTable vuelos = vueloDAO.ObtenerVuelosDesconectado();

                cboVuelo.DataSource = new BindingSource(vuelos, null);
                cboVuelo.DisplayMember = "Codigo";
                cboVuelo.ValueMember = "IdVuelo";
                cboVuelo.DropDownStyle = ComboBoxStyle.DropDownList;    
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al cargar vuelos: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga y refresca el DataGridView desde la base de datos StarOneDB/pasajes.
        /// Solo mostrar los campos relevantes: 
        /// NombreCompleto, 
        /// Rut, 
        /// Edad, 
        /// Origen, 
        /// Destino, 
        /// Asiento, 
        /// PrecioBase, 
        /// PorcentajeDescuento, 
        /// MontoDescuento, 
        /// ValorFinal.
        /// </summary>
        private void CargarGrillaPasajes()
        {
            try
            {
                DataTable dt = pasajeDAO.ObtenerPasajesDesconectado();
                dgvPasajes.DataSource = dt;
            } catch(SqlException ex)
            {
                MessageBox.Show($"Error al cargar pasajes: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Recorre las filas del DataGridView para calcular las métricas acumuladas globales de la jornada.
        /// </summary>
        private void ActualizarMetricas()
        {
            decimal recaudacionTotal = 0;

            if (dgvPasajes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPasajes.Rows)
                {
                    recaudacionTotal += Convert.ToInt32(row.Cells["Total"].Value);
                }
            }

            lblTotalPasajerosVal.Text = $"{dgvPasajes.Rows.Count} Pasajeros";
            lblTotalRecaudadoVal.Text = $"${recaudacionTotal:N0} CLP";
        }

        #endregion

        #region Eventos de Botones y Lógica de Negocio

        /// <summary>
        /// Botón Calcular: Valida los campos y calcula el desglose financiero sin guardar en la BD.
        /// </summary>
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas()) return;

            try
            {
                Pasaje pasaje = CrearObjetoPasajeDesdeGUI(GetVueloSeleccionado());

                // Mostrar resumen financiero en el Panel de Desglose
                lblPrecioBaseVal.Text = $"${pasaje.PrecioBase:N0} CLP";
                lblMontoDescuentoVal.Text = $"${pasaje.MontoDescuento:N0} CLP";
                lblPorcentajeDescVal.Text = $"{pasaje.PorcentajeDescuento}%";
                lblTotalPagarVal.Text = $"${pasaje.ValorFinal:N0} CLP";

                MessageBox.Show($"Cálculo realizado con éxito para el pasajero: {pasaje.NombreCompleto}\n\n" +
                                $"Descuento de RUT aplicado: {pasaje.PorcentajeDescuento}%\n" +
                                $"Total a pagar: ${pasaje.ValorFinal:N0} CLP\n",
                                "Simulación de Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular la tarifa: {ex.Message}", "Error de Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón Registrar: Guarda el pasajero en la base de datos SQL Server Express a través de PasajeroDAO.
        /// </summary>
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas()) return;

            try {
                Pasaje pasaje = CrearObjetoPasajeDesdeGUI(GetVueloSeleccionado());
                bool exito = pasajeDAO.InsertarPasaje(pasaje);

                if (exito)
                {
                    MessageBox.Show($"¡Venta registrada con éxito en StarOneDB!\n\n" +
                                    $"Pasajero: {pasaje.NombreCompleto}\n" +
                                    $"RUT: {pasaje.Rut}\n" +
                                    $"Total Cobrado: ${pasaje.ValorFinal:N0} CLP\n",
                                    "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrillaPasajes();
                    ActualizarMetricas();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el registro en la base de datos.", "Fallo de Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al registrar pasaje: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón Buscar: Filtra los registros de la base de datos según el nombre o RUT ingresado.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();

            try
            {
                DataTable dtFiltrada = pasajeDAO.BuscarPasajesPorRutONombre(filtro);
                dgvPasajes.DataSource = dtFiltrada;

                ActualizarMetricas();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al buscar registro: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Botón Eliminar: Elimina el pasajero seleccionado en el DataGridView previa confirmación modal.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPasajes.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un pasaje de la tabla para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPasaje = Convert.ToInt32(dgvPasajes.CurrentRow.Cells["IdPasaje"].Value);

            DialogResult respuesta = MessageBox.Show($"¿Está seguro de que desea eliminar el registro de venta del pasaje (ID: {idPasaje})?",
                                                    "Confirmación de Eliminación",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    if (pasajeDAO.EliminarPasaje(idPasaje))
                    {
                        MessageBox.Show("Pasaje eliminado de la base de datos.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarGrillaPasajes();
                        ActualizarMetricas();
                        LimpiarFormulario();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de base de datos: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Botón Limpiar: Restablece todos los controles del formulario a su estado inicial.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        /// <summary>
        /// Botón Salir: Cierra la aplicación confirmando la salida.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir del Sistema POS StarOne?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion

        #region Métodos Auxiliares y Validaciones

        /// <summary>
        /// Valida de forma robusta la presencia y formato de los datos ingresados en la GUI.
        /// </summary>
        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre completo del pasajero.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRut.Text))
            {
                MessageBox.Show("Debe ingresar el RUT del pasajero.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRut.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDVRut.Text))
            {
                MessageBox.Show("Debe ingresar el dígito verificador del RUT.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVRut.Focus();
                return false;
            }

            if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0 || edad > 120)
            {
                MessageBox.Show("Ingrese una edad válida (número entero entre 1 y 120).", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdad.Focus();
                return false;
            }

            if (cboVuelo.SelectedIndex == -1 || cboVuelo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un vuelo de la lista desplegable.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVuelo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAsiento.Text))
            {
                MessageBox.Show("Debe especificar el número o código de asiento.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAsiento.Focus();
                return false;
            }

            return true;
        }

        private int GetVueloSeleccionado()
        {
            return (int)cboVuelo.SelectedValue;
        }

        /// <summary>
        /// Construye y retorna un objeto de dominio Pasaje a partir de los controles de la interfaz gráfica.
        /// </summary>
        private Pasaje CrearObjetoPasajeDesdeGUI(int vueloSeleccionado)
        {
            DataRowView vuelo = (DataRowView)cboVuelo.SelectedItem;

            string nombre = txtNombre.Text.Trim();
            string rut = txtRut.Text.Trim() + "-" + txtDVRut.Text.Trim();
            int edad = int.Parse(txtEdad.Text.Trim());
            string asiento = txtAsiento.Text.Trim().ToUpper();
            string origen = vuelo["Origen"].ToString();
            string destino = vuelo["Destino"].ToString();
            decimal valorPasaje = Convert.ToDecimal(vuelo["PrecioBase"]);

            bool aplicaDescuentoRut = chkDescuentoRut.Checked;

            // Instanciar el Pasaje calculando el porcentaje según el RUT
            /*Pasaje pasaje = new Pasaje(vueloSeleccionado, asiento, rut, aplicaDescuentoRut);
            pasaje.NombreCompleto = nombre;
            pasaje.Edad = edad;
            pasaje.PrecioBase = valorPasaje;
            pasaje.Origen = origen;
            pasaje.Destino = destino;*/ // Versión original

            Pasaje pasaje = new Pasaje(nombre, rut, edad, vueloSeleccionado, origen, destino, asiento, valorPasaje, aplicaDescuentoRut); // Nueva versión

            // Instanciar la Entidad de Dominio Pasaje
            return pasaje;
        }

        /// <summary>
        /// Limpia las cajas de texto y restablece la selección de los ComboBoxes.
        /// </summary>
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtRut.Clear();
            txtDVRut.Clear();
            txtEdad.Clear();
            txtAsiento.Clear();
            txtFiltro.Clear();

            if (cboVuelo.Items.Count > 0) cboVuelo.SelectedIndex = 0;

            chkDescuentoRut.Checked = true;

            lblPrecioBaseVal.Text = "$0";
            lblPorcentajeDescVal.Text = "0%";
            lblMontoDescuentoVal.Text = "$0";
            lblTotalPagarVal.Text = "$0";

            txtNombre.Focus();
        }

        #endregion
        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            if (ConexionBD.ProbarConexion())
            {
                MessageBox.Show("¡Conexión establecida con éxito a StarOneDB.mdf!",
                                "Prueba de Conexión",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo conectar a la base de datos.\nVerifica que el archivo StarOneDB.mdf esté en la carpeta BaseDatos y configurado como 'Copy if newer'.",
                                "Error de Conexión",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
