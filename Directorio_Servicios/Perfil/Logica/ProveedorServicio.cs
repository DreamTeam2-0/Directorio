using DataBase;
using MySql.Data.MySqlClient;
using Perfil.Modelos;
using Shared.Session;
using System;
using System.Collections.Generic;

namespace Perfil.Logica
{
    public class ProveedorServicio
    {
        public ProveedorUsuario ObtenerDatosProveedor()
        {
            if (!UserSession.SesionActiva)
                return null;

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    var datos = new ProveedorUsuario
                    {
                        IdUsuario = UserSession.IdUsuario,
                        Especialidades = new List<EspecialidadProveedorModel>()
                    };

                    // 1. Obtener datos personales
                    string queryDatos = @"
                        SELECT 
                            du.nombres, du.apellidos, du.email, du.telefono, 
                            du.whatsapp, du.ciudad, du.direccion_aproximada,
                            du.zonas_servicio, du.otro_contacto, du.identificacion_oficial
                        FROM datos_usuario du
                        WHERE du.ID_Usuario = @idUsuario";

                    using (var reader = db.ExecuteReader(queryDatos,
                        new MySqlParameter("@idUsuario", UserSession.IdUsuario)))
                    {
                        if (reader.Read())
                        {
                            datos.Nombres = reader["nombres"].ToString();
                            datos.Apellidos = reader["apellidos"].ToString();
                            datos.Email = reader["email"].ToString();
                            datos.Telefono = reader["telefono"].ToString();
                            datos.Whatsapp = reader["whatsapp"]?.ToString() ?? "";
                            datos.Ciudad = reader["ciudad"].ToString();
                            datos.Direccion = reader["direccion_aproximada"]?.ToString() ?? "";
                            datos.ZonasServicio = reader["zonas_servicio"]?.ToString() ?? "";
                            datos.OtroContacto = reader["otro_contacto"]?.ToString() ?? "";
                            datos.IdentificacionOficial = reader["identificacion_oficial"]?.ToString() ?? "";
                        }
                    }

                    // 2. Obtener experiencia
                    string queryExperiencia = @"
                        SELECT 
                            tipo_registro, nivel_estudios, anos_experiencia,
                            empresas_anteriores, proyectos_destacados, referencias_laborales,
                            tipo_experiencia, descripcion_otro
                        FROM experiencia_usuario
                        WHERE ID_Usuario = @idUsuario";

                    using (var reader = db.ExecuteReader(queryExperiencia,
                        new MySqlParameter("@idUsuario", UserSession.IdUsuario)))
                    {
                        if (reader.Read())
                        {
                            datos.Experiencia = new ExperienciaProveedorModel
                            {
                                TipoRegistro = reader["tipo_registro"].ToString(),
                                NivelEstudios = reader["nivel_estudios"]?.ToString() ?? "",
                                AnosExperiencia = reader["anos_experiencia"].ToString(),
                                EmpresasAnteriores = reader["empresas_anteriores"]?.ToString() ?? "",
                                ProyectosDestacados = reader["proyectos_destacados"]?.ToString() ?? "",
                                ReferenciasLaborales = reader["referencias_laborales"]?.ToString() ?? "",
                                TipoExperiencia = reader["tipo_experiencia"]?.ToString() ?? "",
                                DescripcionOtro = reader["descripcion_otro"]?.ToString() ?? ""
                            };
                        }
                    }

                    // 3. Obtener categorías/servicios
                    string queryServicios = @"
                        SELECT s.ID_Categoria, c.nombre as categoria, s.experiencia
                        FROM servicios s
                        INNER JOIN categorias c ON s.ID_Categoria = c.ID_Categoria
                        WHERE s.ID_Usuario = @idUsuario
                        GROUP BY s.ID_Categoria";

                    using (var reader = db.ExecuteReader(queryServicios,
                        new MySqlParameter("@idUsuario", UserSession.IdUsuario)))
                    {
                        while (reader.Read())
                        {
                            datos.Especialidades.Add(new EspecialidadProveedorModel
                            {
                                IdCategoria = Convert.ToInt32(reader["ID_Categoria"]),
                                NombreCategoria = reader["categoria"].ToString(),
                                DescripcionServicios = reader["experiencia"]?.ToString() ?? ""
                            });
                        }
                    }

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo datos proveedor: {ex.Message}");
                return null;
            }
        }

        public List<CategoriaModel> ObtenerCategorias()
        {
            var categorias = new List<CategoriaModel>();

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        SELECT ID_Categoria, nombre, descripcion
                        FROM categorias 
                        WHERE activa = TRUE
                        ORDER BY nombre";

                    using (var reader = db.ExecuteReader(query))
                    {
                        while (reader.Read())
                        {
                            categorias.Add(new CategoriaModel
                            {
                                Id = Convert.ToInt32(reader["ID_Categoria"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"]?.ToString() ?? ""
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo categorías: {ex.Message}");
            }

            return categorias;
        }



        public bool ActualizarDatosProveedor(ProveedorUsuario datos)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    // 1. Actualizar datos_usuario
                    string updateDatos = @"
                        UPDATE datos_usuario 
                        SET 
                            nombres = @nombres,
                            apellidos = @apellidos,
                            email = @email,
                            telefono = @telefono,
                            whatsapp = @whatsapp,
                            ciudad = @ciudad,
                            direccion_aproximada = @direccion,
                            zonas_servicio = @zonas,
                            otro_contacto = @otroContacto
                        WHERE ID_Usuario = @idUsuario";

                    int filas = db.ExecuteNonQuery(updateDatos,
                        new MySqlParameter("@nombres", datos.Nombres),
                        new MySqlParameter("@apellidos", datos.Apellidos),
                        new MySqlParameter("@email", datos.Email),
                        new MySqlParameter("@telefono", datos.Telefono),
                        new MySqlParameter("@whatsapp", datos.Whatsapp ?? ""),
                        new MySqlParameter("@ciudad", datos.Ciudad),
                        new MySqlParameter("@direccion", datos.Direccion ?? ""),
                        new MySqlParameter("@zonas", datos.ZonasServicio ?? ""),
                        new MySqlParameter("@otroContacto", datos.OtroContacto ?? ""),
                        new MySqlParameter("@idUsuario", UserSession.IdUsuario));

                    if (filas == 0) return false;

                    // 2. Actualizar/Insertar experiencia_usuario
                    if (datos.Experiencia != null)
                    {
                        // Primero verificar si existe
                        string checkExp = "SELECT COUNT(*) FROM experiencia_usuario WHERE ID_Usuario = @idUsuario";
                        int existeExp = Convert.ToInt32(db.ExecuteScalar(checkExp,
                            new MySqlParameter("@idUsuario", UserSession.IdUsuario)));

                        if (existeExp > 0)
                        {
                            // Actualizar
                            string updateExp = @"
                                UPDATE experiencia_usuario 
                                SET 
                                    tipo_registro = @tipo,
                                    nivel_estudios = @nivel,
                                    anos_experiencia = @anos,
                                    empresas_anteriores = @empresas,
                                    proyectos_destacados = @proyectos,
                                    referencias_laborales = @referencias,
                                    tipo_experiencia = @tipoExp,
                                    descripcion_otro = @descOtro
                                WHERE ID_Usuario = @idUsuario";

                            filas = db.ExecuteNonQuery(updateExp,
                                new MySqlParameter("@tipo", datos.Experiencia.TipoRegistro),
                                new MySqlParameter("@nivel", datos.Experiencia.NivelEstudios ?? (object)DBNull.Value),
                                new MySqlParameter("@anos", datos.Experiencia.AnosExperiencia),
                                new MySqlParameter("@empresas", datos.Experiencia.EmpresasAnteriores ?? (object)DBNull.Value),
                                new MySqlParameter("@proyectos", datos.Experiencia.ProyectosDestacados ?? (object)DBNull.Value),
                                new MySqlParameter("@referencias", datos.Experiencia.ReferenciasLaborales ?? (object)DBNull.Value),
                                new MySqlParameter("@tipoExp", datos.Experiencia.TipoExperiencia ?? (object)DBNull.Value),
                                new MySqlParameter("@descOtro", datos.Experiencia.DescripcionOtro ?? (object)DBNull.Value),
                                new MySqlParameter("@idUsuario", UserSession.IdUsuario));
                        }
                        else
                        {
                            // Insertar
                            string insertExp = @"
                                INSERT INTO experiencia_usuario 
                                (ID_Usuario, tipo_registro, nivel_estudios, anos_experiencia,
                                 empresas_anteriores, proyectos_destacados, referencias_laborales,
                                 tipo_experiencia, descripcion_otro)
                                VALUES 
                                (@idUsuario, @tipo, @nivel, @anos, @empresas, @proyectos, 
                                 @referencias, @tipoExp, @descOtro)";

                            filas = db.ExecuteNonQuery(insertExp,
                                new MySqlParameter("@idUsuario", UserSession.IdUsuario),
                                new MySqlParameter("@tipo", datos.Experiencia.TipoRegistro),
                                new MySqlParameter("@nivel", datos.Experiencia.NivelEstudios ?? (object)DBNull.Value),
                                new MySqlParameter("@anos", datos.Experiencia.AnosExperiencia),
                                new MySqlParameter("@empresas", datos.Experiencia.EmpresasAnteriores ?? (object)DBNull.Value),
                                new MySqlParameter("@proyectos", datos.Experiencia.ProyectosDestacados ?? (object)DBNull.Value),
                                new MySqlParameter("@referencias", datos.Experiencia.ReferenciasLaborales ?? (object)DBNull.Value),
                                new MySqlParameter("@tipoExp", datos.Experiencia.TipoExperiencia ?? (object)DBNull.Value),
                                new MySqlParameter("@descOtro", datos.Experiencia.DescripcionOtro ?? (object)DBNull.Value));
                        }
                    }

                    // 3. Eliminar servicios existentes para reinsertar (simplificado)
                    // En una versión más avanzada, se debería hacer un merge
                    string deleteServicios = "DELETE FROM servicios WHERE ID_Usuario = @idUsuario";
                    db.ExecuteNonQuery(deleteServicios,
                        new MySqlParameter("@idUsuario", UserSession.IdUsuario));

                    // 4. Insertar nuevos servicios por cada categoría
                    if (datos.Especialidades != null)
                    {
                        foreach (var especialidad in datos.Especialidades)
                        {
                            string insertServicio = @"
                                INSERT INTO servicios 
                                (ID_Usuario, ID_Categoria, titulo, descripcion, experiencia,
                                 tipo_precio, visitas)
                                VALUES 
                                (@idUsuario, @idCategoria, @titulo, @descripcion, @experiencia,
                                 'consultar', 0)";

                            string titulo = $"Servicio de {especialidad.NombreCategoria}";

                            db.ExecuteNonQuery(insertServicio,
                                new MySqlParameter("@idUsuario", UserSession.IdUsuario),
                                new MySqlParameter("@idCategoria", especialidad.IdCategoria),
                                new MySqlParameter("@titulo", titulo),
                                new MySqlParameter("@descripcion", especialidad.DescripcionServicios ?? ""),
                                new MySqlParameter("@experiencia", especialidad.DescripcionServicios ?? ""));
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error actualizando datos proveedor: {ex.Message}");
                return false;
            }
        }
    }
}