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
        private Panel _panelCategorias;  // CAMBIADO: de TabControl a Panel
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

        public CategoriaManager(
            Panel panelCategorias,  // CAMBIADO: ahora recibe Panel en lugar de TabControl
            FlowLayoutPanel flpDenominaciones,
            FlowLayoutPanel flpServicios,
            Label lblDenominaciones,
            Label lblServicios,
            Button btnVolverHome,
            FranjaManager franjaManager,
            TextBox txtBuscar,
            Button btnBuscar,
            Label lblBienvenida)
        {
            _panelCategorias = panelCategorias;  // CORREGIDO: ahora existe
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

            // Mostrar el panel de categorías
            _panelCategorias.Visible = true;

            // Actualizar título - MOSTRAR NOMBRE DE CATEGORÍA
            _lblDenominaciones.Text = $"Denominaciones - {categoria.Nombre}";

            // Actualizar el otro label para mostrar la categoría seleccionada
            _lblServicios.Text = $"Categoría seleccionada: {categoria.Nombre}";

            // Configurar buscador para esta categoría
            _txtBuscarCategoria.Text = "BUSCAR SERVICIOS";
            _txtBuscarCategoria.ForeColor = Color.Gray;

            // Cargar datos
            CargarDenominaciones(categoria.Id);
            CargarServicios(categoria.Id);
        }

        // Modifica el método MostrarTodasCategorias:
        public void MostrarTodasCategorias()
        {
            // Mostrar el panel de categorías
            _panelCategorias.Visible = true;

            // Configurar para mostrar todas las categorías
            _lblDenominaciones.Text = "Todas las Categorías";
            _lblServicios.Text = "Seleccione una categoría del carrusel para ver sus denominaciones y servicios";

            // Limpiar controles
            _flpDenominaciones.Controls.Clear();
            _flpServicios.Controls.Clear();

            // Mostrar mensaje informativo
            var lbl = new Label
            {
                Text = "Seleccione una categoría del carrusel en Home para ver sus denominaciones y servicios",
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic),
                ForeColor = Color.Gray,
                Size = new Size(500, 60)
            };
            _flpDenominaciones.Controls.Add(lbl);

            // Configurar buscador para búsqueda general
            _txtBuscarCategoria.Text = "BUSCAR SERVICIOS";
            _txtBuscarCategoria.ForeColor = Color.Gray;

            // Limpiar categoría actual
            _categoriaActual = null;
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
                BackColor = Color.FromArgb(76, 175, 80), // Verde consistente
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = denominacion
            };

            // Efecto hover
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(56, 155, 60);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(76, 175, 80);

            btn.Click += (s, e) =>
            {
                var den = (Denominacion)btn.Tag;
                IncrementarVisitasDenominacion(den.Id);

                // Mostrar información de la denominación
                string mensaje = $"Denominación: {den.Nombre}\n";
                if (!string.IsNullOrEmpty(den.Descripcion))
                    mensaje += $"Descripción: {den.Descripcion}\n";
                mensaje += $"Visitas: {den.Visitas + 1}";

                CrearBoton.MostrarInfo(mensaje);
            };

            return btn;
        }

        private GroupBox CrearPanelServicio(Servicio servicio)
        {
            var groupBox = new GroupBox
            {
                Size = new Size(350, 120),
                BackColor = Color.White,
                ForeColor = Color.Gray, // Color del texto del borde
                Text = "", // Sin texto en el borde
                Margin = new Padding(5),
                Tag = servicio
            };

            // Título del servicio
            var lblTitulo = new Label
            {
                Text = servicio.Titulo,
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
                Location = new Point(10, 15),
                Size = new Size(330, 20),
                ForeColor = Color.FromArgb(32, 74, 135)
            };

            // Proveedor
            var lblProveedor = new Label
            {
                Text = $"Proveedor: {servicio.Proveedor}",
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular),
                Location = new Point(10, 40),
                Size = new Size(330, 15),
                ForeColor = Color.DarkGray
            };

            // Descripción (truncada)
            var descripcion = servicio.Descripcion.Length > 100
                ? servicio.Descripcion.Substring(0, 100) + "..."
                : servicio.Descripcion;

            var lblDescripcion = new Label
            {
                Text = descripcion,
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular),
                Location = new Point(10, 60),
                Size = new Size(330, 40),
                ForeColor = Color.Black
            };

            // Visitas
            var lblVisitas = new Label
            {
                Text = $"{servicio.Visitas} visitas",
                Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Italic),
                Location = new Point(10, 100),
                Size = new Size(100, 15),
                ForeColor = Color.Gray
            };

            groupBox.Controls.Add(lblTitulo);
            groupBox.Controls.Add(lblProveedor);
            groupBox.Controls.Add(lblDescripcion);
            groupBox.Controls.Add(lblVisitas);

            // Efecto hover
            groupBox.MouseEnter += (s, e) => groupBox.BackColor = Color.FromArgb(245, 245, 245);
            groupBox.MouseLeave += (s, e) => groupBox.BackColor = Color.White;

            groupBox.Click += (s, e) =>
            {
                var serv = (Servicio)groupBox.Tag;
                IncrementarVisitasServicio(serv.Id);

                string mensaje = $"Servicio: {serv.Titulo}\n" +
                                $"Proveedor: {serv.Proveedor}\n" +
                                $"Usuario: {serv.Username}\n" +
                                $"Visitas: {serv.Visitas + 1}";

                CrearBoton.MostrarInfo(mensaje);
            };

            return groupBox;
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
                .Where(s => s.Titulo.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                           s.Descripcion.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                           s.Proveedor.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
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
            // Ocultar el panel de categorías
            _panelCategorias.Visible = false;

            // Limpiar la vista
            LimpiarVista();

            // Restaurar el buscador original
            _txtBuscarCategoria.Text = "BUSCAR CATEGORÍAS";
            _txtBuscarCategoria.ForeColor = Color.Gray;
        }


        public void LimpiarVista()
        {
            _flpDenominaciones.Controls.Clear();
            _flpServicios.Controls.Clear();
            _lblDenominaciones.Text = "Todas las Categorías";
            _lblServicios.Text = "Seleccione una categoría del carrusel para ver sus denominaciones y servicios";
            _categoriaActual = null;
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