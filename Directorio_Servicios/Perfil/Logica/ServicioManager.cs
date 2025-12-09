using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using DataBase;

namespace Perfil.Logica
{
    public class Servicio
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public int? IdDenominacion { get; set; }
        public string TipoPrecio { get; set; }
        public string Moneda { get; set; }
        public string Disponibilidad { get; set; }
        public string RadioCobertura { get; set; }
        public string Experiencia { get; set; }
        public int Visitas { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class ServicioManager
    {
        public List<Servicio> ObtenerServiciosPorUsuario(int idUsuario)
        {
            var servicios = new List<Servicio>();

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        SELECT s.*, c.nombre as categoria_nombre, 
                               d.nombre as denominacion_nombre
                        FROM servicios s
                        LEFT JOIN categorias c ON s.ID_Categoria = c.ID_Categoria
                        LEFT JOIN denominaciones d ON s.ID_Denominacion = d.ID_Denominacion
                        WHERE s.ID_Usuario = @idUsuario
                        ORDER BY s.fecha_creacion DESC";

                    using (var reader = db.ExecuteReader(query,
                        new MySqlParameter("@idUsuario", idUsuario)))
                    {
                        while (reader.Read())
                        {
                            servicios.Add(new Servicio
                            {
                                Id = Convert.ToInt32(reader["ID_Servicio"]),
                                IdUsuario = Convert.ToInt32(reader["ID_Usuario"]),
                                Titulo = reader["titulo"].ToString(),
                                Descripcion = reader["descripcion"].ToString(),
                                IdCategoria = Convert.ToInt32(reader["ID_Categoria"]),
                                IdDenominacion = reader["ID_Denominacion"] == DBNull.Value ?
                                    null : (int?)Convert.ToInt32(reader["ID_Denominacion"]),
                                TipoPrecio = reader["tipo_precio"].ToString(),
                                Moneda = reader["moneda"].ToString(),
                                Disponibilidad = reader["disponibilidad"].ToString(),
                                RadioCobertura = reader["radio_cobertura"].ToString(),
                                Experiencia = reader["experiencia"].ToString(),
                                Visitas = Convert.ToInt32(reader["visitas"]),
                                FechaCreacion = Convert.ToDateTime(reader["fecha_creacion"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener servicios: {ex.Message}");
            }

            return servicios;
        }

        public void CrearServicio(Servicio servicio)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        INSERT INTO servicios 
                        (ID_Usuario, titulo, descripcion, ID_Categoria, ID_Denominacion, 
                         tipo_precio, moneda, disponibilidad, radio_cobertura, experiencia)
                        VALUES 
                        (@idUsuario, @titulo, @descripcion, @idCategoria, @idDenominacion,
                         @tipoPrecio, @moneda, @disponibilidad, @radioCobertura, @experiencia)";

                    var parameters = new[]
                    {
                        new MySqlParameter("@idUsuario", servicio.IdUsuario),
                        new MySqlParameter("@titulo", servicio.Titulo),
                        new MySqlParameter("@descripcion", servicio.Descripcion),
                        new MySqlParameter("@idCategoria", servicio.IdCategoria),
                        new MySqlParameter("@idDenominacion", servicio.IdDenominacion ?? (object)DBNull.Value),
                        new MySqlParameter("@tipoPrecio", servicio.TipoPrecio),
                        new MySqlParameter("@moneda", servicio.Moneda),
                        new MySqlParameter("@disponibilidad", servicio.Disponibilidad),
                        new MySqlParameter("@radioCobertura", servicio.RadioCobertura),
                        new MySqlParameter("@experiencia", servicio.Experiencia)
                    };

                    db.ExecuteNonQuery(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear servicio: {ex.Message}");
            }
        }

        public void ActualizarServicio(Servicio servicio)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        UPDATE servicios 
                        SET titulo = @titulo,
                            descripcion = @descripcion,
                            ID_Categoria = @idCategoria,
                            ID_Denominacion = @idDenominacion,
                            tipo_precio = @tipoPrecio,
                            moneda = @moneda,
                            disponibilidad = @disponibilidad,
                            radio_cobertura = @radioCobertura,
                            experiencia = @experiencia,
                            fecha_modificacion = CURRENT_TIMESTAMP
                        WHERE ID_Servicio = @idServicio AND ID_Usuario = @idUsuario";

                    var parameters = new[]
                    {
                        new MySqlParameter("@idServicio", servicio.Id),
                        new MySqlParameter("@idUsuario", servicio.IdUsuario),
                        new MySqlParameter("@titulo", servicio.Titulo),
                        new MySqlParameter("@descripcion", servicio.Descripcion),
                        new MySqlParameter("@idCategoria", servicio.IdCategoria),
                        new MySqlParameter("@idDenominacion", servicio.IdDenominacion ?? (object)DBNull.Value),
                        new MySqlParameter("@tipoPrecio", servicio.TipoPrecio),
                        new MySqlParameter("@moneda", servicio.Moneda),
                        new MySqlParameter("@disponibilidad", servicio.Disponibilidad),
                        new MySqlParameter("@radioCobertura", servicio.RadioCobertura),
                        new MySqlParameter("@experiencia", servicio.Experiencia)
                    };

                    int rowsAffected = db.ExecuteNonQuery(query, parameters);

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se pudo actualizar el servicio. Verifique los permisos.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar servicio: {ex.Message}");
            }
        }

        public void EliminarServicio(int idServicio)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = "DELETE FROM servicios WHERE ID_Servicio = @idServicio";

                    int rowsAffected = db.ExecuteNonQuery(query,
                        new MySqlParameter("@idServicio", idServicio));

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se pudo eliminar el servicio.");
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451) // Foreign key constraint
            {
                throw new Exception("No se puede eliminar el servicio porque tiene calificaciones asociadas.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar servicio: {ex.Message}");
            }
        }
    }
}