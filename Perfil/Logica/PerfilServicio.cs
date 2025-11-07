using Perfil.Modelos;
using DataBase;
using MySql.Data.MySqlClient;
using System;
using Shared.Session;

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
    }
}