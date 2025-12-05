using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DataBase;

namespace ProveedorHome.Servicios
{
    public class ProveedorServicios
    {
        public class EstadisticasProveedor
        {
            public int TotalServicios { get; set; }
            public double PromedioCalificacion { get; set; }
            public int ClientesAtendidos { get; set; }
        }

        public EstadisticasProveedor ObtenerEstadisticas(int idUsuario)
        {
            var estadisticas = new EstadisticasProveedor();

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    // 1. Obtener conteo de servicios activos
                    string queryServicios = @"
                        SELECT COUNT(*) as total_servicios
                        FROM servicios 
                        WHERE ID_Usuario = @idUsuario";

                    estadisticas.TotalServicios = Convert.ToInt32(db.ExecuteScalar(queryServicios,
                        new MySqlParameter("@idUsuario", idUsuario)));

                    // 2. Obtener calificación promedio
                    string queryCalificacion = @"
                        SELECT AVG(puntuacion) as promedio
                        FROM sistema_calificacion 
                        WHERE ID_Empleado = @idUsuario";

                    object resultCalif = db.ExecuteScalar(queryCalificacion,
                        new MySqlParameter("@idUsuario", idUsuario));

                    estadisticas.PromedioCalificacion = resultCalif != DBNull.Value ?
                        Convert.ToDouble(resultCalif) : 0;

                    // 3. Obtener número de clientes atendidos
                    string queryClientes = @"
                        SELECT COUNT(DISTINCT ID_Cliente) as clientes_atendidos
                        FROM sistema_calificacion 
                        WHERE ID_Empleado = @idUsuario";

                    estadisticas.ClientesAtendidos = Convert.ToInt32(db.ExecuteScalar(queryClientes,
                        new MySqlParameter("@idUsuario", idUsuario)));
                }
            }
            catch (Exception)
            {
                // Valores por defecto en caso de error
                estadisticas.TotalServicios = 0;
                estadisticas.PromedioCalificacion = 0;
                estadisticas.ClientesAtendidos = 0;
            }

            return estadisticas;
        }

        public void CargarServicios(FlowLayoutPanel flpServicios, int idUsuario)
        {
            try
            {
                flpServicios.Controls.Clear();

                using (var db = new BDConector())
                {
                    db.Open();

                    string queryServicios = @"
                        SELECT s.titulo, c.nombre as categoria, s.visitas,
                               CASE 
                                   WHEN s.visitas > 100 THEN 'Destacado'
                                   WHEN s.visitas > 10 THEN 'Activo' 
                                   ELSE 'Nuevo'
                               END as estado
                        FROM servicios s
                        INNER JOIN categorias c ON s.ID_Categoria = c.ID_Categoria
                        WHERE s.ID_Usuario = @idUsuario
                        ORDER BY s.fecha_creacion DESC
                        LIMIT 10";

                    using (var reader = db.ExecuteReader(queryServicios,
                        new MySqlParameter("@idUsuario", idUsuario)))
                    {
                        while (reader.Read())
                        {
                            string titulo = reader["titulo"].ToString();
                            string categoria = reader["categoria"].ToString();
                            string estado = reader["estado"].ToString();
                            int visitas = Convert.ToInt32(reader["visitas"]);

                            // Determinar color según estado
                            Color colorEstado = estado == "Destacado" ? Color.Goldenrod :
                                               estado == "Activo" ? Color.Green :
                                               Color.Blue;

                            AgregarServicioCard(flpServicios, titulo, categoria,
                                               $"{estado} ({visitas} v)", colorEstado, visitas);
                        }
                    }

                    // Si no hay servicios, mostrar mensaje
                    if (flpServicios.Controls.Count == 0)
                    {
                        MostrarMensajeNoDatos(flpServicios,
                            "No tienes servicios registrados aún.\n¡Agrega tu primer servicio desde el menú!");
                    }
                }
            }
            catch (Exception)
            {
                MostrarMensajeNoDatos(flpServicios, "Error al cargar servicios");
            }
        }

        private void AgregarServicioCard(FlowLayoutPanel flpServicios, string titulo,
                                         string categoria, string estado, Color colorEstado, int visitas)
        {
            Panel card = new Panel
            {
                Size = new Size(280, 120),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            // Agregar borde
            card.Paint += (sender, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };

            Label lblTitulo = new Label
            {
                Text = titulo.Length > 30 ? titulo.Substring(0, 27) + "..." : titulo,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(260, 25),
                TextAlign = ContentAlignment.TopLeft
            };

            Label lblCategoria = new Label
            {
                Text = $"Categoría: {categoria}",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 40),
                AutoSize = true
            };

            Label lblEstado = new Label
            {
                Text = estado,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(10, 70),
                ForeColor = colorEstado,
                AutoSize = true
            };

            // Indicador de visitas
            Label lblVisitas = new Label
            {
                Text = $"{visitas} visitas",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(180, 70),
                AutoSize = true
            };

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblCategoria);
            card.Controls.Add(lblEstado);
            card.Controls.Add(lblVisitas);
            flpServicios.Controls.Add(card);
        }

        public void CargarCalificaciones(FlowLayoutPanel flpCalificaciones, int idUsuario)
        {
            try
            {
                flpCalificaciones.Controls.Clear();

                using (var db = new BDConector())
                {
                    db.Open();

                    string queryCalificaciones = @"
                        SELECT sc.puntuacion, sc.comentario, sc.fecha_creacion,
                               CONCAT(du.nombres, ' ', du.apellidos) as cliente_nombre
                        FROM sistema_calificacion sc
                        INNER JOIN usuarios u ON sc.ID_Cliente = u.ID_Usuario
                        INNER JOIN datos_usuario du ON u.ID_Usuario = du.ID_Usuario
                        WHERE sc.ID_Empleado = @idUsuario
                        ORDER BY sc.fecha_creacion DESC
                        LIMIT 5";

                    using (var reader = db.ExecuteReader(queryCalificaciones,
                        new MySqlParameter("@idUsuario", idUsuario)))
                    {
                        while (reader.Read())
                        {
                            string cliente = reader["cliente_nombre"].ToString();
                            int puntuacion = Convert.ToInt32(reader["puntuacion"]);
                            string comentario = reader["comentario"].ToString();
                            DateTime fecha = Convert.ToDateTime(reader["fecha_creacion"]);

                            AgregarCalificacionCard(flpCalificaciones, cliente, puntuacion, comentario, fecha);
                        }
                    }

                    // Si no hay calificaciones, mostrar mensaje
                    if (flpCalificaciones.Controls.Count == 0)
                    {
                        MostrarMensajeNoDatos(flpCalificaciones,
                            "Aún no tienes calificaciones.\n¡Completa tu primer servicio!");
                    }
                }
            }
            catch (Exception)
            {
                MostrarMensajeNoDatos(flpCalificaciones, "Error al cargar calificaciones");
            }
        }

        private void AgregarCalificacionCard(FlowLayoutPanel flpCalificaciones, string cliente,
                                            int estrellas, string comentario, DateTime fecha)
        {
            Panel card = new Panel
            {
                Size = new Size(300, 140),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            // Agregar borde
            card.Paint += (sender, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };

            Label lblCliente = new Label
            {
                Text = cliente,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            // Estrellas
            Panel pnlEstrellas = new Panel
            {
                Location = new Point(10, 35),
                Size = new Size(120, 25)
            };

            for (int i = 0; i < 5; i++)
            {
                Label estrella = new Label
                {
                    Text = i < estrellas ? "★" : "☆",
                    Font = new Font("Segoe UI", 14),
                    ForeColor = i < estrellas ? Color.Gold : Color.LightGray,
                    Location = new Point(i * 24, 0),
                    Size = new Size(24, 25),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlEstrellas.Controls.Add(estrella);
            }

            TextBox txtComentario = new TextBox
            {
                Text = comentario,
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 65),
                Size = new Size(270, 50),
                Multiline = true,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                ScrollBars = ScrollBars.Vertical
            };

            Label lblFecha = new Label
            {
                Text = fecha.ToString("dd/MM/yyyy HH:mm"),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(180, 10),
                AutoSize = true
            };

            card.Controls.Add(lblCliente);
            card.Controls.Add(pnlEstrellas);
            card.Controls.Add(txtComentario);
            card.Controls.Add(lblFecha);
            flpCalificaciones.Controls.Add(card);
        }

        private void MostrarMensajeNoDatos(FlowLayoutPanel panel, string mensaje)
        {
            panel.Controls.Clear();

            Label lblMensaje = new Label
            {
                Text = mensaje,
                Font = new Font("Segoe UI", 11, FontStyle.Italic),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(350, 100)
            };
            panel.Controls.Add(lblMensaje);
        }
    }
}