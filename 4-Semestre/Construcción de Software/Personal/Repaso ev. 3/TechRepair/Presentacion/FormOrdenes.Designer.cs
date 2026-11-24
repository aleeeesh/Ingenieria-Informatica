namespace TechRepair
{
    partial class FormOrdenes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEstadoConexion = new System.Windows.Forms.Label();
            this.lblModo = new System.Windows.Forms.Label();
            this.grpIngreso = new System.Windows.Forms.GroupBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTipoEquipo = new System.Windows.Forms.Label();
            this.cboTipoEquipo = new System.Windows.Forms.ComboBox();
            this.lblServicioBase = new System.Windows.Forms.Label();
            this.cboServicioBase = new System.Windows.Forms.ComboBox();
            this.grpAdicionales = new System.Windows.Forms.GroupBox();
            this.chkLimpiezaProfunda = new System.Windows.Forms.CheckBox();
            this.chkCambioPasta = new System.Windows.Forms.CheckBox();
            this.chkInstalacionSoftware = new System.Windows.Forms.CheckBox();
            this.chkRespaldoDatos = new System.Windows.Forms.CheckBox();
            this.grpModalidad = new System.Windows.Forms.GroupBox();
            this.rdbTaller = new System.Windows.Forms.RadioButton();
            this.rdbDomicilio = new System.Windows.Forms.RadioButton();
            this.chkClienteFrecuente = new System.Windows.Forms.CheckBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.pnlDetallePago = new System.Windows.Forms.Panel();
            this.lblSubtotalValor = new System.Windows.Forms.Label();
            this.lblDescuentoValor = new System.Windows.Forms.Label();
            this.lblDomicilioValor = new System.Windows.Forms.Label();
            this.lblIvaValor = new System.Windows.Forms.Label();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.btnGuardarSQL = new System.Windows.Forms.Button();
            this.btnModificarSQL = new System.Windows.Forms.Button();
            this.btnEliminarSQL = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grpHistorial = new System.Windows.Forms.GroupBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.pnlMetricas = new System.Windows.Forms.Panel();
            this.lblTitRecaudado = new System.Windows.Forms.Label();
            this.lblTotalRecaudado = new System.Windows.Forms.Label();
            this.lblTitCantidad = new System.Windows.Forms.Label();
            this.lblCantidadOrdenes = new System.Windows.Forms.Label();
            this.lblTitPromedio = new System.Windows.Forms.Label();
            this.lblPromedioVenta = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.grpIngreso.SuspendLayout();
            this.grpAdicionales.SuspendLayout();
            this.grpModalidad.SuspendLayout();
            this.pnlDetallePago.SuspendLayout();
            this.grpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.pnlMetricas.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblEstadoConexion);
            this.pnlHeader.Controls.Add(this.lblModo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1160, 45);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(270, 21);
            this.lblTitulo.Text = "TechRepair - Órdenes de Servicio";

            // 
            // lblEstadoConexion
            // 
            this.lblEstadoConexion.AutoSize = true;
            this.lblEstadoConexion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEstadoConexion.ForeColor = System.Drawing.Color.LightGray;
            this.lblEstadoConexion.Location = new System.Drawing.Point(460, 14);
            this.lblEstadoConexion.Name = "lblEstadoConexion";
            this.lblEstadoConexion.Size = new System.Drawing.Size(180, 17);
            this.lblEstadoConexion.Text = "● Estado SQL: Verificando...";

            // 
            // lblModo
            // 
            this.lblModo.AutoSize = true;
            this.lblModo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblModo.ForeColor = System.Drawing.Color.Gold;
            this.lblModo.Location = new System.Drawing.Point(880, 14);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(175, 17);
            this.lblModo.Text = "Modo: NUEVO REGISTRO";

            // 
            // grpIngreso
            // 
            this.grpIngreso.Controls.Add(this.lblCliente);
            this.grpIngreso.Controls.Add(this.txtCliente);
            this.grpIngreso.Controls.Add(this.lblTelefono);
            this.grpIngreso.Controls.Add(this.txtTelefono);
            this.grpIngreso.Controls.Add(this.lblTipoEquipo);
            this.grpIngreso.Controls.Add(this.cboTipoEquipo);
            this.grpIngreso.Controls.Add(this.lblServicioBase);
            this.grpIngreso.Controls.Add(this.cboServicioBase);
            this.grpIngreso.Controls.Add(this.grpAdicionales);
            this.grpIngreso.Controls.Add(this.grpModalidad);
            this.grpIngreso.Controls.Add(this.btnCalcular);
            this.grpIngreso.Controls.Add(this.pnlDetallePago);
            this.grpIngreso.Controls.Add(this.btnGuardarSQL);
            this.grpIngreso.Controls.Add(this.btnModificarSQL);
            this.grpIngreso.Controls.Add(this.btnEliminarSQL);
            this.grpIngreso.Controls.Add(this.btnLimpiar);
            this.grpIngreso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpIngreso.Location = new System.Drawing.Point(15, 55);
            this.grpIngreso.Name = "grpIngreso";
            this.grpIngreso.Size = new System.Drawing.Size(430, 625);
            this.grpIngreso.TabIndex = 1;
            this.grpIngreso.TabStop = false;
            this.grpIngreso.Text = "Datos de la Orden de Servicio";

            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCliente.Location = new System.Drawing.Point(15, 28);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(50, 15);
            this.lblCliente.Text = "Cliente:";

            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCliente.Location = new System.Drawing.Point(120, 25);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(290, 24);
            this.txtCliente.TabIndex = 0;

            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono.Location = new System.Drawing.Point(15, 61);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(58, 15);
            this.lblTelefono.Text = "Teléfono:";

            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefono.Location = new System.Drawing.Point(120, 58);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(290, 24);
            this.txtTelefono.TabIndex = 1;

            // 
            // lblTipoEquipo
            // 
            this.lblTipoEquipo.AutoSize = true;
            this.lblTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoEquipo.Location = new System.Drawing.Point(15, 94);
            this.lblTipoEquipo.Name = "lblTipoEquipo";
            this.lblTipoEquipo.Size = new System.Drawing.Size(76, 15);
            this.lblTipoEquipo.Text = "Tipo Equipo:";

            // 
            // cboTipoEquipo
            // 
            this.cboTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboTipoEquipo.FormattingEnabled = true;
            this.cboTipoEquipo.Location = new System.Drawing.Point(120, 91);
            this.cboTipoEquipo.Name = "cboTipoEquipo";
            this.cboTipoEquipo.Size = new System.Drawing.Size(290, 24);
            this.cboTipoEquipo.TabIndex = 2;

            // 
            // lblServicioBase
            // 
            this.lblServicioBase.AutoSize = true;
            this.lblServicioBase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblServicioBase.Location = new System.Drawing.Point(15, 127);
            this.lblServicioBase.Name = "lblServicioBase";
            this.lblServicioBase.Size = new System.Drawing.Size(80, 15);
            this.lblServicioBase.Text = "Servicio Base:";

            // 
            // cboServicioBase
            // 
            this.cboServicioBase.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboServicioBase.FormattingEnabled = true;
            this.cboServicioBase.Location = new System.Drawing.Point(120, 124);
            this.cboServicioBase.Name = "cboServicioBase";
            this.cboServicioBase.Size = new System.Drawing.Size(290, 24);
            this.cboServicioBase.TabIndex = 3;

            // 
            // grpAdicionales
            // 
            this.grpAdicionales.Controls.Add(this.chkLimpiezaProfunda);
            this.grpAdicionales.Controls.Add(this.chkCambioPasta);
            this.grpAdicionales.Controls.Add(this.chkInstalacionSoftware);
            this.grpAdicionales.Controls.Add(this.chkRespaldoDatos);
            this.grpAdicionales.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.grpAdicionales.Location = new System.Drawing.Point(15, 158);
            this.grpAdicionales.Name = "grpAdicionales";
            this.grpAdicionales.Size = new System.Drawing.Size(395, 85);
            this.grpAdicionales.TabIndex = 4;
            this.grpAdicionales.TabStop = false;
            this.grpAdicionales.Text = "Servicios Adicionales ($5.000 c/u)";

            // 
            // chkLimpiezaProfunda
            // 
            this.chkLimpiezaProfunda.AutoSize = true;
            this.chkLimpiezaProfunda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkLimpiezaProfunda.Location = new System.Drawing.Point(12, 22);
            this.chkLimpiezaProfunda.Name = "chkLimpiezaProfunda";
            this.chkLimpiezaProfunda.Size = new System.Drawing.Size(130, 19);
            this.chkLimpiezaProfunda.TabIndex = 0;
            this.chkLimpiezaProfunda.Text = "Limpieza Profunda";

            // 
            // chkCambioPasta
            // 
            this.chkCambioPasta.AutoSize = true;
            this.chkCambioPasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkCambioPasta.Location = new System.Drawing.Point(200, 22);
            this.chkCambioPasta.Name = "chkCambioPasta";
            this.chkCambioPasta.Size = new System.Drawing.Size(145, 19);
            this.chkCambioPasta.TabIndex = 1;
            this.chkCambioPasta.Text = "Cambio Pasta Térmica";

            // 
            // chkInstalacionSoftware
            // 
            this.chkInstalacionSoftware.AutoSize = true;
            this.chkInstalacionSoftware.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkInstalacionSoftware.Location = new System.Drawing.Point(12, 50);
            this.chkInstalacionSoftware.Name = "chkInstalacionSoftware";
            this.chkInstalacionSoftware.Size = new System.Drawing.Size(140, 19);
            this.chkInstalacionSoftware.TabIndex = 2;
            this.chkInstalacionSoftware.Text = "Instalación Software";

            // 
            // chkRespaldoDatos
            // 
            this.chkRespaldoDatos.AutoSize = true;
            this.chkRespaldoDatos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRespaldoDatos.Location = new System.Drawing.Point(200, 50);
            this.chkRespaldoDatos.Name = "chkRespaldoDatos";
            this.chkRespaldoDatos.Size = new System.Drawing.Size(145, 19);
            this.chkRespaldoDatos.TabIndex = 3;
            this.chkRespaldoDatos.Text = "Respaldo de Datos";

            // 
            // grpModalidad
            // 
            this.grpModalidad.Controls.Add(this.rdbTaller);
            this.grpModalidad.Controls.Add(this.rdbDomicilio);
            this.grpModalidad.Controls.Add(this.chkClienteFrecuente);
            this.grpModalidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.grpModalidad.Location = new System.Drawing.Point(15, 250);
            this.grpModalidad.Name = "grpModalidad";
            this.grpModalidad.Size = new System.Drawing.Size(395, 78);
            this.grpModalidad.TabIndex = 5;
            this.grpModalidad.TabStop = false;
            this.grpModalidad.Text = "Modalidad y Convenio";

            // 
            // rdbTaller
            // 
            this.rdbTaller.AutoSize = true;
            this.rdbTaller.Checked = true;
            this.rdbTaller.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdbTaller.Location = new System.Drawing.Point(12, 22);
            this.rdbTaller.Name = "rdbTaller";
            this.rdbTaller.Size = new System.Drawing.Size(130, 19);
            this.rdbTaller.TabIndex = 0;
            this.rdbTaller.TabStop = true;
            this.rdbTaller.Text = "Atención en Taller";

            // 
            // rdbDomicilio
            // 
            this.rdbDomicilio.AutoSize = true;
            this.rdbDomicilio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdbDomicilio.Location = new System.Drawing.Point(200, 22);
            this.rdbDomicilio.Name = "rdbDomicilio";
            this.rdbDomicilio.Size = new System.Drawing.Size(160, 19);
            this.rdbDomicilio.TabIndex = 1;
            this.rdbDomicilio.Text = "A Domicilio (+$4.000)";

            // 
            // chkClienteFrecuente
            // 
            this.chkClienteFrecuente.AutoSize = true;
            this.chkClienteFrecuente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkClienteFrecuente.Location = new System.Drawing.Point(12, 48);
            this.chkClienteFrecuente.Name = "chkClienteFrecuente";
            this.chkClienteFrecuente.Size = new System.Drawing.Size(215, 19);
            this.chkClienteFrecuente.TabIndex = 2;
            this.chkClienteFrecuente.Text = "Cliente Frecuente (15% Descuento)";

            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(15, 336);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(395, 34);
            this.btnCalcular.TabIndex = 6;
            this.btnCalcular.Text = "Calcular Cotización";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);

            // 
            // pnlDetallePago
            // 
            this.pnlDetallePago.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlDetallePago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetallePago.Controls.Add(this.lblSubtotalValor);
            this.pnlDetallePago.Controls.Add(this.lblDescuentoValor);
            this.pnlDetallePago.Controls.Add(this.lblDomicilioValor);
            this.pnlDetallePago.Controls.Add(this.lblIvaValor);
            this.pnlDetallePago.Controls.Add(this.lblTotalValor);
            this.pnlDetallePago.Location = new System.Drawing.Point(15, 378);
            this.pnlDetallePago.Name = "pnlDetallePago";
            this.pnlDetallePago.Size = new System.Drawing.Size(395, 145);
            this.pnlDetallePago.TabIndex = 7;

            // 
            // lblSubtotalValor
            // 
            this.lblSubtotalValor.AutoSize = true;
            this.lblSubtotalValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtotalValor.Location = new System.Drawing.Point(12, 10);
            this.lblSubtotalValor.Name = "lblSubtotalValor";
            this.lblSubtotalValor.Size = new System.Drawing.Size(145, 15);
            this.lblSubtotalValor.Text = "Subtotal Servicio: 0 CLP";

            // 
            // lblDescuentoValor
            // 
            this.lblDescuentoValor.AutoSize = true;
            this.lblDescuentoValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescuentoValor.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblDescuentoValor.Location = new System.Drawing.Point(12, 34);
            this.lblDescuentoValor.Name = "lblDescuentoValor";
            this.lblDescuentoValor.Size = new System.Drawing.Size(140, 15);
            this.lblDescuentoValor.Text = "Descuento (15%): 0 CLP";

            // 
            // lblDomicilioValor
            // 
            this.lblDomicilioValor.AutoSize = true;
            this.lblDomicilioValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDomicilioValor.Location = new System.Drawing.Point(12, 58);
            this.lblDomicilioValor.Name = "lblDomicilioValor";
            this.lblDomicilioValor.Size = new System.Drawing.Size(145, 15);
            this.lblDomicilioValor.Text = "Recargo Domicilio: 0 CLP";

            // 
            // lblIvaValor
            // 
            this.lblIvaValor.AutoSize = true;
            this.lblIvaValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIvaValor.Location = new System.Drawing.Point(12, 82);
            this.lblIvaValor.Name = "lblIvaValor";
            this.lblIvaValor.Size = new System.Drawing.Size(110, 15);
            this.lblIvaValor.Text = "IVA (19%): 0 CLP";

            // 
            // lblTotalValor
            // 
            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTotalValor.Location = new System.Drawing.Point(12, 110);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(185, 20);
            this.lblTotalValor.Text = "TOTAL A PAGAR: 0 CLP";

            // 
            // btnGuardarSQL
            // 
            this.btnGuardarSQL.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnGuardarSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarSQL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarSQL.ForeColor = System.Drawing.Color.White;
            this.btnGuardarSQL.Location = new System.Drawing.Point(15, 533);
            this.btnGuardarSQL.Name = "btnGuardarSQL";
            this.btnGuardarSQL.Size = new System.Drawing.Size(192, 36);
            this.btnGuardarSQL.TabIndex = 8;
            this.btnGuardarSQL.Text = "Guardar en SQL";
            this.btnGuardarSQL.UseVisualStyleBackColor = false;
            this.btnGuardarSQL.Click += new System.EventHandler(this.btnGuardarSQL_Click);

            // 
            // btnModificarSQL
            // 
            this.btnModificarSQL.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.btnModificarSQL.Enabled = false;
            this.btnModificarSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarSQL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarSQL.ForeColor = System.Drawing.Color.White;
            this.btnModificarSQL.Location = new System.Drawing.Point(218, 533);
            this.btnModificarSQL.Name = "btnModificarSQL";
            this.btnModificarSQL.Size = new System.Drawing.Size(192, 36);
            this.btnModificarSQL.TabIndex = 9;
            this.btnModificarSQL.Text = "Modificar en SQL";
            this.btnModificarSQL.UseVisualStyleBackColor = false;
            this.btnModificarSQL.Click += new System.EventHandler(this.btnModificarSQL_Click);

            // 
            // btnEliminarSQL
            // 
            this.btnEliminarSQL.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnEliminarSQL.Enabled = false;
            this.btnEliminarSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarSQL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarSQL.ForeColor = System.Drawing.Color.White;
            this.btnEliminarSQL.Location = new System.Drawing.Point(15, 576);
            this.btnEliminarSQL.Name = "btnEliminarSQL";
            this.btnEliminarSQL.Size = new System.Drawing.Size(192, 36);
            this.btnEliminarSQL.TabIndex = 10;
            this.btnEliminarSQL.Text = "Eliminar de SQL";
            this.btnEliminarSQL.UseVisualStyleBackColor = false;
            this.btnEliminarSQL.Click += new System.EventHandler(this.btnEliminarSQL_Click);

            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(218, 576);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(192, 36);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Nueva Orden / Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // 
            // grpHistorial
            // 
            this.grpHistorial.Controls.Add(this.lblBuscar);
            this.grpHistorial.Controls.Add(this.txtBuscarCliente);
            this.grpHistorial.Controls.Add(this.dgvOrdenes);
            this.grpHistorial.Controls.Add(this.pnlMetricas);
            this.grpHistorial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpHistorial.Location = new System.Drawing.Point(460, 55);
            this.grpHistorial.Name = "grpHistorial";
            this.grpHistorial.Size = new System.Drawing.Size(685, 625);
            this.grpHistorial.TabIndex = 2;
            this.grpHistorial.TabStop = false;
            this.grpHistorial.Text = "Historial de Órdenes Registradas";

            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(15, 30);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(120, 15);
            this.lblBuscar.Text = "Buscar por Cliente:";

            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarCliente.Location = new System.Drawing.Point(140, 26);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(530, 24);
            this.txtBuscarCliente.TabIndex = 0;
            this.txtBuscarCliente.TextChanged += new System.EventHandler(this.txtBuscarCliente_TextChanged);

            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenes.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(15, 62);
            this.dgvOrdenes.MultiSelect = false;
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.RowHeadersVisible = false;
            this.dgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.Size = new System.Drawing.Size(655, 460);
            this.dgvOrdenes.TabIndex = 1;
            this.dgvOrdenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenes_CellClick);

            // 
            // pnlMetricas
            // 
            this.pnlMetricas.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlMetricas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMetricas.Controls.Add(this.lblTitRecaudado);
            this.pnlMetricas.Controls.Add(this.lblTotalRecaudado);
            this.pnlMetricas.Controls.Add(this.lblTitCantidad);
            this.pnlMetricas.Controls.Add(this.lblCantidadOrdenes);
            this.pnlMetricas.Controls.Add(this.lblTitPromedio);
            this.pnlMetricas.Controls.Add(this.lblPromedioVenta);
            this.pnlMetricas.Location = new System.Drawing.Point(15, 532);
            this.pnlMetricas.Name = "pnlMetricas";
            this.pnlMetricas.Size = new System.Drawing.Size(655, 80);
            this.pnlMetricas.TabIndex = 2;

            // 
            // lblTitRecaudado
            // 
            this.lblTitRecaudado.AutoSize = true;
            this.lblTitRecaudado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTitRecaudado.Location = new System.Drawing.Point(20, 15);
            this.lblTitRecaudado.Name = "lblTitRecaudado";
            this.lblTitRecaudado.Size = new System.Drawing.Size(110, 15);
            this.lblTitRecaudado.Text = "TOTAL RECAUDADO";

            // 
            // lblTotalRecaudado
            // 
            this.lblTotalRecaudado.AutoSize = true;
            this.lblTotalRecaudado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecaudado.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblTotalRecaudado.Location = new System.Drawing.Point(20, 38);
            this.lblTotalRecaudado.Name = "lblTotalRecaudado";
            this.lblTotalRecaudado.Size = new System.Drawing.Size(75, 21);
            this.lblTotalRecaudado.Text = "$ 0 CLP";

            // 
            // lblTitCantidad
            // 
            this.lblTitCantidad.AutoSize = true;
            this.lblTitCantidad.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTitCantidad.Location = new System.Drawing.Point(250, 15);
            this.lblTitCantidad.Name = "lblTitCantidad";
            this.lblTitCantidad.Size = new System.Drawing.Size(120, 15);
            this.lblTitCantidad.Text = "ÓRDENES EN PANTALLA";

            // 
            // lblCantidadOrdenes
            // 
            this.lblCantidadOrdenes.AutoSize = true;
            this.lblCantidadOrdenes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCantidadOrdenes.Location = new System.Drawing.Point(250, 38);
            this.lblCantidadOrdenes.Name = "lblCantidadOrdenes";
            this.lblCantidadOrdenes.Size = new System.Drawing.Size(95, 21);
            this.lblCantidadOrdenes.Text = "0 orden(es)";

            // 
            // lblTitPromedio
            // 
            this.lblTitPromedio.AutoSize = true;
            this.lblTitPromedio.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTitPromedio.Location = new System.Drawing.Point(470, 15);
            this.lblTitPromedio.Name = "lblTitPromedio";
            this.lblTitPromedio.Size = new System.Drawing.Size(115, 15);
            this.lblTitPromedio.Text = "PROMEDIO POR ORDEN";

            // 
            // lblPromedioVenta
            // 
            this.lblPromedioVenta.AutoSize = true;
            this.lblPromedioVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPromedioVenta.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblPromedioVenta.Location = new System.Drawing.Point(470, 38);
            this.lblPromedioVenta.Name = "lblPromedioVenta";
            this.lblPromedioVenta.Size = new System.Drawing.Size(75, 21);
            this.lblPromedioVenta.Text = "$ 0 CLP";

            // 
            // FormOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 700);
            this.Controls.Add(this.grpHistorial);
            this.Controls.Add(this.grpIngreso);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormOrdenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TechRepair - Gestión de Órdenes (Ensayo Certamen CRUD)";
            this.Load += new System.EventHandler(this.FormOrdenes_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpIngreso.ResumeLayout(false);
            this.grpIngreso.PerformLayout();
            this.grpAdicionales.ResumeLayout(false);
            this.grpAdicionales.PerformLayout();
            this.grpModalidad.ResumeLayout(false);
            this.grpModalidad.PerformLayout();
            this.pnlDetallePago.ResumeLayout(false);
            this.pnlDetallePago.PerformLayout();
            this.grpHistorial.ResumeLayout(false);
            this.grpHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.pnlMetricas.ResumeLayout(false);
            this.pnlMetricas.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstadoConexion;
        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.GroupBox grpIngreso;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTipoEquipo;
        private System.Windows.Forms.ComboBox cboTipoEquipo;
        private System.Windows.Forms.Label lblServicioBase;
        private System.Windows.Forms.ComboBox cboServicioBase;
        private System.Windows.Forms.GroupBox grpAdicionales;
        private System.Windows.Forms.CheckBox chkLimpiezaProfunda;
        private System.Windows.Forms.CheckBox chkCambioPasta;
        private System.Windows.Forms.CheckBox chkInstalacionSoftware;
        private System.Windows.Forms.CheckBox chkRespaldoDatos;
        private System.Windows.Forms.GroupBox grpModalidad;
        private System.Windows.Forms.RadioButton rdbTaller;
        private System.Windows.Forms.RadioButton rdbDomicilio;
        private System.Windows.Forms.CheckBox chkClienteFrecuente;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Panel pnlDetallePago;
        private System.Windows.Forms.Label lblSubtotalValor;
        private System.Windows.Forms.Label lblDescuentoValor;
        private System.Windows.Forms.Label lblDomicilioValor;
        private System.Windows.Forms.Label lblIvaValor;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Button btnGuardarSQL;
        private System.Windows.Forms.Button btnModificarSQL;
        private System.Windows.Forms.Button btnEliminarSQL;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox grpHistorial;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.Panel pnlMetricas;
        private System.Windows.Forms.Label lblTitRecaudado;
        private System.Windows.Forms.Label lblTotalRecaudado;
        private System.Windows.Forms.Label lblTitCantidad;
        private System.Windows.Forms.Label lblCantidadOrdenes;
        private System.Windows.Forms.Label lblTitPromedio;
        private System.Windows.Forms.Label lblPromedioVenta;
    }
}