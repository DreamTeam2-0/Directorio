using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginDirectorio
{
    public class LoginForm : Form
    {
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegistrar;
        private DatabaseHelper dbHelper;

        public LoginForm()
        {
            dbHelper = new DatabaseHelper();
            InitializeForm();
            CrearControles();
        }

        private void InitializeForm()
        {
            this.Text = "Directorio - Login";
            this.Size = new Size(400, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void CrearControles()
        {
            // 1. LABEL - Título "LOGOTIPO" - VERDE
            Label lblTitulo = new Label();
            lblTitulo.Text = "LOGOTIPO";
            lblTitulo.Font = new Font("Arial", 24, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(34, 139, 34); // Verde forestal
            lblTitulo.Size = new Size(200, 40);
            lblTitulo.Location = new Point(100, 50);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            // 2. LABEL - Subtítulo
            Label lblSubtitulo = new Label();
            lblSubtitulo.Text = "Tu directorio de confianza, donde encontrarás\ntodo lo que necesites.";
            lblSubtitulo.Font = new Font("Arial", 10, FontStyle.Regular);
            lblSubtitulo.ForeColor = Color.Gray;
            lblSubtitulo.Size = new Size(300, 40);
            lblSubtitulo.Location = new Point(50, 100);
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblSubtitulo);

            // 3. LABEL - "Nombre de usuario"
            Label lblUsuario = new Label();
            lblUsuario.Text = "Nombre de usuario";
            lblUsuario.Font = new Font("Arial", 9, FontStyle.Bold);
            lblUsuario.ForeColor = Color.Black;
            lblUsuario.Size = new Size(150, 20);
            lblUsuario.Location = new Point(50, 180);
            this.Controls.Add(lblUsuario);

            // 4. TEXTBOX - Para escribir el usuario
            txtUsuario = new TextBox();
            txtUsuario.Size = new Size(300, 30);
            txtUsuario.Location = new Point(50, 200);
            txtUsuario.Font = new Font("Arial", 11);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtUsuario);

            // 5. LABEL - "Contraseña"
            Label lblPassword = new Label();
            lblPassword.Text = "Contraseña";
            lblPassword.Font = new Font("Arial", 9, FontStyle.Bold);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Size = new Size(150, 20);
            lblPassword.Location = new Point(50, 250);
            this.Controls.Add(lblPassword);

            // 6. TEXTBOX - Para escribir la contraseña
            txtPassword = new TextBox();
            txtPassword.Size = new Size(300, 30);
            txtPassword.Location = new Point(50, 270);
            txtPassword.Font = new Font("Arial", 11);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyPress += new KeyPressEventHandler(txtPassword_KeyPress);
            this.Controls.Add(txtPassword);

            // 7. BUTTON - "Iniciar sesión" - VERDE
            btnLogin = new Button();
            btnLogin.Text = "Iniciar sesión";
            btnLogin.Size = new Size(300, 40);
            btnLogin.Location = new Point(50, 330);
            btnLogin.BackColor = Color.FromArgb(34, 139, 34); // Verde forestal
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Arial", 11, FontStyle.Bold);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Click += new EventHandler(btnLogin_Click);
            this.Controls.Add(btnLogin);

            // 8. BUTTON - "Registrarse" - BORDE VERDE
            btnRegistrar = new Button();
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.Size = new Size(300, 40);
            btnRegistrar.Location = new Point(50, 390);
            btnRegistrar.BackColor = Color.White;
            btnRegistrar.ForeColor = Color.FromArgb(34, 139, 34); // Verde forestal
            btnRegistrar.Font = new Font("Arial", 11, FontStyle.Bold);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.FlatAppearance.BorderColor = Color.FromArgb(34, 139, 34); // Verde forestal
            btnRegistrar.FlatAppearance.BorderSize = 2;
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.Click += new EventHandler(btnRegistrar_Click);
            this.Controls.Add(btnRegistrar);
        }

        // MÉTODO DE LOGIN
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidarLogin();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidarLogin();
                e.Handled = true;
            }
        }

        private void ValidarLogin()
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }

            var resultado = dbHelper.ValidarLogin(usuario, password);

            if (resultado.success)
            {
                MessageBox.Show($"¡Bienvenido {resultado.nombreCompleto}!\nRol: {resultado.rol}", "Login Exitoso");
                LimpiarCampos();
                // Aquí puedes abrir el formulario principal
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error de Login");
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
        }

        // MÉTODO DE REGISTRO
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (Form formularioRegistro = new Form())
            {
                formularioRegistro.Text = "Registrar Nuevo Usuario";
                formularioRegistro.Size = new Size(400, 450);
                formularioRegistro.StartPosition = FormStartPosition.CenterScreen;
                formularioRegistro.FormBorderStyle = FormBorderStyle.FixedDialog;
                formularioRegistro.MaximizeBox = false;

                // Controles del formulario de registro
                int yPos = 20;

                Label lblUsername = new Label() { Text = "Usuario:", Location = new Point(30, yPos), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
                TextBox txtUsername = new TextBox() { Location = new Point(30, yPos + 20), Size = new Size(300, 20), Font = new Font("Arial", 10) };
                yPos += 50;

                Label lblPassword = new Label() { Text = "Contraseña:", Location = new Point(30, yPos), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
                TextBox txtPasswordReg = new TextBox() { Location = new Point(30, yPos + 20), Size = new Size(300, 20), Font = new Font("Arial", 10), UseSystemPasswordChar = true };
                yPos += 50;

                Label lblNombres = new Label() { Text = "Nombres:", Location = new Point(30, yPos), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
                TextBox txtNombres = new TextBox() { Location = new Point(30, yPos + 20), Size = new Size(300, 20), Font = new Font("Arial", 10) };
                yPos += 50;

                Label lblApellidos = new Label() { Text = "Apellidos:", Location = new Point(30, yPos), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
                TextBox txtApellidos = new TextBox() { Location = new Point(30, yPos + 20), Size = new Size(300, 20), Font = new Font("Arial", 10) };
                yPos += 50;

                Label lblEmail = new Label() { Text = "Email:", Location = new Point(30, yPos), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
                TextBox txtEmail = new TextBox() { Location = new Point(30, yPos + 20), Size = new Size(300, 20), Font = new Font("Arial", 10) };
                yPos += 50;

                Label lblTelefono = new Label() { Text = "Teléfono:", Location = new Point(30, yPos), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
                TextBox txtTelefono = new TextBox() { Location = new Point(30, yPos + 20), Size = new Size(300, 20), Font = new Font("Arial", 10) };
                yPos += 50;

                // Botón Registrar - VERDE
                Button btnConfirmarRegistro = new Button()
                {
                    Text = "Registrarse como Cliente",
                    Location = new Point(30, yPos + 10),
                    Size = new Size(300, 35),
                    BackColor = Color.FromArgb(34, 139, 34), // Verde forestal
                    ForeColor = Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat
                };

                btnConfirmarRegistro.Click += (s, ev) =>
                {
                    string username = txtUsername.Text.Trim();
                    string password = txtPasswordReg.Text;
                    string nombres = txtNombres.Text.Trim();
                    string apellidos = txtApellidos.Text.Trim();
                    string email = txtEmail.Text.Trim();
                    string telefono = txtTelefono.Text.Trim();

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                        string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos) ||
                        string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefono))
                    {
                        MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var resultado = dbHelper.RegistrarUsuario(username, password, nombres, apellidos, email, telefono);

                    if (resultado.success)
                    {
                        MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        formularioRegistro.Close();
                    }
                    else
                    {
                        MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                formularioRegistro.Controls.AddRange(new Control[] {
                    lblUsername, txtUsername, lblPassword, txtPasswordReg,
                    lblNombres, txtNombres, lblApellidos, txtApellidos,
                    lblEmail, txtEmail, lblTelefono, txtTelefono,
                    btnConfirmarRegistro
                });

                formularioRegistro.ShowDialog();
            }
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtUsuario.Focus();
        }
    }
}