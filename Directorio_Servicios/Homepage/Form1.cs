using Homepage.Logica;
using Homepage.Modelos;
using Homepage.UI;
using Shared.Session;
using Perfil;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Homepage
{
    public partial class Form1 : Form
    {
        private readonly CategoriaServicio categoriaServicio = new CategoriaServicio();
        private bool panelLateralVisible = false;
        private bool cerrandoParaPerfil = false;
        private int indiceInicio = 0; // Índice de la primera categoría visible
        private int categoriasVisibles = 7; // Siempre mostrar 7 categorías
        private List<Categoria> todasLasCategorias = new List<Categoria>();
        private bool modoBusqueda = false;
        private string ultimaBusqueda = "";
        private List<Button> botonesCategorias = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            btnBuscar.Click += BtnBuscar_Click;

            this.Click += Form1_Click;
            this.FormClosing += Form1_FormClosing;

            btnAnterior.Click += BtnAnterior_Click;
            btnSiguiente.Click += BtnSiguiente_Click;

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            botonesCategorias = new List<Button>();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrandoParaPerfil)
            {
                cerrandoParaPerfil = false;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!UserSession.SesionActiva)
            {
                MessageBox.Show("No hay sesión activa. Será redirigido al login.", "Sesión Expirada",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            lblBienvenida.Text = $"Bienvenido, \n {UserSession.Username}";

            ConfigurarBuscador();
            CargarTodasLasCategorias();
            InicializarCarrusel();
            ActualizarBotonesNavegacion();
        }

        private void ConfigurarBuscador()
        {
            txtBuscar.GotFocus += (s, e) => {
                if (txtBuscar.Text == "BUSCAR CATEGORÍAS")
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }
            };

            txtBuscar.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = "BUSCAR CATEGORÍAS";
                    txtBuscar.ForeColor = Color.Gray;
                }
            };

            txtBuscar.KeyPress += (s, e) =>
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                    CrearBoton.MostrarError("Solo se permiten letras y espacios.");
                }
            };

            txtBuscar.Validating += (s, e) =>
            {
                if (txtBuscar.Text.Length < 3 && txtBuscar.Text != "BUSCAR CATEGORÍAS")
                {
                    e.Cancel = true;
                    CrearBoton.MostrarError("El texto debe tener al menos 3 letras.");
                }
            };

            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnBuscar_Click(s, e);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
        }

        private void CargarTodasLasCategorias()
        {
            try
            {
                todasLasCategorias = categoriaServicio.ObtenerTodas();
                modoBusqueda = false;
                ultimaBusqueda = "";

                if (todasLasCategorias == null || !todasLasCategorias.Any())
                {
                    throw new InvalidOperationException("No se encontraron categorías.");
                }
            }
            catch (Exception ex)
            {
                CrearBoton.MostrarError($"Error al cargar categorías: {ex.Message}");
                todasLasCategorias = new List<Categoria>();
            }
        }

        private void InicializarCarrusel()
        {
            try
            {
                flpCategorias.Controls.Clear();
                botonesCategorias.Clear();

                if (!todasLasCategorias.Any())
                {
                    MostrarMensajeSinCategorias();
                    return;
                }

                // Configurar FlowLayoutPanel para 7 botones en línea
                flpCategorias.AutoScroll = false; // Deshabilitar scroll
                flpCategorias.WrapContents = false; // No envolver contenido
                flpCategorias.FlowDirection = FlowDirection.LeftToRight;

                // Obtener las primeras 7 categorías
                var categoriasVisiblesList = categoriaServicio.ObtenerCarrusel(indiceInicio, categoriasVisibles);

                // Crear botones para las 7 categorías visibles
                foreach (var cat in categoriasVisiblesList)
                {
                    var btn = CrearBotonCarrusel(cat);
                    flpCategorias.Controls.Add(btn);
                    botonesCategorias.Add(btn);
                }

                // Ajustar el tamaño del FlowLayoutPanel si es necesario
                if (flpCategorias.Controls.Count > 0)
                {
                    int totalWidth = (flpCategorias.Controls[0].Width + flpCategorias.Controls[0].Margin.Horizontal) * 7;
                    flpCategorias.Width = Math.Min(totalWidth, flpCategorias.Width);
                }

                ActualizarInfoCarrusel();
            }
            catch (Exception ex)
            {
                CrearBoton.MostrarError($"Error al inicializar carrusel: {ex.Message}");
            }
        }

        private void MostrarMensajeSinCategorias()
        {
            var lbl = new Label
            {
                Text = "No hay categorías disponibles",
                Size = new Size(400, 100),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                ForeColor = Color.Gray
            };
            flpCategorias.Controls.Add(lbl);
            lblPagina.Text = "No hay categorías";
            lblRango.Text = "";
        }

        private Button CrearBotonCarrusel(Categoria categoria)
        {
            var btn = CrearBoton.CrearBotonCategoria(categoria.Nombre, categoria.ColorFondo);
            btn.Tag = categoria;
            btn.Click += (s, e) =>
            {
                var cat = (Categoria)((Button)s).Tag;
                CrearBoton.MostrarInfo($"Seleccionaste: {cat.Nombre} (ID: {cat.Id})");
            };
            return btn;
        }

        private void ActualizarInfoCarrusel()
        {
            if (!todasLasCategorias.Any())
                return;

            int totalCategorias = todasLasCategorias.Count;
            int fin = (indiceInicio + categoriasVisibles - 1) % totalCategorias;
            if (fin < 0) fin += totalCategorias;

            // Mostrar información del carrusel
            lblPagina.Text = $"Mostrando {categoriasVisibles} de {totalCategorias} categorías";
            lblRango.Text = $"IDs: {todasLasCategorias[indiceInicio].Id} - {todasLasCategorias[fin].Id}";

            if (modoBusqueda && !string.IsNullOrEmpty(ultimaBusqueda))
            {
                lblPagina.Text += $" - Búsqueda: '{ultimaBusqueda}'";
            }
        }

        private void ActualizarBotonesNavegacion()
        {
            bool hayCategorias = todasLasCategorias.Any();

            btnAnterior.Enabled = hayCategorias;
            btnSiguiente.Enabled = hayCategorias;

            btnAnterior.BackColor = hayCategorias ? SystemColors.Control : Color.LightGray;
            btnSiguiente.BackColor = hayCategorias ? SystemColors.Control : Color.LightGray;

            btnAnterior.Cursor = hayCategorias ? Cursors.Hand : Cursors.Default;
            btnSiguiente.Cursor = hayCategorias ? Cursors.Hand : Cursors.Default;
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (!todasLasCategorias.Any())
                return;

            // Mover una posición hacia atrás (circular)
            int totalCategorias = todasLasCategorias.Count;
            indiceInicio = (indiceInicio - 1 + totalCategorias) % totalCategorias;

            // Obtener las nuevas categorías visibles
            var nuevasCategorias = categoriaServicio.ObtenerCarrusel(indiceInicio, categoriasVisibles);

            // Actualizar todos los botones
            for (int i = 0; i < categoriasVisibles; i++)
            {
                if (i < botonesCategorias.Count)
                {
                    var cat = nuevasCategorias[i];
                    botonesCategorias[i].Text = cat.Nombre;
                    botonesCategorias[i].BackColor = cat.ColorFondo;
                    botonesCategorias[i].Tag = cat;
                }
            }

            ActualizarInfoCarrusel();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (!todasLasCategorias.Any())
                return;

            // Mover una posición hacia adelante (circular)
            int totalCategorias = todasLasCategorias.Count;
            indiceInicio = (indiceInicio + 1) % totalCategorias;

            // Obtener las nuevas categorías visibles
            var nuevasCategorias = categoriaServicio.ObtenerCarrusel(indiceInicio, categoriasVisibles);

            // Actualizar todos los botones
            for (int i = 0; i < categoriasVisibles; i++)
            {
                if (i < botonesCategorias.Count)
                {
                    var cat = nuevasCategorias[i];
                    botonesCategorias[i].Text = cat.Nombre;
                    botonesCategorias[i].BackColor = cat.ColorFondo;
                    botonesCategorias[i].Tag = cat;
                }
            }

            ActualizarInfoCarrusel();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == "BUSCAR CATEGORÍAS" || string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    // Restaurar todas las categorías
                    CargarTodasLasCategorias();
                    indiceInicio = 0;
                    InicializarCarrusel();
                    ActualizarBotonesNavegacion();
                    return;
                }

                var textoBusqueda = txtBuscar.Text.Trim();
                var resultados = categoriaServicio.Buscar(textoBusqueda);

                todasLasCategorias = resultados;
                modoBusqueda = true;
                ultimaBusqueda = textoBusqueda;
                indiceInicio = 0;

                if (!resultados.Any())
                {
                    CrearBoton.MostrarAdvertencia($"No se encontraron categorías con '{textoBusqueda}'");
                    InicializarCarrusel();
                }
                else
                {
                    InicializarCarrusel();
                }

                ActualizarBotonesNavegacion();
            }
            catch (Exception ex)
            {
                CrearBoton.MostrarError($"Error en la búsqueda: {ex.Message}");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TogglePanelLateral();
        }

        private void TogglePanelLateral()
        {
            panelLateralVisible = !panelLateralVisible;
            panelLateral.Visible = panelLateralVisible;

            if (panelLateralVisible)
                panelLateral.BringToFront();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (panelLateralVisible && !panelLateral.Bounds.Contains(PointToClient(MousePosition)))
            {
                TogglePanelLateral();
            }
        }

        private void btnVerPerfil_Click(object sender, EventArgs e)
        {
            TogglePanelLateral();
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (UserSession.SesionActiva)
            {
                this.Text = $"Directorio de Servicios - {UserSession.NombreCompleto} ({UserSession.Rol})";
            }
        }

        private void AbrirFormularioPerfil()
        {
            try
            {
                cerrandoParaPerfil = true;

                PerfilForm perfilForm = new PerfilForm();
                perfilForm.FormClosed += (s, args) =>
                {
                    this.Show();
                    this.Focus();

                    // Refrescar datos si es necesario
                    if (!modoBusqueda)
                    {
                        CargarTodasLasCategorias();
                        indiceInicio = 0;
                        InicializarCarrusel();
                        ActualizarBotonesNavegacion();
                    }
                };

                this.Hide();
                perfilForm.Show();
            }
            catch (Exception ex)
            {
                cerrandoParaPerfil = false;
                MessageBox.Show($"Error al abrir el perfil: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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