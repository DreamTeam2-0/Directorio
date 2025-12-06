using Homepage.Modelos;
using Homepage.UI;
using MySql.Data.MySqlClient;
using DataBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Homepage.Logica
{
    public class CarruselManager
    {
        public delegate void CategoriaClicEventHandler(Categoria categoria);
        public event CategoriaClicEventHandler OnCategoriaClic;

        private readonly CategoriaServicio _categoriaServicio;
        private FlowLayoutPanel _flpCategorias;
        private Label _lblPagina;
        private Label _lblRango;
        private TableLayoutPanel _tlpSolicitados; // NUEVO: Referencia a la tabla de solicitados

        private List<Categoria> _todasLasCategorias = new List<Categoria>();
        private List<Button> _botonesCategorias = new List<Button>();

        private int _indiceInicio = 0;
        private int _categoriasVisibles = 7;
        private bool _modoBusqueda = false;
        private string _ultimaBusqueda = "";

        // Constructor modificado para aceptar tlpSolicitados
        public CarruselManager(CategoriaServicio categoriaServicio, FlowLayoutPanel flpCategorias,
                               Label lblPagina, Label lblRango, TableLayoutPanel tlpSolicitados) // NUEVO parámetro
        {
            _categoriaServicio = categoriaServicio;
            _flpCategorias = flpCategorias;
            _lblPagina = lblPagina;
            _lblRango = lblRango;
            _tlpSolicitados = tlpSolicitados; // NUEVO: asignar referencia
        }

        public void CargarCategorias()
        {
            try
            {
                _todasLasCategorias = _categoriaServicio.ObtenerTodas();
                _modoBusqueda = false;
                _ultimaBusqueda = "";
                _categoriasVisibles = 7;

                if (_todasLasCategorias == null || !_todasLasCategorias.Any())
                {
                    throw new InvalidOperationException("No se encontraron categorías.");
                }
            }
            catch (Exception ex)
            {
                CrearBoton.MostrarError($"Error al cargar categorías: {ex.Message}");
                _todasLasCategorias = new List<Categoria>();
            }
        }

        public void InicializarCarrusel()
        {
            try
            {
                _flpCategorias.Controls.Clear();
                _botonesCategorias.Clear();

                if (!_todasLasCategorias.Any())
                {
                    MostrarMensajeSinCategorias();
                    return;
                }

                // Configurar FlowLayoutPanel para 7 botones en línea
                _flpCategorias.AutoScroll = false;
                _flpCategorias.WrapContents = false;
                _flpCategorias.FlowDirection = FlowDirection.LeftToRight;

                // Obtener las primeras 7 categorías
                var categoriasVisiblesList = _categoriaServicio.ObtenerCarrusel(_indiceInicio, _categoriasVisibles);

                // Crear botones para las 7 categorías visibles
                foreach (var cat in categoriasVisiblesList)
                {
                    var btn = CrearBotonCarrusel(cat);
                    _flpCategorias.Controls.Add(btn);
                    _botonesCategorias.Add(btn);
                }

                // Ajustar el tamaño del FlowLayoutPanel si es necesario
                if (_flpCategorias.Controls.Count > 0)
                {
                    int totalWidth = (_flpCategorias.Controls[0].Width + _flpCategorias.Controls[0].Margin.Horizontal) * 7;
                    _flpCategorias.Width = Math.Min(totalWidth, _flpCategorias.Width);
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
            _flpCategorias.Controls.Add(lbl);
            _lblPagina.Text = "No hay categorías";
            _lblRango.Text = "";
        }

        private Button CrearBotonCarrusel(Categoria categoria)
        {
            var btn = CrearBoton.CrearBotonCategoria(categoria.Nombre, categoria.ColorFondo);
            btn.Tag = categoria;
            btn.Click += (s, e) =>
            {
                var cat = (Categoria)((Button)s).Tag;
                try
                {
                    // Incrementa visitas en BD cuando se hace clic
                    IncrementarVisitasCategoria(cat.Id);

                    // Actualizar la lista de categorías más solicitadas
                    CargarCategoriasMasSolicitadas();

                    // NUEVO: Aquí necesitas acceder al CategoriaSeccionManager
                    // Esto requiere que pases el manager como parámetro o lo hagas accesible
                    // Por ahora, vamos a usar un enfoque alternativo
                    OnCategoriaClic?.Invoke(cat);
                }
                catch (Exception ex)
                {
                    CrearBoton.MostrarError($"Error al registrar visita: {ex.Message}");
                }
                CrearBoton.MostrarInfo($"Seleccionaste: {cat.Nombre}");
            };
            return btn;
        }

        private void ActualizarInfoCarrusel()
        {
            if (!_todasLasCategorias.Any())
            {
                _lblPagina.Text = "No hay categorías disponibles";
                _lblRango.Text = "";
                return;
            }

            int totalCategorias = _todasLasCategorias.Count;

            if (_categoriasVisibles == 1 && _modoBusqueda)
            {
                // Mostrar información para búsqueda única
                _lblPagina.Text = $"Categoría encontrada: {_todasLasCategorias[0].Nombre}";
                _lblRango.Text = $"ID: {_todasLasCategorias[0].Id}";
            }
            else
            {
                int fin = Math.Min(_indiceInicio + _categoriasVisibles - 1, totalCategorias - 1);

                // Mostrar información del carrusel
                _lblPagina.Text = $"Mostrando {_categoriasVisibles} de {totalCategorias} categorías";
                _lblRango.Text = $"IDs: {_todasLasCategorias[_indiceInicio].Id} - {_todasLasCategorias[fin].Id}";

                if (_modoBusqueda && !string.IsNullOrEmpty(_ultimaBusqueda))
                {
                    _lblPagina.Text += $" - Búsqueda: '{_ultimaBusqueda}'";
                }
            }
        }

        public void MoverAnterior()
        {
            if (!_todasLasCategorias.Any())
                return;

            // Mover una posición hacia atrás (circular)
            int totalCategorias = _todasLasCategorias.Count;
            _indiceInicio = (_indiceInicio - 1 + totalCategorias) % totalCategorias;

            // Obtener las nuevas categorías visibles
            var nuevasCategorias = _categoriaServicio.ObtenerCarrusel(_indiceInicio, _categoriasVisibles);

            // Actualizar todos los botones
            for (int i = 0; i < _categoriasVisibles; i++)
            {
                if (i < _botonesCategorias.Count)
                {
                    var cat = nuevasCategorias[i];
                    _botonesCategorias[i].Text = cat.Nombre;
                    _botonesCategorias[i].BackColor = cat.ColorFondo;
                    _botonesCategorias[i].Tag = cat;
                }
            }

            ActualizarInfoCarrusel();
        }

        public void MoverSiguiente()
        {
            if (!_todasLasCategorias.Any())
                return;

            // Mover una posición hacia adelante (circular)
            int totalCategorias = _todasLasCategorias.Count;
            _indiceInicio = (_indiceInicio + 1) % totalCategorias;

            // Obtener las nuevas categorías visibles
            var nuevasCategorias = _categoriaServicio.ObtenerCarrusel(_indiceInicio, _categoriasVisibles);

            // Actualizar todos los botones
            for (int i = 0; i < _categoriasVisibles; i++)
            {
                if (i < _botonesCategorias.Count)
                {
                    var cat = nuevasCategorias[i];
                    _botonesCategorias[i].Text = cat.Nombre;
                    _botonesCategorias[i].BackColor = cat.ColorFondo;
                    _botonesCategorias[i].Tag = cat;
                }
            }

            ActualizarInfoCarrusel();
        }

        public void ActualizarBotonesNavegacion(Button btnAnterior, Button btnSiguiente)
        {
            bool hayCategorias = _todasLasCategorias.Any();

            btnAnterior.Enabled = hayCategorias;
            btnSiguiente.Enabled = hayCategorias;

            btnAnterior.BackColor = hayCategorias ? SystemColors.Control : Color.LightGray;
            btnSiguiente.BackColor = hayCategorias ? SystemColors.Control : Color.LightGray;

            btnAnterior.Cursor = hayCategorias ? Cursors.Hand : Cursors.Default;
            btnSiguiente.Cursor = hayCategorias ? Cursors.Hand : Cursors.Default;
        }

        public void BuscarCategorias(string textoBusqueda, TextBox txtBuscar)
        {
            try
            {
                // Normalizar la búsqueda (quitar tildes y convertir a mayúsculas)
                string textoNormalizado = NormalizarTexto(textoBusqueda);

                // Buscar categorías que coincidan (con o sin tildes)
                var resultados = _todasLasCategorias
                    .Where(c => NormalizarTexto(c.Nombre).Contains(textoNormalizado))
                    .ToList();

                if (!resultados.Any())
                {
                    CrearBoton.MostrarAdvertencia($"No se encontraron categorías con '{textoBusqueda}'");

                    // Limpiar el buscador
                    txtBuscar.Text = "BUSCAR CATEGORÍAS";
                    txtBuscar.ForeColor = Color.Gray;

                    // Restaurar todas las categorías
                    CargarCategorias();
                    _indiceInicio = 0;
                    InicializarCarrusel();
                    return;
                }

                // Si hay exactamente una categoría que coincide
                if (resultados.Count == 1)
                {
                    _todasLasCategorias = resultados;
                    _modoBusqueda = true;
                    _ultimaBusqueda = textoBusqueda;
                    _indiceInicio = 0;
                    _categoriasVisibles = 1; // Mostrar solo la categoría encontrada

                    // Mostrar mensaje informativo
                    CrearBoton.MostrarInfo($"Categoría encontrada: {resultados[0].Nombre}");
                }
                else
                {
                    // Si hay múltiples coincidencias, mostrar todas las que coinciden
                    _todasLasCategorias = resultados;
                    _modoBusqueda = true;
                    _ultimaBusqueda = textoBusqueda;
                    _indiceInicio = 0;
                    _categoriasVisibles = Math.Min(resultados.Count, 7); // Máximo 7 categorías
                }

                // Limpiar el carrusel y mostrar solo las categorías encontradas
                _flpCategorias.Controls.Clear();
                _botonesCategorias.Clear();

                foreach (var cat in _todasLasCategorias.Take(_categoriasVisibles))
                {
                    var btn = CrearBotonCarrusel(cat);
                    _flpCategorias.Controls.Add(btn);
                    _botonesCategorias.Add(btn);
                }

                ActualizarInfoCarrusel();
            }
            catch (Exception ex)
            {
                CrearBoton.MostrarError($"Error en la búsqueda: {ex.Message}");
            }
        }

        private string NormalizarTexto(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            // Convertir a mayúsculas y quitar tildes
            texto = texto.ToUpper();

            // Reemplazar caracteres con tilde
            var caracteresConTilde = new Dictionary<char, char>
            {
                {'Á', 'A'},
                {'É', 'E'},
                {'Í', 'I'},
                {'Ó', 'O'},
                {'Ú', 'U'},
                {'Ü', 'U'}
            };

            foreach (var kvp in caracteresConTilde)
            {
                texto = texto.Replace(kvp.Key, kvp.Value);
            }

            return texto;
        }

        public void RestablecerCarrusel()
        {
            _indiceInicio = 0;
            InicializarCarrusel();
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

        public void CargarCategoriasMasSolicitadas()
        {
            if (_tlpSolicitados == null) return;

            // Limpiar controles existentes
            _tlpSolicitados.Controls.Clear();
            _tlpSolicitados.ColumnStyles.Clear();
            _tlpSolicitados.ColumnCount = 0;

            string query = @"
        SELECT ID_Categoria, nombre, color, visitas 
        FROM categorias 
        WHERE activa = TRUE 
        ORDER BY visitas DESC 
        LIMIT 2";

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();
                    using (var reader = db.ExecuteReader(query))
                    {
                        int columnIndex = 0;
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("ID_Categoria");
                            string nombre = reader.GetString("nombre");
                            string colorHex = reader.IsDBNull(reader.GetOrdinal("color")) ? "#4CAF50" : reader.GetString("color");
                            int visitas = reader.GetInt32("visitas");

                            // Crear panel para cada categoría popular
                            Panel panel = new Panel
                            {
                                Size = new Size(250, 120),  // Tamaño aumentado
                                BackColor = Color.FromArgb(245, 245, 245),
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(15),  // Margen aumentado
                                Tag = id
                            };

                            // Etiqueta para el nombre - CENTRADA y más grande
                            Label lblNombre = new Label
                            {
                                Text = nombre.ToUpper(),
                                Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold),  // Fuente más grande
                                ForeColor = ColorTranslator.FromHtml(colorHex),
                                AutoSize = false,
                                Dock = DockStyle.Fill,  // Ocupa todo el espacio disponible
                                TextAlign = ContentAlignment.MiddleCenter,  // Centrado
                                Height = 80  // Más alto para centrar mejor
                            };

                            // Etiqueta para las visitas - en la parte inferior
                            Label lblVisitas = new Label
                            {
                                Text = $"{visitas} visitas",
                                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic),
                                ForeColor = Color.Gray,
                                Dock = DockStyle.Bottom,  // Se queda abajo
                                TextAlign = ContentAlignment.MiddleCenter,
                                Height = 25
                            };

                            // Añadir controles en orden inverso (último se dibuja primero)
                            panel.Controls.Add(lblVisitas);
                            panel.Controls.Add(lblNombre);  // Sin icono

                            // Evento clic para incrementar visitas
                            panel.Click += (s, e) =>
                            {
                                IncrementarVisitasCategoria(id);
                                CrearBoton.MostrarInfo($"¡Haz hecho clic en {nombre}!\nVisitas actualizadas.");
                                CargarCategoriasMasSolicitadas(); // Refrescar la lista
                            };

                            // Agregar al TableLayoutPanel
                            _tlpSolicitados.ColumnCount++;
                            _tlpSolicitados.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                            _tlpSolicitados.Controls.Add(panel, columnIndex, 0);
                            columnIndex++;
                        }
                    }
                }

                // Si no hay categorías populares, mostrar mensaje
                if (_tlpSolicitados.Controls.Count == 0)
                {
                    Label lblVacio = new Label
                    {
                        Text = "Aún no hay categorías populares",
                        Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    _tlpSolicitados.Controls.Add(lblVacio, 0, 0);
                }
            }
            catch (Exception ex)
            {
                CrearBoton.MostrarError($"Error al cargar categorías populares: {ex.Message}");
            }
        }

        public List<Categoria> TodasLasCategorias => _todasLasCategorias;
        public bool ModoBusqueda => _modoBusqueda;
    }
}