using System;
using System.Data;
using MySql.Data.MySqlClient;
using DataBase;

namespace Perfil.Modelos
{
    public class Experiencia
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string TipoRegistro { get; set; } // certificado, empirico
        public string NivelEstudios { get; set; } // tecnico, tecnologo, etc.
        public string AnosExperiencia { get; set; }
        public string EmpresasAnteriores { get; set; }
        public string ProyectosDestacados { get; set; }
        public string ReferenciasLaborales { get; set; }
        public string TipoExperiencia { get; set; }
        public string DescripcionOtro { get; set; }
    }

    public class ExperienciaManager
    {
        public Experiencia ObtenerExperienciaPorUsuario(int idUsuario)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        SELECT * FROM experiencia_usuario 
                        WHERE ID_Usuario = @idUsuario 
                        LIMIT 1";

                    using (var reader = db.ExecuteReader(query,
                        new MySqlParameter("@idUsuario", idUsuario)))
                    {
                        if (reader.Read())
                        {
                            return new Experiencia
                            {
                                Id = Convert.ToInt32(reader["ID_Experiencia"]),
                                IdUsuario = Convert.ToInt32(reader["ID_Usuario"]),
                                TipoRegistro = reader["tipo_registro"].ToString(),
                                NivelEstudios = reader["nivel_estudios"]?.ToString(),
                                AnosExperiencia = reader["anos_experiencia"].ToString(),
                                EmpresasAnteriores = reader["empresas_anteriores"]?.ToString(),
                                ProyectosDestacados = reader["proyectos_destacados"]?.ToString(),
                                ReferenciasLaborales = reader["referencias_laborales"]?.ToString(),
                                TipoExperiencia = reader["tipo_experiencia"]?.ToString(),
                                DescripcionOtro = reader["descripcion_otro"]?.ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener experiencia: {ex.Message}");
            }

            return null; // No hay experiencia registrada
        }

        public void CrearExperiencia(Experiencia experiencia)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        INSERT INTO experiencia_usuario 
                        (ID_Usuario, tipo_registro, nivel_estudios, anos_experiencia, 
                         empresas_anteriores, proyectos_destacados, referencias_laborales,
                         tipo_experiencia, descripcion_otro)
                        VALUES 
                        (@idUsuario, @tipoRegistro, @nivelEstudios, @anosExperiencia,
                         @empresasAnteriores, @proyectosDestacados, @referenciasLaborales,
                         @tipoExperiencia, @descripcionOtro)";

                    var parameters = new[]
                    {
                        new MySqlParameter("@idUsuario", experiencia.IdUsuario),
                        new MySqlParameter("@tipoRegistro", experiencia.TipoRegistro),
                        new MySqlParameter("@nivelEstudios", experiencia.NivelEstudios ?? (object)DBNull.Value),
                        new MySqlParameter("@anosExperiencia", experiencia.AnosExperiencia),
                        new MySqlParameter("@empresasAnteriores", experiencia.EmpresasAnteriores ?? (object)DBNull.Value),
                        new MySqlParameter("@proyectosDestacados", experiencia.ProyectosDestacados ?? (object)DBNull.Value),
                        new MySqlParameter("@referenciasLaborales", experiencia.ReferenciasLaborales ?? (object)DBNull.Value),
                        new MySqlParameter("@tipoExperiencia", experiencia.TipoExperiencia ?? (object)DBNull.Value),
                        new MySqlParameter("@descripcionOtro", experiencia.DescripcionOtro ?? (object)DBNull.Value)
                    };

                    db.ExecuteNonQuery(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear experiencia: {ex.Message}");
            }
        }

        public void ActualizarExperiencia(Experiencia experiencia)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        UPDATE experiencia_usuario 
                        SET tipo_registro = @tipoRegistro,
                            nivel_estudios = @nivelEstudios,
                            anos_experiencia = @anosExperiencia,
                            empresas_anteriores = @empresasAnteriores,
                            proyectos_destacados = @proyectosDestacados,
                            referencias_laborales = @referenciasLaborales,
                            tipo_experiencia = @tipoExperiencia,
                            descripcion_otro = @descripcionOtro,
                            fecha_modificacion = CURRENT_TIMESTAMP
                        WHERE ID_Experiencia = @idExperiencia";

                    var parameters = new[]
                    {
                        new MySqlParameter("@idExperiencia", experiencia.Id),
                        new MySqlParameter("@tipoRegistro", experiencia.TipoRegistro),
                        new MySqlParameter("@nivelEstudios", experiencia.NivelEstudios ?? (object)DBNull.Value),
                        new MySqlParameter("@anosExperiencia", experiencia.AnosExperiencia),
                        new MySqlParameter("@empresasAnteriores", experiencia.EmpresasAnteriores ?? (object)DBNull.Value),
                        new MySqlParameter("@proyectosDestacados", experiencia.ProyectosDestacados ?? (object)DBNull.Value),
                        new MySqlParameter("@referenciasLaborales", experiencia.ReferenciasLaborales ?? (object)DBNull.Value),
                        new MySqlParameter("@tipoExperiencia", experiencia.TipoExperiencia ?? (object)DBNull.Value),
                        new MySqlParameter("@descripcionOtro", experiencia.DescripcionOtro ?? (object)DBNull.Value)
                    };

                    int rowsAffected = db.ExecuteNonQuery(query, parameters);

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se pudo actualizar la experiencia");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar experiencia: {ex.Message}");
            }
        }
    }
}