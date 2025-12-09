namespace Perfil
{
    partial class PerfilProveedor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDatosPersonales;
        private System.Windows.Forms.TabPage tabExperiencia;

        // Datos Personales
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblWhatsApp;
        private System.Windows.Forms.TextBox txtWhatsApp;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblZonasServicio;
        private System.Windows.Forms.TextBox txtZonasServicio;
        private System.Windows.Forms.Label lblOtroContacto;
        private System.Windows.Forms.TextBox txtOtroContacto;

        // Experiencia
        private System.Windows.Forms.RadioButton rbCertificado;
        private System.Windows.Forms.RadioButton rbEmpirico;
        private System.Windows.Forms.Panel pnlCertificado;
        private System.Windows.Forms.Panel pnlEmpirico;
        private System.Windows.Forms.ComboBox cbNivelEstudios;
        private System.Windows.Forms.Label lblNivelEstudios;
        private System.Windows.Forms.Label lblAnosExperiencia;
        private System.Windows.Forms.TextBox txtAnosExperiencia;
        private System.Windows.Forms.Label lblEmpresasAnteriores;
        private System.Windows.Forms.TextBox txtEmpresasAnteriores;
        private System.Windows.Forms.Label lblProyectosDestacados;
        private System.Windows.Forms.TextBox txtProyectosDestacados;
        private System.Windows.Forms.Label lblReferencias;
        private System.Windows.Forms.TextBox txtReferencias;
        private System.Windows.Forms.Label lblTipoExperiencia;
        private System.Windows.Forms.TextBox txtTipoExperiencia;
        private System.Windows.Forms.Label lblDescripcionOtro;
        private System.Windows.Forms.TextBox txtDescripcionOtro;

        // Botones
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerfilProveedor));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDatosPersonales = new System.Windows.Forms.TabPage();
            this.tabExperiencia = new System.Windows.Forms.TabPage();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblWhatsApp = new System.Windows.Forms.Label();
            this.txtWhatsApp = new System.Windows.Forms.TextBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblZonasServicio = new System.Windows.Forms.Label();
            this.txtZonasServicio = new System.Windows.Forms.TextBox();
            this.lblOtroContacto = new System.Windows.Forms.Label();
            this.txtOtroContacto = new System.Windows.Forms.TextBox();
            this.rbCertificado = new System.Windows.Forms.RadioButton();
            this.rbEmpirico = new System.Windows.Forms.RadioButton();
            this.pnlCertificado = new System.Windows.Forms.Panel();
            this.cbNivelEstudios = new System.Windows.Forms.ComboBox();
            this.lblNivelEstudios = new System.Windows.Forms.Label();
            this.pnlEmpirico = new System.Windows.Forms.Panel();
            this.txtDescripcionOtro = new System.Windows.Forms.TextBox();
            this.lblDescripcionOtro = new System.Windows.Forms.Label();
            this.txtTipoExperiencia = new System.Windows.Forms.TextBox();
            this.lblTipoExperiencia = new System.Windows.Forms.Label();
            this.lblAnosExperiencia = new System.Windows.Forms.Label();
            this.txtAnosExperiencia = new System.Windows.Forms.TextBox();
            this.lblEmpresasAnteriores = new System.Windows.Forms.Label();
            this.txtEmpresasAnteriores = new System.Windows.Forms.TextBox();
            this.lblProyectosDestacados = new System.Windows.Forms.Label();
            this.txtProyectosDestacados = new System.Windows.Forms.TextBox();
            this.lblReferencias = new System.Windows.Forms.Label();
            this.txtReferencias = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabDatosPersonales.SuspendLayout();
            this.tabExperiencia.SuspendLayout();
            this.pnlCertificado.SuspendLayout();
            this.pnlEmpirico.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDatosPersonales);
            this.tabControl1.Controls.Add(this.tabExperiencia);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 400);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDatosPersonales
            // 
            this.tabDatosPersonales.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabDatosPersonales.Controls.Add(this.txtOtroContacto);
            this.tabDatosPersonales.Controls.Add(this.lblOtroContacto);
            this.tabDatosPersonales.Controls.Add(this.txtZonasServicio);
            this.tabDatosPersonales.Controls.Add(this.lblZonasServicio);
            this.tabDatosPersonales.Controls.Add(this.txtDireccion);
            this.tabDatosPersonales.Controls.Add(this.lblDireccion);
            this.tabDatosPersonales.Controls.Add(this.txtCiudad);
            this.tabDatosPersonales.Controls.Add(this.lblCiudad);
            this.tabDatosPersonales.Controls.Add(this.txtWhatsApp);
            this.tabDatosPersonales.Controls.Add(this.lblWhatsApp);
            this.tabDatosPersonales.Controls.Add(this.txtTelefono);
            this.tabDatosPersonales.Controls.Add(this.lblTelefono);
            this.tabDatosPersonales.Controls.Add(this.txtEmail);
            this.tabDatosPersonales.Controls.Add(this.lblEmail);
            this.tabDatosPersonales.Controls.Add(this.txtApellidos);
            this.tabDatosPersonales.Controls.Add(this.lblApellidos);
            this.tabDatosPersonales.Controls.Add(this.txtNombres);
            this.tabDatosPersonales.Controls.Add(this.lblNombres);
            this.tabDatosPersonales.Location = new System.Drawing.Point(4, 22);
            this.tabDatosPersonales.Name = "tabDatosPersonales";
            this.tabDatosPersonales.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatosPersonales.Size = new System.Drawing.Size(592, 374);
            this.tabDatosPersonales.TabIndex = 0;
            this.tabDatosPersonales.Text = "Datos Personales";
            // 
            // tabExperiencia
            // 
            this.tabExperiencia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabExperiencia.Controls.Add(this.txtReferencias);
            this.tabExperiencia.Controls.Add(this.lblReferencias);
            this.tabExperiencia.Controls.Add(this.txtProyectosDestacados);
            this.tabExperiencia.Controls.Add(this.lblProyectosDestacados);
            this.tabExperiencia.Controls.Add(this.txtEmpresasAnteriores);
            this.tabExperiencia.Controls.Add(this.lblEmpresasAnteriores);
            this.tabExperiencia.Controls.Add(this.txtAnosExperiencia);
            this.tabExperiencia.Controls.Add(this.lblAnosExperiencia);
            this.tabExperiencia.Controls.Add(this.pnlEmpirico);
            this.tabExperiencia.Controls.Add(this.pnlCertificado);
            this.tabExperiencia.Controls.Add(this.rbEmpirico);
            this.tabExperiencia.Controls.Add(this.rbCertificado);
            this.tabExperiencia.Location = new System.Drawing.Point(4, 22);
            this.tabExperiencia.Name = "tabExperiencia";
            this.tabExperiencia.Padding = new System.Windows.Forms.Padding(3);
            this.tabExperiencia.Size = new System.Drawing.Size(592, 374);
            this.tabExperiencia.TabIndex = 1;
            this.tabExperiencia.Text = "Experiencia Profesional";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombres.Location = new System.Drawing.Point(30, 30);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(74, 17);
            this.lblNombres.TabIndex = 0;
            this.lblNombres.Text = "Nombres:";
            // 
            // txtNombres
            // 
            this.txtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtNombres.Location = new System.Drawing.Point(150, 27);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(250, 23);
            this.txtNombres.TabIndex = 1;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblApellidos.Location = new System.Drawing.Point(30, 70);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(74, 17);
            this.lblApellidos.TabIndex = 2;
            this.lblApellidos.Text = "Apellidos:";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtApellidos.Location = new System.Drawing.Point(150, 67);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(250, 23);
            this.txtApellidos.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(30, 110);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 17);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtEmail.Location = new System.Drawing.Point(150, 107);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 23);
            this.txtEmail.TabIndex = 5;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.Location = new System.Drawing.Point(30, 150);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(76, 17);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTelefono.Location = new System.Drawing.Point(150, 147);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 23);
            this.txtTelefono.TabIndex = 7;
            // 
            // lblWhatsApp
            // 
            this.lblWhatsApp.AutoSize = true;
            this.lblWhatsApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblWhatsApp.Location = new System.Drawing.Point(30, 190);
            this.lblWhatsApp.Name = "lblWhatsApp";
            this.lblWhatsApp.Size = new System.Drawing.Size(84, 17);
            this.lblWhatsApp.TabIndex = 8;
            this.lblWhatsApp.Text = "WhatsApp:";
            // 
            // txtWhatsApp
            // 
            this.txtWhatsApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtWhatsApp.Location = new System.Drawing.Point(150, 187);
            this.txtWhatsApp.Name = "txtWhatsApp";
            this.txtWhatsApp.Size = new System.Drawing.Size(200, 23);
            this.txtWhatsApp.TabIndex = 9;
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCiudad.Location = new System.Drawing.Point(30, 230);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(64, 17);
            this.lblCiudad.TabIndex = 10;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCiudad.Location = new System.Drawing.Point(150, 227);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(200, 23);
            this.txtCiudad.TabIndex = 11;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblDireccion.Location = new System.Drawing.Point(30, 270);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(79, 17);
            this.lblDireccion.TabIndex = 12;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDireccion.Location = new System.Drawing.Point(150, 267);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(300, 23);
            this.txtDireccion.TabIndex = 13;
            // 
            // lblZonasServicio
            // 
            this.lblZonasServicio.AutoSize = true;
            this.lblZonasServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblZonasServicio.Location = new System.Drawing.Point(30, 310);
            this.lblZonasServicio.Name = "lblZonasServicio";
            this.lblZonasServicio.Size = new System.Drawing.Size(115, 17);
            this.lblZonasServicio.TabIndex = 14;
            this.lblZonasServicio.Text = "Zonas Servicio:";
            // 
            // txtZonasServicio
            // 
            this.txtZonasServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtZonasServicio.Location = new System.Drawing.Point(150, 307);
            this.txtZonasServicio.Multiline = true;
            this.txtZonasServicio.Name = "txtZonasServicio";
            this.txtZonasServicio.Size = new System.Drawing.Size(300, 50);
            this.txtZonasServicio.TabIndex = 15;
            // 
            // lblOtroContacto
            // 
            this.lblOtroContacto.AutoSize = true;
            this.lblOtroContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblOtroContacto.Location = new System.Drawing.Point(400, 30);
            this.lblOtroContacto.Name = "lblOtroContacto";
            this.lblOtroContacto.Size = new System.Drawing.Size(114, 17);
            this.lblOtroContacto.TabIndex = 16;
            this.lblOtroContacto.Text = "Otro Contacto:";
            // 
            // txtOtroContacto
            // 
            this.txtOtroContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtOtroContacto.Location = new System.Drawing.Point(520, 27);
            this.txtOtroContacto.Name = "txtOtroContacto";
            this.txtOtroContacto.Size = new System.Drawing.Size(200, 23);
            this.txtOtroContacto.TabIndex = 17;
            // 
            // rbCertificado
            // 
            this.rbCertificado.AutoSize = true;
            this.rbCertificado.Checked = true;
            this.rbCertificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.rbCertificado.Location = new System.Drawing.Point(30, 30);
            this.rbCertificado.Name = "rbCertificado";
            this.rbCertificado.Size = new System.Drawing.Size(192, 21);
            this.rbCertificado.TabIndex = 0;
            this.rbCertificado.TabStop = true;
            this.rbCertificado.Text = "Profesional Certificado";
            this.rbCertificado.UseVisualStyleBackColor = true;
            this.rbCertificado.CheckedChanged += new System.EventHandler(this.rbCertificado_CheckedChanged);
            // 
            // rbEmpirico
            // 
            this.rbEmpirico.AutoSize = true;
            this.rbEmpirico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.rbEmpirico.Location = new System.Drawing.Point(30, 70);
            this.rbEmpirico.Name = "rbEmpirico";
            this.rbEmpirico.Size = new System.Drawing.Size(161, 21);
            this.rbEmpirico.TabIndex = 1;
            this.rbEmpirico.Text = "Experiencia Empírica";
            this.rbEmpirico.UseVisualStyleBackColor = true;
            this.rbEmpirico.CheckedChanged += new System.EventHandler(this.rbEmpirico_CheckedChanged);
            // 
            // pnlCertificado
            // 
            this.pnlCertificado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCertificado.Controls.Add(this.cbNivelEstudios);
            this.pnlCertificado.Controls.Add(this.lblNivelEstudios);
            this.pnlCertificado.Location = new System.Drawing.Point(250, 20);
            this.pnlCertificado.Name = "pnlCertificado";
            this.pnlCertificado.Size = new System.Drawing.Size(320, 80);
            this.pnlCertificado.TabIndex = 2;
            this.pnlCertificado.Visible = true;
            // 
            // cbNivelEstudios
            // 
            this.cbNivelEstudios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNivelEstudios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbNivelEstudios.FormattingEnabled = true;
            this.cbNivelEstudios.Location = new System.Drawing.Point(150, 30);
            this.cbNivelEstudios.Name = "cbNivelEstudios";
            this.cbNivelEstudios.Size = new System.Drawing.Size(150, 24);
            this.cbNivelEstudios.TabIndex = 1;
            // 
            // lblNivelEstudios
            // 
            this.lblNivelEstudios.AutoSize = true;
            this.lblNivelEstudios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblNivelEstudios.Location = new System.Drawing.Point(20, 33);
            this.lblNivelEstudios.Name = "lblNivelEstudios";
            this.lblNivelEstudios.Size = new System.Drawing.Size(124, 17);
            this.lblNivelEstudios.TabIndex = 0;
            this.lblNivelEstudios.Text = "Nivel de Estudios:";
            // 
            // pnlEmpirico
            // 
            this.pnlEmpirico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEmpirico.Controls.Add(this.txtDescripcionOtro);
            this.pnlEmpirico.Controls.Add(this.lblDescripcionOtro);
            this.pnlEmpirico.Controls.Add(this.txtTipoExperiencia);
            this.pnlEmpirico.Controls.Add(this.lblTipoExperiencia);
            this.pnlEmpirico.Location = new System.Drawing.Point(250, 20);
            this.pnlEmpirico.Name = "pnlEmpirico";
            this.pnlEmpirico.Size = new System.Drawing.Size(320, 150);
            this.pnlEmpirico.TabIndex = 3;
            this.pnlEmpirico.Visible = false;
            // 
            // txtDescripcionOtro
            // 
            this.txtDescripcionOtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtDescripcionOtro.Location = new System.Drawing.Point(150, 80);
            this.txtDescripcionOtro.Multiline = true;
            this.txtDescripcionOtro.Name = "txtDescripcionOtro";
            this.txtDescripcionOtro.Size = new System.Drawing.Size(150, 50);
            this.txtDescripcionOtro.TabIndex = 3;
            // 
            // lblDescripcionOtro
            // 
            this.lblDescripcionOtro.AutoSize = true;
            this.lblDescripcionOtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescripcionOtro.Location = new System.Drawing.Point(20, 83);
            this.lblDescripcionOtro.Name = "lblDescripcionOtro";
            this.lblDescripcionOtro.Size = new System.Drawing.Size(119, 17);
            this.lblDescripcionOtro.TabIndex = 2;
            this.lblDescripcionOtro.Text = "Descripción otro:";
            // 
            // txtTipoExperiencia
            // 
            this.txtTipoExperiencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTipoExperiencia.Location = new System.Drawing.Point(150, 30);
            this.txtTipoExperiencia.Name = "txtTipoExperiencia";
            this.txtTipoExperiencia.Size = new System.Drawing.Size(150, 23);
            this.txtTipoExperiencia.TabIndex = 1;
            // 
            // lblTipoExperiencia
            // 
            this.lblTipoExperiencia.AutoSize = true;
            this.lblTipoExperiencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipoExperiencia.Location = new System.Drawing.Point(20, 33);
            this.lblTipoExperiencia.Name = "lblTipoExperiencia";
            this.lblTipoExperiencia.Size = new System.Drawing.Size(125, 17);
            this.lblTipoExperiencia.TabIndex = 0;
            this.lblTipoExperiencia.Text = "Tipo Experiencia:";
            // 
            // lblAnosExperiencia
            // 
            this.lblAnosExperiencia.AutoSize = true;
            this.lblAnosExperiencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblAnosExperiencia.Location = new System.Drawing.Point(30, 180);
            this.lblAnosExperiencia.Name = "lblAnosExperiencia";
            this.lblAnosExperiencia.Size = new System.Drawing.Size(148, 17);
            this.lblAnosExperiencia.TabIndex = 4;
            this.lblAnosExperiencia.Text = "Años de Experiencia:";
            // 
            // txtAnosExperiencia
            // 
            this.txtAnosExperiencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAnosExperiencia.Location = new System.Drawing.Point(200, 177);
            this.txtAnosExperiencia.Name = "txtAnosExperiencia";
            this.txtAnosExperiencia.Size = new System.Drawing.Size(100, 23);
            this.txtAnosExperiencia.TabIndex = 5;
            // 
            // lblEmpresasAnteriores
            // 
            this.lblEmpresasAnteriores.AutoSize = true;
            this.lblEmpresasAnteriores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmpresasAnteriores.Location = new System.Drawing.Point(30, 230);
            this.lblEmpresasAnteriores.Name = "lblEmpresasAnteriores";
            this.lblEmpresasAnteriores.Size = new System.Drawing.Size(155, 17);
            this.lblEmpresasAnteriores.TabIndex = 6;
            this.lblEmpresasAnteriores.Text = "Empresas Anteriores:";
            // 
            // txtEmpresasAnteriores
            // 
            this.txtEmpresasAnteriores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtEmpresasAnteriores.Location = new System.Drawing.Point(200, 227);
            this.txtEmpresasAnteriores.Multiline = true;
            this.txtEmpresasAnteriores.Name = "txtEmpresasAnteriores";
            this.txtEmpresasAnteriores.Size = new System.Drawing.Size(350, 50);
            this.txtEmpresasAnteriores.TabIndex = 7;
            // 
            // lblProyectosDestacados
            // 
            this.lblProyectosDestacados.AutoSize = true;
            this.lblProyectosDestacados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblProyectosDestacados.Location = new System.Drawing.Point(30, 290);
            this.lblProyectosDestacados.Name = "lblProyectosDestacados";
            this.lblProyectosDestacados.Size = new System.Drawing.Size(164, 17);
            this.lblProyectosDestacados.TabIndex = 8;
            this.lblProyectosDestacados.Text = "Proyectos Destacados:";
            // 
            // txtProyectosDestacados
            // 
            this.txtProyectosDestacados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtProyectosDestacados.Location = new System.Drawing.Point(200, 287);
            this.txtProyectosDestacados.Multiline = true;
            this.txtProyectosDestacados.Name = "txtProyectosDestacados";
            this.txtProyectosDestacados.Size = new System.Drawing.Size(350, 50);
            this.txtProyectosDestacados.TabIndex = 9;
            // 
            // lblReferencias
            // 
            this.lblReferencias.AutoSize = true;
            this.lblReferencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblReferencias.Location = new System.Drawing.Point(30, 350);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(139, 17);
            this.lblReferencias.TabIndex = 10;
            this.lblReferencias.Text = "Referencias Laborales:";
            // 
            // txtReferencias
            // 
            this.txtReferencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtReferencias.Location = new System.Drawing.Point(200, 347);
            this.txtReferencias.Multiline = true;
            this.txtReferencias.Name = "txtReferencias";
            this.txtReferencias.Size = new System.Drawing.Size(350, 50);
            this.txtReferencias.TabIndex = 11;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(350, 410);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 40);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Silver;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCancelar.Location = new System.Drawing.Point(480, 410);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // PerfilProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerfilProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Datos de Proveedor";
            this.Load += new System.EventHandler(this.EditarDatosProveedorForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDatosPersonales.ResumeLayout(false);
            this.tabDatosPersonales.PerformLayout();
            this.tabExperiencia.ResumeLayout(false);
            this.tabExperiencia.PerformLayout();
            this.pnlCertificado.ResumeLayout(false);
            this.pnlCertificado.PerformLayout();
            this.pnlEmpirico.ResumeLayout(false);
            this.pnlEmpirico.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}