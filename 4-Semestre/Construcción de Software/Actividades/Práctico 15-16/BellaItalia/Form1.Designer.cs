namespace BellaItalia
{
    partial class FormTallerPizzeria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTallerPizzeria));
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
            btnConfirmar = new Button();
            grpHistorial = new GroupBox();
            lstHistorial = new ListBox();
            btnReiniciarJornada = new Button();
            txtPromedioVenta = new Label();
            lblPromedioVenta = new Label();
            txtCantidadPedidos = new Label();
            lblCantidadPedidos = new Label();
            txtRecaudacionTotal = new Label();
            lblRecaudacionTotal = new Label();
            pedidoPizzaBindingSource = new BindingSource(components);
            grpCliente.SuspendLayout();
            grpIngredientes.SuspendLayout();
            grpDetalles.SuspendLayout();
            grpEntrega.SuspendLayout();
            grpPizza.SuspendLayout();
            grpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pedidoPizzaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // grpCliente
            // 
            grpCliente.Controls.Add(txtTelefono);
            grpCliente.Controls.Add(lblTelefono);
            grpCliente.Controls.Add(txtCliente);
            grpCliente.Controls.Add(lblCliente);
            grpCliente.Location = new Point(14, 16);
            grpCliente.Margin = new Padding(3, 4, 3, 4);
            grpCliente.Name = "grpCliente";
            grpCliente.Padding = new Padding(3, 4, 3, 4);
            grpCliente.Size = new Size(463, 120);
            grpCliente.TabIndex = 0;
            grpCliente.TabStop = false;
            grpCliente.Text = "Datos del Cliente";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(309, 44);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(148, 27);
            txtTelefono.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(233, 47);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(70, 20);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(79, 44);
            txtCliente.Margin = new Padding(3, 4, 3, 4);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(148, 27);
            txtCliente.TabIndex = 0;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(6, 47);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(67, 20);
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
            grpIngredientes.Location = new Point(495, 16);
            grpIngredientes.Margin = new Padding(3, 4, 3, 4);
            grpIngredientes.Name = "grpIngredientes";
            grpIngredientes.Padding = new Padding(3, 4, 3, 4);
            grpIngredientes.Size = new Size(350, 120);
            grpIngredientes.TabIndex = 2;
            grpIngredientes.TabStop = false;
            grpIngredientes.Text = "Adicionales ($800 c/u)";
            // 
            // chkTocino
            // 
            chkTocino.AutoSize = true;
            chkTocino.Location = new Point(124, 60);
            chkTocino.Margin = new Padding(3, 4, 3, 4);
            chkTocino.Name = "chkTocino";
            chkTocino.Size = new Size(75, 24);
            chkTocino.TabIndex = 9;
            chkTocino.Text = "Tocino";
            chkTocino.UseVisualStyleBackColor = true;
            // 
            // chkChampinones
            // 
            chkChampinones.AutoSize = true;
            chkChampinones.Location = new Point(228, 29);
            chkChampinones.Margin = new Padding(3, 4, 3, 4);
            chkChampinones.Name = "chkChampinones";
            chkChampinones.Size = new Size(121, 24);
            chkChampinones.TabIndex = 7;
            chkChampinones.Text = "Champiñones";
            chkChampinones.UseVisualStyleBackColor = true;
            // 
            // chkPepperoni
            // 
            chkPepperoni.AutoSize = true;
            chkPepperoni.Location = new Point(124, 29);
            chkPepperoni.Margin = new Padding(3, 4, 3, 4);
            chkPepperoni.Name = "chkPepperoni";
            chkPepperoni.Size = new Size(98, 24);
            chkPepperoni.TabIndex = 6;
            chkPepperoni.Text = "Pepperoni";
            chkPepperoni.UseVisualStyleBackColor = true;
            // 
            // chkAceitunas
            // 
            chkAceitunas.AutoSize = true;
            chkAceitunas.Location = new Point(8, 60);
            chkAceitunas.Margin = new Padding(3, 4, 3, 4);
            chkAceitunas.Name = "chkAceitunas";
            chkAceitunas.Size = new Size(95, 24);
            chkAceitunas.TabIndex = 8;
            chkAceitunas.Text = "Aceitunas";
            chkAceitunas.UseVisualStyleBackColor = true;
            // 
            // chkQuesoExtra
            // 
            chkQuesoExtra.AutoSize = true;
            chkQuesoExtra.Location = new Point(8, 28);
            chkQuesoExtra.Margin = new Padding(3, 4, 3, 4);
            chkQuesoExtra.Name = "chkQuesoExtra";
            chkQuesoExtra.Size = new Size(110, 24);
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
            grpDetalles.Location = new Point(13, 328);
            grpDetalles.Margin = new Padding(3, 4, 3, 4);
            grpDetalles.Name = "grpDetalles";
            grpDetalles.Padding = new Padding(3, 4, 3, 4);
            grpDetalles.Size = new Size(377, 297);
            grpDetalles.TabIndex = 4;
            grpDetalles.TabStop = false;
            grpDetalles.Text = "Detalle de Pago";
            // 
            // txtTotalValor
            // 
            txtTotalValor.AutoSize = true;
            txtTotalValor.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtTotalValor.ForeColor = Color.DarkGreen;
            txtTotalValor.Location = new Point(197, 175);
            txtTotalValor.Name = "txtTotalValor";
            txtTotalValor.Size = new Size(73, 25);
            txtTotalValor.TabIndex = 10;
            txtTotalValor.Text = "$0 CLP";
            txtTotalValor.TextAlign = ContentAlignment.TopRight;
            // 
            // txtIvaValor
            // 
            txtIvaValor.AutoSize = true;
            txtIvaValor.Location = new Point(197, 121);
            txtIvaValor.Name = "txtIvaValor";
            txtIvaValor.Size = new Size(53, 20);
            txtIvaValor.TabIndex = 9;
            txtIvaValor.Text = "$0 CLP";
            // 
            // txtDeliveryValor
            // 
            txtDeliveryValor.AutoSize = true;
            txtDeliveryValor.Location = new Point(197, 95);
            txtDeliveryValor.Name = "txtDeliveryValor";
            txtDeliveryValor.Size = new Size(53, 20);
            txtDeliveryValor.TabIndex = 8;
            txtDeliveryValor.Text = "$0 CLP";
            // 
            // txtDescuentoValor
            // 
            txtDescuentoValor.AutoSize = true;
            txtDescuentoValor.ForeColor = SystemColors.ControlText;
            txtDescuentoValor.Location = new Point(197, 69);
            txtDescuentoValor.Name = "txtDescuentoValor";
            txtDescuentoValor.Size = new Size(53, 20);
            txtDescuentoValor.TabIndex = 7;
            txtDescuentoValor.Text = "$0 CLP";
            txtDescuentoValor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSubtotalValor
            // 
            txtSubtotalValor.AutoSize = true;
            txtSubtotalValor.Location = new Point(197, 43);
            txtSubtotalValor.Name = "txtSubtotalValor";
            txtSubtotalValor.Size = new Size(53, 20);
            txtSubtotalValor.TabIndex = 6;
            txtSubtotalValor.Text = "$0 CLP";
            txtSubtotalValor.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTotalValor
            // 
            lblTotalValor.AutoSize = true;
            lblTotalValor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalValor.ForeColor = Color.DarkGreen;
            lblTotalValor.Location = new Point(11, 175);
            lblTotalValor.Name = "lblTotalValor";
            lblTotalValor.Size = new Size(169, 28);
            lblTotalValor.TabIndex = 5;
            lblTotalValor.Text = "TOTAL A PAGAR:";
            // 
            // lblSeparador
            // 
            lblSeparador.AutoSize = true;
            lblSeparador.Location = new Point(10, 143);
            lblSeparador.Name = "lblSeparador";
            lblSeparador.Size = new Size(267, 20);
            lblSeparador.TabIndex = 4;
            lblSeparador.Text = "___________________________________________";
            // 
            // lblIvaValor
            // 
            lblIvaValor.AutoSize = true;
            lblIvaValor.Location = new Point(10, 121);
            lblIvaValor.Name = "lblIvaValor";
            lblIvaValor.Size = new Size(130, 20);
            lblIvaValor.TabIndex = 3;
            lblIvaValor.Text = "IVA Chileno (19%):";
            // 
            // lblDeliveryValor
            // 
            lblDeliveryValor.AutoSize = true;
            lblDeliveryValor.Location = new Point(15, 95);
            lblDeliveryValor.Name = "lblDeliveryValor";
            lblDeliveryValor.Size = new Size(125, 20);
            lblDeliveryValor.TabIndex = 2;
            lblDeliveryValor.Text = "Recargo Delivery:";
            // 
            // lblDescuentoValor
            // 
            lblDescuentoValor.AutoSize = true;
            lblDescuentoValor.Location = new Point(16, 69);
            lblDescuentoValor.Name = "lblDescuentoValor";
            lblDescuentoValor.Size = new Size(124, 20);
            lblDescuentoValor.TabIndex = 1;
            lblDescuentoValor.Text = "Descuento (10%):";
            // 
            // lblSubtotalValor
            // 
            lblSubtotalValor.AutoSize = true;
            lblSubtotalValor.Location = new Point(34, 43);
            lblSubtotalValor.Name = "lblSubtotalValor";
            lblSubtotalValor.Size = new Size(106, 20);
            lblSubtotalValor.TabIndex = 0;
            lblSubtotalValor.Text = "Subtotal Pizza:";
            // 
            // rdbDelivery
            // 
            rdbDelivery.AutoSize = true;
            rdbDelivery.Location = new Point(168, 31);
            rdbDelivery.Margin = new Padding(3, 4, 3, 4);
            rdbDelivery.Name = "rdbDelivery";
            rdbDelivery.Size = new Size(151, 24);
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
            grpEntrega.Location = new Point(495, 149);
            grpEntrega.Margin = new Padding(3, 4, 3, 4);
            grpEntrega.Name = "grpEntrega";
            grpEntrega.Padding = new Padding(3, 4, 3, 4);
            grpEntrega.Size = new Size(347, 120);
            grpEntrega.TabIndex = 3;
            grpEntrega.TabStop = false;
            grpEntrega.Text = "Servicio y Descuento";
            // 
            // chkConvenioEstudiante
            // 
            chkConvenioEstudiante.AutoSize = true;
            chkConvenioEstudiante.Location = new Point(33, 72);
            chkConvenioEstudiante.Margin = new Padding(3, 4, 3, 4);
            chkConvenioEstudiante.Name = "chkConvenioEstudiante";
            chkConvenioEstudiante.Size = new Size(281, 24);
            chkConvenioEstudiante.TabIndex = 11;
            chkConvenioEstudiante.Text = "Convenio Estudiante/IPVG (10% Dcto)";
            chkConvenioEstudiante.UseVisualStyleBackColor = true;
            // 
            // rdbRetiro
            // 
            rdbRetiro.AutoSize = true;
            rdbRetiro.Location = new Point(27, 31);
            rdbRetiro.Margin = new Padding(3, 4, 3, 4);
            rdbRetiro.Name = "rdbRetiro";
            rdbRetiro.Size = new Size(129, 24);
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
            grpPizza.Location = new Point(14, 149);
            grpPizza.Margin = new Padding(3, 4, 3, 4);
            grpPizza.Name = "grpPizza";
            grpPizza.Padding = new Padding(3, 4, 3, 4);
            grpPizza.Size = new Size(463, 120);
            grpPizza.TabIndex = 1;
            grpPizza.TabStop = false;
            grpPizza.Text = "Tamaño y Masa";
            // 
            // lblMasa
            // 
            lblMasa.AutoSize = true;
            lblMasa.Location = new Point(10, 72);
            lblMasa.Name = "lblMasa";
            lblMasa.Size = new Size(81, 20);
            lblMasa.TabIndex = 6;
            lblMasa.Text = "Tipo Masa:";
            // 
            // cboMasa
            // 
            cboMasa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMasa.FormattingEnabled = true;
            cboMasa.Location = new Point(112, 67);
            cboMasa.Margin = new Padding(3, 4, 3, 4);
            cboMasa.Name = "cboMasa";
            cboMasa.Size = new Size(316, 28);
            cboMasa.TabIndex = 4;
            // 
            // lblTamano
            // 
            lblTamano.AutoSize = true;
            lblTamano.Location = new Point(27, 33);
            lblTamano.Name = "lblTamano";
            lblTamano.Size = new Size(64, 20);
            lblTamano.TabIndex = 4;
            lblTamano.Text = "Tamaño:";
            // 
            // cboTamano
            // 
            cboTamano.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTamano.FormattingEnabled = true;
            cboTamano.Location = new Point(112, 31);
            cboTamano.Margin = new Padding(3, 4, 3, 4);
            cboTamano.Name = "cboTamano";
            cboTamano.Size = new Size(316, 28);
            cboTamano.TabIndex = 2;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(182, 289);
            btnCalcular.Margin = new Padding(3, 4, 3, 4);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(155, 31);
            btnCalcular.TabIndex = 11;
            btnCalcular.Text = "⚡Calcular Total";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(351, 289);
            btnLimpiar.Margin = new Padding(3, 4, 3, 4);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(155, 31);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "\U0001f9f9 Nuevo Pedido";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(520, 289);
            btnConfirmar.Margin = new Padding(3, 4, 3, 4);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(155, 31);
            btnConfirmar.TabIndex = 13;
            btnConfirmar.Text = "✅ Confirmar Pedido";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // grpHistorial
            // 
            grpHistorial.Controls.Add(lstHistorial);
            grpHistorial.Controls.Add(btnReiniciarJornada);
            grpHistorial.Controls.Add(txtPromedioVenta);
            grpHistorial.Controls.Add(lblPromedioVenta);
            grpHistorial.Controls.Add(txtCantidadPedidos);
            grpHistorial.Controls.Add(lblCantidadPedidos);
            grpHistorial.Controls.Add(txtRecaudacionTotal);
            grpHistorial.Controls.Add(lblRecaudacionTotal);
            grpHistorial.Location = new Point(396, 332);
            grpHistorial.Margin = new Padding(3, 4, 3, 4);
            grpHistorial.Name = "grpHistorial";
            grpHistorial.Padding = new Padding(3, 4, 3, 4);
            grpHistorial.Size = new Size(446, 293);
            grpHistorial.TabIndex = 14;
            grpHistorial.TabStop = false;
            grpHistorial.Text = "Historial de Ventas de la Jornada";
            // 
            // lstHistorial
            // 
            lstHistorial.Font = new Font("Consolas", 9F);
            lstHistorial.FormattingEnabled = true;
            lstHistorial.HorizontalScrollbar = true;
            lstHistorial.Location = new Point(6, 27);
            lstHistorial.Name = "lstHistorial";
            lstHistorial.ScrollAlwaysVisible = true;
            lstHistorial.Size = new Size(434, 130);
            lstHistorial.TabIndex = 17;
            // 
            // btnReiniciarJornada
            // 
            btnReiniciarJornada.Location = new Point(128, 254);
            btnReiniciarJornada.Margin = new Padding(3, 4, 3, 4);
            btnReiniciarJornada.Name = "btnReiniciarJornada";
            btnReiniciarJornada.Size = new Size(155, 31);
            btnReiniciarJornada.TabIndex = 15;
            btnReiniciarJornada.Text = "🔄 Reiniciar Jornada";
            btnReiniciarJornada.UseVisualStyleBackColor = true;
            btnReiniciarJornada.Click += btnReiniciarJornada_Click;
            // 
            // txtPromedioVenta
            // 
            txtPromedioVenta.AutoSize = true;
            txtPromedioVenta.Location = new Point(165, 227);
            txtPromedioVenta.Name = "txtPromedioVenta";
            txtPromedioVenta.Size = new Size(53, 20);
            txtPromedioVenta.TabIndex = 16;
            txtPromedioVenta.Text = "$0 CLP";
            // 
            // lblPromedioVenta
            // 
            lblPromedioVenta.AutoSize = true;
            lblPromedioVenta.Location = new Point(53, 227);
            lblPromedioVenta.Name = "lblPromedioVenta";
            lblPromedioVenta.Size = new Size(77, 20);
            lblPromedioVenta.TabIndex = 15;
            lblPromedioVenta.Text = "Promedio:";
            // 
            // txtCantidadPedidos
            // 
            txtCantidadPedidos.AutoSize = true;
            txtCantidadPedidos.Location = new Point(165, 201);
            txtCantidadPedidos.Name = "txtCantidadPedidos";
            txtCantidadPedidos.Size = new Size(17, 20);
            txtCantidadPedidos.TabIndex = 14;
            txtCantidadPedidos.Text = "0";
            // 
            // lblCantidadPedidos
            // 
            lblCantidadPedidos.AutoSize = true;
            lblCantidadPedidos.Location = new Point(66, 201);
            lblCantidadPedidos.Name = "lblCantidadPedidos";
            lblCantidadPedidos.Size = new Size(64, 20);
            lblCantidadPedidos.TabIndex = 13;
            lblCantidadPedidos.Text = "Pedidos:";
            // 
            // txtRecaudacionTotal
            // 
            txtRecaudacionTotal.AutoSize = true;
            txtRecaudacionTotal.Location = new Point(165, 175);
            txtRecaudacionTotal.Name = "txtRecaudacionTotal";
            txtRecaudacionTotal.Size = new Size(53, 20);
            txtRecaudacionTotal.TabIndex = 12;
            txtRecaudacionTotal.Text = "$0 CLP";
            // 
            // lblRecaudacionTotal
            // 
            lblRecaudacionTotal.AutoSize = true;
            lblRecaudacionTotal.Location = new Point(6, 175);
            lblRecaudacionTotal.Name = "lblRecaudacionTotal";
            lblRecaudacionTotal.Size = new Size(124, 20);
            lblRecaudacionTotal.TabIndex = 11;
            lblRecaudacionTotal.Text = "Total Recaudado:";
            // 
            // pedidoPizzaBindingSource
            // 
            pedidoPizzaBindingSource.DataSource = typeof(PedidoPizza);
            // 
            // FormTallerPizzeria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 638);
            Controls.Add(grpHistorial);
            Controls.Add(btnConfirmar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCalcular);
            Controls.Add(grpPizza);
            Controls.Add(grpEntrega);
            Controls.Add(grpDetalles);
            Controls.Add(grpIngredientes);
            Controls.Add(grpCliente);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTallerPizzeria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Pedidos - Pizzería Bella Italia (v1.0)";
            Load += Form1_Load;
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
            ((System.ComponentModel.ISupportInitialize)pedidoPizzaBindingSource).EndInit();
            ResumeLayout(false);
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
        private Button btnConfirmar;
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
        private Button btnReiniciarJornada;
        private BindingSource pedidoPizzaBindingSource;
        private ListBox lstHistorial;
    }
}
