using System;
using DBHelp.DatabaseHelper;
using PassHelp.PasswordHelper;
using System.Drawing;
using System.Windows.Forms;

namespace LoginDirectorio
{
    public partial class RegistroForm : Form
    {
        private DatabaseHelper dbHelper;

        public RegistroForm()
        {
            dbHelper = new DatabaseHelper();
            InitializeComponent();
        }

        private void btnConfirmarRegistro_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPasswordReg.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            // Validar campos obligatorios
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(nombres) ||
                string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(ciudad) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que las contraseñas coincidan
            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordReg.Text = "";
                txtConfirmPassword.Text = "";
                txtPasswordReg.Focus();
                return;
            }

            // Validar fortaleza de contraseña
            if (password.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Encriptar la contraseña antes de enviarla a la BD
            string passwordEncriptado = PasswordHelper.EncriptarPassword(password);

            var resultado = dbHelper.RegistrarUsuario(username, passwordEncriptado, nombres, apellidos, ciudad, email, telefono);

            if (resultado.success)
            {
                MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}