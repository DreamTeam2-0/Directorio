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

                    MessageBox.Show($"¡Bienvenido {resultado.nombreCompleto}!\nRol: {resultado.rol}", "Login Exitoso");
                    LimpiarCampos();

                    // SOLUCIÓN DEFINITIVA
                    this.Hide();
                    using (Form1 homepage = new Form1())
                    {
                        homepage.ShowDialog(); // Usar ShowDialog para mantener el contexto
                    }
                    this.Show(); // Volver a mostrar login si homepage se cierra
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

        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtUsuario.Focus();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de registro (RegistroForm)
            RegistroForm formularioRegistro = new RegistroForm();
            formularioRegistro.ShowDialog();
        }
    }
}