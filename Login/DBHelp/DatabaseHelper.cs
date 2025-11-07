using MySql.Data.MySqlClient;
using PassHelp.PasswordHelper;
using System;
using DataBase;

namespace DBHelp.DatabaseHelper
{
    public class DatabaseHelper
    {
        // Método para validar login CON ENCRIPTACIÓN - SOLO tabla usuarios
        public (bool success, string mensaje, string nombreCompleto, string rol) ValidarLogin(string usuario, string passwordEncriptado)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    // SOLO buscar en usuarios (clientes/empleados) - EXCLUIR usuarios_sistema
                    string queryUsuarios = @"SELECT u.ID_Usuario, u.username, r.nombre as rol, 
                                           du.nombres, du.apellidos 
                                           FROM usuarios u 
                                           INNER JOIN roles r ON u.ID_Rol = r.ID_Rol 
                                           LEFT JOIN datos_usuario du ON u.ID_Usuario = du.ID_Usuario 
                                           WHERE u.username = @usuario AND u.password_hash = @password AND u.activo = TRUE";

                    using (var reader = db.ExecuteReader(queryUsuarios,
                        new MySqlParameter("@usuario", usuario),
                        new MySqlParameter("@password", passwordEncriptado)))
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

                    // Mensaje genérico para mayor seguridad
                    return (false, "Usuario o contraseña incorrectos", "", "");
                }
            }
            catch (Exception)
            {
                // Mensaje genérico incluso en errores de conexión para no revelar información
                return (false, "Error en la autenticación", "", "");
            }
        }

        // Método para obtener el ID de usuario por nombre de usuario
        public (bool success, int idUsuario, string mensaje) ObtenerIdUsuario(string usuario)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = @"SELECT u.ID_Usuario 
                           FROM usuarios u 
                           WHERE u.username = @usuario AND u.activo = TRUE";

                    using (var reader = db.ExecuteReader(query, new MySqlParameter("@usuario", usuario)))
                    {
                        if (reader.Read())
                        {
                            int idUsuario = reader.GetInt32("ID_Usuario");
                            return (true, idUsuario, "ID encontrado");
                        }
                    }

                    return (false, 0, "Usuario no encontrado");
                }
            }
            catch (Exception ex)
            {
                return (false, 0, $"Error al obtener ID: {ex.Message}");
            }
        }


        // Método para registrar nuevo usuario CON ENCRIPTACIÓN
        public (bool success, string mensaje) RegistrarUsuario(string username, string passwordEncriptado, string nombres,
                                                             string apellidos, string ciudad, string email, string telefono)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    // 1. Verificar si el usuario existe
                    string checkQuery = "SELECT COUNT(*) FROM usuarios WHERE username = @username";
                    int existeUsuario = Convert.ToInt32(db.ExecuteScalar(checkQuery,
                        new MySqlParameter("@username", username)));

                    if (existeUsuario > 0)
                    {
                        return (false, "El nombre de usuario no está disponible");
                    }

                    // 2. Insertar en tabla usuarios
                    string insertUsuario = "INSERT INTO usuarios (username, password_hash, ID_Rol, activo) VALUES (@username, @password, 4, TRUE)";
                    int filasAfectadas = db.ExecuteNonQuery(insertUsuario,
                        new MySqlParameter("@username", username),
                        new MySqlParameter("@password", passwordEncriptado));

                    if (filasAfectadas == 0)
                    {
                        return (false, "Error al crear el usuario");
                    }

                    // 3. Obtener el ID del usuario (necesitamos una consulta separada)
                    string getIdQuery = "SELECT LAST_INSERT_ID()";
                    long userId = Convert.ToInt64(db.ExecuteScalar(getIdQuery));

                    // 4. Insertar en datos_usuario (incluyendo ciudad)
                    string insertDatos = @"INSERT INTO datos_usuario (ID_Usuario, nombres, apellidos, ciudad, email, telefono) 
                                         VALUES (@idUsuario, @nombres, @apellidos, @ciudad, @email, @telefono)";

                    filasAfectadas = db.ExecuteNonQuery(insertDatos,
                        new MySqlParameter("@idUsuario", userId),
                        new MySqlParameter("@nombres", nombres),
                        new MySqlParameter("@apellidos", apellidos),
                        new MySqlParameter("@ciudad", ciudad),
                        new MySqlParameter("@email", email),
                        new MySqlParameter("@telefono", telefono));

                    if (filasAfectadas == 0)
                    {
                        // Revertir: eliminar el usuario si falla la inserción de datos
                        string deleteQuery = "DELETE FROM usuarios WHERE ID_Usuario = @idUsuario";
                        db.ExecuteNonQuery(deleteQuery, new MySqlParameter("@idUsuario", userId));
                        return (false, "Error al guardar los datos del usuario");
                    }

                    return (true, $"Usuario registrado exitosamente. Bienvenido {nombres}!");
                }
            }
            catch (Exception)
            {
                return (false, "Error en el registro. Por favor intente nuevamente.");
            }
        }

        // Método para obtener usuario por nombre de usuario - SOLO tabla usuarios
        public (bool success, string nombreCompleto, string rol, string passwordEncriptado, string mensaje) ObtenerUsuario(string usuario)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    // Buscar SOLO en usuarios - EXCLUIR usuarios_sistema
                    string queryUsuarios = @"SELECT du.nombres, du.apellidos, r.nombre as rol, u.password_hash 
                                           FROM usuarios u 
                                           INNER JOIN roles r ON u.ID_Rol = r.ID_Rol 
                                           LEFT JOIN datos_usuario du ON u.ID_Usuario = du.ID_Usuario 
                                           WHERE u.username = @usuario AND u.activo = TRUE";

                    using (var reader = db.ExecuteReader(queryUsuarios, new MySqlParameter("@usuario", usuario)))
                    {
                        if (reader.Read())
                        {
                            string nombres = reader["nombres"] != DBNull.Value ? reader["nombres"].ToString() : "";
                            string apellidos = reader["apellidos"] != DBNull.Value ? reader["apellidos"].ToString() : "";
                            string rol = reader["rol"].ToString();
                            string passwordEncriptado = reader["password_hash"].ToString();
                            string nombreCompleto = string.IsNullOrEmpty(nombres) && string.IsNullOrEmpty(apellidos) ?
                                                   usuario : $"{nombres} {apellidos}";

                            return (true, nombreCompleto, rol, passwordEncriptado, "Usuario encontrado");
                        }
                    }

                    // Mensaje genérico - no revelar que el usuario no existe
                    return (false, null, null, null, "Credenciales incorrectas");
                }
            }
            catch (Exception)
            {
                // Mensaje genérico para errores
                return (false, null, null, null, "Error en la autenticación");
            }
        }

        // Método alternativo para validar login usando verificación manual - SOLO tabla usuarios
        public (bool success, string mensaje, string nombreCompleto, string rol) ValidarLoginConVerificacion(string usuario, string password)
        {
            try
            {
                // Obtener usuario de la base de datos (SOLO tabla usuarios)
                var usuarioData = ObtenerUsuario(usuario);

                if (!usuarioData.success)
                {
                    // Mensaje genérico - no revelar si el usuario existe o no
                    return (false, "Usuario o contraseña incorrectos", "", "");
                }

                // Verificar la contraseña usando PasswordHelper
                bool passwordValido = PasswordHelper.VerificarPassword(password, usuarioData.passwordEncriptado);

                if (passwordValido)
                {
                    return (true, "Login exitoso", usuarioData.nombreCompleto, usuarioData.rol);
                }
                else
                {
                    // Mensaje genérico - no revelar que la contraseña es incorrecta
                    return (false, "Usuario o contraseña incorrectos", "", "");
                }
            }
            catch (Exception)
            {
                // Mensaje genérico para errores
                return (false, "Error en la autenticación", "", "");
            }
        }
    }
}