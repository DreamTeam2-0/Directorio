using Perfil.Modelos;
using Perfil.Logica;
using System;
using System.Windows.Forms;

namespace Perfil
{
    public partial class PerfilForm : Form
    {
        private readonly PerfilServicio _perfilServicio;

        public PerfilForm()
        {
            InitializeComponent();
            _perfilServicio = new PerfilServicio();
        }

        private void PerfilForm_Load(object sender, EventArgs e)
        {
            CargarDatosPerfil();
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
                lblTitulo.Text = $"{perfil.Nombres} {perfil.Apellidos}";
                txtNombres.Text = perfil.Nombres;
                txtApellidos.Text = perfil.Apellidos;
                txtTelefono.Text = perfil.Telefono;
                txtWhatsapp.Text = perfil.Whatsapp;
                txtCorreo.Text = perfil.Email;
                txtOtroContacto.Text = perfil.OtroContacto;
                txtUbicacion.Text = $"{perfil.Ciudad} - {perfil.DireccionAproximada}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar perfil: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                MostrarDatosMock();
            }
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
            // Aquí implementarás la edición de datos
            MessageBox.Show("Funcionalidad de edición se implementará aquí",
                          "Editar Datos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }


        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            // Cerrar este formulario (PerfilForm)
            this.Close();

            // Form1 se mostrará automáticamente gracias al evento FormClosed que configuramos
        }
    }
}