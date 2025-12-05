namespace ProveedorHome
{
    partial class Proveedor
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.panelLateral = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnCambiarCliente = new System.Windows.Forms.Button();
            this.btnEditarDatos = new System.Windows.Forms.Button();
            this.btnEditarServicios = new System.Windows.Forms.Button();
            this.btnVerPerfil = new System.Windows.Forms.Button();
            this.lblMenuTitulo = new System.Windows.Forms.Label();
            this.panelEstadisticas = new System.Windows.Forms.Panel();
            this.lblClientesAtendidos = new System.Windows.Forms.Label();
            this.lblCalificacionPromedio = new System.Windows.Forms.Label();
            this.lblServiciosActivos = new System.Windows.Forms.Label();
            this.lblTituloEstadisticas = new System.Windows.Forms.Label();
            this.lblTituloServicios = new System.Windows.Forms.Label();
            this.flpServicios = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTituloCalificaciones = new System.Windows.Forms.Label();
            this.flpCalificaciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.menuPrincipal.SuspendLayout();
            this.panelLateral.SuspendLayout();
            this.panelEstadisticas.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1200, 29);
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
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(20, 45);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(272, 55);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.panelLateral.Controls.Add(this.btnCerrarSesion);
            this.panelLateral.Controls.Add(this.btnCambiarCliente);
            this.panelLateral.Controls.Add(this.btnEditarDatos);
            this.panelLateral.Controls.Add(this.btnEditarServicios);
            this.panelLateral.Controls.Add(this.btnVerPerfil);
            this.panelLateral.Controls.Add(this.lblMenuTitulo);
            this.panelLateral.Location = new System.Drawing.Point(0, 29);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(300, 700);
            this.panelLateral.TabIndex = 2;
            this.panelLateral.Visible = false;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(150, 630);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(140, 40);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnCambiarCliente
            // 
            this.btnCambiarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(125)))), ((int)(((byte)(49)))));
            this.btnCambiarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(125)))), ((int)(((byte)(49)))));
            this.btnCambiarCliente.FlatAppearance.BorderSize = 2;
            this.btnCambiarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCambiarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCambiarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarCliente.ForeColor = System.Drawing.Color.White;
            this.btnCambiarCliente.Location = new System.Drawing.Point(50, 350);
            this.btnCambiarCliente.Name = "btnCambiarCliente";
            this.btnCambiarCliente.Size = new System.Drawing.Size(200, 60);
            this.btnCambiarCliente.TabIndex = 4;
            this.btnCambiarCliente.Text = "Cambiar a Cliente";
            this.btnCambiarCliente.UseVisualStyleBackColor = false;
            this.btnCambiarCliente.Click += new System.EventHandler(this.btnCambiarCliente_Click);
            // 
            // btnVerPerfil
            this.btnVerPerfil.BackColor = System.Drawing.Color.Transparent;
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
            this.btnVerPerfil.Text = "Ver Perfil Público";
            this.btnVerPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerPerfil.UseVisualStyleBackColor = false;
            this.btnVerPerfil.Click += new System.EventHandler(this.btnVerPerfil_Click);
            // 
            // btnEditarServicios
            this.btnEditarServicios.BackColor = System.Drawing.Color.Transparent;
            this.btnEditarServicios.FlatAppearance.BorderSize = 0;
            this.btnEditarServicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEditarServicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEditarServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarServicios.ForeColor = System.Drawing.Color.White;
            this.btnEditarServicios.Location = new System.Drawing.Point(0, 180);
            this.btnEditarServicios.Name = "btnEditarServicios";
            this.btnEditarServicios.Size = new System.Drawing.Size(300, 50);
            this.btnEditarServicios.TabIndex = 2;
            this.btnEditarServicios.Text = "Editar Servicios";
            this.btnEditarServicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarServicios.UseVisualStyleBackColor = false;
            this.btnEditarServicios.Click += new System.EventHandler(this.btnEditarServicios_Click);
            // 
            // btnEditarDatos
            this.btnEditarDatos.BackColor = System.Drawing.Color.Transparent;
            this.btnEditarDatos.FlatAppearance.BorderSize = 0;
            this.btnEditarDatos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEditarDatos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEditarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarDatos.ForeColor = System.Drawing.Color.White;
            this.btnEditarDatos.Location = new System.Drawing.Point(0, 230);
            this.btnEditarDatos.Name = "btnEditarDatos";
            this.btnEditarDatos.Size = new System.Drawing.Size(300, 50);
            this.btnEditarDatos.TabIndex = 3;
            this.btnEditarDatos.Text = "Editar Datos Personales";
            this.btnEditarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarDatos.UseVisualStyleBackColor = false;
            this.btnEditarDatos.Click += new System.EventHandler(this.btnEditarDatos_Click);
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
            // panelEstadisticas
            // 
            this.panelEstadisticas.BackColor = System.Drawing.Color.White;
            this.panelEstadisticas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEstadisticas.Controls.Add(this.lblClientesAtendidos);
            this.panelEstadisticas.Controls.Add(this.lblCalificacionPromedio);
            this.panelEstadisticas.Controls.Add(this.lblServiciosActivos);
            this.panelEstadisticas.Controls.Add(this.lblTituloEstadisticas);
            // MOVIDO AL CENTRO: 300px desde la izquierda (en lugar de 350)
            this.panelEstadisticas.Location = new System.Drawing.Point(50, 160);
            this.panelEstadisticas.Name = "panelEstadisticas";
            this.panelEstadisticas.Size = new System.Drawing.Size(1100, 150); // Reducido de 800 a 600
            this.panelEstadisticas.TabIndex = 3;
            // 
            // lblClientesAtendidos
            // 
            this.lblClientesAtendidos.AutoSize = true;
            this.lblClientesAtendidos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblClientesAtendidos.Location = new System.Drawing.Point(400, 80);
            this.lblClientesAtendidos.Name = "lblClientesAtendidos";
            this.lblClientesAtendidos.Size = new System.Drawing.Size(119, 25);
            this.lblClientesAtendidos.TabIndex = 3;
            this.lblClientesAtendidos.Text = "24 clientes";
            // 
            // lblCalificacionPromedio
            // 
            this.lblCalificacionPromedio.AutoSize = true;
            this.lblCalificacionPromedio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCalificacionPromedio.Location = new System.Drawing.Point(200, 80);
            this.lblCalificacionPromedio.Name = "lblCalificacionPromedio";
            this.lblCalificacionPromedio.Size = new System.Drawing.Size(76, 25);
            this.lblCalificacionPromedio.TabIndex = 2;
            this.lblCalificacionPromedio.Text = "4.8/5.0";
            // 
            // lblServiciosActivos
            // 
            this.lblServiciosActivos.AutoSize = true;
            this.lblServiciosActivos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblServiciosActivos.Location = new System.Drawing.Point(30, 80);
            this.lblServiciosActivos.Name = "lblServiciosActivos";
            this.lblServiciosActivos.Size = new System.Drawing.Size(138, 25);
            this.lblServiciosActivos.TabIndex = 1;
            this.lblServiciosActivos.Text = "5 servicios act.";
            // 
            // lblTituloEstadisticas
            // 
            this.lblTituloEstadisticas.AutoSize = true;
            this.lblTituloEstadisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloEstadisticas.Location = new System.Drawing.Point(25, 20);
            this.lblTituloEstadisticas.Name = "lblTituloEstadisticas";
            this.lblTituloEstadisticas.Size = new System.Drawing.Size(278, 26);
            this.lblTituloEstadisticas.TabIndex = 0;
            this.lblTituloEstadisticas.Text = "Estadísticas de tu Negocio";
            // 
            // lblTituloServicios
            // 
            this.lblTituloServicios.AutoSize = true;
            this.lblTituloServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // MOVIDO AL CENTRO: 300px desde la izquierda
            this.lblTituloServicios.Location = new System.Drawing.Point(50, 330);
            this.lblTituloServicios.Name = "lblTituloServicios";
            this.lblTituloServicios.Size = new System.Drawing.Size(183, 26);
            this.lblTituloServicios.TabIndex = 4;
            this.lblTituloServicios.Text = "Mis Servicios Activos";
            // 
            // flpServicios
            // 
            this.flpServicios.AutoScroll = true;
            // MOVIDO AL CENTRO: 300px desde la izquierda
            this.flpServicios.Location = new System.Drawing.Point(50, 370);
            this.flpServicios.Name = "flpServicios";
            this.flpServicios.Size = new System.Drawing.Size(500, 150); // Reducido de 800 a 600
            this.flpServicios.TabIndex = 5;
            // 
            // lblTituloCalificaciones
            // 
            this.lblTituloCalificaciones.AutoSize = true;
            this.lblTituloCalificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // MOVIDO AL CENTRO: 300px desde la izquierda
            this.lblTituloCalificaciones.Location = new System.Drawing.Point(650, 330);
            this.lblTituloCalificaciones.Name = "lblTituloCalificaciones";
            this.lblTituloCalificaciones.Size = new System.Drawing.Size(263, 26);
            this.lblTituloCalificaciones.TabIndex = 6;
            this.lblTituloCalificaciones.Text = "Calificaciones Recientes";
            // 
            // flpCalificaciones
            // 
            this.flpCalificaciones.AutoScroll = true;
            // MOVIDO AL CENTRO: 300px desde la izquierda
            this.flpCalificaciones.Location = new System.Drawing.Point(650, 370);
            this.flpCalificaciones.Name = "flpCalificaciones";
            this.flpCalificaciones.Size = new System.Drawing.Size(500, 150); // Reducido de 800 a 600
            this.flpCalificaciones.TabIndex = 7;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            // MOVIDO AL CENTRO: Ajustado a la nueva posición
            this.btnActualizar.Location = new System.Drawing.Point(1000, 200);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 35);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.flpCalificaciones);
            this.Controls.Add(this.lblTituloCalificaciones);
            this.Controls.Add(this.flpServicios);
            this.Controls.Add(this.lblTituloServicios);
            this.Controls.Add(this.panelEstadisticas);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.menuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuPrincipal;
            this.MaximizeBox = false;
            this.Name = "Proveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Proveedor";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.panelLateral.ResumeLayout(false);
            this.panelLateral.PerformLayout();
            this.panelEstadisticas.ResumeLayout(false);
            this.panelEstadisticas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnCambiarCliente;
        private System.Windows.Forms.Button btnEditarDatos;
        private System.Windows.Forms.Button btnEditarServicios;
        private System.Windows.Forms.Button btnVerPerfil;
        private System.Windows.Forms.Label lblMenuTitulo;
        private System.Windows.Forms.Panel panelEstadisticas;
        private System.Windows.Forms.Label lblClientesAtendidos;
        private System.Windows.Forms.Label lblCalificacionPromedio;
        private System.Windows.Forms.Label lblServiciosActivos;
        private System.Windows.Forms.Label lblTituloEstadisticas;
        private System.Windows.Forms.Label lblTituloServicios;
        private System.Windows.Forms.FlowLayoutPanel flpServicios;
        private System.Windows.Forms.Label lblTituloCalificaciones;
        private System.Windows.Forms.FlowLayoutPanel flpCalificaciones;
        private System.Windows.Forms.Button btnActualizar;
    }
}