using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CabanasLosCoihues
{
    partial class frmReservas
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
            grpCliente = new GroupBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            chkSocio = new CheckBox();
            grpServicio = new GroupBox();
            lblCabana = new Label();
            cboCabana = new ComboBox();
            lblTemporada = new Label();
            cboTemporada = new ComboBox();
            lblNoches = new Label();
            txtNoches = new TextBox();
            grpAdicionales = new GroupBox();
            chkTinaja = new CheckBox();
            chkLena = new CheckBox();
            chkMascota = new CheckBox();
            chkDesayuno = new CheckBox();
            chkKayak = new CheckBox();
            lblModalidad = new Label();
            rdbRetiro = new RadioButton();
            rdbTraslado = new RadioButton();
            grpDetalle = new GroupBox();
            lblTSubtotal = new Label();
            lblSubtotal = new Label();
            lblTAdicionales = new Label();
            lblAdicionales = new Label();
            lblTDescuento = new Label();
            lblDescuento = new Label();
            lblTRecargo = new Label();
            lblRecargo = new Label();
            lblTNeto = new Label();
            lblNeto = new Label();
            lblTIva = new Label();
            lblIva = new Label();
            lblTTotal = new Label();
            lblTotal = new Label();
            btnCalcular = new Button();
            btnConfirmar = new Button();
            btnLimpiar = new Button();
            btnReiniciar = new Button();
            grpHistorial = new GroupBox();
            lstReservas = new ListBox();
            lblTotalRecaudado = new Label();
            lblCantidad = new Label();
            lblPromedio = new Label();
            grpCliente.SuspendLayout();
            grpServicio.SuspendLayout();
            grpAdicionales.SuspendLayout();
            grpDetalle.SuspendLayout();
            grpHistorial.SuspendLayout();
            SuspendLayout();
            //
            // grpCliente
            //
            grpCliente.Controls.Add(lblNombre);
            grpCliente.Controls.Add(txtNombre);
            grpCliente.Controls.Add(lblTelefono);
            grpCliente.Controls.Add(txtTelefono);
            grpCliente.Controls.Add(chkSocio);
            grpCliente.Location = new Point(12, 12);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(360, 124);
            grpCliente.TabIndex = 0;
            grpCliente.TabStop = false;
            grpCliente.Text = "Datos del Cliente";
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(14, 32);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(110, 29);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(236, 23);
            txtNombre.TabIndex = 0;
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(14, 63);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(58, 15);
            lblTelefono.Text = "Teléfono:";
            //
            // txtTelefono
            //
            txtTelefono.Location = new Point(110, 60);
            txtTelefono.MaxLength = 9;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(236, 23);
            txtTelefono.TabIndex = 1;
            //
            // chkSocio
            //
            chkSocio.AutoSize = true;
            chkSocio.Location = new Point(14, 92);
            chkSocio.Name = "chkSocio";
            chkSocio.Size = new Size(213, 19);
            chkSocio.TabIndex = 2;
            chkSocio.Text = "Socio Club Los Coihues (10% dto.)";
            chkSocio.UseVisualStyleBackColor = true;
            //
            // grpServicio
            //
            grpServicio.Controls.Add(lblCabana);
            grpServicio.Controls.Add(cboCabana);
            grpServicio.Controls.Add(lblTemporada);
            grpServicio.Controls.Add(cboTemporada);
            grpServicio.Controls.Add(lblNoches);
            grpServicio.Controls.Add(txtNoches);
            grpServicio.Location = new Point(12, 144);
            grpServicio.Name = "grpServicio";
            grpServicio.Size = new Size(360, 124);
            grpServicio.TabIndex = 1;
            grpServicio.TabStop = false;
            grpServicio.Text = "Cabaña y Estadía";
            //
            // lblCabana
            //
            lblCabana.AutoSize = true;
            lblCabana.Location = new Point(14, 32);
            lblCabana.Name = "lblCabana";
            lblCabana.Size = new Size(48, 15);
            lblCabana.Text = "Cabaña:";
            //
            // cboCabana
            //
            cboCabana.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCabana.FormattingEnabled = true;
            cboCabana.Location = new Point(110, 29);
            cboCabana.Name = "cboCabana";
            cboCabana.Size = new Size(236, 23);
            cboCabana.TabIndex = 0;
            //
            // lblTemporada
            //
            lblTemporada.AutoSize = true;
            lblTemporada.Location = new Point(14, 63);
            lblTemporada.Name = "lblTemporada";
            lblTemporada.Size = new Size(70, 15);
            lblTemporada.Text = "Temporada:";
            //
            // cboTemporada
            //
            cboTemporada.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTemporada.FormattingEnabled = true;
            cboTemporada.Location = new Point(110, 60);
            cboTemporada.Name = "cboTemporada";
            cboTemporada.Size = new Size(236, 23);
            cboTemporada.TabIndex = 1;
            //
            // lblNoches
            //
            lblNoches.AutoSize = true;
            lblNoches.Location = new Point(14, 94);
            lblNoches.Name = "lblNoches";
            lblNoches.Size = new Size(47, 15);
            lblNoches.Text = "Noches:";
            //
            // txtNoches
            //
            txtNoches.Location = new Point(110, 91);
            txtNoches.MaxLength = 3;
            txtNoches.Name = "txtNoches";
            txtNoches.Size = new Size(80, 23);
            txtNoches.TabIndex = 2;
            //
            // grpAdicionales
            //
            grpAdicionales.Controls.Add(chkTinaja);
            grpAdicionales.Controls.Add(chkLena);
            grpAdicionales.Controls.Add(chkMascota);
            grpAdicionales.Controls.Add(chkDesayuno);
            grpAdicionales.Controls.Add(chkKayak);
            grpAdicionales.Controls.Add(lblModalidad);
            grpAdicionales.Controls.Add(rdbRetiro);
            grpAdicionales.Controls.Add(rdbTraslado);
            grpAdicionales.Location = new Point(12, 276);
            grpAdicionales.Name = "grpAdicionales";
            grpAdicionales.Size = new Size(360, 262);
            grpAdicionales.TabIndex = 2;
            grpAdicionales.TabStop = false;
            grpAdicionales.Text = "Adicionales y Modalidad";
            //
            // chkTinaja
            //
            chkTinaja.AutoSize = true;
            chkTinaja.Location = new Point(14, 28);
            chkTinaja.Name = "chkTinaja";
            chkTinaja.Size = new Size(160, 19);
            chkTinaja.TabIndex = 0;
            chkTinaja.Text = "Tinaja caliente ($27.500)";
            chkTinaja.UseVisualStyleBackColor = true;
            //
            // chkLena
            //
            chkLena.AutoSize = true;
            chkLena.Location = new Point(14, 54);
            chkLena.Name = "chkLena";
            chkLena.Size = new Size(140, 19);
            chkLena.TabIndex = 1;
            chkLena.Text = "Pack de leña ($6.500)";
            chkLena.UseVisualStyleBackColor = true;
            //
            // chkMascota
            //
            chkMascota.AutoSize = true;
            chkMascota.Location = new Point(14, 80);
            chkMascota.Name = "chkMascota";
            chkMascota.Size = new Size(180, 19);
            chkMascota.TabIndex = 2;
            chkMascota.Text = "Ingreso de mascota ($9.500)";
            chkMascota.UseVisualStyleBackColor = true;
            //
            // chkDesayuno
            //
            chkDesayuno.AutoSize = true;
            chkDesayuno.Location = new Point(14, 106);
            chkDesayuno.Name = "chkDesayuno";
            chkDesayuno.Size = new Size(190, 19);
            chkDesayuno.TabIndex = 3;
            chkDesayuno.Text = "Desayuno campestre ($12.000)";
            chkDesayuno.UseVisualStyleBackColor = true;
            //
            // chkKayak
            //
            chkKayak.AutoSize = true;
            chkKayak.Location = new Point(14, 132);
            chkKayak.Name = "chkKayak";
            chkKayak.Size = new Size(160, 19);
            chkKayak.TabIndex = 4;
            chkKayak.Text = "Paseo en kayak ($17.500)";
            chkKayak.UseVisualStyleBackColor = true;
            //
            // lblModalidad
            //
            lblModalidad.AutoSize = true;
            lblModalidad.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            lblModalidad.Location = new Point(14, 172);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(150, 15);
            lblModalidad.Text = "Modalidad de recepción:";
            //
            // rdbRetiro
            //
            rdbRetiro.AutoSize = true;
            rdbRetiro.Checked = true;
            rdbRetiro.Location = new Point(24, 196);
            rdbRetiro.Name = "rdbRetiro";
            rdbRetiro.Size = new Size(260, 19);
            rdbRetiro.TabIndex = 5;
            rdbRetiro.TabStop = true;
            rdbRetiro.Text = "Retiro de llaves en recepción (sin costo)";
            rdbRetiro.UseVisualStyleBackColor = true;
            //
            // rdbTraslado
            //
            rdbTraslado.AutoSize = true;
            rdbTraslado.Location = new Point(24, 224);
            rdbTraslado.Name = "rdbTraslado";
            rdbTraslado.Size = new Size(320, 19);
            rdbTraslado.TabIndex = 6;
            rdbTraslado.Text = "Recepción con traslado desde terminal (+$15.000)";
            rdbTraslado.UseVisualStyleBackColor = true;
            //
            // grpDetalle
            //
            grpDetalle.Controls.Add(lblTSubtotal);
            grpDetalle.Controls.Add(lblSubtotal);
            grpDetalle.Controls.Add(lblTAdicionales);
            grpDetalle.Controls.Add(lblAdicionales);
            grpDetalle.Controls.Add(lblTDescuento);
            grpDetalle.Controls.Add(lblDescuento);
            grpDetalle.Controls.Add(lblTRecargo);
            grpDetalle.Controls.Add(lblRecargo);
            grpDetalle.Controls.Add(lblTNeto);
            grpDetalle.Controls.Add(lblNeto);
            grpDetalle.Controls.Add(lblTIva);
            grpDetalle.Controls.Add(lblIva);
            grpDetalle.Controls.Add(lblTTotal);
            grpDetalle.Controls.Add(lblTotal);
            grpDetalle.Location = new Point(384, 12);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Size = new Size(364, 256);
            grpDetalle.TabIndex = 3;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Detalle de Pago";
            //
            // lblTSubtotal
            //
            lblTSubtotal.AutoSize = true;
            lblTSubtotal.Location = new Point(14, 30);
            lblTSubtotal.Name = "lblTSubtotal";
            lblTSubtotal.Size = new Size(85, 15);
            lblTSubtotal.Text = "Subtotal base:";
            //
            // lblSubtotal
            //
            lblSubtotal.Location = new Point(190, 28);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(160, 19);
            lblSubtotal.Text = "$0";
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblTAdicionales
            //
            lblTAdicionales.AutoSize = true;
            lblTAdicionales.Location = new Point(14, 58);
            lblTAdicionales.Name = "lblTAdicionales";
            lblTAdicionales.Size = new Size(122, 15);
            lblTAdicionales.Text = "Adicionales elegidos:";
            //
            // lblAdicionales
            //
            lblAdicionales.Location = new Point(190, 56);
            lblAdicionales.Name = "lblAdicionales";
            lblAdicionales.Size = new Size(160, 19);
            lblAdicionales.Text = "0";
            lblAdicionales.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblTDescuento
            //
            lblTDescuento.AutoSize = true;
            lblTDescuento.Location = new Point(14, 86);
            lblTDescuento.Name = "lblTDescuento";
            lblTDescuento.Size = new Size(102, 15);
            lblTDescuento.Text = "Descuento socio:";
            //
            // lblDescuento
            //
            lblDescuento.ForeColor = Color.Red;
            lblDescuento.Location = new Point(190, 84);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(160, 19);
            lblDescuento.Text = "-$0";
            lblDescuento.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblTRecargo
            //
            lblTRecargo.AutoSize = true;
            lblTRecargo.Location = new Point(14, 114);
            lblTRecargo.Name = "lblTRecargo";
            lblTRecargo.Size = new Size(121, 15);
            lblTRecargo.Text = "Recargo modalidad:";
            //
            // lblRecargo
            //
            lblRecargo.Location = new Point(190, 112);
            lblRecargo.Name = "lblRecargo";
            lblRecargo.Size = new Size(160, 19);
            lblRecargo.Text = "$0";
            lblRecargo.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblTNeto
            //
            lblTNeto.AutoSize = true;
            lblTNeto.Location = new Point(14, 142);
            lblTNeto.Name = "lblTNeto";
            lblTNeto.Size = new Size(77, 15);
            lblTNeto.Text = "Neto afecto:";
            //
            // lblNeto
            //
            lblNeto.Location = new Point(190, 140);
            lblNeto.Name = "lblNeto";
            lblNeto.Size = new Size(160, 19);
            lblNeto.Text = "$0";
            lblNeto.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblTIva
            //
            lblTIva.AutoSize = true;
            lblTIva.Location = new Point(14, 170);
            lblTIva.Name = "lblTIva";
            lblTIva.Size = new Size(63, 15);
            lblTIva.Text = "IVA (19%):";
            //
            // lblIva
            //
            lblIva.Location = new Point(190, 168);
            lblIva.Name = "lblIva";
            lblIva.Size = new Size(160, 19);
            lblIva.Text = "$0";
            lblIva.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblTTotal
            //
            lblTTotal.AutoSize = true;
            lblTTotal.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            lblTTotal.Location = new Point(14, 213);
            lblTTotal.Name = "lblTTotal";
            lblTTotal.Size = new Size(129, 20);
            lblTTotal.Text = "TOTAL A PAGAR:";
            //
            // lblTotal
            //
            lblTotal.BackColor = Color.LemonChiffon;
            lblTotal.BorderStyle = BorderStyle.FixedSingle;
            lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Navy;
            lblTotal.Location = new Point(160, 202);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(190, 40);
            lblTotal.Text = "$0";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // btnCalcular
            //
            btnCalcular.Location = new Point(384, 276);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(176, 36);
            btnCalcular.TabIndex = 4;
            btnCalcular.Text = "Calcular Total";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            //
            // btnConfirmar
            //
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new Point(572, 276);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(176, 36);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.Text = "Confirmar Reserva";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.Location = new Point(384, 318);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(176, 36);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar / Nuevo";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // btnReiniciar
            //
            btnReiniciar.Location = new Point(572, 318);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(176, 36);
            btnReiniciar.TabIndex = 7;
            btnReiniciar.Text = "Reiniciar Jornada";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click;
            //
            // grpHistorial
            //
            grpHistorial.Controls.Add(lstReservas);
            grpHistorial.Controls.Add(lblTotalRecaudado);
            grpHistorial.Controls.Add(lblCantidad);
            grpHistorial.Controls.Add(lblPromedio);
            grpHistorial.Location = new Point(384, 364);
            grpHistorial.Name = "grpHistorial";
            grpHistorial.Size = new Size(364, 174);
            grpHistorial.TabIndex = 8;
            grpHistorial.TabStop = false;
            grpHistorial.Text = "Historial y Métricas de la Jornada";
            //
            // lstReservas
            //
            lstReservas.FormattingEnabled = true;
            lstReservas.HorizontalScrollbar = true;
            lstReservas.ItemHeight = 15;
            lstReservas.Location = new Point(14, 24);
            lstReservas.Name = "lstReservas";
            lstReservas.Size = new Size(336, 79);
            lstReservas.TabIndex = 0;
            //
            // lblTotalRecaudado
            //
            lblTotalRecaudado.AutoSize = true;
            lblTotalRecaudado.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalRecaudado.Location = new Point(14, 112);
            lblTotalRecaudado.Name = "lblTotalRecaudado";
            lblTotalRecaudado.Size = new Size(125, 15);
            lblTotalRecaudado.Text = "Total recaudado: $0";
            //
            // lblCantidad
            //
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidad.Location = new Point(14, 132);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(150, 15);
            lblCantidad.Text = "Reservas confirmadas: 0";
            //
            // lblPromedio
            //
            lblPromedio.AutoSize = true;
            lblPromedio.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            lblPromedio.Location = new Point(14, 152);
            lblPromedio.Name = "lblPromedio";
            lblPromedio.Size = new Size(160, 15);
            lblPromedio.Text = "Promedio por reserva: $0";
            //
            // frmReservas
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 550);
            Controls.Add(grpCliente);
            Controls.Add(grpServicio);
            Controls.Add(grpAdicionales);
            Controls.Add(grpDetalle);
            Controls.Add(btnCalcular);
            Controls.Add(btnConfirmar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnReiniciar);
            Controls.Add(grpHistorial);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmReservas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cabañas Los Coihues - Gestión de Reservas";
            Load += frmReservas_Load;
            grpCliente.ResumeLayout(false);
            grpCliente.PerformLayout();
            grpServicio.ResumeLayout(false);
            grpServicio.PerformLayout();
            grpAdicionales.ResumeLayout(false);
            grpAdicionales.PerformLayout();
            grpDetalle.ResumeLayout(false);
            grpDetalle.PerformLayout();
            grpHistorial.ResumeLayout(false);
            grpHistorial.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpCliente;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private CheckBox chkSocio;
        private GroupBox grpServicio;
        private Label lblCabana;
        private ComboBox cboCabana;
        private Label lblTemporada;
        private ComboBox cboTemporada;
        private Label lblNoches;
        private TextBox txtNoches;
        private GroupBox grpAdicionales;
        private CheckBox chkTinaja;
        private CheckBox chkLena;
        private CheckBox chkMascota;
        private CheckBox chkDesayuno;
        private CheckBox chkKayak;
        private Label lblModalidad;
        private RadioButton rdbRetiro;
        private RadioButton rdbTraslado;
        private GroupBox grpDetalle;
        private Label lblTSubtotal;
        private Label lblSubtotal;
        private Label lblTAdicionales;
        private Label lblAdicionales;
        private Label lblTDescuento;
        private Label lblDescuento;
        private Label lblTRecargo;
        private Label lblRecargo;
        private Label lblTNeto;
        private Label lblNeto;
        private Label lblTIva;
        private Label lblIva;
        private Label lblTTotal;
        private Label lblTotal;
        private Button btnCalcular;
        private Button btnConfirmar;
        private Button btnLimpiar;
        private Button btnReiniciar;
        private GroupBox grpHistorial;
        private ListBox lstReservas;
        private Label lblTotalRecaudado;
        private Label lblCantidad;
        private Label lblPromedio;
    }
}