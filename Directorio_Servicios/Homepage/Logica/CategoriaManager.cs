
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
    public class CategoriaManager
    {
        private FlowLayoutPanel _flpDenominaciones;
        private FlowLayoutPanel _flpServicios;
        private TabControl _tabControl;
        private Label _lblDenominaciones;
        private Label _lblServicios;
        private Button _btnVolverHome;
        private FranjaManager _franjaManager;
        private TextBox _txtBuscarCategoria;
        private Button _btnBuscarCategoria;
        private Label _lblBienvenidaCategoria;

        private Categoria _categoriaActual;
        private List<Denominacion> _denominaciones = new List<Denominacion>();
        private List<Servicio> _servicios = new List<Servicio>();

        public CategoriaManager(TabControl tabControl, FlowLayoutPanel flpDenominaciones,
                                       FlowLayoutPanel flpServicios, Label lblDenominaciones,
                                       Label lblServicios, Button btnVolverHome,
                                       FranjaManager franjaManager, TextBox txtBuscar, Button btnBuscar, Label lblBienvenida)
        {
            _tabControl = tabControl;
            _flpDenominaciones = flpDenominaciones;
            _flpServicios = flpServicios;
            _lblDenominaciones = lblDenominaciones;
            _lblServicios = lblServicios;
            _btnVolverHome = btnVolverHome;
            _franjaManager = franjaManager;
            _txtBuscarCategoria = txtBuscar;
            _btnBuscarCategoria = btnBuscar;
            _lblBienvenidaCategoria = lblBienvenida;

            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            _btnVolverHome.Click += (s, e) => VolverAHome();
            _btnBuscarCategoria.Click += (s, e) => BuscarEnCategoria();
        }

        public void MostrarSeccionCategoria(Categoria categoria)
        {
            _categoriaActual = categoria;

            // Cambiar a la pestaña de categorías
            _tabControl.SelectedTab = _tabControl.TabPages[1];

            // Actualizar título
            _lblDenominaciones.Text = $"Denominaciones - {categoria.Nombre}";

            // Configurar buscador para esta categoría
            _txtBuscarCategoria.Text = "BUSCAR SERVICIOS";
            _txtBuscarCategoria.ForeColor = Color.Gray;

            // Cargar datos
            CargarDenominaciones(categoria.Id);
            CargarServicios(categoria.Id);
        }

        public void MostrarTodasCategorias()
        {
            // Cambiar a la pestaña de categorías
            _tabControl.SelectedTab = _tabControl.TabPages[1];

            // Configurar para mostrar todas las categorías
            _lblDenominaciones.Text = "Todas las Categorías";
            _lblServicios.Text = "Seleccione una categoría";

            // Limpiar y mostrar mensaje
            _flpDenominaciones.Controls.Clear();
            _flpServicios.Controls.Clear();

            var lbl = new Label
            {
                Text = "Seleccione una categoría del carrusel para ver sus denominaciones y servicios",
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic),
                ForeColor = Color.Gray,
                Size = new Size(500, 60)
            };
            _flpDenominaciones.Controls.Add(lbl);

            // Configurar buscador para búsqueda general
            _txtBuscarCategoria.Text = "BUSCAR SERVICIOS";
            _txtBuscarCategoria.ForeColor = Color.Gray;
        }

        private void CargarDenominaciones(int idCategoria)
        {
            try
            {
                _flpDenominaciones.Controls.Clear();
                _denominaciones.Clear();

                string query = @"
                    SELECT ID_Denominacion, nombre, descripcion, visitas 
                    FROM denominaciones 
                    WHERE ID_Categoria = @idCategoria 
                    ORDER BY visitas DESC";

                using (var db = new BDConector())
                {
                    db.Open();
                    using (var cmd = new MySqlCommand(query, db._connection))
                    {
                        cmd.Parameters.AddWithValue("@idCategoria", idCategoria);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var denominacion = new Denominacion
                                {
                                    Id = reader.GetInt32("ID_Denominacion"),
                                    Nombre = reader.GetString("nombre"),
                                    Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion"))
                                        ? "" : reader.GetString("descripcion"),
                                    Visitas = reader.GetInt32("visitas")
                                };
                                _denominaciones.Add(denominacion);

                                // Crear botón para la denominación
                                var btnDenominacion = CrearBotonDenominacion(denominacion);
                                _flpDenominaciones.Controls.Add(btnDenominacion);
                            }
                        }
                    }
                }

                if (_denominaciones.Count == 0)
                {
                    var lbl = new Label
                    {
                        Text = "No hay denominaciones disponibles para esta categoría",
                        Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        Size = new Size(400, 30)
                    };
                    _flpDenominaciones.Controls.Add(lbl);
                }
            }
            catch (Exception ex)
            {
                CrearBoton.MostrarError($"Error al cargar denominaciones: {ex.Message}");
            }
        }

        private void CargarServicios(int idCategoria)
        {
            try
            {
                _flpServicios.Controls.Clear();
                _servicios.Clear();

                string query = @"
                    SELECT s.ID_Servicio, s.titulo, s.descripcion, s.visitas,
                           u.username, du.nombres, du.apellidos
                    FROM servicios s
                    INNER JOIN usuarios u ON s.ID_Usuario = u.ID_Usuario
                    INNER JOIN datos_usuario du ON u.ID_Usuario = du.ID_Usuario
                    WHERE s.ID_Categoria = @idCategoria 
                    AND u.activo = TRUE
                    ORDER BY s.visitas DESC
                    LIMIT 10";

                using (var db = new BDConector())
                {
                    db.Open();
                    using (var cmd = new MySqlCommand(query, db._connection))
                    {
                        cmd.Parameters.AddWithValue("@idCategoria", idCategoria);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var servicio = new Servicio
                                {
                                    Id = reader.GetInt32("ID_Servicio"),
                                    Titulo = reader.GetString("titulo"),
                                    Descripcion = reader.GetString("descripcion"),
                                    Visitas = reader.GetInt32("visitas"),
                                    Proveedor = $"{reader.GetString("nombres")} {reader.GetString("apellidos")}",
                                    Username = reader.GetString("username")
                                };
                                _servicios.Add(servicio);

                                // Crear panel para el servicio
                                var panelServicio = CrearPanelServicio(servicio);
                                _flpServicios.Controls.Add(panelServicio);
                            }
                        }
                    }
                }

                if (_servicios.Count == 0)
                {
                    var lbl = new Label
                    {
                        Text = "No hay servicios disponibles para esta categoría",
                        Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        Size = new Size(400, 30)
                    };
                    _flpServicios.Controls.Add(lbl);
                }
            }
            catch (Exception ex)
            {
                CrearBoton.MostrarError($"Error al cargar servicios: {ex.Message}");
            }
        }

        private Button CrearBotonDenominacion(Denominacion denominacion)
        {
            var btn = new Button
            {
                Text = denominacion.Nombre,
                Size = new Size(180, 60),
                BackColor = Color.LightBlue,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = denominacion
            };

            btn.Click += (s, e) =>
            {
                var den = (Denominacion)btn.Tag;
                IncrementarVisitasDenominacion(den.Id);
                CrearBoton.MostrarInfo($"Denominación: {den.Nombre}\nVisitas: {den.Visitas + 1}");
            };

            return btn;
        }

        private Panel CrearPanelServicio(Servicio servicio)
        {
            var panel = new Panel
            {
                Size = new Size(350, 100),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                Tag = servicio
            };

            // Título del servicio
            var lblTitulo = new Label
            {
                Text = servicio.Titulo,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(330, 20),
                ForeColor = Color.DarkBlue
            };

            // Proveedor
            var lblProveedor = new Label
            {
                Text = $"Proveedor: {servicio.Proveedor}",
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular),
                Location = new Point(10, 35),
                Size = new Size(330, 15),
                ForeColor = Color.DarkGray
            };

            // Descripción (truncada)
            var descripcion = servicio.Descripcion.Length > 80
                ? servicio.Descripcion.Substring(0, 80) + "..."
                : servicio.Descripcion;

            var lblDescripcion = new Label
            {
                Text = descripcion,
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular),
                Location = new Point(10, 55),
                Size = new Size(330, 30),
                ForeColor = Color.Black
            };

            // Visitas
            var lblVisitas = new Label
            {
                Text = $"{servicio.Visitas} visitas",
                Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Italic),
                Location = new Point(10, 80),
                Size = new Size(100, 15),
                ForeColor = Color.Gray
            };

            panel.Controls.Add(lblTitulo);
            panel.Controls.Add(lblProveedor);
            panel.Controls.Add(lblDescripcion);
            panel.Controls.Add(lblVisitas);

            panel.Click += (s, e) =>
            {
                var serv = (Servicio)panel.Tag;
                IncrementarVisitasServicio(serv.Id);
                CrearBoton.MostrarInfo($"Servicio: {serv.Titulo}\nProveedor: {serv.Proveedor}");
            };

            return panel;
        }

        private void IncrementarVisitasDenominacion(int idDenominacion)
        {
            string query = "UPDATE denominaciones SET visitas = visitas + 1 WHERE ID_Denominacion = @id";
            EjecutarActualizacion(query, idDenominacion);
        }

        private void IncrementarVisitasServicio(int idServicio)
        {
            string query = "UPDATE servicios SET visitas = visitas + 1 WHERE ID_Servicio = @id";
            EjecutarActualizacion(query, idServicio);
        }

        private void EjecutarActualizacion(string query, int id)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();
                    using (var cmd = new MySqlCommand(query, db._connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al actualizar visitas: {ex.Message}");
            }
        }

        private void BuscarEnCategoria()
        {
            if (_txtBuscarCategoria.Text == "BUSCAR SERVICIOS" || string.IsNullOrWhiteSpace(_txtBuscarCategoria.Text))
            {
                // Si estamos en una categoría específica, recargar todos los servicios
                if (_categoriaActual != null)
                {
                    CargarServicios(_categoriaActual.Id);
                }
                return;
            }

            var textoBusqueda = _txtBuscarCategoria.Text.Trim();

            // Filtrar servicios por texto
            var serviciosFiltrados = _servicios
                .Where(s => s.Titulo.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                           s.Descripcion.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                           s.Proveedor.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Actualizar la vista
            MostrarServiciosFiltrados(serviciosFiltrados);
        }

        private void MostrarServiciosFiltrados(List<Servicio> servicios)
        {
            _flpServicios.Controls.Clear();

            if (servicios.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "No se encontraron servicios con ese criterio",
                    Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Size = new Size(400, 30)
                };
                _flpServicios.Controls.Add(lbl);
                return;
            }

            foreach (var servicio in servicios)
            {
                var panelServicio = CrearPanelServicio(servicio);
                _flpServicios.Controls.Add(panelServicio);
            }
        }

        public void VolverAHome()
        {
            _tabControl.SelectedTab = _tabControl.TabPages[0];
            // Restaurar el buscador original
            _txtBuscarCategoria.Text = "BUSCAR CATEGORÍAS";
            _txtBuscarCategoria.ForeColor = Color.Gray;
        }
    }

    // Clases auxiliares
    public class Denominacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Visitas { get; set; }
    }

    public class Servicio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Proveedor { get; set; }
        public string Username { get; set; }
        public int Visitas { get; set; }
    }
}
