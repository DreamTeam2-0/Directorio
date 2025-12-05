using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelp.DatabaseHelper;
using PassHelp.PasswordHelper;
using Shared.Session;
using Homepage;
using ProveedorHome; // Agregar este using para la interfaz de proveedor

namespace LoginDirectorio
{
    public partial class LoginDirectory : Form
    {
        private DatabaseHelper dbHelper;

        public LoginDirectory()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

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

            var resultado = dbHelper.ValidarLoginConVerificacion(usuario, password);

            if (resultado.success)
            {
                var idResult = dbHelper.ObtenerIdUsuario(usuario);

                if (idResult.success)
                {
                    UserSession.IniciarSesion(idResult.idUsuario, usuario, resultado.nombreCompleto, resultado.rol);

                    MessageBox.Show($"¡Bienvenido {resultado.nombreCompleto}!", "Login Exitoso");
                    LimpiarCampos();

                    // REDIRECCIÓN SEGÚN ROL
                    this.Hide();

                    // Verificar el rol para abrir la interfaz correspondiente
                    AbrirInterfazSegunRol(resultado.rol);
                }
                else
                {
                    MessageBox.Show("Error al iniciar sesión", "Error");
                }
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error de Login");
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
        }

        private void AbrirInterfazSegunRol(string rol)
        {
            switch (rol.ToLower())
            {
                case "empleado":
                    AbrirInterfazProveedor();
                    break;

                case "cliente":
                    AbrirInterfazCliente();
                    break;

                default:
                    // Por defecto, abrir la interfaz de cliente
                    MessageBox.Show($"Rol '{rol}' detectado. Abriendo interfaz por defecto.",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AbrirInterfazCliente();
                    break;
            }
        }

        private void AbrirInterfazCliente()
        {
            Form1 homepage = new Form1();
            homepage.FormClosed += (s, args) =>
            {
                // Cuando Form1 se cierra completamente, mostrar login
                this.Show();
            };
            homepage.Show();
        }

        private void AbrirInterfazProveedor()
        {
            Proveedor proveedorForm = new Proveedor();
            proveedorForm.FormClosed += (s, args) =>
            {
                // Cuando Proveedor se cierra completamente, mostrar login
                this.Show();
            };
            proveedorForm.Show();
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtUsuario.Focus();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea registrarse como Cliente o como Proveedor de servicios?",
                                                  "Tipo de Registro",
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes) // Sí = Cliente
            {
                RegistroForm formularioRegistro = new RegistroForm();
                formularioRegistro.ShowDialog();
            }
            else if (result == DialogResult.No) // No = Proveedor
            {
                this.Hide();
                var formularioProveedor = new RegistroProveedorForm();
                formularioProveedor.FormClosed += (s, args) => this.Show();
                formularioProveedor.Show();
            }
            // Si es Cancel, no hace nada
        }
    }
}