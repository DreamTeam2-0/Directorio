
using Perfil.Modelos;
using Perfil.Logica;
using System;
using System.Windows.Forms;

namespace Perfil
{
    public partial class PerfilForm : Form
    {
        private readonly PerfilServicio _perfilServicio;
        private bool _modoEdicion = false;

        public PerfilForm()
        {
            InitializeComponent();
            _perfilServicio = new PerfilServicio();
        }

        private void PerfilForm_Load(object sender, EventArgs e)
        {
            CargarDatosPerfil();
            ConfigurarModoLectura();
        }

        private void CargarDatosPerfil()
        {
            try
            {
                var perfil = _perfilServicio.ObtenerPerfil();

                // Si no hay datos en BD, usar datos mock
                if (perfil == null)
                {
                    MostrarDatosMock();
                    return;
                }

                // Cargar datos desde BD
                ActualizarControles(perfil);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar perfil: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                MostrarDatosMock();
            }
        }

        private void ActualizarControles(PerfilUsuario perfil)
        {
            lblTitulo.Text = $"{perfil.Nombres} {perfil.Apellidos}";
            txtNombres.Text = perfil.Nombres;
            txtApellidos.Text = perfil.Apellidos;
            txtTelefono.Text = perfil.Telefono;
            txtWhatsapp.Text = perfil.Whatsapp;
            txtCorreo.Text = perfil.Email;
            txtOtroContacto.Text = perfil.OtroContacto;
            txtUbicacion.Text = $"{perfil.Ciudad} - {perfil.DireccionAproximada}";
        }

        private void MostrarDatosMock()
        {
            // Datos de ejemplo cuando no hay datos en BD
            lblTitulo.Text = "Nombre de Usuario";
            txtNombres.Text = "Nombres";
            txtApellidos.Text = "Apellidos";
            txtTelefono.Text = "000-000-0000";
            txtWhatsapp.Text = "000-000-0000";
            txtCorreo.Text = "usuario@ejemplo.com";
            txtOtroContacto.Text = "Instagram: @usuario";
            txtUbicacion.Text = "Ciudad, Zona";
        }

        private void btnEditarDatos_Click(object sender, EventArgs e)
        {
            if (!_modoEdicion)
            {
                // Activar modo edición
                ActivarModoEdicion();
            }
            else
            {
                // Guardar cambios
                GuardarCambios();
            }
        }

        private void ActivarModoEdicion()
        {
            _modoEdicion = true;

            // Habilitar edición de campos
            txtNombres.ReadOnly = false;
            txtApellidos.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtWhatsapp.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtOtroContacto.ReadOnly = false;
            txtUbicacion.ReadOnly = false;

            // Cambiar aspecto visual de campos editables
            CambiarEstiloEdicion(true);

            // Cambiar texto del botón
            btnEditarDatos.Text = "Guardar Cambios";
            btnEditarDatos.BackColor = System.Drawing.Color.FromArgb(33, 150, 243); // Azul para guardar

            // Cambiar texto del botón volver a "Cancelar"
            btnVolverMenu.Text = "Cancelar";
            btnVolverMenu.BackColor = System.Drawing.Color.FromArgb(244, 67, 54); // Rojo para cancelar
        }

        private void ConfigurarModoLectura()
        {
            _modoEdicion = false;

            // Deshabilitar edición de campos
            txtNombres.ReadOnly = true;
            txtApellidos.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtWhatsapp.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtOtroContacto.ReadOnly = true;
            txtUbicacion.ReadOnly = true;

            // Restaurar estilo visual
            CambiarEstiloEdicion(false);

            // Restaurar texto de botones
            btnEditarDatos.Text = "Editar Datos";
            btnEditarDatos.BackColor = System.Drawing.Color.FromArgb(76, 175, 80); // Verde original

            btnVolverMenu.Text = "Volver al Menú";
            btnVolverMenu.BackColor = System.Drawing.Color.FromArgb(192, 192, 192); // Gris original
        }

        private void CambiarEstiloEdicion(bool modoEdicion)
        {
            var backColor = modoEdicion ? System.Drawing.Color.LightYellow : System.Drawing.Color.White;
            var borderColor = modoEdicion ? System.Drawing.Color.FromArgb(33, 150, 243) : System.Drawing.SystemColors.WindowFrame;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BackColor = backColor;
                    textBox.BorderStyle = modoEdicion ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;
                }
            }
        }

        private void GuardarCambios()
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtNombres.Text))
                {
                    MessageBox.Show("El campo Nombres es obligatorio", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombres.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellidos.Text))
                {
                    MessageBox.Show("El campo Apellidos es obligatorio", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellidos.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("El campo Correo es obligatorio", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("El campo Teléfono es obligatorio", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return;
                }

                // Validar formato de email
                if (!EsEmailValido(txtCorreo.Text))
                {
                    MessageBox.Show("Por favor ingrese un correo electrónico válido", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return;
                }

                // Parsear ubicación (separar ciudad y dirección)
                var ubicacion = txtUbicacion.Text;
                var partesUbicacion = _perfilServicio.ParsearUbicacion(ubicacion);

                // Crear objeto PerfilUsuario con los datos actualizados
                var perfilActualizado = new PerfilUsuario
                {
                    Nombres = txtNombres.Text.Trim(),
                    Apellidos = txtApellidos.Text.Trim(),
                    Ciudad = partesUbicacion[0],
                    DireccionAproximada = partesUbicacion[1],
                    Email = txtCorreo.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Whatsapp = txtWhatsapp.Text.Trim(),
                    OtroContacto = txtOtroContacto.Text.Trim()
                };

                // Guardar en base de datos
                bool resultado = _perfilServicio.ActualizarPerfil(perfilActualizado);

                if (resultado)
                {
                    MessageBox.Show("Datos actualizados correctamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar título con nuevos datos
                    lblTitulo.Text = $"{perfilActualizado.Nombres} {perfilActualizado.Apellidos}";

                    // Volver a modo lectura
                    ConfigurarModoLectura();
                }
                else
                {
                    MessageBox.Show("No se pudieron guardar los cambios", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            if (_modoEdicion)
            {
                // Si estamos en modo edición, preguntar si desea cancelar
                var result = MessageBox.Show("¿Está seguro de que desea cancelar la edición? Los cambios no guardados se perderán.",
                                           "Cancelar Edición",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Recargar datos originales
                    CargarDatosPerfil();
                    ConfigurarModoLectura();
                }
            }
            else
            {
                // Cerrar formulario
                this.Close();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y caracteres de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtWhatsapp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y caracteres de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
