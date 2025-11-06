using Homepage.Logica;
using Homepage.Modelos;
using Homepage.UI;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Homepage
{
    public partial class Form1 : Form
    {
        private readonly CategoriaServicio categoriaServicio = new CategoriaServicio();
        private bool panelLateralVisible = false;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            btnBuscar.Click += BtnBuscar_Click;

            // Evento para cerrar el panel al hacer click fuera de él
            this.Click += Form1_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarBuscador();
            CargarCategorias();
        }

        private void ConfigurarBuscador()
        {
            // Placeholder
            txtBuscar.GotFocus += (s, e) => { if (txtBuscar.Text == "BUSCAR CATEGORÍAS") { txtBuscar.Text = ""; txtBuscar.ForeColor = Color.Black; } };
            txtBuscar.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtBuscar.Text)) { txtBuscar.Text = "BUSCAR CATEGORÍAS"; txtBuscar.ForeColor = Color.Gray; } };

            // SOLO LETRAS Y ESPACIOS
            txtBuscar.KeyPress += (s, e) =>
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                    CrearBoton.MostrarError("Solo se permiten letras y espacios.");
                }
            };

            // VALIDACIÓN AL PERDER FOCO
            txtBuscar.Validating += (s, e) =>
            {
                if (txtBuscar.Text.Length < 3 && txtBuscar.Text != "BUSCAR CATEGORÍAS")
                {
                    e.Cancel = true;
                    CrearBoton.MostrarError("El texto debe tener al menos 3 letras.");
                }
            };
        }

        private void CargarCategorias()
        {
            try
            {
                flpCategorias.Controls.Clear();
                var categorias = categoriaServicio.ObtenerTodas();

                if (categorias == null || !categorias.Any())
                    throw new InvalidOperationException("No se encontraron categorías.");

                foreach (var cat in categorias)
                {
                    var btn = CrearBoton.CrearBotonCategoria(cat.Nombre, cat.ColorFondo);
                    btn.Click += (s, e) => CrearBoton.MostrarInfo($"Seleccionaste: {cat.Nombre}");
                    flpCategorias.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                CrearBoton.MostrarError($"Error al cargar categorías: {ex.Message}");
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == "BUSCAR CATEGORÍAS" || string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    CargarCategorias();
                    return;
                }

                var resultados = categoriaServicio.Buscar(txtBuscar.Text.Trim());

                flpCategorias.Controls.Clear();

                if (!resultados.Any())
                {
                    CrearBoton.MostrarAdvertencia("No se encontraron categorías con ese nombre.");
                    return;
                }

                foreach (var cat in resultados)
                {
                    var btn = CrearBoton.CrearBotonCategoria(cat.Nombre, cat.ColorFondo);
                    flpCategorias.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                CrearBoton.MostrarError($"Error en la búsqueda: {ex.Message}");
            }
        }

        // EVENTOS PARA EL PANEL LATERAL
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TogglePanelLateral();
        }

        private void TogglePanelLateral()
        {
            panelLateralVisible = !panelLateralVisible;
            panelLateral.Visible = panelLateralVisible;

            // Traer el panel al frente cuando está visible
            if (panelLateralVisible)
                panelLateral.BringToFront();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            // Cerrar el panel si está abierto y se hace click fuera de él
            if (panelLateralVisible && !panelLateral.Bounds.Contains(PointToClient(MousePosition)))
            {
                TogglePanelLateral();
            }
        }

        private void btnVerPerfil_Click(object sender, EventArgs e)
        {
            // Cerrar el panel lateral
            TogglePanelLateral();

            // Abrir el formulario de perfil (lo crearás después)
            AbrirFormularioPerfil();
        }

        private void AbrirFormularioPerfil()
        {
            try
            {
                // Aquí abrirás el formulario de perfil cuando lo crees
                // Por ahora muestra un mensaje
                MessageBox.Show("Formulario de perfil se abrirá aquí. Crea el formulario 'PerfilForm' para implementar esta funcionalidad.",
                              "Funcionalidad Pendiente",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                // Cuando crees el PerfilForm, descomenta esta línea:
                // PerfilForm perfilForm = new PerfilForm();
                // perfilForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el perfil: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}