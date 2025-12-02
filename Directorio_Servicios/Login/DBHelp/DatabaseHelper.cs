using DataBase;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using PassHelp.PasswordHelper;
using System;
using System.Collections.Generic;

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

        // Método principal para registrar proveedor usando tablas temporales
        public (bool success, string mensaje) RegistrarProveedor(
            string username, string passwordEncriptado, string nombres, string apellidos,
            string ciudad, string email, string telefono, string tipoProveedor,
            string nivelEstudios, string anosExperienciaCert, string empresasAnteriores,
            string proyectosDestacados, string referenciasLaborales,
            string anosExperienciaEmp, string tipoExperiencia, string descripcionOtro,
            string categorias, string subEspecialidades, string herramientas, string descripcionServicios,
            List<byte[]> contenidosArchivos, List<string> nombresArchivos, List<string> tiposArchivos,
            List<string> categoriasArchivos, List<bool> obligatorios,
            string identificacionOficial = null, string direccionAproximada = null, string zonasServicio = null)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    // Verificar si el usuario ya existe
                    string checkUsuario = "SELECT COUNT(*) FROM usuarios WHERE username = @username";
                    int existeUsuario = Convert.ToInt32(db.ExecuteScalar(checkUsuario,
                        new MySqlParameter("@username", username)));

                    if (existeUsuario > 0)
                    {
                        return (false, "El nombre de usuario no está disponible");
                    }

                    // Verificar si el email ya existe
                    string checkEmail = "SELECT COUNT(*) FROM datos_usuario WHERE email = @email";
                    int existeEmail = Convert.ToInt32(db.ExecuteScalar(checkEmail,
                        new MySqlParameter("@email", email)));

                    if (existeEmail > 0)
                    {
                        return (false, "El email ya está registrado");
                    }

                    // 1. Insertar en temp_registros
                    string insertTempRegistros = @"INSERT INTO temp_registros 
                                           (tipo_registro, username, password_hash, nombres, apellidos, 
                                            identificacion_oficial, email, telefono, ciudad, direccion_aproximada, zonas_servicio, estado) 
                                           VALUES (@tipo_registro, @username, @password_hash, @nombres, @apellidos, 
                                                   @identificacion_oficial, @email, @telefono, @ciudad, @direccion_aproximada, @zonas_servicio, 'pendiente')";

                    int filas = db.ExecuteNonQuery(insertTempRegistros,
                        new MySqlParameter("@tipo_registro", tipoProveedor),
                        new MySqlParameter("@username", username),
                        new MySqlParameter("@password_hash", passwordEncriptado),
                        new MySqlParameter("@nombres", nombres),
                        new MySqlParameter("@apellidos", apellidos),
                        new MySqlParameter("@identificacion_oficial", identificacionOficial ?? (object)DBNull.Value),
                        new MySqlParameter("@email", email),
                        new MySqlParameter("@telefono", telefono),
                        new MySqlParameter("@ciudad", ciudad),
                        new MySqlParameter("@direccion_aproximada", direccionAproximada ?? (object)DBNull.Value),
                        new MySqlParameter("@zonas_servicio", zonasServicio ?? (object)DBNull.Value)
                    );

                    if (filas == 0)
                    {
                        return (false, "Error al insertar en temp_registros");
                    }

                    long idTemp = Convert.ToInt64(db.ExecuteScalar("SELECT LAST_INSERT_ID()"));

                    // 2. Insertar en temp_certificaciones o temp_experiencia_empirica según el tipo
                    if (tipoProveedor == "certificado")
                    {
                        // Validar campos obligatorios para certificado
                        if (string.IsNullOrEmpty(nivelEstudios) || string.IsNullOrEmpty(anosExperienciaCert))
                        {
                            db.ExecuteNonQuery("DELETE FROM temp_registros WHERE ID_Temp = @ID_Temp", new MySqlParameter("@ID_Temp", idTemp));
                            return (false, "Complete todos los campos obligatorios para profesional certificado");
                        }

                        string insertCert = @"INSERT INTO temp_certificaciones 
                                      (ID_Temp, nivel_estudios, anos_experiencia, empresas_anteriores, proyectos_destacados, referencias_laborales) 
                                      VALUES (@ID_Temp, @nivel_estudios, @anos_experiencia, @empresas_anteriores, @proyectos_destacados, @referencias_laborales)";

                        filas = db.ExecuteNonQuery(insertCert,
                            new MySqlParameter("@ID_Temp", idTemp),
                            new MySqlParameter("@nivel_estudios", nivelEstudios ?? (object)DBNull.Value),
                            new MySqlParameter("@anos_experiencia", anosExperienciaCert ?? (object)DBNull.Value),
                            new MySqlParameter("@empresas_anteriores", empresasAnteriores ?? (object)DBNull.Value),
                            new MySqlParameter("@proyectos_destacados", proyectosDestacados ?? (object)DBNull.Value),
                            new MySqlParameter("@referencias_laborales", referenciasLaborales ?? (object)DBNull.Value)
                        );

                        if (filas == 0)
                        {
                            db.ExecuteNonQuery("DELETE FROM temp_registros WHERE ID_Temp = @ID_Temp", new MySqlParameter("@ID_Temp", idTemp));
                            return (false, "Error al insertar en temp_certificaciones");
                        }
                    }
                    else if (tipoProveedor == "empirico")
                    {
                        // Validar campos obligatorios para empírico
                        if (string.IsNullOrEmpty(anosExperienciaEmp))
                        {
                            db.ExecuteNonQuery("DELETE FROM temp_registros WHERE ID_Temp = @ID_Temp", new MySqlParameter("@ID_Temp", idTemp));
                            return (false, "Complete todos los campos obligatorios para empírico");
                        }

                        string insertEmp = @"INSERT INTO temp_experiencia_empirica 
                                     (ID_Temp, anos_experiencia, tipo_experiencia, descripcion_otro) 
                                     VALUES (@ID_Temp, @anos_experiencia, @tipo_experiencia, @descripcion_otro)";

                        filas = db.ExecuteNonQuery(insertEmp,
                            new MySqlParameter("@ID_Temp", idTemp),
                            new MySqlParameter("@anos_experiencia", anosExperienciaEmp ?? (object)DBNull.Value),
                            new MySqlParameter("@tipo_experiencia", tipoExperiencia ?? (object)DBNull.Value),
                            new MySqlParameter("@descripcion_otro", descripcionOtro ?? (object)DBNull.Value)
                        );

                        if (filas == 0)
                        {
                            db.ExecuteNonQuery("DELETE FROM temp_registros WHERE ID_Temp = @ID_Temp", new MySqlParameter("@ID_Temp", idTemp));
                            return (false, "Error al insertar en temp_experiencia_empirica");
                        }
                    }
                    else
                    {
                        db.ExecuteNonQuery("DELETE FROM temp_registros WHERE ID_Temp = @ID_Temp", new MySqlParameter("@ID_Temp", idTemp));
                        return (false, "Tipo de proveedor no válido");
                    }

                    // 3. Insertar en temp_especialidades
                    string insertEsp = @"INSERT INTO temp_especialidades 
                                 (ID_Temp, categorias, sub_especialidades, herramientas, descripcion_servicios) 
                                 VALUES (@ID_Temp, @categorias, @sub_especialidades, @herramientas, @descripcion_servicios)";

                    filas = db.ExecuteNonQuery(insertEsp,
                        new MySqlParameter("@ID_Temp", idTemp),
                        new MySqlParameter("@categorias", categorias ?? (object)DBNull.Value),
                        new MySqlParameter("@sub_especialidades", subEspecialidades ?? (object)DBNull.Value),
                        new MySqlParameter("@herramientas", herramientas ?? (object)DBNull.Value),
                        new MySqlParameter("@descripcion_servicios", descripcionServicios ?? (object)DBNull.Value)
                    );

                    if (filas == 0)
                    {
                        db.ExecuteNonQuery("DELETE FROM temp_registros WHERE ID_Temp = @ID_Temp", new MySqlParameter("@ID_Temp", idTemp));
                        return (false, "Error al insertar en temp_especialidades");
                    }

                    // 4. Insertar múltiples archivos en temp_archivos
                    for (int i = 0; i < contenidosArchivos.Count; i++)
                    {
                        if (contenidosArchivos[i] != null && contenidosArchivos[i].Length > 0)
                        {
                            string insertArchivo = @"INSERT INTO temp_archivos 
                                             (ID_Temp, nombre_archivo, tipo_archivo, contenido, categoria_archivo, obligatorio) 
                                             VALUES (@ID_Temp, @nombre_archivo, @tipo_archivo, @contenido, @categoria_archivo, @obligatorio)";

                            MySqlParameter paramContenido = new MySqlParameter("@contenido", MySqlDbType.LongBlob);
                            paramContenido.Value = contenidosArchivos[i];

                            filas = db.ExecuteNonQuery(insertArchivo,
                                new MySqlParameter("@ID_Temp", idTemp),
                                new MySqlParameter("@nombre_archivo", nombresArchivos[i] ?? "archivo_desconocido"),
                                new MySqlParameter("@tipo_archivo", tiposArchivos[i] ?? "application/octet-stream"),
                                paramContenido,
                                new MySqlParameter("@categoria_archivo", categoriasArchivos[i] ?? "otro"),
                                new MySqlParameter("@obligatorio", obligatorios[i])
                            );

                            if (filas == 0)
                            {
                                db.ExecuteNonQuery("DELETE FROM temp_registros WHERE ID_Temp = @ID_Temp", new MySqlParameter("@ID_Temp", idTemp));
                                return (false, "Error al insertar archivo en temp_archivos");
                            }
                        }
                    }

                    // 5. Confirmación exitosa - SIN llamar a confirmar_registro
                    // Retornar mensaje de éxito personalizado
                    return (true, "Enviamos tus datos a revisión. En las próximas horas recibirás una notificación vía email con una respuesta a tu solicitud de registro.");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error en el registro: {ex.Message}");
            }
        }

        // Método para procesar registro manualmente si no existe el procedimiento almacenado
        private int ProcesarRegistroManual(BDConector db, long idTemp, string tipoProveedor)
        {
            try
            {
                // 1. Obtener datos de temp_registros
                string queryTemp = "SELECT * FROM temp_registros WHERE ID_Temp = @ID_Temp";
                using (var reader = db.ExecuteReader(queryTemp, new MySqlParameter("@ID_Temp", idTemp)))
                {
                    if (reader.Read())
                    {
                        string username = reader["username"].ToString();
                        string password_hash = reader["password_hash"].ToString();
                        string nombres = reader["nombres"].ToString();
                        string apellidos = reader["apellidos"].ToString();
                        string email = reader["email"].ToString();
                        string telefono = reader["telefono"].ToString();
                        string ciudad = reader["ciudad"].ToString();
                        string identificacion_oficial = reader["identificacion_oficial"] != DBNull.Value ? reader["identificacion_oficial"].ToString() : null;
                        string direccion_aproximada = reader["direccion_aproximada"] != DBNull.Value ? reader["direccion_aproximada"].ToString() : null;
                        string zonas_servicio = reader["zonas_servicio"] != DBNull.Value ? reader["zonas_servicio"].ToString() : null;

                        // Determinar rol según tipo
                        int idRol = tipoProveedor == "certificado" ? 5 : 6; // Ajusta según tus IDs de rol

                        // 2. Insertar en usuarios
                        string insertUsuario = @"INSERT INTO usuarios (username, password_hash, ID_Rol, activo) 
                                               VALUES (@username, @password_hash, @id_rol, TRUE)";
                        int filas = db.ExecuteNonQuery(insertUsuario,
                            new MySqlParameter("@username", username),
                            new MySqlParameter("@password_hash", password_hash),
                            new MySqlParameter("@id_rol", idRol)
                        );

                        if (filas == 0) return 0;

                        long idUsuario = Convert.ToInt64(db.ExecuteScalar("SELECT LAST_INSERT_ID()"));

                        // 3. Insertar en datos_usuario
                        string insertDatos = @"INSERT INTO datos_usuario (ID_Usuario, nombres, apellidos, ciudad, email, telefono, 
                                                    identificacion_oficial, direccion_aproximada, zonas_servicio) 
                                               VALUES (@id_usuario, @nombres, @apellidos, @ciudad, @email, @telefono, 
                                                    @identificacion_oficial, @direccion_aproximada, @zonas_servicio)";

                        filas = db.ExecuteNonQuery(insertDatos,
                            new MySqlParameter("@id_usuario", idUsuario),
                            new MySqlParameter("@nombres", nombres),
                            new MySqlParameter("@apellidos", apellidos),
                            new MySqlParameter("@ciudad", ciudad),
                            new MySqlParameter("@email", email),
                            new MySqlParameter("@telefono", telefono),
                            new MySqlParameter("@identificacion_oficial", identificacion_oficial ?? (object)DBNull.Value),
                            new MySqlParameter("@direccion_aproximada", direccion_aproximada ?? (object)DBNull.Value),
                            new MySqlParameter("@zonas_servicio", zonas_servicio ?? (object)DBNull.Value)
                        );

                        if (filas == 0)
                        {
                            // Revertir si falla
                            db.ExecuteNonQuery("DELETE FROM usuarios WHERE ID_Usuario = @id_usuario",
                                new MySqlParameter("@id_usuario", idUsuario));
                            return 0;
                        }

                        // 4. Procesar datos específicos según tipo
                        if (tipoProveedor == "certificado")
                        {
                            ProcesarCertificadoManual(db, idTemp, idUsuario);
                        }
                        else if (tipoProveedor == "empirico")
                        {
                            ProcesarEmpiricoManual(db, idTemp, idUsuario);
                        }

                        // 5. Procesar especialidades
                        ProcesarEspecialidadesManual(db, idTemp, idUsuario);

                        // 6. Procesar archivos
                        ProcesarArchivosManual(db, idTemp, idUsuario);

                        // 7. Eliminar registros temporales
                        db.ExecuteNonQuery("DELETE FROM temp_registros WHERE ID_Temp = @ID_Temp",
                            new MySqlParameter("@ID_Temp", idTemp));

                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void ProcesarCertificadoManual(BDConector db, long idTemp, long idUsuario)
        {
            string queryCert = "SELECT * FROM temp_certificaciones WHERE ID_Temp = @ID_Temp";
            using (var reader = db.ExecuteReader(queryCert, new MySqlParameter("@ID_Temp", idTemp)))
            {
                if (reader.Read())
                {
                    string nivel_estudios = reader["nivel_estudios"].ToString();
                    string anos_experiencia = reader["anos_experiencia"].ToString();
                    string empresas_anteriores = reader["empresas_anteriores"] != DBNull.Value ? reader["empresas_anteriores"].ToString() : null;
                    string proyectos_destacados = reader["proyectos_destacados"] != DBNull.Value ? reader["proyectos_destacados"].ToString() : null;
                    string referencias_laborales = reader["referencias_laborales"] != DBNull.Value ? reader["referencias_laborales"].ToString() : null;

                    string insertExp = @"INSERT INTO experiencia_usuario (ID_Usuario, tipo_registro, nivel_estudios, 
                                        anos_experiencia, empresas_anteriores, proyectos_destacados, referencias_laborales) 
                                       VALUES (@id_usuario, 'certificado', @nivel_estudios, @anos_experiencia, 
                                        @empresas_anteriores, @proyectos_destacados, @referencias_laborales)";

                    db.ExecuteNonQuery(insertExp,
                        new MySqlParameter("@id_usuario", idUsuario),
                        new MySqlParameter("@nivel_estudios", nivel_estudios),
                        new MySqlParameter("@anos_experiencia", anos_experiencia),
                        new MySqlParameter("@empresas_anteriores", empresas_anteriores ?? (object)DBNull.Value),
                        new MySqlParameter("@proyectos_destacados", proyectos_destacados ?? (object)DBNull.Value),
                        new MySqlParameter("@referencias_laborales", referencias_laborales ?? (object)DBNull.Value)
                    );
                }
            }
        }

        private void ProcesarEmpiricoManual(BDConector db, long idTemp, long idUsuario)
        {
            string queryEmp = "SELECT * FROM temp_experiencia_empirica WHERE ID_Temp = @ID_Temp";
            using (var reader = db.ExecuteReader(queryEmp, new MySqlParameter("@ID_Temp", idTemp)))
            {
                if (reader.Read())
                {
                    string anos_experiencia = reader["anos_experiencia"].ToString();
                    string tipo_experiencia = reader["tipo_experiencia"] != DBNull.Value ? reader["tipo_experiencia"].ToString() : null;
                    string descripcion_otro = reader["descripcion_otro"] != DBNull.Value ? reader["descripcion_otro"].ToString() : null;

                    string insertExp = @"INSERT INTO experiencia_usuario (ID_Usuario, tipo_registro, anos_experiencia, 
                                        tipo_experiencia, descripcion_otro) 
                                       VALUES (@id_usuario, 'empirico', @anos_experiencia, 
                                        @tipo_experiencia, @descripcion_otro)";

                    db.ExecuteNonQuery(insertExp,
                        new MySqlParameter("@id_usuario", idUsuario),
                        new MySqlParameter("@anos_experiencia", anos_experiencia),
                        new MySqlParameter("@tipo_experiencia", tipo_experiencia ?? (object)DBNull.Value),
                        new MySqlParameter("@descripcion_otro", descripcion_otro ?? (object)DBNull.Value)
                    );
                }
            }
        }

        private void ProcesarEspecialidadesManual(BDConector db, long idTemp, long idUsuario)
        {
            string queryEsp = "SELECT * FROM temp_especialidades WHERE ID_Temp = @ID_Temp";
            using (var reader = db.ExecuteReader(queryEsp, new MySqlParameter("@ID_Temp", idTemp)))
            {
                if (reader.Read())
                {
                    string categorias = reader["categorias"].ToString();
                    string sub_especialidades = reader["sub_especialidades"] != DBNull.Value ? reader["sub_especialidades"].ToString() : null;
                    string herramientas = reader["herramientas"] != DBNull.Value ? reader["herramientas"].ToString() : null;
                    string descripcion_servicios = reader["descripcion_servicios"] != DBNull.Value ? reader["descripcion_servicios"].ToString() : null;

                    // Aquí puedes procesar las especialidades según tu lógica
                    // Por ejemplo, crear servicios o relacionar con categorías
                    // Por ahora solo guardamos en una tabla temporal o en datos_usuario
                }
            }
        }

        private void ProcesarArchivosManual(BDConector db, long idTemp, long idUsuario)
        {
            string queryArch = "SELECT * FROM temp_archivos WHERE ID_Temp = @ID_Temp";
            using (var reader = db.ExecuteReader(queryArch, new MySqlParameter("@ID_Temp", idTemp)))
            {
                while (reader.Read())
                {
                    string nombre_archivo = reader["nombre_archivo"].ToString();
                    string tipo_archivo = reader["tipo_archivo"].ToString();
                    byte[] contenido = (byte[])reader["contenido"];
                    string categoria_archivo = reader["categoria_archivo"].ToString();
                    bool obligatorio = Convert.ToBoolean(reader["obligatorio"]);

                    string insertArchivo = @"INSERT INTO archivos_proveedor (ID_Usuario, nombre_archivo, tipo_archivo, 
                                           contenido, categoria_archivo, obligatorio) 
                                           VALUES (@id_usuario, @nombre_archivo, @tipo_archivo, 
                                           @contenido, @categoria_archivo, @obligatorio)";

                    MySqlParameter paramContenido = new MySqlParameter("@contenido", MySqlDbType.LongBlob);
                    paramContenido.Value = contenido;

                    db.ExecuteNonQuery(insertArchivo,
                        new MySqlParameter("@id_usuario", idUsuario),
                        new MySqlParameter("@nombre_archivo", nombre_archivo),
                        new MySqlParameter("@tipo_archivo", tipo_archivo),
                        paramContenido,
                        new MySqlParameter("@categoria_archivo", categoria_archivo),
                        new MySqlParameter("@obligatorio", obligatorio)
                    );
                }
            }
        }

        // Método para obtener categorías disponibles
        public List<(int id, string nombre)> ObtenerCategorias()
        {
            var categorias = new List<(int, string)>();

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = "SELECT ID_Categoria, nombre FROM categorias WHERE activa = TRUE ORDER BY nombre";

                    using (var reader = db.ExecuteReader(query))
                    {
                        while (reader.Read())
                        {
                            categorias.Add((reader.GetInt32("ID_Categoria"), reader.GetString("nombre")));
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Log error
            }

            return categorias;
        }

        // Método para obtener denominaciones por categoría
        public List<(int id, string nombre)> ObtenerDenominaciones(int idCategoria)
        {
            var denominaciones = new List<(int, string)>();

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = "SELECT ID_Denominacion, nombre FROM denominaciones WHERE ID_Categoria = @idCategoria ORDER BY nombre";

                    using (var reader = db.ExecuteReader(query, new MySqlParameter("@idCategoria", idCategoria)))
                    {
                        while (reader.Read())
                        {
                            denominaciones.Add((reader.GetInt32("ID_Denominacion"), reader.GetString("nombre")));
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Log error
            }

            return denominaciones;
        }

        // Método para verificar si un username está disponible
        public (bool disponible, string mensaje) VerificarDisponibilidadUsername(string username)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    // Verificar en usuarios
                    string queryUsuarios = "SELECT COUNT(*) FROM usuarios WHERE username = @username";
                    int countUsuarios = Convert.ToInt32(db.ExecuteScalar(queryUsuarios,
                        new MySqlParameter("@username", username)));

                    if (countUsuarios > 0)
                    {
                        return (false, "El nombre de usuario no está disponible");
                    }

                    // Verificar en temp_registros
                    string queryTemp = "SELECT COUNT(*) FROM temp_registros WHERE username = @username AND estado = 'pendiente'";
                    int countTemp = Convert.ToInt32(db.ExecuteScalar(queryTemp,
                        new MySqlParameter("@username", username)));

                    if (countTemp > 0)
                    {
                        return (false, "El nombre de usuario está siendo procesado en otro registro");
                    }

                    return (true, "Nombre de usuario disponible");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error al verificar disponibilidad: {ex.Message}");
            }
        }

        // Método para verificar si un email está disponible
        public (bool disponible, string mensaje) VerificarDisponibilidadEmail(string email)
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    // Verificar en datos_usuario
                    string queryDatos = "SELECT COUNT(*) FROM datos_usuario WHERE email = @email";
                    int countDatos = Convert.ToInt32(db.ExecuteScalar(queryDatos,
                        new MySqlParameter("@email", email)));

                    if (countDatos > 0)
                    {
                        return (false, "El email ya está registrado");
                    }

                    // Verificar en temp_registros
                    string queryTemp = "SELECT COUNT(*) FROM temp_registros WHERE email = @email AND estado = 'pendiente'";
                    int countTemp = Convert.ToInt32(db.ExecuteScalar(queryTemp,
                        new MySqlParameter("@email", email)));

                    if (countTemp > 0)
                    {
                        return (false, "El email está siendo procesado en otro registro");
                    }

                    return (true, "Email disponible");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error al verificar disponibilidad: {ex.Message}");
            }
        }
    }
}