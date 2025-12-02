using System;

namespace LoginDirectorio.RegistroFases
{
    partial class FaseDatosBasicos
    {
        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPasswordReg = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtIdentificacionOficial = new System.Windows.Forms.TextBox();
            this.txtDireccionAproximada = new System.Windows.Forms.TextBox();
            this.txtZonasServicio = new System.Windows.Forms.TextBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblIdentificacionOficial = new System.Windows.Forms.Label();
            this.lblDireccionAproximada = new System.Windows.Forms.Label();
            this.lblZonasServicio = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // FaseDatosBasicos
            this.Size = new System.Drawing.Size(360, 600);
            this.BackColor = System.Drawing.Color.White;

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(30, 20);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(54, 15);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Usuario:";

            // txtUsername
            this.txtUsername.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUsername.Location = new System.Drawing.Point(30, 40);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 23);
            this.txtUsername.TabIndex = 1;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(30, 70);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(79, 15);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Contraseña:";

            // txtPasswordReg
            this.txtPasswordReg.Font = new System.Drawing.Font("Arial", 10F);
            this.txtPasswordReg.Location = new System.Drawing.Point(30, 90);
            this.txtPasswordReg.Name = "txtPasswordReg";
            this.txtPasswordReg.PasswordChar = '•';
            this.txtPasswordReg.Size = new System.Drawing.Size(300, 23);
            this.txtPasswordReg.TabIndex = 3;

            // lblConfirmPassword
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfirmPassword.Location = new System.Drawing.Point(30, 120);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(127, 15);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Confirmar Contraseña:";

            // txtConfirmPassword
            this.txtConfirmPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(30, 140);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '•';
            this.txtConfirmPassword.Size = new System.Drawing.Size(300, 23);
            this.txtConfirmPassword.TabIndex = 5;

            // lblNombres
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombres.Location = new System.Drawing.Point(30, 170);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(60, 15);
            this.lblNombres.TabIndex = 6;
            this.lblNombres.Text = "Nombres:";

            // txtNombres
            this.txtNombres.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNombres.Location = new System.Drawing.Point(30, 190);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(300, 23);
            this.txtNombres.TabIndex = 7;

            // lblApellidos
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblApellidos.Location = new System.Drawing.Point(30, 220);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(60, 15);
            this.lblApellidos.TabIndex = 8;
            this.lblApellidos.Text = "Apellidos:";

            // txtApellidos
            this.txtApellidos.Font = new System.Drawing.Font("Arial", 10F);
            this.txtApellidos.Location = new System.Drawing.Point(30, 240);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(300, 23);
            this.txtApellidos.TabIndex = 9;

            // lblCiudad
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblCiudad.Location = new System.Drawing.Point(30, 270);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(50, 15);
            this.lblCiudad.TabIndex = 10;
            this.lblCiudad.Text = "Ciudad:";

            // txtCiudad
            this.txtCiudad.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCiudad.Location = new System.Drawing.Point(30, 290);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(300, 23);
            this.txtCiudad.TabIndex = 11;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(30, 320);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(45, 15);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Font = new System.Drawing.Font("Arial", 10F);
            this.txtEmail.Location = new System.Drawing.Point(30, 340);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 23);
            this.txtEmail.TabIndex = 13;

            // lblTelefono
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.Location = new System.Drawing.Point(30, 370);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(60, 15);
            this.lblTelefono.TabIndex = 14;
            this.lblTelefono.Text = "Teléfono:";

            // txtTelefono
            this.txtTelefono.Font = new System.Drawing.Font("Arial", 10F);
            this.txtTelefono.Location = new System.Drawing.Point(30, 390);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(300, 23);
            this.txtTelefono.TabIndex = 15;

            // lblIdentificacionOficial
            this.lblIdentificacionOficial.AutoSize = true;
            this.lblIdentificacionOficial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdentificacionOficial.Location = new System.Drawing.Point(30, 420);
            this.lblIdentificacionOficial.Name = "lblIdentificacionOficial";
            this.lblIdentificacionOficial.Size = new System.Drawing.Size(130, 15);
            this.lblIdentificacionOficial.TabIndex = 16;
            this.lblIdentificacionOficial.Text = "Identificación Oficial:";

            // txtIdentificacionOficial
            this.txtIdentificacionOficial.Font = new System.Drawing.Font("Arial", 10F);
            this.txtIdentificacionOficial.Location = new System.Drawing.Point(30, 440);
            this.txtIdentificacionOficial.Name = "txtIdentificacionOficial";
            this.txtIdentificacionOficial.Size = new System.Drawing.Size(300, 23);
            this.txtIdentificacionOficial.TabIndex = 17;

            // lblDireccionAproximada
            this.lblDireccionAproximada.AutoSize = true;
            this.lblDireccionAproximada.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblDireccionAproximada.Location = new System.Drawing.Point(30, 470);
            this.lblDireccionAproximada.Name = "lblDireccionAproximada";
            this.lblDireccionAproximada.Size = new System.Drawing.Size(140, 15);
            this.lblDireccionAproximada.TabIndex = 18;
            this.lblDireccionAproximada.Text = "Dirección Aproximada:";

            // txtDireccionAproximada
            this.txtDireccionAproximada.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDireccionAproximada.Location = new System.Drawing.Point(30, 490);
            this.txtDireccionAproximada.Name = "txtDireccionAproximada";
            this.txtDireccionAproximada.Size = new System.Drawing.Size(300, 23);
            this.txtDireccionAproximada.TabIndex = 19;

            // lblZonasServicio
            this.lblZonasServicio.AutoSize = true;
            this.lblZonasServicio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblZonasServicio.Location = new System.Drawing.Point(30, 520);
            this.lblZonasServicio.Name = "lblZonasServicio";
            this.lblZonasServicio.Size = new System.Drawing.Size(100, 15);
            this.lblZonasServicio.TabIndex = 20;
            this.lblZonasServicio.Text = "Zonas de Servicio:";

            // txtZonasServicio
            this.txtZonasServicio.Font = new System.Drawing.Font("Arial", 10F);
            this.txtZonasServicio.Location = new System.Drawing.Point(30, 540);
            this.txtZonasServicio.Name = "txtZonasServicio";
            this.txtZonasServicio.Size = new System.Drawing.Size(300, 23);
            this.txtZonasServicio.TabIndex = 21;

            // btnVolver
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnVolver.FlatAppearance.BorderSize = 2;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnVolver.Location = new System.Drawing.Point(180, 570);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(150, 25);
            this.btnVolver.TabIndex = 22;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // btnSiguiente
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSiguiente.Location = new System.Drawing.Point(30, 570);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(150, 25);
            this.btnSiguiente.TabIndex = 23;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);

            // Agregar controles
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPasswordReg);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.lblApellidos);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblIdentificacionOficial);
            this.Controls.Add(this.txtIdentificacionOficial);
            this.Controls.Add(this.lblDireccionAproximada);
            this.Controls.Add(this.txtDireccionAproximada);
            this.Controls.Add(this.lblZonasServicio);
            this.Controls.Add(this.txtZonasServicio);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnSiguiente);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            SiguienteClick?.Invoke(this, e);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverClick?.Invoke(this, e);
        }
    }
}