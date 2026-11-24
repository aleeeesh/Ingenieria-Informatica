
namespace StarOne.GUI
{
    partial class FormStarOne
    {


        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblSubtituloHeader = new Label();
            lblTituloHeader = new Label();
            grpPasajero = new GroupBox();
            txtDVRut = new TextBox();
            lblGuionRut = new Label();
            chkDescuentoRut = new CheckBox();
            txtEdad = new TextBox();
            lblEdad = new Label();
            txtRut = new TextBox();
            lblRut = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            grpVuelo = new GroupBox();
            txtAsiento = new TextBox();
            lblAsiento = new Label();
            cboVuelo = new ComboBox();
            lblVuelo = new Label();
            grpResumen = new GroupBox();
            lblTotalPagarVal = new Label();
            lblTotalPagar = new Label();
            lblMontoDescuentoVal = new Label();
            lblMontoDescuento = new Label();
            lblPorcentajeDescVal = new Label();
            lblPorcentajeDesc = new Label();
            lblPrecioBaseVal = new Label();
            lblPrecioBase = new Label();
            grpAcciones = new GroupBox();
            btnSalir = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnRegistrar = new Button();
            btnCalcular = new Button();
            grpBusqueda = new GroupBox();
            btnBuscar = new Button();
            txtFiltro = new TextBox();
            lblFiltro = new Label();
            grpHistorial = new GroupBox();
            dgvPasajes = new DataGridView();
            grpMetricas = new GroupBox();
            btnProbarConexion = new Button();
            lblTotalRecaudadoVal = new Label();
            lblTotalRecaudado = new Label();
            lblTotalPasajerosVal = new Label();
            lblTotalPasajeros = new Label();
            pnlHeader.SuspendLayout();
            grpPasajero.SuspendLayout();
            grpVuelo.SuspendLayout();
            grpResumen.SuspendLayout();
            grpAcciones.SuspendLayout();
            grpBusqueda.SuspendLayout();
            grpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPasajes).BeginInit();
            grpMetricas.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 47, 108);
            pnlHeader.Controls.Add(lblSubtituloHeader);
            pnlHeader.Controls.Add(lblTituloHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1084, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtituloHeader
            // 
            lblSubtituloHeader.AutoSize = true;
            lblSubtituloHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblSubtituloHeader.ForeColor = Color.FromArgb(255, 170, 0);
            lblSubtituloHeader.Location = new Point(20, 42);
            lblSubtituloHeader.Name = "lblSubtituloHeader";
            lblSubtituloHeader.Size = new Size(406, 17);
            lblSubtituloHeader.TabIndex = 1;
            lblSubtituloHeader.Text = "Instituto Profesional Virginio Gómez — Certamen 3 (Semana 14)";
            // 
            // lblTituloHeader
            // 
            lblTituloHeader.AutoSize = true;
            lblTituloHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloHeader.ForeColor = Color.White;
            lblTituloHeader.Location = new Point(18, 10);
            lblTituloHeader.Name = "lblTituloHeader";
            lblTituloHeader.Size = new Size(568, 30);
            lblTituloHeader.TabIndex = 0;
            lblTituloHeader.Text = "SISTEMA AÉREO STARONE — VENTA DE PASAJES POS";
            // 
            // grpPasajero
            // 
            grpPasajero.Controls.Add(txtDVRut);
            grpPasajero.Controls.Add(lblGuionRut);
            grpPasajero.Controls.Add(chkDescuentoRut);
            grpPasajero.Controls.Add(txtEdad);
            grpPasajero.Controls.Add(lblEdad);
            grpPasajero.Controls.Add(txtRut);
            grpPasajero.Controls.Add(lblRut);
            grpPasajero.Controls.Add(txtNombre);
            grpPasajero.Controls.Add(lblNombre);
            grpPasajero.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpPasajero.ForeColor = Color.FromArgb(0, 47, 108);
            grpPasajero.Location = new Point(20, 85);
            grpPasajero.Name = "grpPasajero";
            grpPasajero.Size = new Size(520, 150);
            grpPasajero.TabIndex = 1;
            grpPasajero.TabStop = false;
            grpPasajero.Text = "1. Datos del Pasajero";
            // 
            // txtDVRut
            // 
            txtDVRut.CharacterCasing = CharacterCasing.Upper;
            txtDVRut.Location = new Point(274, 77);
            txtDVRut.MaxLength = 1;
            txtDVRut.Name = "txtDVRut";
            txtDVRut.Size = new Size(23, 24);
            txtDVRut.TabIndex = 3;
            // 
            // lblGuionRut
            // 
            lblGuionRut.AutoSize = true;
            lblGuionRut.Location = new Point(256, 81);
            lblGuionRut.Name = "lblGuionRut";
            lblGuionRut.Size = new Size(13, 17);
            lblGuionRut.TabIndex = 7;
            lblGuionRut.Text = "-";
            // 
            // chkDescuentoRut
            // 
            chkDescuentoRut.AutoSize = true;
            chkDescuentoRut.Checked = true;
            chkDescuentoRut.CheckState = CheckState.Checked;
            chkDescuentoRut.Font = new Font("Segoe UI", 9F);
            chkDescuentoRut.ForeColor = Color.DarkGreen;
            chkDescuentoRut.Location = new Point(130, 115);
            chkDescuentoRut.Name = "chkDescuentoRut";
            chkDescuentoRut.Size = new Size(284, 19);
            chkDescuentoRut.TabIndex = 5;
            chkDescuentoRut.Text = "Aplicar Descuento por RUT (10 + último dígito)%";
            chkDescuentoRut.UseVisualStyleBackColor = true;
            // 
            // txtEdad
            // 
            txtEdad.Font = new Font("Segoe UI", 9F);
            txtEdad.Location = new Point(395, 75);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(100, 23);
            txtEdad.TabIndex = 4;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Font = new Font("Segoe UI", 9F);
            lblEdad.ForeColor = Color.Black;
            lblEdad.Location = new Point(350, 78);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(36, 15);
            lblEdad.TabIndex = 4;
            lblEdad.Text = "Edad:";
            // 
            // txtRut
            // 
            txtRut.Font = new Font("Segoe UI", 9F);
            txtRut.Location = new Point(130, 75);
            txtRut.Name = "txtRut";
            txtRut.Size = new Size(120, 23);
            txtRut.TabIndex = 2;
            // 
            // lblRut
            // 
            lblRut.AutoSize = true;
            lblRut.Font = new Font("Segoe UI", 9F);
            lblRut.ForeColor = Color.Black;
            lblRut.Location = new Point(15, 78);
            lblRut.Name = "lblRut";
            lblRut.Size = new Size(117, 15);
            lblRut.TabIndex = 2;
            lblRut.Text = "RUT (ej: 19876543-2):";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9F);
            txtNombre.Location = new Point(130, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(365, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F);
            lblNombre.ForeColor = Color.Black;
            lblNombre.Location = new Point(15, 38);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(110, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre Completo:";
            // 
            // grpVuelo
            // 
            grpVuelo.Controls.Add(txtAsiento);
            grpVuelo.Controls.Add(lblAsiento);
            grpVuelo.Controls.Add(cboVuelo);
            grpVuelo.Controls.Add(lblVuelo);
            grpVuelo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpVuelo.ForeColor = Color.FromArgb(0, 47, 108);
            grpVuelo.Location = new Point(555, 85);
            grpVuelo.Name = "grpVuelo";
            grpVuelo.Size = new Size(510, 150);
            grpVuelo.TabIndex = 2;
            grpVuelo.TabStop = false;
            grpVuelo.Text = "2. Selección de Vuelo y Asiento";
            // 
            // txtAsiento
            // 
            txtAsiento.Font = new Font("Segoe UI", 9F);
            txtAsiento.Location = new Point(130, 85);
            txtAsiento.Name = "txtAsiento";
            txtAsiento.Size = new Size(120, 23);
            txtAsiento.TabIndex = 7;
            // 
            // lblAsiento
            // 
            lblAsiento.AutoSize = true;
            lblAsiento.Font = new Font("Segoe UI", 9F);
            lblAsiento.ForeColor = Color.Black;
            lblAsiento.Location = new Point(15, 88);
            lblAsiento.Name = "lblAsiento";
            lblAsiento.Size = new Size(92, 15);
            lblAsiento.TabIndex = 2;
            lblAsiento.Text = "Código Asiento:";
            // 
            // cboVuelo
            // 
            cboVuelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVuelo.Font = new Font("Segoe UI", 9F);
            cboVuelo.FormattingEnabled = true;
            cboVuelo.Location = new Point(130, 38);
            cboVuelo.Name = "cboVuelo";
            cboVuelo.Size = new Size(360, 23);
            cboVuelo.TabIndex = 6;
            // 
            // lblVuelo
            // 
            lblVuelo.AutoSize = true;
            lblVuelo.Font = new Font("Segoe UI", 9F);
            lblVuelo.ForeColor = Color.Black;
            lblVuelo.Location = new Point(15, 41);
            lblVuelo.Name = "lblVuelo";
            lblVuelo.Size = new Size(99, 15);
            lblVuelo.TabIndex = 0;
            lblVuelo.Text = "Vuelo Disponible:";
            // 
            // grpResumen
            // 
            grpResumen.BackColor = Color.FromArgb(248, 249, 250);
            grpResumen.Controls.Add(lblTotalPagarVal);
            grpResumen.Controls.Add(lblTotalPagar);
            grpResumen.Controls.Add(lblMontoDescuentoVal);
            grpResumen.Controls.Add(lblMontoDescuento);
            grpResumen.Controls.Add(lblPorcentajeDescVal);
            grpResumen.Controls.Add(lblPorcentajeDesc);
            grpResumen.Controls.Add(lblPrecioBaseVal);
            grpResumen.Controls.Add(lblPrecioBase);
            grpResumen.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpResumen.ForeColor = Color.FromArgb(0, 47, 108);
            grpResumen.Location = new Point(20, 245);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new Size(520, 120);
            grpResumen.TabIndex = 3;
            grpResumen.TabStop = false;
            grpResumen.Text = "3. Desglose Financiero";
            // 
            // lblTotalPagarVal
            // 
            lblTotalPagarVal.AutoSize = true;
            lblTotalPagarVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalPagarVal.ForeColor = Color.DarkBlue;
            lblTotalPagarVal.Location = new Point(380, 75);
            lblTotalPagarVal.Name = "lblTotalPagarVal";
            lblTotalPagarVal.Size = new Size(52, 21);
            lblTotalPagarVal.TabIndex = 7;
            lblTotalPagarVal.Text = "-bash";
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTotalPagar.ForeColor = Color.Black;
            lblTotalPagar.Location = new Point(270, 78);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(94, 17);
            lblTotalPagar.TabIndex = 6;
            lblTotalPagar.Text = "Total a Pagar:";
            // 
            // lblMontoDescuentoVal
            // 
            lblMontoDescuentoVal.AutoSize = true;
            lblMontoDescuentoVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMontoDescuentoVal.ForeColor = Color.DarkRed;
            lblMontoDescuentoVal.Location = new Point(380, 35);
            lblMontoDescuentoVal.Name = "lblMontoDescuentoVal";
            lblMontoDescuentoVal.Size = new Size(42, 17);
            lblMontoDescuentoVal.TabIndex = 5;
            lblMontoDescuentoVal.Text = "-bash";
            // 
            // lblMontoDescuento
            // 
            lblMontoDescuento.AutoSize = true;
            lblMontoDescuento.Font = new Font("Segoe UI", 9F);
            lblMontoDescuento.ForeColor = Color.Black;
            lblMontoDescuento.Location = new Point(270, 37);
            lblMontoDescuento.Name = "lblMontoDescuento";
            lblMontoDescuento.Size = new Size(105, 15);
            lblMontoDescuento.TabIndex = 4;
            lblMontoDescuento.Text = "Monto Descuento:";
            // 
            // lblPorcentajeDescVal
            // 
            lblPorcentajeDescVal.AutoSize = true;
            lblPorcentajeDescVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPorcentajeDescVal.ForeColor = Color.DarkGreen;
            lblPorcentajeDescVal.Location = new Point(120, 78);
            lblPorcentajeDescVal.Name = "lblPorcentajeDescVal";
            lblPorcentajeDescVal.Size = new Size(26, 17);
            lblPorcentajeDescVal.TabIndex = 3;
            lblPorcentajeDescVal.Text = "0%";
            // 
            // lblPorcentajeDesc
            // 
            lblPorcentajeDesc.AutoSize = true;
            lblPorcentajeDesc.Font = new Font("Segoe UI", 9F);
            lblPorcentajeDesc.ForeColor = Color.Black;
            lblPorcentajeDesc.Location = new Point(15, 78);
            lblPorcentajeDesc.Name = "lblPorcentajeDesc";
            lblPorcentajeDesc.Size = new Size(79, 15);
            lblPorcentajeDesc.TabIndex = 2;
            lblPorcentajeDesc.Text = "% Descuento:";
            // 
            // lblPrecioBaseVal
            // 
            lblPrecioBaseVal.AutoSize = true;
            lblPrecioBaseVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPrecioBaseVal.ForeColor = Color.Black;
            lblPrecioBaseVal.Location = new Point(120, 35);
            lblPrecioBaseVal.Name = "lblPrecioBaseVal";
            lblPrecioBaseVal.Size = new Size(42, 17);
            lblPrecioBaseVal.TabIndex = 1;
            lblPrecioBaseVal.Text = "-bash";
            // 
            // lblPrecioBase
            // 
            lblPrecioBase.AutoSize = true;
            lblPrecioBase.Font = new Font("Segoe UI", 9F);
            lblPrecioBase.ForeColor = Color.Black;
            lblPrecioBase.Location = new Point(15, 37);
            lblPrecioBase.Name = "lblPrecioBase";
            lblPrecioBase.Size = new Size(70, 15);
            lblPrecioBase.TabIndex = 0;
            lblPrecioBase.Text = "Precio Base:";
            // 
            // grpAcciones
            // 
            grpAcciones.Controls.Add(btnSalir);
            grpAcciones.Controls.Add(btnLimpiar);
            grpAcciones.Controls.Add(btnEliminar);
            grpAcciones.Controls.Add(btnRegistrar);
            grpAcciones.Controls.Add(btnCalcular);
            grpAcciones.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpAcciones.ForeColor = Color.FromArgb(0, 47, 108);
            grpAcciones.Location = new Point(555, 245);
            grpAcciones.Name = "grpAcciones";
            grpAcciones.Size = new Size(510, 120);
            grpAcciones.TabIndex = 4;
            grpAcciones.TabStop = false;
            grpAcciones.Text = "4. Panel de Acciones";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(220, 53, 69);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(395, 45);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(95, 45);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(300, 45);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(90, 45);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 193, 7);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.Black;
            btnEliminar.Location = new Point(205, 45);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 45);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(40, 167, 69);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(110, 45);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(90, 45);
            btnRegistrar.TabIndex = 1;
            btnRegistrar.Text = "Registrar (BD)";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.FromArgb(0, 47, 108);
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Location = new Point(15, 45);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(90, 45);
            btnCalcular.TabIndex = 0;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // grpBusqueda
            // 
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Controls.Add(txtFiltro);
            grpBusqueda.Controls.Add(lblFiltro);
            grpBusqueda.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpBusqueda.ForeColor = Color.FromArgb(0, 47, 108);
            grpBusqueda.Location = new Point(20, 375);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(1045, 60);
            grpBusqueda.TabIndex = 5;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Búsqueda y Filtro Dinámico en Base de Datos";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(0, 47, 108);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(480, 22);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(120, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar / Filtrar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtFiltro
            // 
            txtFiltro.Font = new Font("Segoe UI", 9F);
            txtFiltro.Location = new Point(170, 24);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(300, 23);
            txtFiltro.TabIndex = 1;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Font = new Font("Segoe UI", 9F);
            lblFiltro.ForeColor = Color.Black;
            lblFiltro.Location = new Point(15, 27);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(148, 15);
            lblFiltro.TabIndex = 0;
            lblFiltro.Text = "Buscar por RUT o Nombre:";
            // 
            // grpHistorial
            // 
            grpHistorial.Controls.Add(dgvPasajes);
            grpHistorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpHistorial.ForeColor = Color.FromArgb(0, 47, 108);
            grpHistorial.Location = new Point(20, 445);
            grpHistorial.Name = "grpHistorial";
            grpHistorial.Size = new Size(1045, 200);
            grpHistorial.TabIndex = 6;
            grpHistorial.TabStop = false;
            grpHistorial.Text = "Registro en Base de Datos (StarOneDB — Tabla Pasajeros)";
            // 
            // dgvPasajes
            // 
            dgvPasajes.AllowUserToAddRows = false;
            dgvPasajes.AllowUserToDeleteRows = false;
            dgvPasajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPasajes.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 47, 108);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPasajes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPasajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(0, 47, 108);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 170, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPasajes.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPasajes.Dock = DockStyle.Fill;
            dgvPasajes.EnableHeadersVisualStyles = false;
            dgvPasajes.Location = new Point(3, 19);
            dgvPasajes.MultiSelect = false;
            dgvPasajes.Name = "dgvPasajes";
            dgvPasajes.ReadOnly = true;
            dgvPasajes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPasajes.Size = new Size(1039, 178);
            dgvPasajes.TabIndex = 0;
            // 
            // grpMetricas
            // 
            grpMetricas.BackColor = Color.FromArgb(248, 249, 250);
            grpMetricas.Controls.Add(btnProbarConexion);
            grpMetricas.Controls.Add(lblTotalRecaudadoVal);
            grpMetricas.Controls.Add(lblTotalRecaudado);
            grpMetricas.Controls.Add(lblTotalPasajerosVal);
            grpMetricas.Controls.Add(lblTotalPasajeros);
            grpMetricas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpMetricas.ForeColor = Color.FromArgb(0, 47, 108);
            grpMetricas.Location = new Point(20, 655);
            grpMetricas.Name = "grpMetricas";
            grpMetricas.Size = new Size(1045, 55);
            grpMetricas.TabIndex = 7;
            grpMetricas.TabStop = false;
            grpMetricas.Text = "Métricas Globales Acumuladas de la Jornada";
            // 
            // btnProbarConexion
            // 
            btnProbarConexion.Location = new Point(851, 19);
            btnProbarConexion.Name = "btnProbarConexion";
            btnProbarConexion.Size = new Size(142, 23);
            btnProbarConexion.TabIndex = 4;
            btnProbarConexion.Text = "Probar Conexión";
            btnProbarConexion.UseVisualStyleBackColor = true;
            btnProbarConexion.Click += btnProbarConexion_Click;
            // 
            // lblTotalRecaudadoVal
            // 
            lblTotalRecaudadoVal.AutoSize = true;
            lblTotalRecaudadoVal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalRecaudadoVal.ForeColor = Color.DarkBlue;
            lblTotalRecaudadoVal.Location = new Point(480, 23);
            lblTotalRecaudadoVal.Name = "lblTotalRecaudadoVal";
            lblTotalRecaudadoVal.Size = new Size(46, 19);
            lblTotalRecaudadoVal.TabIndex = 3;
            lblTotalRecaudadoVal.Text = "-bash";
            // 
            // lblTotalRecaudado
            // 
            lblTotalRecaudado.AutoSize = true;
            lblTotalRecaudado.Font = new Font("Segoe UI", 9F);
            lblTotalRecaudado.ForeColor = Color.Black;
            lblTotalRecaudado.Location = new Point(330, 25);
            lblTotalRecaudado.Name = "lblTotalRecaudado";
            lblTotalRecaudado.Size = new Size(139, 15);
            lblTotalRecaudado.TabIndex = 2;
            lblTotalRecaudado.Text = "Recaudación Total Venta:";
            // 
            // lblTotalPasajerosVal
            // 
            lblTotalPasajerosVal.AutoSize = true;
            lblTotalPasajerosVal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalPasajerosVal.ForeColor = Color.DarkGreen;
            lblTotalPasajerosVal.Location = new Point(180, 23);
            lblTotalPasajerosVal.Name = "lblTotalPasajerosVal";
            lblTotalPasajerosVal.Size = new Size(17, 19);
            lblTotalPasajerosVal.TabIndex = 1;
            lblTotalPasajerosVal.Text = "0";
            // 
            // lblTotalPasajeros
            // 
            lblTotalPasajeros.AutoSize = true;
            lblTotalPasajeros.Font = new Font("Segoe UI", 9F);
            lblTotalPasajeros.ForeColor = Color.Black;
            lblTotalPasajeros.Location = new Point(20, 25);
            lblTotalPasajeros.Name = "lblTotalPasajeros";
            lblTotalPasajeros.Size = new Size(152, 15);
            lblTotalPasajeros.TabIndex = 0;
            lblTotalPasajeros.Text = "Total Pasajeros Registrados:";
            // 
            // FormStarOne
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1084, 725);
            Controls.Add(grpMetricas);
            Controls.Add(grpHistorial);
            Controls.Add(grpBusqueda);
            Controls.Add(grpAcciones);
            Controls.Add(grpResumen);
            Controls.Add(grpVuelo);
            Controls.Add(grpPasajero);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormStarOne";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Aéreo StarOne — Venta POS de Pasajes";
            Load += FormStarOne_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpPasajero.ResumeLayout(false);
            grpPasajero.PerformLayout();
            grpVuelo.ResumeLayout(false);
            grpVuelo.PerformLayout();
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            grpAcciones.ResumeLayout(false);
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPasajes).EndInit();
            grpMetricas.ResumeLayout(false);
            grpMetricas.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label lblSubtituloHeader;
        private System.Windows.Forms.GroupBox grpPasajero;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblRut;
        private System.Windows.Forms.TextBox txtRut;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.CheckBox chkDescuentoRut;
        private System.Windows.Forms.GroupBox grpVuelo;
        private System.Windows.Forms.Label lblVuelo;
        private System.Windows.Forms.ComboBox cboVuelo;
        private System.Windows.Forms.Label lblAsiento;
        private System.Windows.Forms.TextBox txtAsiento;
        private System.Windows.Forms.GroupBox grpResumen;
        private System.Windows.Forms.Label lblPrecioBase;
        private System.Windows.Forms.Label lblPrecioBaseVal;
        private System.Windows.Forms.Label lblPorcentajeDesc;
        private System.Windows.Forms.Label lblPorcentajeDescVal;
        private System.Windows.Forms.Label lblMontoDescuento;
        private System.Windows.Forms.Label lblMontoDescuentoVal;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label lblTotalPagarVal;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox grpBusqueda;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox grpHistorial;
        private System.Windows.Forms.DataGridView dgvPasajes;
        private System.Windows.Forms.GroupBox grpMetricas;
        private System.Windows.Forms.Label lblTotalPasajeros;
        private System.Windows.Forms.Label lblTotalPasajerosVal;
        private System.Windows.Forms.Label lblTotalRecaudado;
        private System.Windows.Forms.Label lblTotalRecaudadoVal;
        private TextBox txtDVRut;
        private Label lblGuionRut;
        private Button btnProbarConexion;
    }
}

