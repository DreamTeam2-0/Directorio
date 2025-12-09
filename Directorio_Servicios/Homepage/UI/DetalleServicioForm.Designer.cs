
namespace Homepage.UI
{
    partial class DetalleServicioForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label lblInformacionBasica;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblTipoPrecio;
        private System.Windows.Forms.TextBox txtTipoPrecio;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.Label lblDisponibilidad;
        private System.Windows.Forms.TextBox txtDisponibilidad;
        private System.Windows.Forms.Label lblRadioCobertura;
        private System.Windows.Forms.TextBox txtRadioCobertura;
        private System.Windows.Forms.Label lblExperiencia;
        private System.Windows.Forms.TextBox txtExperiencia;
        private System.Windows.Forms.Label lblInformacionContacto;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblWhatsapp;
        private System.Windows.Forms.TextBox txtWhatsapp;
        private System.Windows.Forms.Label lblOtroContacto;
        private System.Windows.Forms.TextBox txtOtroContacto;
        private System.Windows.Forms.Label lblZonasServicio;
        private System.Windows.Forms.TextBox txtZonasServicio;
        private System.Windows.Forms.Button btnComentario;
        private System.Windows.Forms.Label lblVisitas;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblVisitas = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.txtZonasServicio = new System.Windows.Forms.TextBox();
            this.lblZonasServicio = new System.Windows.Forms.Label();
            this.txtOtroContacto = new System.Windows.Forms.TextBox();
            this.lblOtroContacto = new System.Windows.Forms.Label();
            this.txtWhatsapp = new System.Windows.Forms.TextBox();
            this.lblWhatsapp = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblInformacionContacto = new System.Windows.Forms.Label();
            this.txtExperiencia = new System.Windows.Forms.TextBox();
            this.lblExperiencia = new System.Windows.Forms.Label();
            this.txtRadioCobertura = new System.Windows.Forms.TextBox();
            this.lblRadioCobertura = new System.Windows.Forms.Label();
            this.txtDisponibilidad = new System.Windows.Forms.TextBox();
            this.lblDisponibilidad = new System.Windows.Forms.Label();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.txtTipoPrecio = new System.Windows.Forms.TextBox();
            this.lblTipoPrecio = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblInformacionBasica = new System.Windows.Forms.Label();
            this.btnComentario = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.panelHeader.Controls.Add(this.lblVisitas);
            this.panelHeader.Controls.Add(this.btnCerrar);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblVisitas
            // 
            this.lblVisitas.AutoSize = true;
            this.lblVisitas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitas.ForeColor = System.Drawing.Color.White;
            this.lblVisitas.Location = new System.Drawing.Point(20, 50);
            this.lblVisitas.Name = "lblVisitas";
            this.lblVisitas.Size = new System.Drawing.Size(69, 15);
            this.lblVisitas.TabIndex = 2;
            this.lblVisitas.Text = "0 visitas";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnCerrar.FlatAppearance.BorderSize = 2;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnCerrar.Location = new System.Drawing.Point(670, 20);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 35);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(166, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título Servicio";
            // 
            // panelContenido
            // 
            this.panelContenido.AutoScroll = true;
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Controls.Add(this.txtZonasServicio);
            this.panelContenido.Controls.Add(this.lblZonasServicio);
            this.panelContenido.Controls.Add(this.txtOtroContacto);
            this.panelContenido.Controls.Add(this.lblOtroContacto);
            this.panelContenido.Controls.Add(this.txtWhatsapp);
            this.panelContenido.Controls.Add(this.lblWhatsapp);
            this.panelContenido.Controls.Add(this.txtTelefono);
            this.panelContenido.Controls.Add(this.lblTelefono);
            this.panelContenido.Controls.Add(this.txtEmail);
            this.panelContenido.Controls.Add(this.lblEmail);
            this.panelContenido.Controls.Add(this.txtCiudad);
            this.panelContenido.Controls.Add(this.lblCiudad);
            this.panelContenido.Controls.Add(this.lblInformacionContacto);
            this.panelContenido.Controls.Add(this.txtExperiencia);
            this.panelContenido.Controls.Add(this.lblExperiencia);
            this.panelContenido.Controls.Add(this.txtRadioCobertura);
            this.panelContenido.Controls.Add(this.lblRadioCobertura);
            this.panelContenido.Controls.Add(this.txtDisponibilidad);
            this.panelContenido.Controls.Add(this.lblDisponibilidad);
            this.panelContenido.Controls.Add(this.txtMoneda);
            this.panelContenido.Controls.Add(this.lblMoneda);
            this.panelContenido.Controls.Add(this.txtTipoPrecio);
            this.panelContenido.Controls.Add(this.lblTipoPrecio);
            this.panelContenido.Controls.Add(this.txtDescripcion);
            this.panelContenido.Controls.Add(this.lblDescripcion);
            this.panelContenido.Controls.Add(this.txtProveedor);
            this.panelContenido.Controls.Add(this.lblProveedor);
            this.panelContenido.Controls.Add(this.lblInformacionBasica);
            this.panelContenido.Controls.Add(this.btnComentario);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 80);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(800, 520);
            this.panelContenido.TabIndex = 1;
            // 
            // txtZonasServicio
            // 
            this.txtZonasServicio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtZonasServicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtZonasServicio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZonasServicio.Location = new System.Drawing.Point(440, 420);
            this.txtZonasServicio.Multiline = true;
            this.txtZonasServicio.Name = "txtZonasServicio";
            this.txtZonasServicio.ReadOnly = true;
            this.txtZonasServicio.Size = new System.Drawing.Size(330, 40);
            this.txtZonasServicio.TabIndex = 28;
            // 
            // lblZonasServicio
            // 
            this.lblZonasServicio.AutoSize = true;
            this.lblZonasServicio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZonasServicio.Location = new System.Drawing.Point(440, 400);
            this.lblZonasServicio.Name = "lblZonasServicio";
            this.lblZonasServicio.Size = new System.Drawing.Size(110, 15);
            this.lblZonasServicio.TabIndex = 27;
            this.lblZonasServicio.Text = "Zonas de Servicio";
            // 
            // txtOtroContacto
            // 
            this.txtOtroContacto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOtroContacto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOtroContacto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtroContacto.Location = new System.Drawing.Point(440, 350);
            this.txtOtroContacto.Name = "txtOtroContacto";
            this.txtOtroContacto.ReadOnly = true;
            this.txtOtroContacto.Size = new System.Drawing.Size(330, 14);
            this.txtOtroContacto.TabIndex = 26;
            // 
            // lblOtroContacto
            // 
            this.lblOtroContacto.AutoSize = true;
            this.lblOtroContacto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtroContacto.Location = new System.Drawing.Point(440, 330);
            this.lblOtroContacto.Name = "lblOtroContacto";
            this.lblOtroContacto.Size = new System.Drawing.Size(88, 15);
            this.lblOtroContacto.TabIndex = 25;
            this.lblOtroContacto.Text = "Otro Contacto";
            // 
            // txtWhatsapp
            // 
            this.txtWhatsapp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtWhatsapp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWhatsapp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWhatsapp.Location = new System.Drawing.Point(440, 290);
            this.txtWhatsapp.Name = "txtWhatsapp";
            this.txtWhatsapp.ReadOnly = true;
            this.txtWhatsapp.Size = new System.Drawing.Size(330, 14);
            this.txtWhatsapp.TabIndex = 24;
            // 
            // lblWhatsapp
            // 
            this.lblWhatsapp.AutoSize = true;
            this.lblWhatsapp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhatsapp.Location = new System.Drawing.Point(440, 270);
            this.lblWhatsapp.Name = "lblWhatsapp";
            this.lblWhatsapp.Size = new System.Drawing.Size(68, 15);
            this.lblWhatsapp.TabIndex = 23;
            this.lblWhatsapp.Text = "WhatsApp";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(440, 230);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(330, 14);
            this.txtTelefono.TabIndex = 22;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(440, 210);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(58, 15);
            this.lblTelefono.TabIndex = 21;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(440, 170);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(330, 14);
            this.txtEmail.TabIndex = 20;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(440, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 19;
            this.lblEmail.Text = "Email";
            // 
            // txtCiudad
            // 
            this.txtCiudad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCiudad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCiudad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiudad.Location = new System.Drawing.Point(440, 110);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.ReadOnly = true;
            this.txtCiudad.Size = new System.Drawing.Size(330, 14);
            this.txtCiudad.TabIndex = 18;
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiudad.Location = new System.Drawing.Point(440, 90);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(48, 15);
            this.lblCiudad.TabIndex = 17;
            this.lblCiudad.Text = "Ciudad";
            // 
            // lblInformacionContacto
            // 
            this.lblInformacionContacto.AutoSize = true;
            this.lblInformacionContacto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacionContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.lblInformacionContacto.Location = new System.Drawing.Point(440, 50);
            this.lblInformacionContacto.Name = "lblInformacionContacto";
            this.lblInformacionContacto.Size = new System.Drawing.Size(195, 19);
            this.lblInformacionContacto.TabIndex = 16;
            this.lblInformacionContacto.Text = "Información de Contacto";
            // 
            // txtExperiencia
            // 
            this.txtExperiencia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtExperiencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExperiencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExperiencia.Location = new System.Drawing.Point(30, 420);
            this.txtExperiencia.Multiline = true;
            this.txtExperiencia.Name = "txtExperiencia";
            this.txtExperiencia.ReadOnly = true;
            this.txtExperiencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExperiencia.Size = new System.Drawing.Size(380, 60);
            this.txtExperiencia.TabIndex = 15;
            // 
            // lblExperiencia
            // 
            this.lblExperiencia.AutoSize = true;
            this.lblExperiencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExperiencia.Location = new System.Drawing.Point(30, 400);
            this.lblExperiencia.Name = "lblExperiencia";
            this.lblExperiencia.Size = new System.Drawing.Size(72, 15);
            this.lblExperiencia.TabIndex = 14;
            this.lblExperiencia.Text = "Experiencia";
            // 
            // txtRadioCobertura
            // 
            this.txtRadioCobertura.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRadioCobertura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRadioCobertura.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRadioCobertura.Location = new System.Drawing.Point(30, 350);
            this.txtRadioCobertura.Name = "txtRadioCobertura";
            this.txtRadioCobertura.ReadOnly = true;
            this.txtRadioCobertura.Size = new System.Drawing.Size(380, 14);
            this.txtRadioCobertura.TabIndex = 13;
            // 
            // lblRadioCobertura
            // 
            this.lblRadioCobertura.AutoSize = true;
            this.lblRadioCobertura.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadioCobertura.Location = new System.Drawing.Point(30, 330);
            this.lblRadioCobertura.Name = "lblRadioCobertura";
            this.lblRadioCobertura.Size = new System.Drawing.Size(119, 15);
            this.lblRadioCobertura.TabIndex = 12;
            this.lblRadioCobertura.Text = "Radio de Cobertura";
            // 
            // txtDisponibilidad
            // 
            this.txtDisponibilidad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDisponibilidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDisponibilidad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisponibilidad.Location = new System.Drawing.Point(30, 290);
            this.txtDisponibilidad.Name = "txtDisponibilidad";
            this.txtDisponibilidad.ReadOnly = true;
            this.txtDisponibilidad.Size = new System.Drawing.Size(380, 14);
            this.txtDisponibilidad.TabIndex = 11;
            // 
            // lblDisponibilidad
            // 
            this.lblDisponibilidad.AutoSize = true;
            this.lblDisponibilidad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponibilidad.Location = new System.Drawing.Point(30, 270);
            this.lblDisponibilidad.Name = "lblDisponibilidad";
            this.lblDisponibilidad.Size = new System.Drawing.Size(94, 15);
            this.lblDisponibilidad.TabIndex = 10;
            this.lblDisponibilidad.Text = "Disponibilidad";
            // 
            // txtMoneda
            // 
            this.txtMoneda.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMoneda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda.Location = new System.Drawing.Point(30, 230);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(380, 14);
            this.txtMoneda.TabIndex = 9;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneda.Location = new System.Drawing.Point(30, 210);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(53, 15);
            this.lblMoneda.TabIndex = 8;
            this.lblMoneda.Text = "Moneda";
            // 
            // txtTipoPrecio
            // 
            this.txtTipoPrecio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTipoPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTipoPrecio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoPrecio.Location = new System.Drawing.Point(30, 170);
            this.txtTipoPrecio.Name = "txtTipoPrecio";
            this.txtTipoPrecio.ReadOnly = true;
            this.txtTipoPrecio.Size = new System.Drawing.Size(380, 14);
            this.txtTipoPrecio.TabIndex = 7;
            // 
            // lblTipoPrecio
            // 
            this.lblTipoPrecio.AutoSize = true;
            this.lblTipoPrecio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPrecio.Location = new System.Drawing.Point(30, 150);
            this.lblTipoPrecio.Name = "lblTipoPrecio";
            this.lblTipoPrecio.Size = new System.Drawing.Size(96, 15);
            this.lblTipoPrecio.TabIndex = 6;
            this.lblTipoPrecio.Text = "Tipo de Precio";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(30, 110);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(380, 30);
            this.txtDescripcion.TabIndex = 5;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(30, 90);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(75, 15);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtProveedor
            // 
            this.txtProveedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProveedor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.Location = new System.Drawing.Point(30, 50);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(380, 14);
            this.txtProveedor.TabIndex = 3;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(30, 30);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(63, 15);
            this.lblProveedor.TabIndex = 2;
            this.lblProveedor.Text = "Proveedor";
            // 
            // lblInformacionBasica
            // 
            this.lblInformacionBasica.AutoSize = true;
            this.lblInformacionBasica.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacionBasica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.lblInformacionBasica.Location = new System.Drawing.Point(30, 0);
            this.lblInformacionBasica.Name = "lblInformacionBasica";
            this.lblInformacionBasica.Size = new System.Drawing.Size(157, 19);
            this.lblInformacionBasica.TabIndex = 1;
            this.lblInformacionBasica.Text = "Información Básica";
            // 
            // btnComentario
            // 
            this.btnComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnComentario.FlatAppearance.BorderSize = 0;
            this.btnComentario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComentario.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComentario.ForeColor = System.Drawing.Color.White;
            this.btnComentario.Location = new System.Drawing.Point(300, 490);
            this.btnComentario.Name = "btnComentario";
            this.btnComentario.Size = new System.Drawing.Size(200, 40);
            this.btnComentario.TabIndex = 0;
            this.btnComentario.Text = "Añadir Comentario/Calificación";
            this.btnComentario.UseVisualStyleBackColor = false;
            this.btnComentario.Click += new System.EventHandler(this.btnComentario_Click);
            // 
            // DetalleServicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetalleServicioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle del Servicio";
            this.Load += new System.EventHandler(this.DetalleServicioForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
