namespace PizzeriaBellaItalia
{
    partial class FormPizzeriaCRUD
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPizzeriaCRUD));
            grpCliente = new GroupBox();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtCliente = new TextBox();
            lblCliente = new Label();
            grpIngredientes = new GroupBox();
            chkTocino = new CheckBox();
            chkChampinones = new CheckBox();
            chkPepperoni = new CheckBox();
            chkAceitunas = new CheckBox();
            chkQuesoExtra = new CheckBox();
            grpDetalles = new GroupBox();
            txtTotalValor = new Label();
            txtIvaValor = new Label();
            txtDeliveryValor = new Label();
            txtDescuentoValor = new Label();
            txtSubtotalValor = new Label();
            lblTotalValor = new Label();
            lblSeparador = new Label();
            lblIvaValor = new Label();
            lblDeliveryValor = new Label();
            lblDescuentoValor = new Label();
            lblSubtotalValor = new Label();
            rdbDelivery = new RadioButton();
            grpEntrega = new GroupBox();
            chkConvenioEstudiante = new CheckBox();
            rdbRetiro = new RadioButton();
            grpPizza = new GroupBox();
            lblMasa = new Label();
            cboMasa = new ComboBox();
            lblTamano = new Label();
            cboTamano = new ComboBox();
            btnCalcular = new Button();
            btnLimpiar = new Button();
            grpHistorial = new GroupBox();
            dgvPedidos = new DataGridView();
            txtPromedioVenta = new Label();
            lblPromedioVenta = new Label();
            txtCantidadPedidos = new Label();
            lblCantidadPedidos = new Label();
            txtRecaudacionTotal = new Label();
            lblRecaudacionTotal = new Label();
            pedidoPizzaBindingSource = new BindingSource(components);
            lblEstadoConexion = new Label();
            label1 = new Label();
            grpCliente.SuspendLayout();
            grpIngredientes.SuspendLayout();
            grpDetalles.SuspendLayout();
            grpEntrega.SuspendLayout();
            grpPizza.SuspendLayout();
            grpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pedidoPizzaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // grpCliente
            // 
            grpCliente.Controls.Add(txtTelefono);
            grpCliente.Controls.Add(lblTelefono);
            grpCliente.Controls.Add(txtCliente);
            grpCliente.Controls.Add(lblCliente);
            grpCliente.Location = new Point(12, 12);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(405, 90);
            grpCliente.TabIndex = 0;
            grpCliente.TabStop = false;
            grpCliente.Text = "Datos del Cliente";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(270, 33);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(130, 23);
            txtTelefono.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(204, 35);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(55, 15);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(69, 33);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(130, 23);
            txtCliente.TabIndex = 0;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(5, 35);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(54, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Nombre:";
            // 
            // grpIngredientes
            // 
            grpIngredientes.Controls.Add(chkTocino);
            grpIngredientes.Controls.Add(chkChampinones);
            grpIngredientes.Controls.Add(chkPepperoni);
            grpIngredientes.Controls.Add(chkAceitunas);
            grpIngredientes.Controls.Add(chkQuesoExtra);
            grpIngredientes.Location = new Point(433, 12);
            grpIngredientes.Name = "grpIngredientes";
            grpIngredientes.Size = new Size(306, 90);
            grpIngredientes.TabIndex = 2;
            grpIngredientes.TabStop = false;
            grpIngredientes.Text = "Adicionales ($800 c/u)";
            // 
            // chkTocino
            // 
            chkTocino.AutoSize = true;
            chkTocino.Location = new Point(108, 45);
            chkTocino.Name = "chkTocino";
            chkTocino.Size = new Size(61, 19);
            chkTocino.TabIndex = 9;
            chkTocino.Text = "Tocino";
            chkTocino.UseVisualStyleBackColor = true;
            // 
            // chkChampinones
            // 
            chkChampinones.AutoSize = true;
            chkChampinones.Location = new Point(200, 22);
            chkChampinones.Name = "chkChampinones";
            chkChampinones.Size = new Size(100, 19);
            chkChampinones.TabIndex = 7;
            chkChampinones.Text = "Champiñones";
            chkChampinones.UseVisualStyleBackColor = true;
            // 
            // chkPepperoni
            // 
            chkPepperoni.AutoSize = true;
            chkPepperoni.Location = new Point(108, 22);
            chkPepperoni.Name = "chkPepperoni";
            chkPepperoni.Size = new Size(80, 19);
            chkPepperoni.TabIndex = 6;
            chkPepperoni.Text = "Pepperoni";
            chkPepperoni.UseVisualStyleBackColor = true;
            // 
            // chkAceitunas
            // 
            chkAceitunas.AutoSize = true;
            chkAceitunas.Location = new Point(7, 45);
            chkAceitunas.Name = "chkAceitunas";
            chkAceitunas.Size = new Size(78, 19);
            chkAceitunas.TabIndex = 8;
            chkAceitunas.Text = "Aceitunas";
            chkAceitunas.UseVisualStyleBackColor = true;
            // 
            // chkQuesoExtra
            // 
            chkQuesoExtra.AutoSize = true;
            chkQuesoExtra.Location = new Point(7, 21);
            chkQuesoExtra.Name = "chkQuesoExtra";
            chkQuesoExtra.Size = new Size(89, 19);
            chkQuesoExtra.TabIndex = 5;
            chkQuesoExtra.Text = "Queso extra";
            chkQuesoExtra.UseVisualStyleBackColor = true;
            // 
            // grpDetalles
            // 
            grpDetalles.Controls.Add(txtTotalValor);
            grpDetalles.Controls.Add(txtIvaValor);
            grpDetalles.Controls.Add(txtDeliveryValor);
            grpDetalles.Controls.Add(txtDescuentoValor);
            grpDetalles.Controls.Add(txtSubtotalValor);
            grpDetalles.Controls.Add(lblTotalValor);
            grpDetalles.Controls.Add(lblSeparador);
            grpDetalles.Controls.Add(lblIvaValor);
            grpDetalles.Controls.Add(lblDeliveryValor);
            grpDetalles.Controls.Add(lblDescuentoValor);
            grpDetalles.Controls.Add(lblSubtotalValor);
            grpDetalles.Location = new Point(11, 246);
            grpDetalles.Name = "grpDetalles";
            grpDetalles.Size = new Size(330, 223);
            grpDetalles.TabIndex = 4;
            grpDetalles.TabStop = false;
            grpDetalles.Text = "Detalle de Pago";
            // 
            // txtTotalValor
            // 
            txtTotalValor.AutoSize = true;
            txtTotalValor.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtTotalValor.ForeColor = Color.DarkGreen;
            txtTotalValor.Location = new Point(172, 131);
            txtTotalValor.Name = "txtTotalValor";
            txtTotalValor.Size = new Size(57, 20);
            txtTotalValor.TabIndex = 10;
            txtTotalValor.Text = "$0 CLP";
            txtTotalValor.TextAlign = ContentAlignment.TopRight;
            // 
            // txtIvaValor
            // 
            txtIvaValor.AutoSize = true;
            txtIvaValor.Location = new Point(172, 91);
            txtIvaValor.Name = "txtIvaValor";
            txtIvaValor.Size = new Size(43, 15);
            txtIvaValor.TabIndex = 9;
            txtIvaValor.Text = "$0 CLP";
            // 
            // txtDeliveryValor
            // 
            txtDeliveryValor.AutoSize = true;
            txtDeliveryValor.Location = new Point(172, 71);
            txtDeliveryValor.Name = "txtDeliveryValor";
            txtDeliveryValor.Size = new Size(43, 15);
            txtDeliveryValor.TabIndex = 8;
            txtDeliveryValor.Text = "$0 CLP";
            // 
            // txtDescuentoValor
            // 
            txtDescuentoValor.AutoSize = true;
            txtDescuentoValor.ForeColor = SystemColors.ControlText;
            txtDescuentoValor.Location = new Point(172, 52);
            txtDescuentoValor.Name = "txtDescuentoValor";
            txtDescuentoValor.Size = new Size(43, 15);
            txtDescuentoValor.TabIndex = 7;
            txtDescuentoValor.Text = "$0 CLP";
            txtDescuentoValor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSubtotalValor
            // 
            txtSubtotalValor.AutoSize = true;
            txtSubtotalValor.Location = new Point(172, 32);
            txtSubtotalValor.Name = "txtSubtotalValor";
            txtSubtotalValor.Size = new Size(43, 15);
            txtSubtotalValor.TabIndex = 6;
            txtSubtotalValor.Text = "$0 CLP";
            txtSubtotalValor.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTotalValor
            // 
            lblTotalValor.AutoSize = true;
            lblTotalValor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalValor.ForeColor = Color.DarkGreen;
            lblTotalValor.Location = new Point(10, 131);
            lblTotalValor.Name = "lblTotalValor";
            lblTotalValor.Size = new Size(131, 21);
            lblTotalValor.TabIndex = 5;
            lblTotalValor.Text = "TOTAL A PAGAR:";
            // 
            // lblSeparador
            // 
            lblSeparador.AutoSize = true;
            lblSeparador.Location = new Point(9, 107);
            lblSeparador.Name = "lblSeparador";
            lblSeparador.Size = new Size(222, 15);
            lblSeparador.TabIndex = 4;
            lblSeparador.Text = "___________________________________________";
            // 
            // lblIvaValor
            // 
            lblIvaValor.AutoSize = true;
            lblIvaValor.Location = new Point(9, 91);
            lblIvaValor.Name = "lblIvaValor";
            lblIvaValor.Size = new Size(104, 15);
            lblIvaValor.TabIndex = 3;
            lblIvaValor.Text = "IVA Chileno (19%):";
            // 
            // lblDeliveryValor
            // 
            lblDeliveryValor.AutoSize = true;
            lblDeliveryValor.Location = new Point(13, 71);
            lblDeliveryValor.Name = "lblDeliveryValor";
            lblDeliveryValor.Size = new Size(98, 15);
            lblDeliveryValor.TabIndex = 2;
            lblDeliveryValor.Text = "Recargo Delivery:";
            // 
            // lblDescuentoValor
            // 
            lblDescuentoValor.AutoSize = true;
            lblDescuentoValor.Location = new Point(14, 52);
            lblDescuentoValor.Name = "lblDescuentoValor";
            lblDescuentoValor.Size = new Size(99, 15);
            lblDescuentoValor.TabIndex = 1;
            lblDescuentoValor.Text = "Descuento (10%):";
            // 
            // lblSubtotalValor
            // 
            lblSubtotalValor.AutoSize = true;
            lblSubtotalValor.Location = new Point(30, 32);
            lblSubtotalValor.Name = "lblSubtotalValor";
            lblSubtotalValor.Size = new Size(83, 15);
            lblSubtotalValor.TabIndex = 0;
            lblSubtotalValor.Text = "Subtotal Pizza:";
            // 
            // rdbDelivery
            // 
            rdbDelivery.AutoSize = true;
            rdbDelivery.Location = new Point(147, 23);
            rdbDelivery.Name = "rdbDelivery";
            rdbDelivery.Size = new Size(119, 19);
            rdbDelivery.TabIndex = 10;
            rdbDelivery.TabStop = true;
            rdbDelivery.Text = "Delivery (+$2.000)";
            rdbDelivery.UseVisualStyleBackColor = true;
            // 
            // grpEntrega
            // 
            grpEntrega.Controls.Add(chkConvenioEstudiante);
            grpEntrega.Controls.Add(rdbDelivery);
            grpEntrega.Controls.Add(rdbRetiro);
            grpEntrega.Location = new Point(433, 112);
            grpEntrega.Name = "grpEntrega";
            grpEntrega.Size = new Size(304, 90);
            grpEntrega.TabIndex = 3;
            grpEntrega.TabStop = false;
            grpEntrega.Text = "Servicio y Descuento";
            // 
            // chkConvenioEstudiante
            // 
            chkConvenioEstudiante.AutoSize = true;
            chkConvenioEstudiante.Location = new Point(29, 54);
            chkConvenioEstudiante.Name = "chkConvenioEstudiante";
            chkConvenioEstudiante.Size = new Size(226, 19);
            chkConvenioEstudiante.TabIndex = 11;
            chkConvenioEstudiante.Text = "Convenio Estudiante/IPVG (10% Dcto)";
            chkConvenioEstudiante.UseVisualStyleBackColor = true;
            // 
            // rdbRetiro
            // 
            rdbRetiro.AutoSize = true;
            rdbRetiro.Location = new Point(24, 23);
            rdbRetiro.Name = "rdbRetiro";
            rdbRetiro.Size = new Size(103, 19);
            rdbRetiro.TabIndex = 10;
            rdbRetiro.TabStop = true;
            rdbRetiro.Text = "Retiro en Local";
            rdbRetiro.UseVisualStyleBackColor = true;
            // 
            // grpPizza
            // 
            grpPizza.Controls.Add(lblMasa);
            grpPizza.Controls.Add(cboMasa);
            grpPizza.Controls.Add(lblTamano);
            grpPizza.Controls.Add(cboTamano);
            grpPizza.Location = new Point(12, 112);
            grpPizza.Name = "grpPizza";
            grpPizza.Size = new Size(405, 90);
            grpPizza.TabIndex = 1;
            grpPizza.TabStop = false;
            grpPizza.Text = "Tamaño y Masa";
            // 
            // lblMasa
            // 
            lblMasa.AutoSize = true;
            lblMasa.Location = new Point(9, 54);
            lblMasa.Name = "lblMasa";
            lblMasa.Size = new Size(64, 15);
            lblMasa.TabIndex = 6;
            lblMasa.Text = "Tipo Masa:";
            // 
            // cboMasa
            // 
            cboMasa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMasa.FormattingEnabled = true;
            cboMasa.Location = new Point(98, 50);
            cboMasa.Name = "cboMasa";
            cboMasa.Size = new Size(277, 23);
            cboMasa.TabIndex = 4;
            // 
            // lblTamano
            // 
            lblTamano.AutoSize = true;
            lblTamano.Location = new Point(24, 25);
            lblTamano.Name = "lblTamano";
            lblTamano.Size = new Size(52, 15);
            lblTamano.TabIndex = 4;
            lblTamano.Text = "Tamaño:";
            // 
            // cboTamano
            // 
            cboTamano.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTamano.FormattingEnabled = true;
            cboTamano.Location = new Point(98, 23);
            cboTamano.Name = "cboTamano";
            cboTamano.Size = new Size(277, 23);
            cboTamano.TabIndex = 2;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(159, 217);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(136, 23);
            btnCalcular.TabIndex = 11;
            btnCalcular.Text = "⚡Calcular Total";
            btnCalcular.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(307, 217);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(136, 23);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "\U0001f9f9 Nuevo Pedido";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // grpHistorial
            // 
            grpHistorial.Controls.Add(dgvPedidos);
            grpHistorial.Controls.Add(txtPromedioVenta);
            grpHistorial.Controls.Add(lblPromedioVenta);
            grpHistorial.Controls.Add(txtCantidadPedidos);
            grpHistorial.Controls.Add(lblCantidadPedidos);
            grpHistorial.Controls.Add(txtRecaudacionTotal);
            grpHistorial.Controls.Add(lblRecaudacionTotal);
            grpHistorial.Location = new Point(346, 249);
            grpHistorial.Name = "grpHistorial";
            grpHistorial.Size = new Size(390, 220);
            grpHistorial.TabIndex = 14;
            grpHistorial.TabStop = false;
            grpHistorial.Text = "Historial de Ventas de la Jornada";
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(5, 17);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.Size = new Size(382, 111);
            dgvPedidos.TabIndex = 17;
            // 
            // txtPromedioVenta
            // 
            txtPromedioVenta.AutoSize = true;
            txtPromedioVenta.Location = new Point(144, 170);
            txtPromedioVenta.Name = "txtPromedioVenta";
            txtPromedioVenta.Size = new Size(43, 15);
            txtPromedioVenta.TabIndex = 16;
            txtPromedioVenta.Text = "$0 CLP";
            // 
            // lblPromedioVenta
            // 
            lblPromedioVenta.AutoSize = true;
            lblPromedioVenta.Location = new Point(40, 170);
            lblPromedioVenta.Name = "lblPromedioVenta";
            lblPromedioVenta.Size = new Size(62, 15);
            lblPromedioVenta.TabIndex = 15;
            lblPromedioVenta.Text = "Promedio:";
            // 
            // txtCantidadPedidos
            // 
            txtCantidadPedidos.AutoSize = true;
            txtCantidadPedidos.Location = new Point(144, 151);
            txtCantidadPedidos.Name = "txtCantidadPedidos";
            txtCantidadPedidos.Size = new Size(13, 15);
            txtCantidadPedidos.TabIndex = 14;
            txtCantidadPedidos.Text = "0";
            // 
            // lblCantidadPedidos
            // 
            lblCantidadPedidos.AutoSize = true;
            lblCantidadPedidos.Location = new Point(50, 151);
            lblCantidadPedidos.Name = "lblCantidadPedidos";
            lblCantidadPedidos.Size = new Size(52, 15);
            lblCantidadPedidos.TabIndex = 13;
            lblCantidadPedidos.Text = "Pedidos:";
            // 
            // txtRecaudacionTotal
            // 
            txtRecaudacionTotal.AutoSize = true;
            txtRecaudacionTotal.Location = new Point(144, 131);
            txtRecaudacionTotal.Name = "txtRecaudacionTotal";
            txtRecaudacionTotal.Size = new Size(43, 15);
            txtRecaudacionTotal.TabIndex = 12;
            txtRecaudacionTotal.Text = "$0 CLP";
            // 
            // lblRecaudacionTotal
            // 
            lblRecaudacionTotal.AutoSize = true;
            lblRecaudacionTotal.Location = new Point(5, 131);
            lblRecaudacionTotal.Name = "lblRecaudacionTotal";
            lblRecaudacionTotal.Size = new Size(97, 15);
            lblRecaudacionTotal.TabIndex = 11;
            lblRecaudacionTotal.Text = "Total Recaudado:";
            // 
            // lblEstadoConexion
            // 
            lblEstadoConexion.AutoSize = true;
            lblEstadoConexion.ForeColor = Color.Red;
            lblEstadoConexion.Location = new Point(11, 472);
            lblEstadoConexion.Name = "lblEstadoConexion";
            lblEstadoConexion.Size = new Size(199, 15);
            lblEstadoConexion.TabIndex = 15;
            lblEstadoConexion.Text = "● Estado SQL Express: No conectado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(282, 472);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 16;
            label1.Text = "Modo:";
            // 
            // FormPizzeriaCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 493);
            Controls.Add(label1);
            Controls.Add(lblEstadoConexion);
            Controls.Add(grpHistorial);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCalcular);
            Controls.Add(grpPizza);
            Controls.Add(grpEntrega);
            Controls.Add(grpDetalles);
            Controls.Add(grpIngredientes);
            Controls.Add(grpCliente);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPizzeriaCRUD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Pedidos - Pizzería Bella Italia (v1.1)";
            Load += FormPizzeriaCRUD_Load;
            grpCliente.ResumeLayout(false);
            grpCliente.PerformLayout();
            grpIngredientes.ResumeLayout(false);
            grpIngredientes.PerformLayout();
            grpDetalles.ResumeLayout(false);
            grpDetalles.PerformLayout();
            grpEntrega.ResumeLayout(false);
            grpEntrega.PerformLayout();
            grpPizza.ResumeLayout(false);
            grpPizza.PerformLayout();
            grpHistorial.ResumeLayout(false);
            grpHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pedidoPizzaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpCliente;
        private GroupBox grpIngredientes;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtCliente;
        private Label lblCliente;
        private GroupBox grpDetalles;
        private GroupBox grpEntrega;
        private GroupBox grpPizza;
        private Label lblTamano;
        private ComboBox cboTamano;
        private Label lblMasa;
        private ComboBox cboMasa;
        private CheckBox chkChampinones;
        private CheckBox chkPepperoni;
        private CheckBox chkAceitunas;
        private CheckBox chkQuesoExtra;
        private CheckBox chkTocino;
        private Label lblDescuentoValor;
        private Label lblSubtotalValor;
        private CheckBox chkConvenioEstudiante;
        private RadioButton rdbDelivery;
        private RadioButton rdbRetiro;
        private Label lblIvaValor;
        private Label lblDeliveryValor;
        private Label lblTotalValor;
        private Label lblSeparador;
        private Button btnCalcular;
        private Button btnLimpiar;
        private Label txtTotalValor;
        private Label txtIvaValor;
        private Label txtDeliveryValor;
        private Label txtDescuentoValor;
        private Label txtSubtotalValor;
        private GroupBox grpHistorial;
        private Label txtCantidadPedidos;
        private Label lblCantidadPedidos;
        private Label txtRecaudacionTotal;
        private Label lblRecaudacionTotal;
        private Label txtPromedioVenta;
        private Label lblPromedioVenta;
        private BindingSource pedidoPizzaBindingSource;
        private Label lblEstadoConexion;
        private DataGridView dgvPedidos;
        private Label label1;
    }
}
