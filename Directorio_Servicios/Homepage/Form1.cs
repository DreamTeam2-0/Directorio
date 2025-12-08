using MySql.Data.MySqlClient;
using DataBase;
using Homepage.Logica;
using Homepage.Modelos;
using Homepage.UI;
using Shared.Session;
using Perfil;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Homepage
{
    public partial class Form1 : Form
    {
        private readonly CategoriaServicio _categoriaServicio = new CategoriaServicio();
        private CarruselManager _carruselManager;
        private PanelManager _panelManager;
        private FranjaManager _franjaManager;
        private BuscadorManager _buscadorManager;
        private CategoriaManager _categoriaManager;
        private bool _cerrandoParaPerfil = false;

        public Form1()
        {
            InitializeComponent();

            // Inicializar manejadores
            _carruselManager = new CarruselManager(_categoriaServicio, flpCategorias, lblPagina, lblRango, tlpSolicitados);
            _panelManager = new PanelManager(panelLateral);
            _franjaManager = new FranjaManager(this, lblBienvenida, txtBuscar, btnBuscar);
            _buscadorManager = new BuscadorManager(txtBuscar, RealizarBusqueda);

            // Inicializar el manager de sección de categorías - USA CategoriaManager
            _categoriaManager = new CategoriaManager(
                tabControlPrincipal,
                flpDenominaciones,
                flpServicios,
                lblDenominaciones,
                lblServicios,
                btnVolverHome,
                _franjaManager,
                txtBuscar,
                btnBuscar,
                lblBienvenida
            );

            // Configurar eventos
            this.Load += Form1_Load;
            this.Click += Form1_Click;
            this.FormClosing += Form1_FormClosing;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            // Configurar evento para cuando se hace clic en una categoría
            ConfigurarEventosCategorias();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserSession.VerificarYReiniciarSiEsNecesario();

            if (!UserSession.SesionActiva)
            {
                MessageBox.Show("No hay sesión activa. Será redirigido al login.", "Sesión Expirada",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            lblBienvenida.Text = $"Bienvenido, {UserSession.Username}";

            // MOSTRAR/OCULTAR BOTÓN "Volver a Proveedor"
            if (UserSession.EnVistaTemporalCliente() || UserSession.Rol.ToLower() == "empleado")
            {
                btnCambiarEmprendedor.Visible = true;
                btnCambiarEmprendedor.Text = UserSession.EnVistaTemporalCliente()
                    ? "← Volver a Proveedor"
                    : "Cambiar a Prestador de Servicios";
            }
            else if (UserSession.EnVistaTemporalCliente() || UserSession.Rol.ToLower() == "cliente_vista")
            {
                btnCambiarEmprendedor.Visible = true;
                btnCambiarEmprendedor.Text = "Cambiar a Prestador de Servicios";
            }

            // Crear franja verde
            _franjaManager.CrearFranjaVerde();

            // Configurar buscador
            _buscadorManager.ConfigurarBuscador();

            // Cargar categorías
            _carruselManager.CargarCategorias();
            _carruselManager.InicializarCarrusel();
            _carruselManager.ActualizarBotonesNavegacion(btnAnterior, btnSiguiente);

            // Cargar categorías más solicitadas
            _carruselManager.CargarCategoriasMasSolicitadas();
        }

        private void ConfigurarEventosCategorias()
        {
            // Configurar eventos de los botones del carrusel
            foreach (Control control in flpCategorias.Controls)
            {
                if (control is Button btn && btn.Tag is Categoria categoria)
                {
                    btn.Click -= BtnCategoria_Click; // Remover si ya existe
                    btn.Click += BtnCategoria_Click;
                }
            }
        }

        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null && btn.Tag is Categoria categoria)
            {
                try
                {
                    // Incrementar visitas en BD
                    IncrementarVisitasCategoria(categoria.Id);

                    // Actualizar la lista de categorías más solicitadas
                    _carruselManager.CargarCategoriasMasSolicitadas();

                    // Mostrar la sección de categorías
                    _categoriaManager.MostrarSeccionCategoria(categoria);

                    CrearBoton.MostrarInfo($"Seleccionaste: {categoria.Nombre}");
                }
                catch (Exception ex)
                {
                    CrearBoton.MostrarError($"Error al registrar visita: {ex.Message}");
                }
            }
        }

        private void IncrementarVisitasCategoria(int idCategoria)
        {
            string query = "UPDATE categorias SET visitas = visitas + 1, fecha_modificacion = CURRENT_TIMESTAMP WHERE ID_Categoria = @id";

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();
                    using (var cmd = new MySqlCommand(query, db._connection))
                    {
                        cmd.Parameters.AddWithValue("@id", idCategoria);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al actualizar visitas: {ex.Message}");
            }
        }

        private void RealizarBusqueda()
        {
            // Verificar en qué pestaña estamos
            if (tabControlPrincipal.SelectedTab == tabPageHome)
            {
                // Búsqueda en el home
                if (txtBuscar.Text == "BUSCAR CATEGORÍAS" || string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    // Restaurar todas las categorías
                    _carruselManager.CargarCategorias();
                    _carruselManager.RestablecerCarrusel();
                    _carruselManager.ActualizarBotonesNavegacion(btnAnterior, btnSiguiente);
                    _carruselManager.CargarCategoriasMasSolicitadas();
                    return;
                }

                var textoBusqueda = txtBuscar.Text.Trim();
                _carruselManager.BuscarCategorias(textoBusqueda, txtBuscar);
                _carruselManager.ActualizarBotonesNavegacion(btnAnterior, btnSiguiente);
            }
            else if (tabControlPrincipal.SelectedTab == tabPageCategorias)
            {
                // El buscador en la pestaña de categorías es manejado por CategoriaManager
                // No hacemos nada aquí, ya que el manager lo maneja
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            _carruselManager.MoverAnterior();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            _carruselManager.MoverSiguiente();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cerrandoParaPerfil)
            {
                _cerrandoParaPerfil = false;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                bool regresandoAProveedor = UserSession.RolTemporal == "regresando_a_proveedor";

                if (!regresandoAProveedor)
                {
                    if (UserSession.EnVistaTemporalCliente())
                    {
                        UserSession.RestaurarRolOriginal();
                    }

                    if (!UserSession.EnVistaTemporalCliente())
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
                            return;
                        }
                    }
                }

                if (regresandoAProveedor)
                {
                    UserSession.RolTemporal = "cliente_vista";
                }
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            _panelManager.CerrarPanelSiEsNecesario(this.PointToClient(MousePosition));
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _panelManager.TogglePanelLateral();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (!VerificarSesionActiva()) return;

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

        private bool VerificarSesionActiva()
        {
            if (!UserSession.SesionActiva)
            {
                MessageBox.Show("La sesión ha expirado. Será redirigido al login.",
                              "Sesión Expirada",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                this.Close();
                return false;
            }
            return true;
        }

        private void btnVerPerfil_Click(object sender, EventArgs e)
        {
            if (!VerificarSesionActiva()) return;

            _panelManager.TogglePanelLateral();
            AbrirFormularioPerfil();
        }

        private void AbrirFormularioPerfil()
        {
            try
            {
                _cerrandoParaPerfil = true;

                PerfilForm perfilForm = new PerfilForm();
                perfilForm.FormClosed += (s, args) =>
                {
                    this.Show();
                    this.Focus();

                    if (!_carruselManager.ModoBusqueda)
                    {
                        _carruselManager.CargarCategorias();
                        _carruselManager.RestablecerCarrusel();
                        _carruselManager.ActualizarBotonesNavegacion(btnAnterior, btnSiguiente);
                        _carruselManager.CargarCategoriasMasSolicitadas();
                    }
                };

                this.Hide();
                perfilForm.Show();
            }
            catch (Exception ex)
            {
                _cerrandoParaPerfil = false;
                MessageBox.Show($"Error al abrir el perfil: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (UserSession.SesionActiva)
            {
                this.Text = $"Directorio de Servicios - {UserSession.NombreCompleto} ({UserSession.Rol})";
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible && UserSession.SesionActiva)
            {
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                this.Focus();
            }
        }

        private void btnVolverProveedor_Click(object sender, EventArgs e)
        {
            _panelManager.TogglePanelLateral();

            if (!UserSession.SesionActiva)
            {
                MessageBox.Show("La sesión ha expirado. Será redirigido al login.",
                              "Sesión Expirada",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            if (UserSession.PuedeAccederAProveedor())
            {
                var resultado = MessageBox.Show("¿Desea volver al panel de proveedor?\n\n" +
                                               "Regresará a la gestión de sus servicios y estadísticas.",
                                               "Volver a Proveedor",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    UserSession.RolTemporal = "regresando_a_proveedor";
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe iniciar sesión con una cuenta de proveedor para acceder al panel de proveedor.\n\n" +
                               "Si es proveedor, cierre sesión e inicie con su cuenta de empleado.",
                               "Acceso Restringido",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }

        private void MenuItemCategorias_Click(object sender, EventArgs e)
        {
            if (!UserSession.SesionActiva)
            {
                MessageBox.Show("La sesión ha expirado.", "Sesión Expirada",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Mostrar la pestaña de categorías con vista general
            _categoriaManager.MostrarTodasCategorias();
        }

        private void btnVolverHome_Click(object sender, EventArgs e)
        {
            _categoriaManager.VolverAHome();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                BtnAnterior_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Right)
            {
                BtnSiguiente_Click(sender, e);
            }
        }
    }
}
