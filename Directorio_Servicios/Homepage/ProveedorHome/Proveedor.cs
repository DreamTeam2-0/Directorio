using Shared.Session;
using System;
using System.Windows.Forms;
using ProveedorHome.Logica;
using ProveedorHome.Servicios;
using Perfil;
using FranjaManager = ProveedorHome.Logica.FranjaManager;
using PanelManager = ProveedorHome.Logica.PanelManager;

namespace ProveedorHome
{
    public partial class Proveedor : Form
    {
        private PanelManager _panelManager;
        private FranjaManager _franjaManager;
        private ProveedorServicios _proveedorServicios;
        private bool _cerrandoParaPerfil = false;

        public Proveedor()
        {
            InitializeComponent();

            // Inicializar manejadores y servicios
            _panelManager = new PanelManager(panelLateral);
            _franjaManager = new FranjaManager(this, lblBienvenida);
            _proveedorServicios = new ProveedorServicios();

            // Configurar eventos
            this.Load += PrincipalProveedor_Load;
            this.Click += PrincipalProveedor_Click;
            this.FormClosing += PrincipalProveedor_FormClosing;
            this.KeyPreview = true;

            lblBienvenida.BackColor = System.Drawing.Color.Transparent;
        }

        private void PrincipalProveedor_Load(object sender, EventArgs e)
        {
            if (!UserSession.SesionActiva)
            {
                MessageBox.Show("No hay sesión activa. Será redirigido al login.", "Sesión Expirada",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            lblBienvenida.Text = $"Bienvenido, {UserSession.NombreCompleto}";

            // Crear franja verde
            _franjaManager.CrearFranjaVerde();

            // Cargar datos iniciales desde BD
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            // Cargar estadísticas reales
            CargarEstadisticas();

            // Cargar servicios reales
            _proveedorServicios.CargarServicios(flpServicios, UserSession.IdUsuario);

            // Cargar calificaciones reales
            CargarCalificacionesRecientes();
        }

        private void CargarEstadisticas()
        {
            try
            {
                var estadisticas = _proveedorServicios.ObtenerEstadisticas(UserSession.IdUsuario);

                lblServiciosActivos.Text = $"{estadisticas.TotalServicios} servicios activos";
                lblCalificacionPromedio.Text = $"Valoración: {estadisticas.PromedioCalificacion:F1}/5.0";
                lblClientesAtendidos.Text = $"{estadisticas.ClientesAtendidos} clientes";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estadísticas: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Valores por defecto en caso de error
                lblServiciosActivos.Text = "0 servicios activos";
                lblCalificacionPromedio.Text = "0.0/5.0";
                lblClientesAtendidos.Text = "0 clientes";
            }
        }

        private void CargarCalificacionesRecientes()
        {
            try
            {
                _proveedorServicios.CargarCalificaciones(flpCalificaciones, UserSession.IdUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar calificaciones: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrincipalProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cerrandoParaPerfil)
            {
                _cerrandoParaPerfil = false;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Solo mostrar confirmación si la sesión sigue activa
                if (UserSession.SesionActiva)
                {
                    var resultado = MessageBox.Show("¿Estás seguro de que quieres cerrar sesión?",
                                                  "Cerrar Sesión",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        UserSession.CerrarSesion();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void PrincipalProveedor_Click(object sender, EventArgs e)
        {
            _panelManager.CerrarPanelSiEsNecesario(this.PointToClient(MousePosition));
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _panelManager.TogglePanelLateral();
        }

        // Reemplazar el método btnEditarServicios_Click en Proveedor.cs
        private void btnEditarServicios_Click(object sender, EventArgs e)
        {
            _panelManager.TogglePanelLateral();

            // Abrir formulario de edición de servicios
            using (var editarServiciosForm = new Perfil.EditarServicios())
            {
                editarServiciosForm.StartPosition = FormStartPosition.CenterParent;
                editarServiciosForm.ShowDialog();

                // Recargar datos después de cerrar el formulario
                if (editarServiciosForm.DialogResult == DialogResult.OK ||
                    editarServiciosForm.DialogResult == DialogResult.Yes)
                {
                    CargarDatosIniciales();
                }
            }
        }

        private void btnEditarDatos_Click(object sender, EventArgs e)
        {
            _panelManager.TogglePanelLateral();

            // Abrir formulario de edición de datos para proveedor
            var editarDatosForm = new Perfil.PerfilProveedor();
            var result = editarDatosForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Recargar datos si se guardaron cambios
                CargarDatosIniciales();
                MessageBox.Show("Datos actualizados correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCambiarCliente_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Desea cambiar a la vista de cliente?\n\nPodrá buscar servicios pero no podrá gestionar sus servicios como proveedor.",
                                          "Cambiar a Vista Cliente",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Guardar estado actual del formulario
                var proveedorForm = this;

                // Usar el nuevo método
                UserSession.CambiarAVistaCliente();

                // Abrir formulario de cliente
                this.Hide();
                Homepage.Form1 clienteForm = new Homepage.Form1();
                clienteForm.FormClosed += (s, args) =>
                {
                    // Verificar si la sesión sigue activa
                    if (UserSession.SesionActiva)
                    {
                        UserSession.RestaurarRolOriginal();
                        proveedorForm.Show();
                        proveedorForm.Focus();
                        proveedorForm.BringToFront();
                    }
                    else
                    {
                        // Si no hay sesión, cerrar todo
                        proveedorForm.Close();
                    }
                };
                clienteForm.Show();
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Estás seguro de que quieres cerrar sesión?",
                                          "Cerrar Sesión",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                UserSession.CerrarSesion();
                this.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CargarDatosIniciales();
                MessageBox.Show("Datos actualizados correctamente", "Actualización",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (UserSession.SesionActiva)
            {
                this.Text = $"Panel Proveedor - {UserSession.NombreCompleto}";
            }
        }

        
    }
}