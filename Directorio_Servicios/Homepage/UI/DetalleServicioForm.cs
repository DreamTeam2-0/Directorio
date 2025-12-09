
using DataBase;
using Homepage.Modelos;
using MySql.Data.MySqlClient;
using Shared.Session;
using System;
using System.Windows.Forms;

namespace Homepage.UI
{
    public partial class DetalleServicioForm : Form
    {
        private int _idServicio;
        private ServicioDetallado _servicio;

        public DetalleServicioForm(int idServicio)
        {
            InitializeComponent();
            _idServicio = idServicio;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void DetalleServicioForm_Load(object sender, EventArgs e)
        {
            IncrementarVisitasServicio(); // Primero incrementar visitas
            CargarDatosServicio();
        }

        private void CargarDatosServicio()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Cargando datos para servicio ID: {_idServicio}");

                _servicio = ObtenerServicioDetallado(_idServicio);

                if (_servicio != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Servicio encontrado: {_servicio.Titulo}");

                    // Datos básicos
                    lblTitulo.Text = _servicio.Titulo;
                    txtProveedor.Text = $"{_servicio.Nombres} {_servicio.Apellidos}";
                    txtDescripcion.Text = _servicio.Descripcion;
                    txtTipoPrecio.Text = ObtenerTextoPrecio(_servicio.TipoPrecio);
                    txtMoneda.Text = !string.IsNullOrEmpty(_servicio.Moneda) ? _servicio.Moneda : "No especificado";
                    txtDisponibilidad.Text = !string.IsNullOrEmpty(_servicio.Disponibilidad) ? _servicio.Disponibilidad : "No especificado";
                    txtRadioCobertura.Text = !string.IsNullOrEmpty(_servicio.RadioCobertura) ? _servicio.RadioCobertura : "No especificado";
                    txtExperiencia.Text = !string.IsNullOrEmpty(_servicio.Experiencia) ? _servicio.Experiencia : "No especificado";

                    // Datos de contacto
                    txtCiudad.Text = !string.IsNullOrEmpty(_servicio.Ciudad) ? _servicio.Ciudad : "No especificado";
                    txtEmail.Text = !string.IsNullOrEmpty(_servicio.Email) ? _servicio.Email : "No especificado";
                    txtTelefono.Text = !string.IsNullOrEmpty(_servicio.Telefono) ? _servicio.Telefono : "No especificado";
                    txtWhatsapp.Text = !string.IsNullOrEmpty(_servicio.Whatsapp) ? _servicio.Whatsapp : "No disponible";
                    txtOtroContacto.Text = !string.IsNullOrEmpty(_servicio.OtroContacto) ? _servicio.OtroContacto : "No disponible";
                    txtZonasServicio.Text = !string.IsNullOrEmpty(_servicio.ZonasServicio) ? _servicio.ZonasServicio : "No especificado";

                    // Visitas
                    lblVisitas.Text = $"{_servicio.Visitas} visitas"; // +1 porque ya incrementamos
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Servicio no encontrado en la base de datos");
                    MessageBox.Show($"No se pudo cargar la información del servicio (ID: {_idServicio}).\nEl servicio podría no existir o haber sido eliminado.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en CargarDatosServicio: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Error al cargar los datos: {ex.Message}\n\nDetalles: {ex.InnerException?.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private ServicioDetallado ObtenerServicioDetallado(int idServicio)
        {
            string query = @"
                SELECT 
                    s.ID_Servicio,
                    s.titulo,
                    s.descripcion,
                    s.tipo_precio,
                    s.moneda,
                    s.disponibilidad,
                    s.radio_cobertura,
                    s.experiencia,
                    s.visitas,
                    du.nombres,
                    du.apellidos,
                    du.ciudad,
                    du.direccion_aproximada,
                    du.email,
                    du.telefono,
                    du.whatsapp,
                    du.otro_contacto,
                    du.zonas_servicio
                FROM servicios s
                INNER JOIN datos_usuario du ON s.ID_Usuario = du.ID_Usuario
                WHERE s.ID_Servicio = @idServicio";

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();
                    System.Diagnostics.Debug.WriteLine($"Conexión abierta, ejecutando consulta para ID: {idServicio}");

                    using (var cmd = new MySqlCommand(query, db._connection))
                    {
                        cmd.Parameters.AddWithValue("@idServicio", idServicio);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                System.Diagnostics.Debug.WriteLine("Lectura exitosa del servicio");

                                // Método auxiliar para manejar valores nulos
                                string GetSafeString(int ordinal)
                                {
                                    return reader.IsDBNull(ordinal) ? "" : reader.GetString(ordinal);
                                }

                                return new ServicioDetallado
                                {
                                    Id = reader.GetInt32("ID_Servicio"),
                                    Titulo = GetSafeString(reader.GetOrdinal("titulo")),
                                    Descripcion = GetSafeString(reader.GetOrdinal("descripcion")),
                                    TipoPrecio = GetSafeString(reader.GetOrdinal("tipo_precio")),
                                    Moneda = GetSafeString(reader.GetOrdinal("moneda")),
                                    Disponibilidad = GetSafeString(reader.GetOrdinal("disponibilidad")),
                                    RadioCobertura = GetSafeString(reader.GetOrdinal("radio_cobertura")),
                                    Experiencia = GetSafeString(reader.GetOrdinal("experiencia")),
                                    Visitas = reader.GetInt32("visitas"),
                                    Nombres = GetSafeString(reader.GetOrdinal("nombres")),
                                    Apellidos = GetSafeString(reader.GetOrdinal("apellidos")),
                                    Ciudad = GetSafeString(reader.GetOrdinal("ciudad")),
                                    DireccionAproximada = GetSafeString(reader.GetOrdinal("direccion_aproximada")),
                                    Email = GetSafeString(reader.GetOrdinal("email")),
                                    Telefono = GetSafeString(reader.GetOrdinal("telefono")),
                                    Whatsapp = GetSafeString(reader.GetOrdinal("whatsapp")),
                                    OtroContacto = GetSafeString(reader.GetOrdinal("otro_contacto")),
                                    ZonasServicio = GetSafeString(reader.GetOrdinal("zonas_servicio"))
                                };
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("No se encontró el servicio en la BD");
                                return null;
                            }
                        }
                    }
                }
            }
            catch (MySqlException mySqlEx)
            {
                System.Diagnostics.Debug.WriteLine($"Error MySQL: {mySqlEx.Message}\nCódigo: {mySqlEx.Number}");
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error general obteniendo servicio: {ex.Message}");
                return null;
            }
        }

        private string ObtenerTextoPrecio(string tipoPrecio)
        {
            if (string.IsNullOrEmpty(tipoPrecio))
                return "No especificado";

            switch (tipoPrecio.ToLower())
            {
                case "fijo": return "Precio Fijo";
                case "por_hora": return "Por Hora";
                case "presupuesto": return "Presupuesto";
                case "consultar": return "Consultar Precio";
                default: return tipoPrecio;
            }
        }

        private void IncrementarVisitasServicio()
        {
            try
            {
                string query = "UPDATE servicios SET visitas = visitas + 1 WHERE ID_Servicio = @id";

                using (var db = new BDConector())
                {
                    db.Open();
                    using (var cmd = new MySqlCommand(query, db._connection))
                    {
                        cmd.Parameters.AddWithValue("@id", _idServicio);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"Visitas incrementadas. Filas afectadas: {rowsAffected}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error incrementando visitas: {ex.Message}");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComentario_Click(object sender, EventArgs e)
        {
            if (_servicio == null)
            {
                MessageBox.Show("No hay información del servicio disponible.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!UserSession.SesionActiva)
            {
                MessageBox.Show("Debe iniciar sesión para calificar y comentar servicios.",
                              "Sesión Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Necesitamos obtener el ID del empleado (proveedor)
                int idEmpleado = ObtenerIdEmpleadoDelServicio(_idServicio);

                if (idEmpleado <= 0)
                {
                    MessageBox.Show("No se pudo identificar al proveedor del servicio.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var calificarForm = new CalificarServicioForm(
                    _idServicio,
                    idEmpleado,
                    _servicio.Titulo,
                    $"{_servicio.Nombres} {_servicio.Apellidos}"
                );

                calificarForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de calificación: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerIdEmpleadoDelServicio(int idServicio)
        {
            string query = "SELECT ID_Usuario FROM servicios WHERE ID_Servicio = @idServicio";

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();
                    using (var cmd = new MySqlCommand(query, db._connection))
                    {
                        cmd.Parameters.AddWithValue("@idServicio", idServicio);
                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error obteniendo ID empleado: {ex.Message}");
            }

            return 0;
        }

        // Clase para almacenar los datos detallados del servicio
        public class ServicioDetallado
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string TipoPrecio { get; set; }
            public string Moneda { get; set; }
            public string Disponibilidad { get; set; }
            public string RadioCobertura { get; set; }
            public string Experiencia { get; set; }
            public int Visitas { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Ciudad { get; set; }
            public string DireccionAproximada { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
            public string Whatsapp { get; set; }
            public string OtroContacto { get; set; }
            public string ZonasServicio { get; set; }
        }
    }
}
