// DetallesRegistroTempForm.Designer.cs
namespace DetallesRegistroTemp
{
    partial class DetallesRegistroTempForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBasicos;
        private System.Windows.Forms.TabPage tabPageCertificaciones;
        private System.Windows.Forms.TabPage tabPageExperiencia;
        private System.Windows.Forms.TabPage tabPageEspecialidades;
        private System.Windows.Forms.TabPage tabPageArchivos;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnDescargarArchivo;
        private System.Windows.Forms.DataGridView dgvArchivos;

        // Controles básicos
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblZonas;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.Label lblFechaModificacion;

        // Controles certificaciones
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblNivelEstudios;
        private System.Windows.Forms.Label lblAnosExperiencia;
        private System.Windows.Forms.Label lblEmpresas;
        private System.Windows.Forms.Label lblProyectos;
        private System.Windows.Forms.Label lblReferencias;
        private System.Windows.Forms.Label lblFechaCert;
        private System.Windows.Forms.TextBox txtEmpresas;
        private System.Windows.Forms.TextBox txtProyectos;
        private System.Windows.Forms.TextBox txtReferencias;

        // Controles experiencia empírica
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblExpAnos;
        private System.Windows.Forms.Label lblTipoExp;
        private System.Windows.Forms.Label lblDescripcionOtro;
        private System.Windows.Forms.Label lblFechaExp;
        private System.Windows.Forms.TextBox txtDescripcionOtro;

        // Controles especialidades
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblCategorias;
        private System.Windows.Forms.Label lblSubEspecialidades;
        private System.Windows.Forms.Label lblHerramientas;
        private System.Windows.Forms.Label lblDescripcionServicios;
        private System.Windows.Forms.Label lblFechaEsp;
        private System.Windows.Forms.TextBox txtDescripcionServicios;

        // Controles archivos
        private System.Windows.Forms.Label lblTotalArchivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Archivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tamanio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obligatorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Creacion;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBasicos = new System.Windows.Forms.TabPage();
            this.lblFechaModificacion = new System.Windows.Forms.Label();
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblZonas = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageCertificaciones = new System.Windows.Forms.TabPage();
            this.txtReferencias = new System.Windows.Forms.TextBox();
            this.txtProyectos = new System.Windows.Forms.TextBox();
            this.txtEmpresas = new System.Windows.Forms.TextBox();
            this.lblFechaCert = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblReferencias = new System.Windows.Forms.Label();
            this.lblProyectos = new System.Windows.Forms.Label();
            this.lblEmpresas = new System.Windows.Forms.Label();
            this.lblAnosExperiencia = new System.Windows.Forms.Label();
            this.lblNivelEstudios = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPageExperiencia = new System.Windows.Forms.TabPage();
            this.txtDescripcionOtro = new System.Windows.Forms.TextBox();
            this.lblFechaExp = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblDescripcionOtro = new System.Windows.Forms.Label();
            this.lblTipoExp = new System.Windows.Forms.Label();
            this.lblExpAnos = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPageEspecialidades = new System.Windows.Forms.TabPage();
            this.txtDescripcionServicios = new System.Windows.Forms.TextBox();
            this.lblFechaEsp = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblDescripcionServicios = new System.Windows.Forms.Label();
            this.lblHerramientas = new System.Windows.Forms.Label();
            this.lblSubEspecialidades = new System.Windows.Forms.Label();
            this.lblCategorias = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPageArchivos = new System.Windows.Forms.TabPage();
            this.lblTotalArchivos = new System.Windows.Forms.Label();
            this.dgvArchivos = new System.Windows.Forms.DataGridView();
            this.ID_Archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tamanio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obligatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDescargarArchivo = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageBasicos.SuspendLayout();
            this.tabPageCertificaciones.SuspendLayout();
            this.tabPageExperiencia.SuspendLayout();
            this.tabPageEspecialidades.SuspendLayout();
            this.tabPageArchivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageBasicos);
            this.tabControl1.Controls.Add(this.tabPageCertificaciones);
            this.tabControl1.Controls.Add(this.tabPageExperiencia);
            this.tabControl1.Controls.Add(this.tabPageEspecialidades);
            this.tabControl1.Controls.Add(this.tabPageArchivos);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageBasicos
            // 
            this.tabPageBasicos.Controls.Add(this.lblFechaModificacion);
            this.tabPageBasicos.Controls.Add(this.lblFechaCreacion);
            this.tabPageBasicos.Controls.Add(this.lblEstado);
            this.tabPageBasicos.Controls.Add(this.lblZonas);
            this.tabPageBasicos.Controls.Add(this.lblDireccion);
            this.tabPageBasicos.Controls.Add(this.lblCiudad);
            this.tabPageBasicos.Controls.Add(this.lblTelefono);
            this.tabPageBasicos.Controls.Add(this.lblEmail);
            this.tabPageBasicos.Controls.Add(this.lblApellidos);
            this.tabPageBasicos.Controls.Add(this.lblNombres);
            this.tabPageBasicos.Controls.Add(this.lblUsername);
            this.tabPageBasicos.Controls.Add(this.label11);
            this.tabPageBasicos.Controls.Add(this.label10);
            this.tabPageBasicos.Controls.Add(this.label9);
            this.tabPageBasicos.Controls.Add(this.label8);
            this.tabPageBasicos.Controls.Add(this.label7);
            this.tabPageBasicos.Controls.Add(this.label6);
            this.tabPageBasicos.Controls.Add(this.label5);
            this.tabPageBasicos.Controls.Add(this.label4);
            this.tabPageBasicos.Controls.Add(this.label3);
            this.tabPageBasicos.Controls.Add(this.label2);
            this.tabPageBasicos.Controls.Add(this.label1);
            this.tabPageBasicos.Location = new System.Drawing.Point(4, 22);
            this.tabPageBasicos.Name = "tabPageBasicos";
            this.tabPageBasicos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasicos.Size = new System.Drawing.Size(752, 474);
            this.tabPageBasicos.TabIndex = 0;
            this.tabPageBasicos.Text = "Datos Básicos";
            this.tabPageBasicos.UseVisualStyleBackColor = true;
            // 
            // lblFechaModificacion
            // 
            this.lblFechaModificacion.AutoSize = true;
            this.lblFechaModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaModificacion.Location = new System.Drawing.Point(150, 400);
            this.lblFechaModificacion.Name = "lblFechaModificacion";
            this.lblFechaModificacion.Size = new System.Drawing.Size(41, 15);
            this.lblFechaModificacion.TabIndex = 20;
            this.lblFechaModificacion.Text = "label12";
            // 
            // lblFechaCreacion
            // 
            this.lblFechaCreacion.AutoSize = true;
            this.lblFechaCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCreacion.Location = new System.Drawing.Point(150, 370);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(41, 15);
            this.lblFechaCreacion.TabIndex = 19;
            this.lblFechaCreacion.Text = "label12";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(150, 340);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(47, 15);
            this.lblEstado.TabIndex = 18;
            this.lblEstado.Text = "label12";
            // 
            // lblZonas
            // 
            this.lblZonas.AutoSize = true;
            this.lblZonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZonas.Location = new System.Drawing.Point(150, 310);
            this.lblZonas.Name = "lblZonas";
            this.lblZonas.Size = new System.Drawing.Size(41, 15);
            this.lblZonas.TabIndex = 17;
            this.lblZonas.Text = "label12";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(150, 280);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(41, 15);
            this.lblDireccion.TabIndex = 16;
            this.lblDireccion.Text = "label12";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiudad.Location = new System.Drawing.Point(150, 250);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(41, 15);
            this.lblCiudad.TabIndex = 15;
            this.lblCiudad.Text = "label12";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(150, 220);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(41, 15);
            this.lblTelefono.TabIndex = 14;
            this.lblTelefono.Text = "label12";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(150, 190);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 15);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "label12";
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidos.Location = new System.Drawing.Point(150, 160);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(41, 15);
            this.lblApellidos.TabIndex = 12;
            this.lblApellidos.Text = "label12";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.Location = new System.Drawing.Point(150, 130);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(41, 15);
            this.lblNombres.TabIndex = 11;
            this.lblNombres.Text = "label12";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(150, 100);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(47, 15);
            this.lblUsername.TabIndex = 10;
            this.lblUsername.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 400);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "Fecha Modificación:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 370);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Fecha Creación:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 340);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Estado:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Zonas Servicio:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Dirección:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ciudad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Teléfono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Apellidos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombres:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // tabPageCertificaciones
            // 
            this.tabPageCertificaciones.Controls.Add(this.txtReferencias);
            this.tabPageCertificaciones.Controls.Add(this.txtProyectos);
            this.tabPageCertificaciones.Controls.Add(this.txtEmpresas);
            this.tabPageCertificaciones.Controls.Add(this.lblFechaCert);
            this.tabPageCertificaciones.Controls.Add(this.label17);
            this.tabPageCertificaciones.Controls.Add(this.lblReferencias);
            this.tabPageCertificaciones.Controls.Add(this.lblProyectos);
            this.tabPageCertificaciones.Controls.Add(this.lblEmpresas);
            this.tabPageCertificaciones.Controls.Add(this.lblAnosExperiencia);
            this.tabPageCertificaciones.Controls.Add(this.lblNivelEstudios);
            this.tabPageCertificaciones.Controls.Add(this.label16);
            this.tabPageCertificaciones.Controls.Add(this.label15);
            this.tabPageCertificaciones.Controls.Add(this.label14);
            this.tabPageCertificaciones.Controls.Add(this.label13);
            this.tabPageCertificaciones.Controls.Add(this.label12);
            this.tabPageCertificaciones.Location = new System.Drawing.Point(4, 22);
            this.tabPageCertificaciones.Name = "tabPageCertificaciones";
            this.tabPageCertificaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCertificaciones.Size = new System.Drawing.Size(752, 474);
            this.tabPageCertificaciones.TabIndex = 1;
            this.tabPageCertificaciones.Text = "Certificaciones";
            this.tabPageCertificaciones.UseVisualStyleBackColor = true;
            // 
            // txtReferencias
            // 
            this.txtReferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReferencias.Location = new System.Drawing.Point(150, 250);
            this.txtReferencias.Multiline = true;
            this.txtReferencias.Name = "txtReferencias";
            this.txtReferencias.ReadOnly = true;
            this.txtReferencias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReferencias.Size = new System.Drawing.Size(580, 100);
            this.txtReferencias.TabIndex = 14;
            // 
            // txtProyectos
            // 
            this.txtProyectos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProyectos.Location = new System.Drawing.Point(150, 190);
            this.txtProyectos.Multiline = true;
            this.txtProyectos.Name = "txtProyectos";
            this.txtProyectos.ReadOnly = true;
            this.txtProyectos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProyectos.Size = new System.Drawing.Size(580, 50);
            this.txtProyectos.TabIndex = 13;
            // 
            // txtEmpresas
            // 
            this.txtEmpresas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpresas.Location = new System.Drawing.Point(150, 130);
            this.txtEmpresas.Multiline = true;
            this.txtEmpresas.Name = "txtEmpresas";
            this.txtEmpresas.ReadOnly = true;
            this.txtEmpresas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmpresas.Size = new System.Drawing.Size(580, 50);
            this.txtEmpresas.TabIndex = 12;
            // 
            // lblFechaCert
            // 
            this.lblFechaCert.AutoSize = true;
            this.lblFechaCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCert.Location = new System.Drawing.Point(150, 360);
            this.lblFechaCert.Name = "lblFechaCert";
            this.lblFechaCert.Size = new System.Drawing.Size(41, 15);
            this.lblFechaCert.TabIndex = 11;
            this.lblFechaCert.Text = "label12";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(20, 360);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 15);
            this.label17.TabIndex = 10;
            this.label17.Text = "Fecha Creación:";
            // 
            // lblReferencias
            // 
            this.lblReferencias.AutoSize = true;
            this.lblReferencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencias.Location = new System.Drawing.Point(20, 250);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(86, 15);
            this.lblReferencias.TabIndex = 8;
            this.lblReferencias.Text = "Referencias:";
            // 
            // lblProyectos
            // 
            this.lblProyectos.AutoSize = true;
            this.lblProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProyectos.Location = new System.Drawing.Point(20, 190);
            this.lblProyectos.Name = "lblProyectos";
            this.lblProyectos.Size = new System.Drawing.Size(73, 15);
            this.lblProyectos.TabIndex = 6;
            this.lblProyectos.Text = "Proyectos:";
            // 
            // lblEmpresas
            // 
            this.lblEmpresas.AutoSize = true;
            this.lblEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresas.Location = new System.Drawing.Point(20, 130);
            this.lblEmpresas.Name = "lblEmpresas";
            this.lblEmpresas.Size = new System.Drawing.Size(73, 15);
            this.lblEmpresas.TabIndex = 4;
            this.lblEmpresas.Text = "Empresas:";
            // 
            // lblAnosExperiencia
            // 
            this.lblAnosExperiencia.AutoSize = true;
            this.lblAnosExperiencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnosExperiencia.Location = new System.Drawing.Point(150, 70);
            this.lblAnosExperiencia.Name = "lblAnosExperiencia";
            this.lblAnosExperiencia.Size = new System.Drawing.Size(41, 15);
            this.lblAnosExperiencia.TabIndex = 3;
            this.lblAnosExperiencia.Text = "label12";
            // 
            // lblNivelEstudios
            // 
            this.lblNivelEstudios.AutoSize = true;
            this.lblNivelEstudios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelEstudios.Location = new System.Drawing.Point(150, 40);
            this.lblNivelEstudios.Name = "lblNivelEstudios";
            this.lblNivelEstudios.Size = new System.Drawing.Size(41, 15);
            this.lblNivelEstudios.TabIndex = 2;
            this.lblNivelEstudios.Text = "label12";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(20, 70);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(124, 15);
            this.label16.TabIndex = 1;
            this.label16.Text = "Años Experiencia:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(20, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Nivel Estudios:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(20, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 15);
            this.label14.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 15);
            this.label13.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 15);
            this.label12.TabIndex = 0;
            // 
            // tabPageExperiencia
            // 
            this.tabPageExperiencia.Controls.Add(this.txtDescripcionOtro);
            this.tabPageExperiencia.Controls.Add(this.lblFechaExp);
            this.tabPageExperiencia.Controls.Add(this.label21);
            this.tabPageExperiencia.Controls.Add(this.lblDescripcionOtro);
            this.tabPageExperiencia.Controls.Add(this.lblTipoExp);
            this.tabPageExperiencia.Controls.Add(this.lblExpAnos);
            this.tabPageExperiencia.Controls.Add(this.label20);
            this.tabPageExperiencia.Controls.Add(this.label19);
            this.tabPageExperiencia.Controls.Add(this.label18);
            this.tabPageExperiencia.Location = new System.Drawing.Point(4, 22);
            this.tabPageExperiencia.Name = "tabPageExperiencia";
            this.tabPageExperiencia.Size = new System.Drawing.Size(752, 474);
            this.tabPageExperiencia.TabIndex = 2;
            this.tabPageExperiencia.Text = "Experiencia Empírica";
            this.tabPageExperiencia.UseVisualStyleBackColor = true;
            // 
            // txtDescripcionOtro
            // 
            this.txtDescripcionOtro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcionOtro.Location = new System.Drawing.Point(150, 130);
            this.txtDescripcionOtro.Multiline = true;
            this.txtDescripcionOtro.Name = "txtDescripcionOtro";
            this.txtDescripcionOtro.ReadOnly = true;
            this.txtDescripcionOtro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionOtro.Size = new System.Drawing.Size(580, 200);
            this.txtDescripcionOtro.TabIndex = 8;
            // 
            // lblFechaExp
            // 
            this.lblFechaExp.AutoSize = true;
            this.lblFechaExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaExp.Location = new System.Drawing.Point(150, 350);
            this.lblFechaExp.Name = "lblFechaExp";
            this.lblFechaExp.Size = new System.Drawing.Size(41, 15);
            this.lblFechaExp.TabIndex = 7;
            this.lblFechaExp.Text = "label12";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(20, 350);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(108, 15);
            this.label21.TabIndex = 6;
            this.label21.Text = "Fecha Creación:";
            // 
            // lblDescripcionOtro
            // 
            this.lblDescripcionOtro.AutoSize = true;
            this.lblDescripcionOtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionOtro.Location = new System.Drawing.Point(20, 130);
            this.lblDescripcionOtro.Name = "lblDescripcionOtro";
            this.lblDescripcionOtro.Size = new System.Drawing.Size(124, 15);
            this.lblDescripcionOtro.TabIndex = 4;
            this.lblDescripcionOtro.Text = "Descripción (Otro):";
            // 
            // lblTipoExp
            // 
            this.lblTipoExp.AutoSize = true;
            this.lblTipoExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoExp.Location = new System.Drawing.Point(150, 70);
            this.lblTipoExp.Name = "lblTipoExp";
            this.lblTipoExp.Size = new System.Drawing.Size(41, 15);
            this.lblTipoExp.TabIndex = 3;
            this.lblTipoExp.Text = "label12";
            // 
            // lblExpAnos
            // 
            this.lblExpAnos.AutoSize = true;
            this.lblExpAnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpAnos.Location = new System.Drawing.Point(150, 40);
            this.lblExpAnos.Name = "lblExpAnos";
            this.lblExpAnos.Size = new System.Drawing.Size(41, 15);
            this.lblExpAnos.TabIndex = 2;
            this.lblExpAnos.Text = "label12";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(20, 70);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(121, 15);
            this.label20.TabIndex = 1;
            this.label20.Text = "Tipo Experiencia:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(20, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 15);
            this.label19.TabIndex = 0;
            this.label19.Text = "Años Experiencia:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(20, 100);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 15);
            this.label18.TabIndex = 0;
            // 
            // tabPageEspecialidades
            // 
            this.tabPageEspecialidades.Controls.Add(this.txtDescripcionServicios);
            this.tabPageEspecialidades.Controls.Add(this.lblFechaEsp);
            this.tabPageEspecialidades.Controls.Add(this.label26);
            this.tabPageEspecialidades.Controls.Add(this.lblDescripcionServicios);
            this.tabPageEspecialidades.Controls.Add(this.lblHerramientas);
            this.tabPageEspecialidades.Controls.Add(this.lblSubEspecialidades);
            this.tabPageEspecialidades.Controls.Add(this.lblCategorias);
            this.tabPageEspecialidades.Controls.Add(this.label25);
            this.tabPageEspecialidades.Controls.Add(this.label24);
            this.tabPageEspecialidades.Controls.Add(this.label23);
            this.tabPageEspecialidades.Controls.Add(this.label22);
            this.tabPageEspecialidades.Location = new System.Drawing.Point(4, 22);
            this.tabPageEspecialidades.Name = "tabPageEspecialidades";
            this.tabPageEspecialidades.Size = new System.Drawing.Size(752, 474);
            this.tabPageEspecialidades.TabIndex = 3;
            this.tabPageEspecialidades.Text = "Especialidades";
            this.tabPageEspecialidades.UseVisualStyleBackColor = true;
            // 
            // txtDescripcionServicios
            // 
            this.txtDescripcionServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcionServicios.Location = new System.Drawing.Point(150, 190);
            this.txtDescripcionServicios.Multiline = true;
            this.txtDescripcionServicios.Name = "txtDescripcionServicios";
            this.txtDescripcionServicios.ReadOnly = true;
            this.txtDescripcionServicios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionServicios.Size = new System.Drawing.Size(580, 150);
            this.txtDescripcionServicios.TabIndex = 10;
            // 
            // lblFechaEsp
            // 
            this.lblFechaEsp.AutoSize = true;
            this.lblFechaEsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEsp.Location = new System.Drawing.Point(150, 360);
            this.lblFechaEsp.Name = "lblFechaEsp";
            this.lblFechaEsp.Size = new System.Drawing.Size(41, 15);
            this.lblFechaEsp.TabIndex = 9;
            this.lblFechaEsp.Text = "label12";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(20, 360);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(108, 15);
            this.label26.TabIndex = 8;
            this.label26.Text = "Fecha Creación:";
            // 
            // lblDescripcionServicios
            // 
            this.lblDescripcionServicios.AutoSize = true;
            this.lblDescripcionServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionServicios.Location = new System.Drawing.Point(20, 190);
            this.lblDescripcionServicios.Name = "lblDescripcionServicios";
            this.lblDescripcionServicios.Size = new System.Drawing.Size(124, 15);
            this.lblDescripcionServicios.TabIndex = 6;
            this.lblDescripcionServicios.Text = "Descripción (Otro):";
            // 
            // lblHerramientas
            // 
            this.lblHerramientas.AutoSize = true;
            this.lblHerramientas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHerramientas.Location = new System.Drawing.Point(150, 130);
            this.lblHerramientas.Name = "lblHerramientas";
            this.lblHerramientas.Size = new System.Drawing.Size(41, 15);
            this.lblHerramientas.TabIndex = 5;
            this.lblHerramientas.Text = "label12";
            // 
            // lblSubEspecialidades
            // 
            this.lblSubEspecialidades.AutoSize = true;
            this.lblSubEspecialidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubEspecialidades.Location = new System.Drawing.Point(150, 100);
            this.lblSubEspecialidades.Name = "lblSubEspecialidades";
            this.lblSubEspecialidades.Size = new System.Drawing.Size(41, 15);
            this.lblSubEspecialidades.TabIndex = 4;
            this.lblSubEspecialidades.Text = "label12";
            // 
            // lblCategorias
            // 
            this.lblCategorias.AutoSize = true;
            this.lblCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategorias.Location = new System.Drawing.Point(150, 70);
            this.lblCategorias.Name = "lblCategorias";
            this.lblCategorias.Size = new System.Drawing.Size(41, 15);
            this.lblCategorias.TabIndex = 3;
            this.lblCategorias.Text = "label12";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(20, 130);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(96, 15);
            this.label25.TabIndex = 2;
            this.label25.Text = "Herramientas:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(20, 100);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(124, 15);
            this.label24.TabIndex = 1;
            this.label24.Text = "Sub-Especialidades:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(20, 70);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 15);
            this.label23.TabIndex = 0;
            this.label23.Text = "Categorías:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(20, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 15);
            this.label22.TabIndex = 0;
            // 
            // tabPageArchivos
            // 
            this.tabPageArchivos.Controls.Add(this.lblTotalArchivos);
            this.tabPageArchivos.Controls.Add(this.dgvArchivos);
            this.tabPageArchivos.Controls.Add(this.btnDescargarArchivo);
            this.tabPageArchivos.Location = new System.Drawing.Point(4, 22);
            this.tabPageArchivos.Name = "tabPageArchivos";
            this.tabPageArchivos.Size = new System.Drawing.Size(752, 474);
            this.tabPageArchivos.TabIndex = 4;
            this.tabPageArchivos.Text = "Archivos";
            this.tabPageArchivos.UseVisualStyleBackColor = true;
            // 
            // lblTotalArchivos
            // 
            this.lblTotalArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalArchivos.AutoSize = true;
            this.lblTotalArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArchivos.Location = new System.Drawing.Point(600, 20);
            this.lblTotalArchivos.Name = "lblTotalArchivos";
            this.lblTotalArchivos.Size = new System.Drawing.Size(110, 15);
            this.lblTotalArchivos.TabIndex = 2;
            this.lblTotalArchivos.Text = "Total archivos: 0";
            // 
            // dgvArchivos
            // 
            this.dgvArchivos.AllowUserToAddRows = false;
            this.dgvArchivos.AllowUserToDeleteRows = false;
            this.dgvArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArchivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArchivos.BackgroundColor = System.Drawing.Color.White;
            this.dgvArchivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArchivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Archivo,
            this.Nombre,
            this.Tipo,
            this.Categoria,
            this.Tamanio,
            this.Obligatorio,
            this.Fecha_Creacion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArchivos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArchivos.Location = new System.Drawing.Point(20, 50);
            this.dgvArchivos.MultiSelect = false;
            this.dgvArchivos.Name = "dgvArchivos";
            this.dgvArchivos.ReadOnly = true;
            this.dgvArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArchivos.Size = new System.Drawing.Size(710, 350);
            this.dgvArchivos.TabIndex = 1;
            this.dgvArchivos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArchivos_CellDoubleClick);
            // 
            // ID_Archivo
            // 
            this.ID_Archivo.DataPropertyName = "ID_Temp_Archivo";
            this.ID_Archivo.FillWeight = 60F;
            this.ID_Archivo.HeaderText = "ID";
            this.ID_Archivo.Name = "ID_Archivo";
            this.ID_Archivo.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre_archivo";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "tipo_archivo";
            this.Tipo.FillWeight = 100F;
            this.Tipo.HeaderText = "Tipo MIME";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "categoria_archivo";
            this.Categoria.FillWeight = 90F;
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Tamanio
            // 
            this.Tamanio.DataPropertyName = "tamanio";
            this.Tamanio.FillWeight = 80F;
            this.Tamanio.HeaderText = "Tamaño";
            this.Tamanio.Name = "Tamanio";
            this.Tamanio.ReadOnly = true;
            // 
            // Obligatorio
            // 
            this.Obligatorio.DataPropertyName = "obligatorio";
            this.Obligatorio.FillWeight = 70F;
            this.Obligatorio.HeaderText = "Oblig.";
            this.Obligatorio.Name = "Obligatorio";
            this.Obligatorio.ReadOnly = true;
            // 
            // Fecha_Creacion
            // 
            this.Fecha_Creacion.DataPropertyName = "fecha_creacion";
            this.Fecha_Creacion.FillWeight = 100F;
            this.Fecha_Creacion.HeaderText = "Fecha Creación";
            this.Fecha_Creacion.Name = "Fecha_Creacion";
            this.Fecha_Creacion.ReadOnly = true;
            // 
            // btnDescargarArchivo
            // 
            this.btnDescargarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDescargarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnDescargarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargarArchivo.ForeColor = System.Drawing.Color.White;
            this.btnDescargarArchivo.Location = new System.Drawing.Point(20, 420);
            this.btnDescargarArchivo.Name = "btnDescargarArchivo";
            this.btnDescargarArchivo.Size = new System.Drawing.Size(140, 35);
            this.btnDescargarArchivo.TabIndex = 0;
            this.btnDescargarArchivo.Text = "Descargar Archivo";
            this.btnDescargarArchivo.UseVisualStyleBackColor = false;
            this.btnDescargarArchivo.Click += new System.EventHandler(this.btnDescargarArchivo_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(652, 520);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 35);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(12, 520);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 35);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir Detalles";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // DetallesRegistroTempForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.tabControl1);
            this.Name = "DetallesRegistroTempForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalles del Registro Temporal";
            this.tabControl1.ResumeLayout(false);
            this.tabPageBasicos.ResumeLayout(false);
            this.tabPageBasicos.PerformLayout();
            this.tabPageCertificaciones.ResumeLayout(false);
            this.tabPageCertificaciones.PerformLayout();
            this.tabPageExperiencia.ResumeLayout(false);
            this.tabPageExperiencia.PerformLayout();
            this.tabPageEspecialidades.ResumeLayout(false);
            this.tabPageEspecialidades.PerformLayout();
            this.tabPageArchivos.ResumeLayout(false);
            this.tabPageArchivos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).EndInit();
            this.ResumeLayout(false);

        }
    }
}