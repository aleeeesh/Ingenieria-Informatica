namespace GanaderaChan.Presentacion
{
    partial class FormVentas
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            grpCliente = new GroupBox();
            txtRut = new TextBox();
            lblCliente = new Label();
            txtCliente = new TextBox();
            lblRut = new Label();
            grpDetalle = new GroupBox();
            txtCantidad = new TextBox();
            lblCategoria = new Label();
            cboCategoria = new ComboBox();
            lblCantidad = new Label();
            grpFormaPago = new GroupBox();
            rdbEfectivo = new RadioButton();
            rdbTransferencia = new RadioButton();
            grpAcciones = new GroupBox();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            grpHistorial = new GroupBox();
            lstVentas = new ListBox();
            lblTotalRecaudadoTitle = new Label();
            lblTotalRecaudado = new Label();
            lblTotalChanchitosTitle = new Label();
            lblTotalChanchitos = new Label();
            lblCantidadVentasTitle = new Label();
            lblCantidadVentas = new Label();
            grpCliente.SuspendLayout();
            grpDetalle.SuspendLayout();
            grpFormaPago.SuspendLayout();
            grpAcciones.SuspendLayout();
            grpHistorial.SuspendLayout();
            SuspendLayout();
            // 
            // grpCliente
            // 
            grpCliente.Controls.Add(txtRut);
            grpCliente.Controls.Add(lblCliente);
            grpCliente.Controls.Add(txtCliente);
            grpCliente.Controls.Add(lblRut);
            grpCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpCliente.Location = new Point(12, 12);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(420, 95);
            grpCliente.TabIndex = 0;
            grpCliente.TabStop = false;
            grpCliente.Text = "Datos del Cliente";
            // 
            // txtRut
            // 
            txtRut.Font = new Font("Segoe UI", 9F);
            txtRut.Location = new Point(150, 57);
            txtRut.Name = "txtRut";
            txtRut.Size = new Size(255, 23);
            txtRut.TabIndex = 3;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 9F);
            lblCliente.Location = new Point(15, 28);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(94, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Nombre Cliente:";
            // 
            // txtCliente
            // 
            txtCliente.Font = new Font("Segoe UI", 9F);
            txtCliente.Location = new Point(150, 25);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(255, 23);
            txtCliente.TabIndex = 1;
            // 
            // lblRut
            // 
            lblRut.AutoSize = true;
            lblRut.Font = new Font("Segoe UI", 9F);
            lblRut.Location = new Point(15, 60);
            lblRut.Name = "lblRut";
            lblRut.Size = new Size(72, 15);
            lblRut.TabIndex = 2;
            lblRut.Text = "RUT Cliente:";
            // 
            // grpDetalle
            // 
            grpDetalle.Controls.Add(txtCantidad);
            grpDetalle.Controls.Add(lblCategoria);
            grpDetalle.Controls.Add(cboCategoria);
            grpDetalle.Controls.Add(lblCantidad);
            grpDetalle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpDetalle.Location = new Point(12, 115);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Size = new Size(420, 95);
            grpDetalle.TabIndex = 3;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Detalle de la Venta de Ganado";
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Segoe UI", 9F);
            txtCantidad.Location = new Point(150, 57);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(255, 23);
            txtCantidad.TabIndex = 4;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9F);
            lblCategoria.Location = new Point(15, 28);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(96, 15);
            lblCategoria.TabIndex = 0;
            lblCategoria.Text = "Categoría Cerdo:";
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.Font = new Font("Segoe UI", 9F);
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(150, 25);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(255, 23);
            cboCategoria.TabIndex = 4;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F);
            lblCantidad.Location = new Point(15, 60);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(101, 15);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cant. Chanchitos:";
            // 
            // grpFormaPago
            // 
            grpFormaPago.Controls.Add(rdbEfectivo);
            grpFormaPago.Controls.Add(rdbTransferencia);
            grpFormaPago.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpFormaPago.Location = new Point(12, 218);
            grpFormaPago.Name = "grpFormaPago";
            grpFormaPago.Size = new Size(420, 60);
            grpFormaPago.TabIndex = 6;
            grpFormaPago.TabStop = false;
            grpFormaPago.Text = "Forma de Pago";
            // 
            // rdbEfectivo
            // 
            rdbEfectivo.AutoSize = true;
            rdbEfectivo.Checked = true;
            rdbEfectivo.Font = new Font("Segoe UI", 9F);
            rdbEfectivo.Location = new Point(30, 25);
            rdbEfectivo.Name = "rdbEfectivo";
            rdbEfectivo.Size = new Size(124, 19);
            rdbEfectivo.TabIndex = 7;
            rdbEfectivo.TabStop = true;
            rdbEfectivo.Text = "Efectivo / Contado";
            // 
            // rdbTransferencia
            // 
            rdbTransferencia.AutoSize = true;
            rdbTransferencia.Font = new Font("Segoe UI", 9F);
            rdbTransferencia.Location = new Point(200, 25);
            rdbTransferencia.Name = "rdbTransferencia";
            rdbTransferencia.Size = new Size(143, 19);
            rdbTransferencia.TabIndex = 8;
            rdbTransferencia.Text = "Transferencia Bancaria";
            // 
            // grpAcciones
            // 
            grpAcciones.Controls.Add(btnRegistrar);
            grpAcciones.Controls.Add(btnLimpiar);
            grpAcciones.Controls.Add(btnSalir);
            grpAcciones.Location = new Point(12, 285);
            grpAcciones.Name = "grpAcciones";
            grpAcciones.Size = new Size(420, 65);
            grpAcciones.TabIndex = 9;
            grpAcciones.TabStop = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(0, 47, 108);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(15, 18);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(125, 35);
            btnRegistrar.TabIndex = 10;
            btnRegistrar.Text = "Registrar Venta";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 9F);
            btnLimpiar.Location = new Point(150, 18);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 35);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 9F);
            btnSalir.Location = new Point(280, 18);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(125, 35);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "Salir del Sistema";
            btnSalir.Click += btnSalir_Click;
            // 
            // grpHistorial
            // 
            grpHistorial.Controls.Add(lstVentas);
            grpHistorial.Controls.Add(lblTotalRecaudadoTitle);
            grpHistorial.Controls.Add(lblTotalRecaudado);
            grpHistorial.Controls.Add(lblTotalChanchitosTitle);
            grpHistorial.Controls.Add(lblTotalChanchitos);
            grpHistorial.Controls.Add(lblCantidadVentasTitle);
            grpHistorial.Controls.Add(lblCantidadVentas);
            grpHistorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpHistorial.Location = new Point(445, 12);
            grpHistorial.Name = "grpHistorial";
            grpHistorial.Size = new Size(430, 338);
            grpHistorial.TabIndex = 13;
            grpHistorial.TabStop = false;
            grpHistorial.Text = "Historial de Ventas Almacenadas (Lista VENTAS)";
            // 
            // lstVentas
            // 
            lstVentas.Font = new Font("Segoe UI", 8.5F);
            lstVentas.FormattingEnabled = true;
            lstVentas.HorizontalScrollbar = true;
            lstVentas.Location = new Point(15, 25);
            lstVentas.Name = "lstVentas";
            lstVentas.ScrollAlwaysVisible = true;
            lstVentas.Size = new Size(400, 212);
            lstVentas.TabIndex = 14;
            // 
            // lblTotalRecaudadoTitle
            // 
            lblTotalRecaudadoTitle.AutoSize = true;
            lblTotalRecaudadoTitle.Font = new Font("Segoe UI", 9F);
            lblTotalRecaudadoTitle.Location = new Point(15, 250);
            lblTotalRecaudadoTitle.Name = "lblTotalRecaudadoTitle";
            lblTotalRecaudadoTitle.Size = new Size(130, 15);
            lblTotalRecaudadoTitle.TabIndex = 15;
            lblTotalRecaudadoTitle.Text = "Total Recaudado (CLP):";
            // 
            // lblTotalRecaudado
            // 
            lblTotalRecaudado.AutoSize = true;
            lblTotalRecaudado.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTotalRecaudado.ForeColor = Color.FromArgb(0, 47, 108);
            lblTotalRecaudado.Location = new Point(150, 249);
            lblTotalRecaudado.Name = "lblTotalRecaudado";
            lblTotalRecaudado.Size = new Size(53, 17);
            lblTotalRecaudado.TabIndex = 16;
            lblTotalRecaudado.Text = "$ 0 CLP";
            // 
            // lblTotalChanchitosTitle
            // 
            lblTotalChanchitosTitle.AutoSize = true;
            lblTotalChanchitosTitle.Font = new Font("Segoe UI", 9F);
            lblTotalChanchitosTitle.Location = new Point(15, 275);
            lblTotalChanchitosTitle.Name = "lblTotalChanchitosTitle";
            lblTotalChanchitosTitle.Size = new Size(121, 15);
            lblTotalChanchitosTitle.TabIndex = 17;
            lblTotalChanchitosTitle.Text = "Chanchitos Vendidos:";
            // 
            // lblTotalChanchitos
            // 
            lblTotalChanchitos.AutoSize = true;
            lblTotalChanchitos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalChanchitos.Location = new Point(150, 275);
            lblTotalChanchitos.Name = "lblTotalChanchitos";
            lblTotalChanchitos.Size = new Size(74, 15);
            lblTotalChanchitos.TabIndex = 18;
            lblTotalChanchitos.Text = "0 unidad(es)";
            // 
            // lblCantidadVentasTitle
            // 
            lblCantidadVentasTitle.AutoSize = true;
            lblCantidadVentasTitle.Font = new Font("Segoe UI", 9F);
            lblCantidadVentasTitle.Location = new Point(15, 300);
            lblCantidadVentasTitle.Name = "lblCantidadVentasTitle";
            lblCantidadVentasTitle.Size = new Size(147, 15);
            lblCantidadVentasTitle.TabIndex = 19;
            lblCantidadVentasTitle.Text = "Transacciones Registradas:";
            // 
            // lblCantidadVentas
            // 
            lblCantidadVentas.AutoSize = true;
            lblCantidadVentas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidadVentas.Location = new Point(168, 300);
            lblCantidadVentas.Name = "lblCantidadVentas";
            lblCantidadVentas.Size = new Size(74, 15);
            lblCantidadVentas.TabIndex = 20;
            lblCantidadVentas.Text = "0 registro(s)";
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 362);
            Controls.Add(grpCliente);
            Controls.Add(grpDetalle);
            Controls.Add(grpFormaPago);
            Controls.Add(grpAcciones);
            Controls.Add(grpHistorial);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ganadera Chan - Sistema de Control y Registro de Ventas de Ganado";
            Load += FormVentas_Load;
            grpCliente.ResumeLayout(false);
            grpCliente.PerformLayout();
            grpDetalle.ResumeLayout(false);
            grpDetalle.PerformLayout();
            grpFormaPago.ResumeLayout(false);
            grpFormaPago.PerformLayout();
            grpAcciones.ResumeLayout(false);
            grpHistorial.ResumeLayout(false);
            grpHistorial.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblRut;

        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblCantidad;

        private System.Windows.Forms.GroupBox grpFormaPago;
        private System.Windows.Forms.RadioButton rdbEfectivo;
        private System.Windows.Forms.RadioButton rdbTransferencia;

        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;

        private System.Windows.Forms.GroupBox grpHistorial;
        private System.Windows.Forms.ListBox lstVentas;
        private System.Windows.Forms.Label lblTotalRecaudadoTitle;
        private System.Windows.Forms.Label lblTotalRecaudado;
        private System.Windows.Forms.Label lblTotalChanchitosTitle;
        private System.Windows.Forms.Label lblTotalChanchitos;
        private System.Windows.Forms.Label lblCantidadVentasTitle;
        private System.Windows.Forms.Label lblCantidadVentas;
        private TextBox txtRut;
        private TextBox txtCantidad;
    }
}
