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
        private bool _cerrandoParaPerfil = false;

        public Form1()
        {
            InitializeComponent();

            // Inicializar manejadores - NUEVO: pasar tlpSolicitados al constructor
            _carruselManager = new CarruselManager(_categoriaServicio, flpCategorias, lblPagina, lblRango, tlpSolicitados);
            _panelManager = new PanelManager(panelLateral);
            _franjaManager = new FranjaManager(this, lblBienvenida, txtBuscar, btnBuscar);
            _buscadorManager = new BuscadorManager(txtBuscar, RealizarBusqueda);

            // Configurar eventos
            this.Load += Form1_Load;
            btnBuscar.Click += BtnBuscar_Click;
            this.Click += Form1_Click;
            this.FormClosing += Form1_FormClosing;
            btnAnterior.Click += BtnAnterior_Click;
            btnSiguiente.Click += BtnSiguiente_Click;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
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

            // MOSTRAR/OCULTAR BOTÓN "Volver a Proveedor" con mejor lógica
            if (UserSession.EnVistaTemporalCliente() || UserSession.Rol.ToLower() == "empleado")
            {
                btnCambiarEmprendedor.Visible = true;

                // Actualizar el nombre del botón existente
                btnCambiarEmprendedor.Text = UserSession.EnVistaTemporalCliente()
                    ? "← Volver a Proveedor"
                    : "Cambiar a Prestador de Servicios";
            }
            else if(UserSession.EnVistaTemporalCliente() || UserSession.Rol.ToLower() == "cliente_vista")
            {
                btnCambiarEmprendedor.Visible = true;

                // Actualizar el nombre del botón existente
                btnCambiarEmprendedor.Text = UserSession.EnVistaTemporalCliente()
                    ? "Cambiar a Prestador de Servicios"
                    : "Cambiar a Prestador de Servicios";
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

        private bool VerificarSesionActiva()
        {
            if (!UserSession.SesionActiva)
            {
                MessageBox.Show("La sesión ha expirado. Será redirigido al login.",
                              "Sesión Expirada",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);

                // Cerrar este formulario
                this.Close();
                return false;
            }
            return true;
        }

        private void RealizarBusqueda()
        {
            if (txtBuscar.Text == "BUSCAR CATEGORÍAS" || string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                // Restaurar todas las categorías
                _carruselManager.CargarCategorias();
                _carruselManager.RestablecerCarrusel();
                _carruselManager.ActualizarBotonesNavegacion(btnAnterior, btnSiguiente);
                _carruselManager.CargarCategoriasMasSolicitadas(); // NUEVO: refrescar populares
                return;
            }

            var textoBusqueda = txtBuscar.Text.Trim();
            _carruselManager.BuscarCategorias(textoBusqueda, txtBuscar);
            _carruselManager.ActualizarBotonesNavegacion(btnAnterior, btnSiguiente);
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

        // Resto de métodos permanecen iguales...
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cerrandoParaPerfil)
            {
                _cerrandoParaPerfil = false;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Verificar si estamos regresando intencionalmente a proveedor
                bool regresandoAProveedor = UserSession.RolTemporal == "regresando_a_proveedor";

                // Solo mostrar confirmación de cierre si NO estamos regresando a proveedor
                if (!regresandoAProveedor)
                {
                    // Si viene de proveedor y cierra Form1, restaurar rol
                    if (UserSession.EnVistaTemporalCliente())
                    {
                        UserSession.RestaurarRolOriginal();
                    }

                    // Solo preguntar por cerrar sesión si no está en modo temporal
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

                // Si estamos regresando a proveedor, limpiar la bandera temporal
                if (regresandoAProveedor)
                {
                    UserSession.RolTemporal = "cliente_vista"; // Restaurar estado original
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

                    // Refrescar datos si es necesario
                    if (!_carruselManager.ModoBusqueda)
                    {
                        _carruselManager.CargarCategorias();
                        _carruselManager.RestablecerCarrusel();
                        _carruselManager.ActualizarBotonesNavegacion(btnAnterior, btnSiguiente);
                        _carruselManager.CargarCategoriasMasSolicitadas(); // NUEVO: refrescar populares
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

            // Verificar si la sesión sigue activa
            if (!UserSession.SesionActiva)
            {
                MessageBox.Show("La sesión ha expirado. Será redirigido al login.",
                              "Sesión Expirada",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Usar el nuevo método para verificar permisos
            if (UserSession.PuedeAccederAProveedor())
            {
                // AGREGAR CONFIRMACIÓN ANTES DE VOLVER
                var resultado = MessageBox.Show("¿Desea volver al panel de proveedor?\n\n" +
                                               "Regresará a la gestión de sus servicios y estadísticas.",
                                               "Volver a Proveedor",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Marcar que estamos regresando intencionalmente
                    UserSession.RolTemporal = "regresando_a_proveedor";
                    this.Close(); // Cierra Form1 y vuelve a Proveedor
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Navegación con teclado
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