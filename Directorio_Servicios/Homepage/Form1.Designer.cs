namespace Homepage
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHome = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.panelVerdeSuperior = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblCategorias = new System.Windows.Forms.Label();
            this.flpCategorias = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblPagina = new System.Windows.Forms.Label();
            this.lblRango = new System.Windows.Forms.Label();
            this.lblSolicitados = new System.Windows.Forms.Label();
            this.tlpSolicitados = new System.Windows.Forms.TableLayoutPanel();
            this.panelContenidoCategorias = new System.Windows.Forms.Panel();
            this.btnVolverHome = new System.Windows.Forms.Button();
            this.lblServicios = new System.Windows.Forms.Label();
            this.lblDenominaciones = new System.Windows.Forms.Label();
            this.flpServicios = new System.Windows.Forms.FlowLayoutPanel();
            this.flpDenominaciones = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLateral = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnCambiarEmprendedor = new System.Windows.Forms.Button();
            this.btnConfiguraciones = new System.Windows.Forms.Button();
            this.btnVerPerfil = new System.Windows.Forms.Button();
            this.lblMenuTitulo = new System.Windows.Forms.Label();
            this.menuPrincipal.SuspendLayout();
            this.panelVerdeSuperior.SuspendLayout();
            this.panelContenidoCategorias.SuspendLayout();
            this.panelLateral.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.menuItemHome,
            this.menuItemCategorias});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1040, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Menú";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuItemHome
            // 
            this.menuItemHome.Name = "menuItemHome";
            this.menuItemHome.Size = new System.Drawing.Size(49, 20);
            this.menuItemHome.Text = "Home";
            this.menuItemHome.Click += new System.EventHandler(this.MenuItemHome_Click);
            // 
            // menuItemCategorias
            // 
            this.menuItemCategorias.Name = "menuItemCategorias";
            this.menuItemCategorias.Size = new System.Drawing.Size(75, 20);
            this.menuItemCategorias.Text = "Categorías";
            this.menuItemCategorias.Click += new System.EventHandler(this.MenuItemCategorias_Click);
            // 
            // panelVerdeSuperior
            // 
            this.panelVerdeSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.panelVerdeSuperior.Controls.Add(this.lblBienvenida);
            this.panelVerdeSuperior.Controls.Add(this.txtBuscar);
            this.panelVerdeSuperior.Controls.Add(this.btnBuscar);
            this.panelVerdeSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVerdeSuperior.Location = new System.Drawing.Point(0, 24);
            this.panelVerdeSuperior.Name = "panelVerdeSuperior";
            this.panelVerdeSuperior.Size = new System.Drawing.Size(1040, 80);
            this.panelVerdeSuperior.TabIndex = 13;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Location = new System.Drawing.Point(12, 20);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(183, 37);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(650, 30);
            this.txtBuscar.MaxLength = 30;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(253, 23);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.Text = "BUSCAR CATEGORÍAS";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(920, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 37);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // lblCategorias
            // 
            this.lblCategorias.AutoSize = true;
            this.lblCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategorias.Location = new System.Drawing.Point(22, 135);
            this.lblCategorias.Name = "lblCategorias";
            this.lblCategorias.Size = new System.Drawing.Size(172, 37);
            this.lblCategorias.TabIndex = 7;
            this.lblCategorias.Text = "Categorías";
            // 
            // flpCategorias
            // 
            this.flpCategorias.Location = new System.Drawing.Point(110, 180);
            this.flpCategorias.Name = "flpCategorias";
            this.flpCategorias.Size = new System.Drawing.Size(820, 110);
            this.flpCategorias.TabIndex = 4;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(70, 210);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(40, 60);
            this.btnAnterior.TabIndex = 9;
            this.btnAnterior.Text = "◀";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.BtnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Location = new System.Drawing.Point(930, 210);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(40, 60);
            this.btnSiguiente.TabIndex = 10;
            this.btnSiguiente.Text = "▶";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.BtnSiguiente_Click);
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagina.Location = new System.Drawing.Point(450, 155);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(140, 20);
            this.lblPagina.TabIndex = 11;
            this.lblPagina.Text = "Mostrando 7 de X cat.";
            this.lblPagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRango
            // 
            this.lblRango.AutoSize = true;
            this.lblRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRango.ForeColor = System.Drawing.Color.Gray;
            this.lblRango.Location = new System.Drawing.Point(470, 295);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(90, 17);
            this.lblRango.TabIndex = 12;
            this.lblRango.Text = "IDs: 1 - 7";
            this.lblRango.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSolicitados
            // 
            this.lblSolicitados.AutoSize = true;
            this.lblSolicitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolicitados.Location = new System.Drawing.Point(22, 320);
            this.lblSolicitados.Name = "lblSolicitados";
            this.lblSolicitados.Size = new System.Drawing.Size(241, 37);
            this.lblSolicitados.TabIndex = 5;
            this.lblSolicitados.Text = "Más Solicitados";
            // 
            // tlpSolicitados
            // 
            this.tlpSolicitados.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tlpSolicitados.ColumnCount = 2;
            this.tlpSolicitados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSolicitados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSolicitados.Location = new System.Drawing.Point(22, 370);
            this.tlpSolicitados.Name = "tlpSolicitados";
            this.tlpSolicitados.RowCount = 1;
            this.tlpSolicitados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSolicitados.Size = new System.Drawing.Size(409, 100);
            this.tlpSolicitados.TabIndex = 6;
            // 
            // panelContenidoCategorias
            // 
            this.panelContenidoCategorias.Controls.Add(this.btnVolverHome);
            this.panelContenidoCategorias.Controls.Add(this.lblServicios);
            this.panelContenidoCategorias.Controls.Add(this.lblDenominaciones);
            this.panelContenidoCategorias.Controls.Add(this.flpServicios);
            this.panelContenidoCategorias.Controls.Add(this.flpDenominaciones);
            this.panelContenidoCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenidoCategorias.Location = new System.Drawing.Point(0, 104);
            this.panelContenidoCategorias.Name = "panelContenidoCategorias";
            this.panelContenidoCategorias.Size = new System.Drawing.Size(1040, 541);
            this.panelContenidoCategorias.TabIndex = 14;
            this.panelContenidoCategorias.Visible = false;
            // 
            // btnVolverHome
            // 
            this.btnVolverHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverHome.Location = new System.Drawing.Point(30, 480);
            this.btnVolverHome.Name = "btnVolverHome";
            this.btnVolverHome.Size = new System.Drawing.Size(120, 35);
            this.btnVolverHome.TabIndex = 4;
            this.btnVolverHome.Text = "← Volver";
            this.btnVolverHome.UseVisualStyleBackColor = true;
            this.btnVolverHome.Click += new System.EventHandler(this.btnVolverHome_Click);
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicios.Location = new System.Drawing.Point(545, 40);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(123, 31);
            this.lblServicios.TabIndex = 3;
            this.lblServicios.Text = "Servicios";
            // 
            // lblDenominaciones
            // 
            this.lblDenominaciones.AutoSize = true;
            this.lblDenominaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenominaciones.Location = new System.Drawing.Point(25, 40);
            this.lblDenominaciones.Name = "lblDenominaciones";
            this.lblDenominaciones.Size = new System.Drawing.Size(205, 31);
            this.lblDenominaciones.TabIndex = 2;
            this.lblDenominaciones.Text = "Denominaciones";
            // 
            // flpServicios
            // 
            this.flpServicios.Location = new System.Drawing.Point(550, 80);
            this.flpServicios.Name = "flpServicios";
            this.flpServicios.Size = new System.Drawing.Size(400, 350);
            this.flpServicios.TabIndex = 1;
            // 
            // flpDenominaciones
            // 
            this.flpDenominaciones.Location = new System.Drawing.Point(30, 80);
            this.flpDenominaciones.Name = "flpDenominaciones";
            this.flpDenominaciones.Size = new System.Drawing.Size(400, 350);
            this.flpDenominaciones.TabIndex = 0;
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.panelLateral.Controls.Add(this.btnCerrarSesion);
            this.panelLateral.Controls.Add(this.btnCambiarEmprendedor);
            this.panelLateral.Controls.Add(this.btnConfiguraciones);
            this.panelLateral.Controls.Add(this.btnVerPerfil);
            this.panelLateral.Controls.Add(this.lblMenuTitulo);
            this.panelLateral.Location = new System.Drawing.Point(0, 24);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(300, 621);
            this.panelLateral.TabIndex = 8;
            this.panelLateral.Visible = false;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(150, 550);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(140, 40);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnCambiarEmprendedor
            // 
            this.btnCambiarEmprendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(125)))), ((int)(((byte)(49)))));
            this.btnCambiarEmprendedor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(125)))), ((int)(((byte)(49)))));
            this.btnCambiarEmprendedor.FlatAppearance.BorderSize = 2;
            this.btnCambiarEmprendedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCambiarEmprendedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCambiarEmprendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEmprendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarEmprendedor.ForeColor = System.Drawing.Color.White;
            this.btnCambiarEmprendedor.Location = new System.Drawing.Point(50, 300);
            this.btnCambiarEmprendedor.Name = "btnCambiarEmprendedor";
            this.btnCambiarEmprendedor.Size = new System.Drawing.Size(200, 60);
            this.btnCambiarEmprendedor.TabIndex = 3;
            this.btnCambiarEmprendedor.Text = "Cambiar a Prestador de Servicios";
            this.btnCambiarEmprendedor.UseVisualStyleBackColor = false;
            this.btnCambiarEmprendedor.Click += new System.EventHandler(this.btnVolverProveedor_Click);
            // 
            // btnConfiguraciones
            // 
            this.btnConfiguraciones.FlatAppearance.BorderSize = 0;
            this.btnConfiguraciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnConfiguraciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnConfiguraciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguraciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguraciones.ForeColor = System.Drawing.Color.White;
            this.btnConfiguraciones.Location = new System.Drawing.Point(0, 180);
            this.btnConfiguraciones.Name = "btnConfiguraciones";
            this.btnConfiguraciones.Size = new System.Drawing.Size(300, 50);
            this.btnConfiguraciones.TabIndex = 2;
            this.btnConfiguraciones.Text = "Configuraciones";
            this.btnConfiguraciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguraciones.UseVisualStyleBackColor = false;
            // 
            // btnVerPerfil
            // 
            this.btnVerPerfil.FlatAppearance.BorderSize = 0;
            this.btnVerPerfil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnVerPerfil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnVerPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerPerfil.ForeColor = System.Drawing.Color.White;
            this.btnVerPerfil.Location = new System.Drawing.Point(0, 130);
            this.btnVerPerfil.Name = "btnVerPerfil";
            this.btnVerPerfil.Size = new System.Drawing.Size(300, 50);
            this.btnVerPerfil.TabIndex = 1;
            this.btnVerPerfil.Text = "Ver perfil";
            this.btnVerPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerPerfil.UseVisualStyleBackColor = false;
            this.btnVerPerfil.Click += new System.EventHandler(this.btnVerPerfil_Click);
            // 
            // lblMenuTitulo
            // 
            this.lblMenuTitulo.AutoSize = true;
            this.lblMenuTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuTitulo.ForeColor = System.Drawing.Color.White;
            this.lblMenuTitulo.Location = new System.Drawing.Point(20, 30);
            this.lblMenuTitulo.Name = "lblMenuTitulo";
            this.lblMenuTitulo.Size = new System.Drawing.Size(63, 24);
            this.lblMenuTitulo.TabIndex = 0;
            this.lblMenuTitulo.Text = "Menú";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 645);
            this.Controls.Add(this.panelContenidoCategorias);
            this.Controls.Add(this.tlpSolicitados);
            this.Controls.Add(this.lblSolicitados);
            this.Controls.Add(this.lblRango);
            this.Controls.Add(this.lblPagina);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.flpCategorias);
            this.Controls.Add(this.lblCategorias);
            this.Controls.Add(this.panelVerdeSuperior);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.panelVerdeSuperior.ResumeLayout(false);
            this.panelVerdeSuperior.PerformLayout();
            this.panelContenidoCategorias.ResumeLayout(false);
            this.panelContenidoCategorias.PerformLayout();
            this.panelLateral.ResumeLayout(false);
            this.panelLateral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemHome;
        private System.Windows.Forms.ToolStripMenuItem menuItemCategorias;
        private System.Windows.Forms.Panel panelVerdeSuperior;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCategorias;
        private System.Windows.Forms.FlowLayoutPanel flpCategorias;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.Label lblSolicitados;
        private System.Windows.Forms.TableLayoutPanel tlpSolicitados;
        private System.Windows.Forms.Panel panelContenidoCategorias;
        private System.Windows.Forms.Button btnVolverHome;
        private System.Windows.Forms.Label lblServicios;
        private System.Windows.Forms.Label lblDenominaciones;
        private System.Windows.Forms.FlowLayoutPanel flpServicios;
        private System.Windows.Forms.FlowLayoutPanel flpDenominaciones;
        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnCambiarEmprendedor;
        private System.Windows.Forms.Button btnConfiguraciones;
        private System.Windows.Forms.Button btnVerPerfil;
        private System.Windows.Forms.Label lblMenuTitulo;
    }
}