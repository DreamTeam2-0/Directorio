// LoginAdminForm.cs
using CRUD_Directorio.AdminSystem;
using DataBase;
using MySql.Data.MySqlClient;
using Shared.Session;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD_Directorio.Login
{
    public partial class LoginAdminForm : Form
    {
        public LoginAdminForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();

                    // Verificar credenciales
                    string query = @"SELECT us.ID_Usuario_Sistema, us.username, us.nombres, us.apellidos, r.nombre as rol
                           FROM usuarios_sistema us
                           INNER JOIN roles r ON us.ID_Rol = r.ID_Rol
                           WHERE us.username = @username 
                           AND us.password_hash = SHA2(@password, 256)
                           AND (r.nombre = 'admin' OR r.nombre = 'administrador')
                           AND us.activo = 1";

                    MySqlParameter[] parameters = {
                new MySqlParameter("@username", username),
                new MySqlParameter("@password", password)
            };

                    MySqlDataReader reader = null;
                    try
                    {
                        reader = db.ExecuteReader(query, parameters);

                        if (reader.Read())
                        {
                            int idUsuario = reader.GetInt32("ID_Usuario_Sistema");
                            string nombreCompleto = $"{reader.GetString("nombres")} {reader.GetString("apellidos")}";
                            string rol = reader.GetString("rol");

                            // Cerrar el reader ANTES de usar la conexión de nuevo
                            reader.Close();
                            reader = null;

                            // Iniciar sesión
                            UserSession.IniciarSesionAdmin(idUsuario, username, nombreCompleto, rol);

                            // Registrar acción en sistema (ahora sí puede usar la conexión)
                            RegistrarAccionLogin(db, idUsuario, "Inicio de sesión administrador");

                            // Abrir formulario principal de admin
                            AdminMainForm mainForm = new AdminMainForm();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Credenciales incorrectas o no tiene permisos de administrador",
                                "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    finally
                    {
                        if (reader != null && !reader.IsClosed)
                            reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarAccionLogin(BDConector db, int idUsuario, string accion)
        {
            try
            {
                // Crear una NUEVA instancia de BDConector para esta operación
                using (BDConector dbSeparada = new BDConector())
                {
                    dbSeparada.Open();

                    string query = @"INSERT INTO acciones_sistema 
                           (ID_Usuario_Sistema, accion, tabla_afectada, registro_afectado_id, detalles) 
                           VALUES (@idUsuario, @accion, NULL, NULL, @detalles)";

                    MySqlParameter[] parameters = {
                new MySqlParameter("@idUsuario", idUsuario),
                new MySqlParameter("@accion", accion),
                new MySqlParameter("@detalles", $"Login desde IP: {GetLocalIPAddress()} - Hora: {DateTime.Now}")
            };

                    dbSeparada.ExecuteNonQuery(query, parameters);
                }
            }
            catch (Exception ex)
            {
                // Solo log, no mostrar error al usuario
                Console.WriteLine($"Error al registrar acción de login: {ex.Message}");
            }
        }

        private string GetLocalIPAddress()
        {
            try
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return "127.0.0.1";
            }
            catch
            {
                return "127.0.0.1";
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        // Variable para controlar si ya se mostró el mensaje de confirmación
        private bool confirmacionMostrada = false;

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Llamar al método que pregunta y cierra
            CerrarConConfirmacion();
        }

        private void LoginAdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si ya se mostró la confirmación, permitir el cierre
            if (confirmacionMostrada)
            {
                // Ya se preguntó, solo cerrar sesión y salir
                UserSession.CerrarSesion();
                return;
            }

            // Cancelar el cierre automático para manejar nosotros
            e.Cancel = true;

            // Llamar al método que pregunta y cierra
            CerrarConConfirmacion();
        }

        private void CerrarConConfirmacion()
        {
            // Si ya se mostró la confirmación, salir
            if (confirmacionMostrada) return;

            // Mostrar confirmación UNA sola vez
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cerrar la aplicación?",
                "Cerrar Aplicación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                // Marcar que ya se mostró la confirmación
                confirmacionMostrada = true;

                // Cerrar sesión
                UserSession.CerrarSesion();

                // Cerrar la aplicación completamente
                Application.Exit();
                Environment.Exit(0);
            }
            // Si el usuario dice No, no hacer nada
            // confirmacionMostrada sigue siendo false para futuros intentos
        }
    }
}