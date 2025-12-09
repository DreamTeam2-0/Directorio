using DataBase;
using MySql.Data.MySqlClient;
using Perfil.Modelos;
using Shared.Session;
using System;
using System.Data.SqlClient;

namespace Perfil.Logica
{
    public class PerfilServicio
    {
        public PerfilUsuario ObtenerPerfil()
        {
            if (!UserSession.SesionActiva)
            {
                System.Diagnostics.Debug.WriteLine("No hay sesión activa");
                return null;
            }

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        SELECT 
                            du.nombres, 
                            du.apellidos, 
                            du.ciudad, 
                            du.direccion_aproximada, 
                            du.email, 
                            du.telefono, 
                            du.whatsapp, 
                            du.otro_contacto 
                        FROM datos_usuario du 
                        WHERE du.ID_Usuario = @idUsuario 
                        LIMIT 1";

                    using (var reader = db.ExecuteReader(query, new MySqlParameter("@idUsuario", UserSession.IdUsuario)))
                    {
                        if (reader.Read())
                        {
                            return new PerfilUsuario
                            {
                                Nombres = reader["nombres"].ToString(),
                                Apellidos = reader["apellidos"].ToString(),
                                Ciudad = reader["ciudad"].ToString(),
                                DireccionAproximada = reader["direccion_aproximada"]?.ToString() ?? "",
                                Email = reader["email"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                Whatsapp = reader["whatsapp"]?.ToString() ?? "",
                                OtroContacto = reader["otro_contacto"]?.ToString() ?? ""
                            };
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando perfil desde BD: {ex.Message}");
                return null;
            }
        }

        public bool ActualizarPerfil(PerfilUsuario perfil)
        {
            if (!UserSession.SesionActiva)
            {
                System.Diagnostics.Debug.WriteLine("No hay sesión activa");
                return false;
            }

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    // Verificar si el usuario ya tiene datos en la tabla
                    string checkQuery = "SELECT COUNT(*) FROM datos_usuario WHERE ID_Usuario = @idUsuario";
                    var count = Convert.ToInt32(db.ExecuteScalar(checkQuery,
                        new MySqlParameter("@idUsuario", UserSession.IdUsuario)));

                    string query;

                    if (count > 0)
                    {
                        // Actualizar registro existente
                        query = @"
                            UPDATE datos_usuario 
                            SET nombres = @nombres,
                                apellidos = @apellidos,
                                ciudad = @ciudad,
                                direccion_aproximada = @direccion,
                                email = @email,
                                telefono = @telefono,
                                whatsapp = @whatsapp,
                                otro_contacto = @otroContacto
                            WHERE ID_Usuario = @idUsuario";
                    }
                    else
                    {
                        // Insertar nuevo registro
                        query = @"
                            INSERT INTO datos_usuario 
                            (ID_Usuario, nombres, apellidos, ciudad, direccion_aproximada, 
                             email, telefono, whatsapp, otro_contacto)
                            VALUES 
                            (@idUsuario, @nombres, @apellidos, @ciudad, @direccion,
                             @email, @telefono, @whatsapp, @otroContacto)";
                    }

                    var parameters = new[]
                    {
                        new MySqlParameter("@idUsuario", UserSession.IdUsuario),
                        new MySqlParameter("@nombres", perfil.Nombres),
                        new MySqlParameter("@apellidos", perfil.Apellidos),
                        new MySqlParameter("@ciudad", perfil.Ciudad),
                        new MySqlParameter("@direccion", perfil.DireccionAproximada),
                        new MySqlParameter("@email", perfil.Email),
                        new MySqlParameter("@telefono", perfil.Telefono),
                        new MySqlParameter("@whatsapp", perfil.Whatsapp),
                        new MySqlParameter("@otroContacto", perfil.OtroContacto)
                    };

                    int rowsAffected = db.ExecuteNonQuery(query, parameters);
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error actualizando perfil: {ex.Message}");
                return false;
            }
        }

        public string[] ParsearUbicacion(string ubicacion)
        {
            // Separar ciudad y dirección de la ubicación completa
            // Formato esperado: "Ciudad - Dirección"
            var partes = ubicacion.Split(new[] { " - " }, StringSplitOptions.None);

            if (partes.Length >= 2)
            {
                return new[] { partes[0].Trim(), partes[1].Trim() };
            }
            else if (partes.Length == 1)
            {
                return new[] { partes[0].Trim(), "" };
            }

            return new[] { "", "" };
        }
    }
}
