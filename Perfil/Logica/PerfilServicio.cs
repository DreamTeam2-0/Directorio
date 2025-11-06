using Perfil.Modelos;
using Perfil.ConectorBD;
using MySql.Data.MySqlClient;
using System;

namespace Perfil.Logica
{
    public class PerfilServicio
    {
        public PerfilUsuario ObtenerPerfil()
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    // NOTA: Reemplaza '1' con el ID del usuario logueado cuando implementes autenticación
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
                        WHERE du.ID_Usuario = 1 
                        LIMIT 1";

                    using (var reader = db.ExecuteReader(query))
                    {
                        if (reader.Read())
                        {
                            return new PerfilUsuario
                            {
                                Nombres = reader["nombres"].ToString(),
                                Apellidos = reader["apellidos"].ToString(),
                                Ciudad = reader["ciudad"].ToString(),
                                DireccionAproximada = reader["direccion_aproximada"].ToString(),
                                Email = reader["email"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                Whatsapp = reader["whatsapp"].ToString(),
                                OtroContacto = reader["otro_contacto"].ToString()
                            };
                        }
                    }
                }

                return null; // No se encontraron datos
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando perfil desde BD: {ex.Message}");
                return null;
            }
        }
    }
}