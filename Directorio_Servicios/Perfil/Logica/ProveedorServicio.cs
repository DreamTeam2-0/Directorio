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
                        IdUsuario = UserSession.IdUsuario
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

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo datos proveedor: {ex.Message}");
                return null;
            }
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