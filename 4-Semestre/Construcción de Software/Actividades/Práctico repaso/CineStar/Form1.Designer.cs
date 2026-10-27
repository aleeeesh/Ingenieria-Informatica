namespace CineStar.Presentacion
{
    partial class FormCine
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

        private void InitializeComponent()
        {
            grpCliente = new GroupBox();
            lblCliente = new Label();
            txtCliente = new TextBox();
            lblRut = new Label();
            txtRut = new TextBox();
            chkSocio = new CheckBox();
            grpEntradas = new GroupBox();
            lblPelicula = new Label();
            cboPelicula = new ComboBox();
            lblCantidad = new Label();
            txtCantidad = new TextBox();
            grpSnacks = new GroupBox();
            lblSnack = new Label();
            cboSnack = new ComboBox();
            grpAcciones = new GroupBox();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            grpHistorial = new GroupBox();
            lstVentas = new ListBox();
            lblTotalRecaudado = new Label();
            lblTotalEntradas = new Label();
            lblCantidadVentas = new Label();
            grpCliente.SuspendLayout();
            grpEntradas.SuspendLayout();
            grpSnacks.SuspendLayout();
            grpAcciones.SuspendLayout();
            grpHistorial.SuspendLayout();
            SuspendLayout();
            // 
            // grpCliente
            // 
            grpCliente.Controls.Add(lblCliente);
            grpCliente.Controls.Add(txtCliente);
            grpCliente.Controls.Add(lblRut);
            grpCliente.Controls.Add(txtRut);
            grpCliente.Controls.Add(chkSocio);
            grpCliente.Location = new Point(12, 12);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(420, 100);
            grpCliente.TabIndex = 0;
            grpCliente.TabStop = false;
            grpCliente.Text = "Datos del Cliente";
            // 
            // lblCliente
            // 
            lblCliente.Location = new Point(15, 25);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(64, 23);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Nombre:";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(85, 22);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(315, 27);
            txtCliente.TabIndex = 1;
            // 
            // lblRut
            // 
            lblRut.Location = new Point(38, 60);
            lblRut.Name = "lblRut";
            lblRut.Size = new Size(41, 23);
            lblRut.TabIndex = 2;
            lblRut.Text = "RUT:";
            // 
            // txtRut
            // 
            txtRut.Location = new Point(85, 57);
            txtRut.Name = "txtRut";
            txtRut.Size = new Size(150, 27);
            txtRut.TabIndex = 3;
            // 
            // chkSocio
            // 
            chkSocio.Location = new Point(267, 60);
            chkSocio.Name = "chkSocio";
            chkSocio.Size = new Size(133, 24);
            chkSocio.TabIndex = 4;
            chkSocio.Text = "Socio CineClub (15% Desc.)";
            // 
            // grpEntradas
            // 
            grpEntradas.Controls.Add(lblPelicula);
            grpEntradas.Controls.Add(cboPelicula);
            grpEntradas.Controls.Add(lblCantidad);
            grpEntradas.Controls.Add(txtCantidad);
            grpEntradas.Location = new Point(12, 120);
            grpEntradas.Name = "grpEntradas";
            grpEntradas.Size = new Size(420, 95);
            grpEntradas.TabIndex = 1;
            grpEntradas.TabStop = false;
            grpEntradas.Text = "Selección de Entradas y Película";
            // 
            // lblPelicula
            // 
            lblPelicula.Location = new Point(15, 25);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(64, 23);
            lblPelicula.TabIndex = 0;
            lblPelicula.Text = "Película:";
            // 
            // cboPelicula
            // 
            cboPelicula.Location = new Point(85, 22);
            cboPelicula.Name = "cboPelicula";
            cboPelicula.Size = new Size(315, 28);
            cboPelicula.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.Location = new Point(7, 60);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(72, 23);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(85, 57);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(100, 27);
            txtCantidad.TabIndex = 3;
            // 
            // grpSnacks
            // 
            grpSnacks.Controls.Add(lblSnack);
            grpSnacks.Controls.Add(cboSnack);
            grpSnacks.Location = new Point(12, 225);
            grpSnacks.Name = "grpSnacks";
            grpSnacks.Size = new Size(420, 65);
            grpSnacks.TabIndex = 2;
            grpSnacks.TabStop = false;
            grpSnacks.Text = "Combos de Snacks (Confitería)";
            // 
            // lblSnack
            // 
            lblSnack.Location = new Point(15, 25);
            lblSnack.Name = "lblSnack";
            lblSnack.Size = new Size(64, 23);
            lblSnack.TabIndex = 0;
            lblSnack.Text = "Combo:";
            // 
            // cboSnack
            // 
            cboSnack.Location = new Point(85, 22);
            cboSnack.Name = "cboSnack";
            cboSnack.Size = new Size(315, 28);
            cboSnack.TabIndex = 1;
            // 
            // grpAcciones
            // 
            grpAcciones.Controls.Add(btnRegistrar);
            grpAcciones.Controls.Add(btnLimpiar);
            grpAcciones.Controls.Add(btnSalir);
            grpAcciones.Location = new Point(12, 300);
            grpAcciones.Name = "grpAcciones";
            grpAcciones.Size = new Size(420, 60);
            grpAcciones.TabIndex = 3;
            grpAcciones.TabStop = false;
            grpAcciones.Text = "Operaciones";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(15, 22);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(120, 30);
            btnRegistrar.TabIndex = 0;
            btnRegistrar.Text = "Procesar Venta";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(150, 22);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 30);
            btnLimpiar.TabIndex = 1;
            btnLimpiar.Text = "Limpiar Formulario";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(285, 22);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(115, 30);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            // 
            // grpHistorial
            // 
            grpHistorial.Controls.Add(lstVentas);
            grpHistorial.Controls.Add(lblTotalRecaudado);
            grpHistorial.Controls.Add(lblTotalEntradas);
            grpHistorial.Controls.Add(lblCantidadVentas);
            grpHistorial.Location = new Point(445, 12);
            grpHistorial.Name = "grpHistorial";
            grpHistorial.Size = new Size(450, 348);
            grpHistorial.TabIndex = 4;
            grpHistorial.TabStop = false;
            grpHistorial.Text = "Registro de Ventas en Lista (VENTAS) y Resumen";
            // 
            // lstVentas
            // 
            lstVentas.Location = new Point(15, 25);
            lstVentas.Name = "lstVentas";
            lstVentas.Size = new Size(420, 204);
            lstVentas.TabIndex = 0;
            // 
            // lblTotalRecaudado
            // 
            lblTotalRecaudado.Location = new Point(15, 255);
            lblTotalRecaudado.Name = "lblTotalRecaudado";
            lblTotalRecaudado.Size = new Size(420, 20);
            lblTotalRecaudado.TabIndex = 1;
            lblTotalRecaudado.Text = "Total Recaudado: $ 0 CLP";
            // 
            // lblTotalEntradas
            // 
            lblTotalEntradas.Location = new Point(15, 280);
            lblTotalEntradas.Name = "lblTotalEntradas";
            lblTotalEntradas.Size = new Size(420, 20);
            lblTotalEntradas.TabIndex = 2;
            lblTotalEntradas.Text = "Total Entradas Vendidas: 0 ticket(s)";
            // 
            // lblCantidadVentas
            // 
            lblCantidadVentas.Location = new Point(15, 305);
            lblCantidadVentas.Name = "lblCantidadVentas";
            lblCantidadVentas.Size = new Size(420, 20);
            lblCantidadVentas.TabIndex = 3;
            lblCantidadVentas.Text = "Transacciones Procesadas: 0 registro(s)";
            // 
            // FormCine
            // 
            ClientSize = new Size(910, 375);
            Controls.Add(grpCliente);
            Controls.Add(grpEntradas);
            Controls.Add(grpSnacks);
            Controls.Add(grpAcciones);
            Controls.Add(grpHistorial);
            Name = "FormCine";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CineStar - Sistema de Venta de Entradas y Snacks";
            Load += FormCine_Load;
            grpCliente.ResumeLayout(false);
            grpCliente.PerformLayout();
            grpEntradas.ResumeLayout(false);
            grpEntradas.PerformLayout();
            grpSnacks.ResumeLayout(false);
            grpAcciones.ResumeLayout(false);
            grpHistorial.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblRut;
        private System.Windows.Forms.TextBox txtRut;
        private System.Windows.Forms.CheckBox chkSocio;

        private System.Windows.Forms.GroupBox grpEntradas;
        private System.Windows.Forms.Label lblPelicula;
        private System.Windows.Forms.ComboBox cboPelicula;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;

        private System.Windows.Forms.GroupBox grpSnacks;
        private System.Windows.Forms.Label lblSnack;
        private System.Windows.Forms.ComboBox cboSnack;

        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;

        private System.Windows.Forms.GroupBox grpHistorial;
        private System.Windows.Forms.ListBox lstVentas;
        private System.Windows.Forms.Label lblTotalRecaudado;
        private System.Windows.Forms.Label lblTotalEntradas;
        private System.Windows.Forms.Label lblCantidadVentas;
    }
}