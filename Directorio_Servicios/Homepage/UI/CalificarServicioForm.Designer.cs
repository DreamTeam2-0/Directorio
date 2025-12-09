
namespace Homepage.UI
{
    partial class CalificarServicioForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label lblInfoServicio;
        private System.Windows.Forms.Label lblTituloServicio;
        private System.Windows.Forms.Label lblProveedorLabel;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblUsuarioLabel;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblCalificacion;
        private System.Windows.Forms.Label lblEstrella1;
        private System.Windows.Forms.Label lblEstrella2;
        private System.Windows.Forms.Label lblEstrella3;
        private System.Windows.Forms.Label lblEstrella4;
        private System.Windows.Forms.Label lblEstrella5;
        private System.Windows.Forms.Label lblCalificacionValida;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblComentarioValido;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblInstrucciones;

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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblComentarioValido = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.lblCalificacionValida = new System.Windows.Forms.Label();
            this.lblEstrella5 = new System.Windows.Forms.Label();
            this.lblEstrella4 = new System.Windows.Forms.Label();
            this.lblEstrella3 = new System.Windows.Forms.Label();
            this.lblEstrella2 = new System.Windows.Forms.Label();
            this.lblEstrella1 = new System.Windows.Forms.Label();
            this.lblCalificacion = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblUsuarioLabel = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblProveedorLabel = new System.Windows.Forms.Label();
            this.lblTituloServicio = new System.Windows.Forms.Label();
            this.lblInfoServicio = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.panelHeader.Controls.Add(this.btnCancelar);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(600, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnCancelar.Location = new System.Drawing.Point(470, 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(243, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Calificar y Comentar";
            // 
            // panelContenido
            // 
            this.panelContenido.AutoScroll = true;
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Controls.Add(this.lblInstrucciones);
            this.panelContenido.Controls.Add(this.btnEnviar);
            this.panelContenido.Controls.Add(this.lblComentarioValido);
            this.panelContenido.Controls.Add(this.txtComentario);
            this.panelContenido.Controls.Add(this.lblComentario);
            this.panelContenido.Controls.Add(this.lblCalificacionValida);
            this.panelContenido.Controls.Add(this.lblEstrella5);
            this.panelContenido.Controls.Add(this.lblEstrella4);
            this.panelContenido.Controls.Add(this.lblEstrella3);
            this.panelContenido.Controls.Add(this.lblEstrella2);
            this.panelContenido.Controls.Add(this.lblEstrella1);
            this.panelContenido.Controls.Add(this.lblCalificacion);
            this.panelContenido.Controls.Add(this.lblUsuario);
            this.panelContenido.Controls.Add(this.lblUsuarioLabel);
            this.panelContenido.Controls.Add(this.lblProveedor);
            this.panelContenido.Controls.Add(this.lblProveedorLabel);
            this.panelContenido.Controls.Add(this.lblTituloServicio);
            this.panelContenido.Controls.Add(this.lblInfoServicio);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 70);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(600, 480);
            this.panelContenido.TabIndex = 1;
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.AutoSize = true;
            this.lblInstrucciones.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrucciones.ForeColor = System.Drawing.Color.Gray;
            this.lblInstrucciones.Location = new System.Drawing.Point(30, 340);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(543, 28);
            this.lblInstrucciones.TabIndex = 16;
            this.lblInstrucciones.Text = "Nota: El comentario debe tener al menos 10 caracteres. Máximo 500 caracteres.\r\nNo puede calificar su propio servicio. Solo puede calificar una vez cada servicio.";
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(200, 400);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(200, 40);
            this.btnEnviar.TabIndex = 15;
            this.btnEnviar.Text = "Enviar Calificación";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblComentarioValido
            // 
            this.lblComentarioValido.AutoSize = true;
            this.lblComentarioValido.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentarioValido.Location = new System.Drawing.Point(540, 240);
            this.lblComentarioValido.Name = "lblComentarioValido";
            this.lblComentarioValido.Size = new System.Drawing.Size(15, 16);
            this.lblComentarioValido.TabIndex = 14;
            this.lblComentarioValido.Text = "✗";
            // 
            // txtComentario
            // 
            this.txtComentario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(30, 270);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComentario.Size = new System.Drawing.Size(540, 60);
            this.txtComentario.TabIndex = 13;
            this.txtComentario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComentario_KeyPress);
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentario.Location = new System.Drawing.Point(30, 240);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(205, 16);
            this.lblComentario.TabIndex = 12;
            this.lblComentario.Text = "Comentario (mínimo 10 caracteres)";
            // 
            // lblCalificacionValida
            // 
            this.lblCalificacionValida.AutoSize = true;
            this.lblCalificacionValida.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalificacionValida.Location = new System.Drawing.Point(540, 170);
            this.lblCalificacionValida.Name = "lblCalificacionValida";
            this.lblCalificacionValida.Size = new System.Drawing.Size(15, 16);
            this.lblCalificacionValida.TabIndex = 11;
            this.lblCalificacionValida.Text = "✗";
            // 
            // lblEstrella5
            // 
            this.lblEstrella5.AutoSize = true;
            this.lblEstrella5.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstrella5.ForeColor = System.Drawing.Color.Gray;
            this.lblEstrella5.Location = new System.Drawing.Point(230, 150);
            this.lblEstrella5.Name = "lblEstrella5";
            this.lblEstrella5.Size = new System.Drawing.Size(40, 45);
            this.lblEstrella5.TabIndex = 10;
            this.lblEstrella5.Text = "☆";
            this.lblEstrella5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEstrella5.Click += new System.EventHandler(this.EstrellaLabel_Click);
            this.lblEstrella5.MouseEnter += new System.EventHandler(this.EstrellaLabel_MouseEnter);
            this.lblEstrella5.MouseLeave += new System.EventHandler(this.EstrellaLabel_MouseLeave);
            // 
            // lblEstrella4
            // 
            this.lblEstrella4.AutoSize = true;
            this.lblEstrella4.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstrella4.ForeColor = System.Drawing.Color.Gray;
            this.lblEstrella4.Location = new System.Drawing.Point(190, 150);
            this.lblEstrella4.Name = "lblEstrella4";
            this.lblEstrella4.Size = new System.Drawing.Size(40, 45);
            this.lblEstrella4.TabIndex = 9;
            this.lblEstrella4.Text = "☆";
            this.lblEstrella4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEstrella4.Click += new System.EventHandler(this.EstrellaLabel_Click);
            this.lblEstrella4.MouseEnter += new System.EventHandler(this.EstrellaLabel_MouseEnter);
            this.lblEstrella4.MouseLeave += new System.EventHandler(this.EstrellaLabel_MouseLeave);
            // 
            // lblEstrella3
            // 
            this.lblEstrella3.AutoSize = true;
            this.lblEstrella3.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstrella3.ForeColor = System.Drawing.Color.Gray;
            this.lblEstrella3.Location = new System.Drawing.Point(150, 150);
            this.lblEstrella3.Name = "lblEstrella3";
            this.lblEstrella3.Size = new System.Drawing.Size(40, 45);
            this.lblEstrella3.TabIndex = 8;
            this.lblEstrella3.Text = "☆";
            this.lblEstrella3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEstrella3.Click += new System.EventHandler(this.EstrellaLabel_Click);
            this.lblEstrella3.MouseEnter += new System.EventHandler(this.EstrellaLabel_MouseEnter);
            this.lblEstrella3.MouseLeave += new System.EventHandler(this.EstrellaLabel_MouseLeave);
            // 
            // lblEstrella2
            // 
            this.lblEstrella2.AutoSize = true;
            this.lblEstrella2.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstrella2.ForeColor = System.Drawing.Color.Gray;
            this.lblEstrella2.Location = new System.Drawing.Point(110, 150);
            this.lblEstrella2.Name = "lblEstrella2";
            this.lblEstrella2.Size = new System.Drawing.Size(40, 45);
            this.lblEstrella2.TabIndex = 7;
            this.lblEstrella2.Text = "☆";
            this.lblEstrella2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEstrella2.Click += new System.EventHandler(this.EstrellaLabel_Click);
            this.lblEstrella2.MouseEnter += new System.EventHandler(this.EstrellaLabel_MouseEnter);
            this.lblEstrella2.MouseLeave += new System.EventHandler(this.EstrellaLabel_MouseLeave);
            // 
            // lblEstrella1
            // 
            this.lblEstrella1.AutoSize = true;
            this.lblEstrella1.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstrella1.ForeColor = System.Drawing.Color.Gray;
            this.lblEstrella1.Location = new System.Drawing.Point(70, 150);
            this.lblEstrella1.Name = "lblEstrella1";
            this.lblEstrella1.Size = new System.Drawing.Size(40, 45);
            this.lblEstrella1.TabIndex = 6;
            this.lblEstrella1.Text = "☆";
            this.lblEstrella1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEstrella1.Click += new System.EventHandler(this.EstrellaLabel_Click);
            this.lblEstrella1.MouseEnter += new System.EventHandler(this.EstrellaLabel_MouseEnter);
            this.lblEstrella1.MouseLeave += new System.EventHandler(this.EstrellaLabel_MouseLeave);
            // 
            // lblCalificacion
            // 
            this.lblCalificacion.AutoSize = true;
            this.lblCalificacion.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalificacion.Location = new System.Drawing.Point(30, 160);
            this.lblCalificacion.Name = "lblCalificacion";
            this.lblCalificacion.Size = new System.Drawing.Size(34, 16);
            this.lblCalificacion.TabIndex = 5;
            this.lblCalificacion.Text = "★ 1-5";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.lblUsuario.Location = new System.Drawing.Point(110, 130);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(94, 15);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Nombre Usuario";
            // 
            // lblUsuarioLabel
            // 
            this.lblUsuarioLabel.AutoSize = true;
            this.lblUsuarioLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioLabel.Location = new System.Drawing.Point(30, 130);
            this.lblUsuarioLabel.Name = "lblUsuarioLabel";
            this.lblUsuarioLabel.Size = new System.Drawing.Size(74, 15);
            this.lblUsuarioLabel.TabIndex = 3;
            this.lblUsuarioLabel.Text = "Usted es:";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.ForeColor = System.Drawing.Color.DimGray;
            this.lblProveedor.Location = new System.Drawing.Point(110, 100);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(108, 15);
            this.lblProveedor.TabIndex = 2;
            this.lblProveedor.Text = "Nombre Proveedor";
            // 
            // lblProveedorLabel
            // 
            this.lblProveedorLabel.AutoSize = true;
            this.lblProveedorLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedorLabel.Location = new System.Drawing.Point(30, 100);
            this.lblProveedorLabel.Name = "lblProveedorLabel";
            this.lblProveedorLabel.Size = new System.Drawing.Size(74, 15);
            this.lblProveedorLabel.TabIndex = 1;
            this.lblProveedorLabel.Text = "Proveedor:";
            // 
            // lblTituloServicio
            // 
            this.lblTituloServicio.AutoSize = true;
            this.lblTituloServicio.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.lblTituloServicio.Location = new System.Drawing.Point(30, 70);
            this.lblTituloServicio.Name = "lblTituloServicio";
            this.lblTituloServicio.Size = new System.Drawing.Size(118, 18);
            this.lblTituloServicio.TabIndex = 0;
            this.lblTituloServicio.Text = "Título Servicio";
            // 
            // lblInfoServicio
            // 
            this.lblInfoServicio.AutoSize = true;
            this.lblInfoServicio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.lblInfoServicio.Location = new System.Drawing.Point(30, 30);
            this.lblInfoServicio.Name = "lblInfoServicio";
            this.lblInfoServicio.Size = new System.Drawing.Size(215, 19);
            this.lblInfoServicio.TabIndex = 0;
            this.lblInfoServicio.Text = "Información del Servicio";
            // 
            // CalificarServicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 550);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalificarServicioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calificar Servicio";
            this.Load += new System.EventHandler(this.CalificarServicioForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
