using DataBase;
using MySql.Data.MySqlClient;
using Perfil.Logica;
using Perfil.Modelos;
using Shared.Session;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Perfil
{
    public partial class EditarServicios : Form
    {
        private int _idUsuario;
        private List<Servicio> _servicios;
        private Experiencia _experienciaActual;
        private ServicioManager _servicioManager;
        private CategoriaManager _categoriaManager;
        private ExperienciaManager _experienciaManager;

        public EditarServicios()
        {
            InitializeComponent();
            _idUsuario = UserSession.IdUsuario;
            _servicioManager = new ServicioManager();
            _categoriaManager = new CategoriaManager();
            _experienciaManager = new ExperienciaManager();
        }

        private void EditarServicios_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
            AplicarEstilos();
            MostrarInstrucciones();
        }

        private void CargarDatosIniciales()
        {
            try
            {
                // Cargar servicios del usuario (solo títulos)
                _servicios = _servicioManager.ObtenerServiciosPorUsuario(_idUsuario);
                CargarListaServicios();

                // Cargar experiencia del usuario si existe
                CargarExperienciaUsuario();

                // Cargar categorías para combobox
                var categorias = _categoriaManager.ObtenerCategorias();
                cmbCategoria.DataSource = categorias;
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "Id";

                // Cargar tipos de registro experiencia
                cmbTipoExperiencia.Items.AddRange(new string[] { "certificado", "empirico" });
                cmbNivelEstudios.Items.AddRange(new string[] { "tecnico", "tecnologo", "profesional", "especializacion", "maestria", "doctorado" });

                lblTotalServicios.Text = $"Tienes {_servicios.Count} servicios";
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar datos: {ex.Message}");
            }
        }

        private void CargarListaServicios()
        {
            flpServicios.Controls.Clear();

            if (_servicios.Count == 0)
            {
                Label lblVacio = new Label
                {
                    Text = "No tienes servicios registrados.\nHaz clic en 'Nuevo Servicio' para crear uno.",
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(280, 60),
                    Margin = new Padding(10)
                };
                flpServicios.Controls.Add(lblVacio);
                return;
            }

            foreach (var servicio in _servicios)
            {
                Panel card = CrearCardServicio(servicio);
                flpServicios.Controls.Add(card);
            }
        }

        private Panel CrearCardServicio(Servicio servicio)
        {
            Panel card = new Panel
            {
                Size = new Size(280, 60),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                Tag = servicio.Id,
                Cursor = Cursors.Hand
            };

            // SOLUCIÓN: Usar MouseClick en lugar de Click para tarjetas
            card.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    SeleccionarServicio(servicio);
                }
            };

            // También agregar eventos a los labels dentro del panel
            Label lblTitulo = new Label
            {
                Text = servicio.Titulo.Length > 30 ?
                       servicio.Titulo.Substring(0, 27) + "..." :
                       servicio.Titulo,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(260, 20),
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand  // Importante: cursor de mano en el label
            };

            Label lblDetalle = new Label
            {
                Text = $"Categoría ID: {servicio.IdCategoria} | {servicio.Visitas} visitas",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(10, 30),
                Size = new Size(260, 20),
                Cursor = Cursors.Hand  // Importante: cursor de mano en el label
            };

            // Eventos para los labels también
            lblTitulo.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    SeleccionarServicio(servicio);
                }
            };

            lblDetalle.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    SeleccionarServicio(servicio);
                }
            };

            // Efecto hover para todo el panel
            card.MouseEnter += (s, e) =>
            {
                card.BackColor = Color.FromArgb(240, 240, 240);
                card.BorderStyle = BorderStyle.Fixed3D;
                lblTitulo.BackColor = Color.FromArgb(240, 240, 240);
                lblDetalle.BackColor = Color.FromArgb(240, 240, 240);
            };

            card.MouseLeave += (s, e) =>
            {
                card.BackColor = Color.White;
                card.BorderStyle = BorderStyle.FixedSingle;
                lblTitulo.BackColor = Color.White;
                lblDetalle.BackColor = Color.White;
            };

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblDetalle);

            return card;
        }

        private void CargarExperienciaUsuario()
        {
            try
            {
                _experienciaActual = _experienciaManager.ObtenerExperienciaPorUsuario(_idUsuario);

                if (_experienciaActual != null)
                {
                    // Llenar formulario de experiencia
                    cmbTipoExperiencia.SelectedItem = _experienciaActual.TipoRegistro;
                    cmbNivelEstudios.SelectedItem = _experienciaActual.NivelEstudios;
                    txtAnosExperiencia.Text = _experienciaActual.AnosExperiencia;
                    txtEmpresasAnteriores.Text = _experienciaActual.EmpresasAnteriores;
                    txtProyectosDestacados.Text = _experienciaActual.ProyectosDestacados;
                    txtReferenciasLaborales.Text = _experienciaActual.ReferenciasLaborales;
                    txtTipoExperiencia.Text = _experienciaActual.TipoExperiencia;
                    txtDescripcionOtro.Text = _experienciaActual.DescripcionOtro;

                    lblEstadoExperiencia.Text = "Experiencia registrada ✓";
                    lblEstadoExperiencia.ForeColor = Color.Green;
                }
                else
                {
                    lblEstadoExperiencia.Text = "Sin experiencia registrada";
                    lblEstadoExperiencia.ForeColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar experiencia: {ex.Message}");
            }
        }

        private void SeleccionarServicio(Servicio servicio)
        {
            try
            {
                // Desvincular eventos temporalmente para evitar loops
                cmbCategoria.SelectedIndexChanged -= cmbCategoria_SelectedIndexChanged;

                // Llenar formulario de servicio
                txtId.Text = servicio.Id.ToString();
                txtTitulo.Text = servicio.Titulo;
                txtDescripcion.Text = servicio.Descripcion;

                // Seleccionar categoría - FORZAR la selección
                bool categoriaEncontrada = false;
                foreach (Categoria item in cmbCategoria.Items)
                {
                    if (item.Id == servicio.IdCategoria)
                    {
                        cmbCategoria.SelectedItem = item;
                        categoriaEncontrada = true;
                        break;
                    }
                }

                // Si no encontró la categoría, cargarla primero
                if (!categoriaEncontrada && servicio.IdCategoria > 0)
                {
                    CargarDenominaciones(servicio.IdCategoria);
                }

                // Resto de campos
                if (!string.IsNullOrEmpty(servicio.TipoPrecio))
                {
                    cmbTipoPrecio.SelectedItem = servicio.TipoPrecio;
                }
                else
                {
                    cmbTipoPrecio.SelectedIndex = 0;
                }

                txtMoneda.Text = servicio.Moneda ?? "USD";
                txtDisponibilidad.Text = servicio.Disponibilidad ?? "";
                txtRadioCobertura.Text = servicio.RadioCobertura ?? "";
                txtExperiencia.Text = servicio.Experiencia ?? "";

                // Resaltar tarjeta seleccionada
                ResaltarCardSeleccionada(servicio.Id);

                // Volver a vincular evento
                cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;

                lblSeleccionado.Text = $"Editando: {servicio.Titulo}";
                lblSeleccionado.ForeColor = Color.FromArgb(52, 152, 219);

                // Mostrar mensaje de éxito
                //statusStrip1.Items[0].Text = $"Servicio '{servicio.Titulo}' cargado";
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar servicio: {ex.Message}");
            }
        }

        private void ResaltarCardSeleccionada(int idServicio)
        {
            foreach (Control control in flpServicios.Controls)
            {
                if (control is Panel card && card.Tag is int tagId)
                {
                    if (tagId == idServicio)
                    {
                        card.BackColor = Color.FromArgb(220, 237, 255);
                        card.BorderStyle = BorderStyle.Fixed3D;
                    }
                    else
                    {
                        card.BackColor = Color.White;
                        card.BorderStyle = BorderStyle.FixedSingle;
                    }
                }
            }
        }

        private void CargarDenominaciones(int idCategoria)
        {
            try
            {
                var denominaciones = _categoriaManager.ObtenerDenominacionesPorCategoria(idCategoria);

                // Agregar opción "Ninguna"
                var lista = new List<Denominacion>
                {
                    new Denominacion { Id = 0, Nombre = "(Sin denominación específica)" }
                };
                lista.AddRange(denominaciones);

                cmbDenominacion.DataSource = lista;
                cmbDenominacion.DisplayMember = "Nombre";
                cmbDenominacion.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar denominaciones: {ex.Message}");
            }
        }

        private void btnGuardarServicio_Click(object sender, EventArgs e)
        {
            if (!ValidarServicio())
                return;

            try
            {
                var servicio = new Servicio
                {
                    Id = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text),
                    IdUsuario = _idUsuario,
                    Titulo = txtTitulo.Text,
                    Descripcion = txtDescripcion.Text,
                    IdCategoria = (cmbCategoria.SelectedItem as Categoria)?.Id ?? 0,
                    IdDenominacion = (cmbDenominacion.SelectedItem as Denominacion)?.Id,
                    TipoPrecio = cmbTipoPrecio.SelectedItem?.ToString() ?? "consultar",
                    Moneda = txtMoneda.Text,
                    Disponibilidad = txtDisponibilidad.Text,
                    RadioCobertura = txtRadioCobertura.Text,
                    Experiencia = txtExperiencia.Text
                };

                if (servicio.Id == 0)
                {
                    _servicioManager.CrearServicio(servicio);
                    MostrarMensaje("✅ Servicio creado exitosamente");
                }
                else
                {
                    _servicioManager.ActualizarServicio(servicio);
                    MostrarMensaje("✅ Servicio actualizado exitosamente");
                }

                LimpiarFormularioServicio();
                CargarDatosIniciales();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al guardar servicio: {ex.Message}");
            }
        }

        private void btnGuardarExperiencia_Click(object sender, EventArgs e)
        {
            if (!ValidarExperiencia())
                return;

            try
            {
                var experiencia = new Experiencia
                {
                    IdUsuario = _idUsuario,
                    TipoRegistro = cmbTipoExperiencia.SelectedItem?.ToString() ?? "empirico",
                    NivelEstudios = cmbNivelEstudios.SelectedItem?.ToString(),
                    AnosExperiencia = txtAnosExperiencia.Text,
                    EmpresasAnteriores = txtEmpresasAnteriores.Text,
                    ProyectosDestacados = txtProyectosDestacados.Text,
                    ReferenciasLaborales = txtReferenciasLaborales.Text,
                    TipoExperiencia = txtTipoExperiencia.Text,
                    DescripcionOtro = txtDescripcionOtro.Text
                };

                if (_experienciaActual != null)
                {
                    experiencia.Id = _experienciaActual.Id;
                    _experienciaManager.ActualizarExperiencia(experiencia);
                    MostrarMensaje("✅ Experiencia actualizada exitosamente");
                }
                else
                {
                    _experienciaManager.CrearExperiencia(experiencia);
                    MostrarMensaje("✅ Experiencia registrada exitosamente");
                }

                CargarExperienciaUsuario();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al guardar experiencia: {ex.Message}");
            }
        }

        private void btnNuevoServicio_Click(object sender, EventArgs e)
        {
            LimpiarFormularioServicio();
            lblSeleccionado.Text = "Creando nuevo servicio";
            lblSeleccionado.ForeColor = Color.FromArgb(39, 174, 96);

            // Deseleccionar cualquier tarjeta
            foreach (Control control in flpServicios.Controls)
            {
                if (control is Panel card)
                {
                    card.BackColor = Color.White;
                    card.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void btnEliminarServicio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || txtId.Text == "0")
            {
                MostrarError("Seleccione un servicio para eliminar");
                return;
            }

            var resultado = MessageBox.Show("¿Está seguro de eliminar este servicio?\nEsta acción no se puede deshacer.",
                                          "Confirmar eliminación",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int idServicio = Convert.ToInt32(txtId.Text);
                    _servicioManager.EliminarServicio(idServicio);
                    MostrarMensaje("✅ Servicio eliminado exitosamente");
                    LimpiarFormularioServicio();
                    CargarDatosIniciales();
                }
                catch (Exception ex)
                {
                    MostrarError($"Error al eliminar: {ex.Message}");
                }
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem is Categoria categoriaSeleccionada)
            {
                CargarDenominaciones(categoriaSeleccionada.Id);
            }
        }

        private void cmbTipoExperiencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esCertificado = cmbTipoExperiencia.SelectedItem?.ToString() == "certificado";

            // Mostrar/ocultar campos según tipo
            lblNivelEstudios.Visible = esCertificado;
            cmbNivelEstudios.Visible = esCertificado;

            lblTipoExperiencia.Visible = !esCertificado;
            txtTipoExperiencia.Visible = !esCertificado;
        }

        private bool ValidarServicio()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MostrarError("El título del servicio es requerido");
                txtTitulo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MostrarError("La descripción es requerida");
                txtDescripcion.Focus();
                return false;
            }

            if (!(cmbCategoria.SelectedItem is Categoria))
            {
                MostrarError("Seleccione una categoría");
                cmbCategoria.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarExperiencia()
        {
            if (string.IsNullOrWhiteSpace(txtAnosExperiencia.Text))
            {
                MostrarError("Los años de experiencia son requeridos");
                txtAnosExperiencia.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormularioServicio()
        {
            txtId.Text = "";
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtMoneda.Text = "USD";
            txtDisponibilidad.Text = "";
            txtRadioCobertura.Text = "";
            txtExperiencia.Text = "";
            cmbTipoPrecio.SelectedIndex = 0;
        }

        private void AplicarEstilos()
        {
            // Estilo para FlowLayoutPanel
            flpServicios.BackColor = Color.White;
            flpServicios.BorderStyle = BorderStyle.FixedSingle;

            // Estilo para GroupBox
            gbServicio.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            gbExperiencia.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        private void MostrarInstrucciones()
        {
            lblInstrucciones.Text = "👈 Haz clic en un servicio para editarlo\n" +
                                   "➕ Usa 'Nuevo Servicio' para crear uno nuevo\n" +
                                   "💾 Guarda ambos formularios por separado";
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}