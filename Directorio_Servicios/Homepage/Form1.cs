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

            // Inicializar manejadores
            _carruselManager = new CarruselManager(_categoriaServicio, flpCategorias, lblPagina, lblRango);
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
            if (!UserSession.SesionActiva)
            {
                MessageBox.Show("No hay sesión activa. Será redirigido al login.", "Sesión Expirada",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            lblBienvenida.Text = $"Bienvenido, {UserSession.Username}";

            // Crear franja verde
            _franjaManager.CrearFranjaVerde();

            // Configurar buscador
            _buscadorManager.ConfigurarBuscador();

            // Cargar categorías
            _carruselManager.CargarCategorias();
            _carruselManager.InicializarCarrusel();
            _carruselManager.ActualizarBotonesNavegacion(btnAnterior, btnSiguiente);
        }

        private void RealizarBusqueda()
        {
            if (txtBuscar.Text == "BUSCAR CATEGORÍAS" || string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                // Restaurar todas las categorías
                _carruselManager.CargarCategorias();
                _carruselManager.RestablecerCarrusel();
                _carruselManager.ActualizarBotonesNavegacion(btnAnterior, btnSiguiente);
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

        // Resto de métodos permanecen iguales (simplificados)...

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cerrandoParaPerfil)
            {
                _cerrandoParaPerfil = false;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
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

        private void Form1_Click(object sender, EventArgs e)
        {
            _panelManager.CerrarPanelSiEsNecesario(this.PointToClient(MousePosition));
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _panelManager.TogglePanelLateral();
        }

        private void btnVerPerfil_Click(object sender, EventArgs e)
        {
            _panelManager.TogglePanelLateral();
            AbrirFormularioPerfil();
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