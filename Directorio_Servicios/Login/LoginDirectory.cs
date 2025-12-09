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

            CargarLogotipo();
        }

        private void CargarLogotipo()
        {
            try
            {
                // Usa la ruta completa o relativa según donde esté tu proyecto
                string rutaImagen = @"C:\Users\ROG STRIX\Downloads\logo2.png"; // Ruta completa
                                                                               // O si quieres usar una ruta relativa:
                                                                               // string rutaImagen = Path.Combine(Application.StartupPath, "Resources", "logo2.png");

                if (System.IO.File.Exists(rutaImagen))
                {
                    pictureBoxLogo.Image = Image.FromFile(rutaImagen);
                    pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom; // Mantener proporciones
                }
                else
                {
                    MessageBox.Show($"No se encontró la imagen en: {rutaImagen}\nMostrando texto alternativo.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Mostrar texto alternativo si no se encuentra la imagen
                    pictureBoxLogo.Image?.Dispose();
                    pictureBoxLogo.Image = null;

                    // Crear una etiqueta temporal
                    using (Graphics g = pictureBoxLogo.CreateGraphics())
                    {
                        g.Clear(Color.White);
                        g.DrawString("LOGO",
                                     new Font("Arial", 16, FontStyle.Bold),
                                     Brushes.Green,
                                     new PointF(10, 40));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el logotipo: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                // IMPORTANTE: Verificar si la aplicación ya se está cerrando
                if (!Application.MessageLoop)
                    return;

                // Cuando Form1 se cierra completamente, mostrar login
                if (!this.IsDisposed && this.Visible == false)
                {
                    this.Show();
                    this.Focus();
                }
            };
            homepage.Show();
        }

        private void AbrirInterfazProveedor()
        {
            Proveedor proveedorForm = new Proveedor();
            proveedorForm.FormClosed += (s, args) =>
            {
                // IMPORTANTE: Verificar si la aplicación ya se está cerrando
                if (!Application.MessageLoop)
                    return;

                // Cuando Proveedor se cierra completamente, mostrar login
                if (!this.IsDisposed && this.Visible == false)
                {
                    this.Show();
                    this.Focus();
                }
            };
            proveedorForm.Show();
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtUsuario.Focus();
        }

        private void LoginDirectory_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Confirmar cierre de aplicación
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var resultado = MessageBox.Show("¿Está seguro que desea salir de la aplicación?",
                                              "Salir",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Asegurar que la sesión se cierra correctamente
                    UserSession.CerrarSesion();

                    // Forzar cierre de todos los hilos
                    Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (var formSeleccion = new SeleccionRegistroForm())
            {
                var result = formSeleccion.ShowDialog();

                if (result == DialogResult.OK)
                {
                    switch (formSeleccion.TipoSeleccionado)
                    {
                        case SeleccionRegistroForm.TipoRegistro.Cliente:
                            RegistroForm formularioRegistro = new RegistroForm();
                            formularioRegistro.ShowDialog();
                            break;

                        case SeleccionRegistroForm.TipoRegistro.Proveedor:
                            this.Hide();
                            var formularioProveedor = new RegistroProveedorForm();
                            formularioProveedor.FormClosed += (s, args) => this.Show();
                            formularioProveedor.Show();
                            break;

                        case SeleccionRegistroForm.TipoRegistro.Ninguno:
                        default:
                            // No hacer nada
                            break;
                    }
                }
            }
        }
    }
}
