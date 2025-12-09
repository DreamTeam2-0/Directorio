using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using DataBase;

namespace Perfil.Logica
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Icono { get; set; }
        public string Color { get; set; }
    }

    public class Denominacion
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class CategoriaManager
    {
        public List<Categoria> ObtenerCategorias()
        {
            var categorias = new List<Categoria>();

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        SELECT ID_Categoria, nombre, descripcion, icono, color
                        FROM categorias 
                        WHERE activa = TRUE
                        ORDER BY nombre";

                    using (var reader = db.ExecuteReader(query))
                    {
                        while (reader.Read())
                        {
                            categorias.Add(new Categoria
                            {
                                Id = Convert.ToInt32(reader["ID_Categoria"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString(),
                                Icono = reader["icono"].ToString(),
                                Color = reader["color"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener categorías: {ex.Message}");
            }

            return categorias;
        }

        public List<Denominacion> ObtenerDenominacionesPorCategoria(int idCategoria)
        {
            var denominaciones = new List<Denominacion>();

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        SELECT ID_Denominacion, ID_Categoria, nombre, descripcion
                        FROM denominaciones 
                        WHERE ID_Categoria = @idCategoria
                        ORDER BY nombre";

                    using (var reader = db.ExecuteReader(query,
                        new MySqlParameter("@idCategoria", idCategoria)))
                    {
                        while (reader.Read())
                        {
                            denominaciones.Add(new Denominacion
                            {
                                Id = Convert.ToInt32(reader["ID_Denominacion"]),
                                IdCategoria = Convert.ToInt32(reader["ID_Categoria"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener denominaciones: {ex.Message}");
            }

            return denominaciones;
        }
    }
}