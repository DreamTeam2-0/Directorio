namespace Perfil
{
    partial class PerfilForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picPerfil;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblWhatsapp;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblOtroContacto;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtWhatsapp;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtOtroContacto;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Panel panelDatosPersonales;
        private System.Windows.Forms.Label lblDatosPersonales;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Button btnEditarDatos;

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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picPerfil = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblWhatsapp = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblOtroContacto = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtWhatsapp = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtOtroContacto = new System.Windows.Forms.TextBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.panelDatosPersonales = new System.Windows.Forms.Panel();
            this.lblDatosPersonales = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.btnEditarDatos = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPerfil)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDatosPersonales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.picPerfil);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(600, 120);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(120, 45);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(215, 29);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Nombre de Usuario";
            // 
            // picPerfil
            // 
            this.picPerfil.BackColor = System.Drawing.Color.White;
            this.picPerfil.Location = new System.Drawing.Point(30, 20);
            this.picPerfil.Name = "picPerfil";
            this.picPerfil.Size = new System.Drawing.Size(80, 80);
            this.picPerfil.TabIndex = 0;
            this.picPerfil.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTelefono, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWhatsapp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCorreo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblOtroContacto, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblUbicacion, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTelefono, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtWhatsapp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCorreo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtOtroContacto, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUbicacion, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 140);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 180);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.Location = new System.Drawing.Point(3, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(73, 17);
            this.lblTelefono.TabIndex = 0;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblWhatsapp
            // 
            this.lblWhatsapp.AutoSize = true;
            this.lblWhatsapp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblWhatsapp.Location = new System.Drawing.Point(273, 0);
            this.lblWhatsapp.Name = "lblWhatsapp";
            this.lblWhatsapp.Size = new System.Drawing.Size(81, 17);
            this.lblWhatsapp.TabIndex = 1;
            this.lblWhatsapp.Text = "Whatsapp";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCorreo.Location = new System.Drawing.Point(3, 60);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(58, 17);
            this.lblCorreo.TabIndex = 2;
            this.lblCorreo.Text = "Correo";
            // 
            // lblOtroContacto
            // 
            this.lblOtroContacto.AutoSize = true;
            this.lblOtroContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblOtroContacto.Location = new System.Drawing.Point(273, 60);
            this.lblOtroContacto.Name = "lblOtroContacto";
            this.lblOtroContacto.Size = new System.Drawing.Size(110, 17);
            this.lblOtroContacto.TabIndex = 3;
            this.lblOtroContacto.Text = "Otro Contacto";
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblUbicacion.Location = new System.Drawing.Point(3, 120);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(83, 17);
            this.lblUbicacion.TabIndex = 4;
            this.lblUbicacion.Text = "Ubicación";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(3, 28);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(260, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // txtWhatsapp
            // 
            this.txtWhatsapp.Location = new System.Drawing.Point(273, 28);
            this.txtWhatsapp.Name = "txtWhatsapp";
            this.txtWhatsapp.ReadOnly = true;
            this.txtWhatsapp.Size = new System.Drawing.Size(260, 20);
            this.txtWhatsapp.TabIndex = 6;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(3, 88);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.ReadOnly = true;
            this.txtCorreo.Size = new System.Drawing.Size(260, 20);
            this.txtCorreo.TabIndex = 7;
            // 
            // txtOtroContacto
            // 
            this.txtOtroContacto.Location = new System.Drawing.Point(273, 88);
            this.txtOtroContacto.Name = "txtOtroContacto";
            this.txtOtroContacto.ReadOnly = true;
            this.txtOtroContacto.Size = new System.Drawing.Size(260, 20);
            this.txtOtroContacto.TabIndex = 8;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(3, 148);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.ReadOnly = true;
            this.txtUbicacion.Size = new System.Drawing.Size(260, 20);
            this.txtUbicacion.TabIndex = 9;
            // 
            // panelDatosPersonales
            // 
            this.panelDatosPersonales.Controls.Add(this.lblDatosPersonales);
            this.panelDatosPersonales.Controls.Add(this.txtNombres);
            this.panelDatosPersonales.Controls.Add(this.txtApellidos);
            this.panelDatosPersonales.Controls.Add(this.lblNombres);
            this.panelDatosPersonales.Controls.Add(this.lblApellidos);
            this.panelDatosPersonales.Location = new System.Drawing.Point(30, 340);
            this.panelDatosPersonales.Name = "panelDatosPersonales";
            this.panelDatosPersonales.Size = new System.Drawing.Size(540, 120);
            this.panelDatosPersonales.TabIndex = 2;
            // 
            // lblDatosPersonales
            // 
            this.lblDatosPersonales.AutoSize = true;
            this.lblDatosPersonales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDatosPersonales.Location = new System.Drawing.Point(3, 10);
            this.lblDatosPersonales.Name = "lblDatosPersonales";
            this.lblDatosPersonales.Size = new System.Drawing.Size(144, 20);
            this.lblDatosPersonales.TabIndex = 0;
            this.lblDatosPersonales.Text = "Datos Personales";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(90, 50);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(200, 20);
            this.txtNombres.TabIndex = 3;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(90, 80);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.ReadOnly = true;
            this.txtApellidos.Size = new System.Drawing.Size(200, 20);
            this.txtApellidos.TabIndex = 4;
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombres.Location = new System.Drawing.Point(10, 51);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(74, 17);
            this.lblNombres.TabIndex = 1;
            this.lblNombres.Text = "Nombres";
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblApellidos.Location = new System.Drawing.Point(10, 81);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(74, 17);
            this.lblApellidos.TabIndex = 2;
            this.lblApellidos.Text = "Apellidos";
            // 
            // btnEditarDatos
            // 
            this.btnEditarDatos.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnEditarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnEditarDatos.ForeColor = System.Drawing.Color.White;
            this.btnEditarDatos.Location = new System.Drawing.Point(220, 480);
            this.btnEditarDatos.Name = "btnEditarDatos";
            this.btnEditarDatos.Size = new System.Drawing.Size(160, 40);
            this.btnEditarDatos.TabIndex = 3;
            this.btnEditarDatos.Text = "Editar Datos";
            this.btnEditarDatos.UseVisualStyleBackColor = false;
            this.btnEditarDatos.Click += new System.EventHandler(this.btnEditarDatos_Click);
            // 
            // PerfilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.AutoSize;
            this.ClientSize = new System.Drawing.Size(600, 540);
            this.Controls.Add(this.btnEditarDatos);
            this.Controls.Add(this.panelDatosPersonales);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelHeader);
            this.Name = "PerfilForm";
            this.Text = "Perfil de Usuario";
            this.Load += new System.EventHandler(this.PerfilForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPerfil)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelDatosPersonales.ResumeLayout(false);
            this.panelDatosPersonales.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}