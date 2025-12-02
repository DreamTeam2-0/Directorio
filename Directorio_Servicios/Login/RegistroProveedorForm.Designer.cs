namespace LoginDirectorio
{
    partial class RegistroProveedorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCertificado;
        private System.Windows.Forms.Button btnEmpirico;
        private System.Windows.Forms.Label lblSeleccion;
        private System.Windows.Forms.Button btnVolver;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblSeleccion = new System.Windows.Forms.Label();
            this.btnEmpirico = new System.Windows.Forms.Button();
            this.btnCertificado = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // panel1
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.lblSeleccion);
            this.panel1.Controls.Add(this.btnEmpirico);
            this.panel1.Controls.Add(this.btnCertificado);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 600);
            this.panel1.TabIndex = 0;

            // btnVolver
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnVolver.FlatAppearance.BorderSize = 2;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnVolver.Location = new System.Drawing.Point(30, 500);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(300, 40);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver al Login";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // lblSeleccion
            this.lblSeleccion.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSeleccion.ForeColor = System.Drawing.Color.Gray;
            this.lblSeleccion.Location = new System.Drawing.Point(30, 150);
            this.lblSeleccion.Name = "lblSeleccion";
            this.lblSeleccion.Size = new System.Drawing.Size(300, 40);
            this.lblSeleccion.TabIndex = 3;
            this.lblSeleccion.Text = "Seleccione el tipo de proveedor que desea registrar:";
            this.lblSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnEmpirico
            this.btnEmpirico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnEmpirico.FlatAppearance.BorderSize = 0;
            this.btnEmpirico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpirico.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnEmpirico.ForeColor = System.Drawing.Color.White;
            this.btnEmpirico.Location = new System.Drawing.Point(30, 300);
            this.btnEmpirico.Name = "btnEmpirico";
            this.btnEmpirico.Size = new System.Drawing.Size(300, 50);
            this.btnEmpirico.TabIndex = 2;
            this.btnEmpirico.Text = "Empírico (Experiencia Práctica)";
            this.btnEmpirico.UseVisualStyleBackColor = false;
            this.btnEmpirico.Click += new System.EventHandler(this.btnEmpirico_Click);

            // btnCertificado
            this.btnCertificado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnCertificado.FlatAppearance.BorderSize = 0;
            this.btnCertificado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCertificado.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCertificado.ForeColor = System.Drawing.Color.White;
            this.btnCertificado.Location = new System.Drawing.Point(30, 220);
            this.btnCertificado.Name = "btnCertificado";
            this.btnCertificado.Size = new System.Drawing.Size(300, 50);
            this.btnCertificado.TabIndex = 1;
            this.btnCertificado.Text = "Profesional Certificado";
            this.btnCertificado.UseVisualStyleBackColor = false;
            this.btnCertificado.Click += new System.EventHandler(this.btnCertificado_Click);

            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 80);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Proveedor";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // RegistroProveedorForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 600);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegistroProveedorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Proveedor";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}