using System;
using MySql.Data.MySqlClient;

namespace LoginDirectorio
{
    public class DatabaseHelper
    {
        private string connectionString = "server=localhost;database=directorio_servicios;uid=root;pwd=dinosaurio0619;charset=utf8mb4;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Método para validar login
        public (bool success, string mensaje, string nombreCompleto, string rol) ValidarLogin(string usuario, string password)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    // PRIMERO buscar en usuarios_sistema (administradores)
                    string querySistema = @"SELECT us.ID_Usuario_Sistema, us.username, us.nombres, us.apellidos, r.nombre as rol 
                                          FROM usuarios_sistema us 
                                          INNER JOIN roles r ON us.ID_Rol = r.ID_Rol 
                                          WHERE us.username = @usuario AND us.password_hash = @password AND us.activo = TRUE";

                    using (MySqlCommand command = new MySqlCommand(querySistema, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", usuario);
                        command.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombreCompleto = reader["nombres"] + " " + reader["apellidos"];
                                string rol = reader["rol"].ToString();
                                return (true, "Login exitoso", nombreCompleto, rol);
                            }
                        }
                    }

                    // SI no encontró en usuarios_sistema, buscar en usuarios (clientes/empleados)
                    string queryUsuarios = @"SELECT u.ID_Usuario, u.username, r.nombre as rol, 
                                           du.nombres, du.apellidos 
                                           FROM usuarios u 
                                           INNER JOIN roles r ON u.ID_Rol = r.ID_Rol 
                                           LEFT JOIN datos_usuario du ON u.ID_Usuario = du.ID_Usuario 
                                           WHERE u.username = @usuario AND u.password_hash = @password AND u.activo = TRUE";

                    using (MySqlCommand command = new MySqlCommand(queryUsuarios, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", usuario);
                        command.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombreCompleto = reader["nombres"] != DBNull.Value ?
                                                       reader["nombres"] + " " + reader["apellidos"] :
                                                       reader["username"].ToString();
                                string rol = reader["rol"].ToString();
                                return (true, "Login exitoso", nombreCompleto, rol);
                            }
                        }
                    }

                    return (false, "Usuario o contraseña incorrectos", "", "");
                }
            }
            catch (Exception ex)
            {
                return (false, "Error de conexión: " + ex.Message, "", "");
            }
        }

        // Método para registrar nuevo usuario
        public (bool success, string mensaje) RegistrarUsuario(string username, string password, string nombres,
                                                             string apellidos, string email, string telefono)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    // Verificar si el usuario ya existe
                    string checkQuery = "SELECT COUNT(*) FROM usuarios WHERE username = @username";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@username", username);

                    int existe = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existe > 0)
                    {
                        return (false, "El usuario ya existe");
                    }

                    // Insertar en tabla usuarios (rol 4 = cliente por defecto)
                    string insertUsuario = "INSERT INTO usuarios (username, password_hash, ID_Rol) VALUES (@username, @password, 4)";
                    MySqlCommand cmdUsuario = new MySqlCommand(insertUsuario, connection);
                    cmdUsuario.Parameters.AddWithValue("@username", username);
                    cmdUsuario.Parameters.AddWithValue("@password", password);

                    cmdUsuario.ExecuteNonQuery();

                    // Obtener el ID del usuario recién insertado
                    long userId = cmdUsuario.LastInsertedId;

                    // Insertar en datos_usuario
                    string insertDatos = @"INSERT INTO datos_usuario (ID_Usuario, nombres, apellidos, ciudad, email, telefono) 
                                         VALUES (@idUsuario, @nombres, @apellidos, 'Ciudad por defecto', @email, @telefono)";
                    MySqlCommand cmdDatos = new MySqlCommand(insertDatos, connection);
                    cmdDatos.Parameters.AddWithValue("@idUsuario", userId);
                    cmdDatos.Parameters.AddWithValue("@nombres", nombres);
                    cmdDatos.Parameters.AddWithValue("@apellidos", apellidos);
                    cmdDatos.Parameters.AddWithValue("@email", email);
                    cmdDatos.Parameters.AddWithValue("@telefono", telefono);

                    cmdDatos.ExecuteNonQuery();

                    return (true, $"Usuario {username} registrado exitosamente como Cliente");
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al registrar: " + ex.Message);
            }
        }
    }
}