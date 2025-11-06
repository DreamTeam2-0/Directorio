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
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.flpCategorias = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSolicitados = new System.Windows.Forms.Label();
            this.tlpSolicitados = new System.Windows.Forms.TableLayoutPanel();
            this.lblCategorias = new System.Windows.Forms.Label();
            this.panelLateral = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnCambiarEmprendedor = new System.Windows.Forms.Button();
            this.btnConfiguraciones = new System.Windows.Forms.Button();
            this.btnVerPerfil = new System.Windows.Forms.Button();
            this.lblMenuTitulo = new System.Windows.Forms.Label();
            this.menuPrincipal.SuspendLayout();
            this.panelLateral.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1466, 29);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 25);
            this.toolStripMenuItem1.Text = "Menú";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Futura Md BT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(12, 35);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(297, 57);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Location = new System.Drawing.Point(340, 55);
            this.txtBuscar.MaxLength = 30;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(253, 20);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.Text = "BUSCAR CATEGORÍAS";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(616, 45);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 37);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // flpCategorias
            // 
            this.flpCategorias.AutoScroll = true;
            this.flpCategorias.Location = new System.Drawing.Point(22, 213);
            this.flpCategorias.Name = "flpCategorias";
            this.flpCategorias.Size = new System.Drawing.Size(1400, 150);
            this.flpCategorias.TabIndex = 4;
            // 
            // lblSolicitados
            // 
            this.lblSolicitados.AutoSize = true;
            this.lblSolicitados.Font = new System.Drawing.Font("Futura Md BT", 24F, System.Drawing.FontStyle.Italic);
            this.lblSolicitados.Location = new System.Drawing.Point(22, 376);
            this.lblSolicitados.Name = "lblSolicitados";
            this.lblSolicitados.Size = new System.Drawing.Size(235, 39);
            this.lblSolicitados.TabIndex = 5;
            this.lblSolicitados.Text = "Más Solicitados";
            // 
            // tlpSolicitados
            // 
            this.tlpSolicitados.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tlpSolicitados.ColumnCount = 2;
            this.tlpSolicitados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSolicitados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSolicitados.Location = new System.Drawing.Point(22, 431);
            this.tlpSolicitados.Name = "tlpSolicitados";
            this.tlpSolicitados.RowCount = 1;
            this.tlpSolicitados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSolicitados.Size = new System.Drawing.Size(409, 100);
            this.tlpSolicitados.TabIndex = 6;
            // 
            // lblCategorias
            // 
            this.lblCategorias.AutoSize = true;
            this.lblCategorias.Font = new System.Drawing.Font("Futura Md BT", 24F, System.Drawing.FontStyle.Italic);
            this.lblCategorias.Location = new System.Drawing.Point(22, 160);
            this.lblCategorias.Name = "lblCategorias";
            this.lblCategorias.Size = new System.Drawing.Size(168, 39);
            this.lblCategorias.TabIndex = 7;
            this.lblCategorias.Text = "Categorías";
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.panelLateral.Controls.Add(this.btnCerrarSesion);
            this.panelLateral.Controls.Add(this.btnCambiarEmprendedor);
            this.panelLateral.Controls.Add(this.btnConfiguraciones);
            this.panelLateral.Controls.Add(this.btnVerPerfil);
            this.panelLateral.Controls.Add(this.lblMenuTitulo);
            this.panelLateral.Location = new System.Drawing.Point(0, 29);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(300, 616);
            this.panelLateral.TabIndex = 8;
            this.panelLateral.Visible = false;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 280);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(300, 50);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            // 
            // btnCambiarEmprendedor
            // 
            this.btnCambiarEmprendedor.BackColor = System.Drawing.Color.Transparent;
            this.btnCambiarEmprendedor.FlatAppearance.BorderSize = 0;
            this.btnCambiarEmprendedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnCambiarEmprendedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.btnCambiarEmprendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEmprendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCambiarEmprendedor.ForeColor = System.Drawing.Color.White;
            this.btnCambiarEmprendedor.Location = new System.Drawing.Point(0, 230);
            this.btnCambiarEmprendedor.Name = "btnCambiarEmprendedor";
            this.btnCambiarEmprendedor.Size = new System.Drawing.Size(300, 50);
            this.btnCambiarEmprendedor.TabIndex = 3;
            this.btnCambiarEmprendedor.Text = "Cambiar a emprendedor";
            this.btnCambiarEmprendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarEmprendedor.UseVisualStyleBackColor = false;
            // 
            // btnConfiguraciones
            // 
            this.btnConfiguraciones.BackColor = System.Drawing.Color.Transparent;
            this.btnConfiguraciones.FlatAppearance.BorderSize = 0;
            this.btnConfiguraciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnConfiguraciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.btnConfiguraciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguraciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
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
            this.btnVerPerfil.BackColor = System.Drawing.Color.Transparent;
            this.btnVerPerfil.FlatAppearance.BorderSize = 0;
            this.btnVerPerfil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnVerPerfil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.btnVerPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
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
            this.lblMenuTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblMenuTitulo.ForeColor = System.Drawing.Color.White;
            this.lblMenuTitulo.Location = new System.Drawing.Point(20, 30);
            this.lblMenuTitulo.Name = "lblMenuTitulo";
            this.lblMenuTitulo.Size = new System.Drawing.Size(65, 24);
            this.lblMenuTitulo.TabIndex = 0;
            this.lblMenuTitulo.Text = "Menú";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 645);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.lblCategorias);
            this.Controls.Add(this.tlpSolicitados);
            this.Controls.Add(this.lblSolicitados);
            this.Controls.Add(this.flpCategorias);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.panelLateral.ResumeLayout(false);
            this.panelLateral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.FlowLayoutPanel flpCategorias;
        private System.Windows.Forms.Label lblSolicitados;
        private System.Windows.Forms.TableLayoutPanel tlpSolicitados;
        private System.Windows.Forms.Label lblCategorias;
        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnCambiarEmprendedor;
        private System.Windows.Forms.Button btnConfiguraciones;
        private System.Windows.Forms.Button btnVerPerfil;
        private System.Windows.Forms.Label lblMenuTitulo;
    }
}