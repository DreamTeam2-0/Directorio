// FileUploadManager.cs
using DataBase;
using MySql.Data.MySqlClient;
using Shared.Session;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Utilities
{
    public class FileUploadManager
    {
        public FileUploadResult UploadFile(string filePath, string destinationTable, string description = "")
        {
            var result = new FileUploadResult();

            try
            {
                string fileName = Path.GetFileName(filePath);
                string extension = Path.GetExtension(filePath).ToLower();

                // Validación de seguridad - solo extensiones permitidas
                string[] allowedExtensions = {
                     ".jpg", ".jpeg", ".png", ".gif", ".bmp",
                     ".pdf", ".txt", ".doc", ".docx"
                };

                if (!allowedExtensions.Contains(extension))
                {
                    result.Success = false;
                    result.Message = $"Tipo de archivo no permitido: {extension}\n" +
                                   $"Solo se permiten: imágenes (jpg, png, gif, bmp), PDF, TXT y Word (doc, docx)";
                    return result;
                }

                byte[] fileBytes = File.ReadAllBytes(filePath);

                // Validar tamaño máximo (10MB)
                if (fileBytes.Length > 10 * 1024 * 1024)
                {
                    result.Success = false;
                    result.Message = $"El archivo '{fileName}' excede el tamaño máximo de 10MB";
                    return result;
                }

                // Obtener el MIME type (usando nombre diferente para evitar conflicto)
                string detectedMimeType = MimeMapping.GetMimeMapping(filePath);

                // Validación adicional para archivos peligrosos disfrazados
                // Verificar que la extensión coincida con el MIME type
                string[] dangerousExtensions = { ".exe", ".bat", ".cmd", ".ps1", ".vbs", ".js", ".jar" };

                if (dangerousExtensions.Contains(extension) &&
                    !detectedMimeType.StartsWith("application/octet-stream"))
                {
                    // Archivo potencialmente peligroso disfrazado
                    result.Success = false;
                    result.Message = "Archivo potencialmente peligroso detectado";
                    return result;
                }

                using (BDConector db = new BDConector())
                {
                    db.Open();

                    string mimeType = MimeMapping.GetMimeMapping(filePath);
                    string category = GetFileCategory(mimeType, filePath);

                    string query = destinationTable == "archivos_generales"
                        ? @"INSERT INTO archivos_generales 
                           (nombre_archivo, tipo_archivo, contenido, categoria_archivo, descripcion) 
                           VALUES (@nombre, @tipo, @contenido, @categoria, @descripcion)"
                        : @"INSERT INTO archivos_proveedor 
                           (ID_Usuario, nombre_archivo, tipo_archivo, contenido, categoria_archivo, obligatorio) 
                           VALUES (@idUsuario, @nombre, @tipo, @contenido, @categoria, @obligatorio)";

                    MySqlParameter[] parameters;

                    if (destinationTable == "archivos_generales")
                    {
                        parameters = new MySqlParameter[] {
                            new MySqlParameter("@nombre", fileName),
                            new MySqlParameter("@tipo", mimeType),
                            new MySqlParameter("@contenido", fileBytes),
                            new MySqlParameter("@categoria", category),
                            new MySqlParameter("@descripcion", string.IsNullOrEmpty(description)
                                ? $"Subido por admin: {UserSession.Username} - Fecha: {DateTime.Now:g}"
                                : description)
                        };
                    }
                    else
                    {
                        parameters = new MySqlParameter[] {
                            new MySqlParameter("@idUsuario", UserSession.IdUsuario),
                            new MySqlParameter("@nombre", fileName),
                            new MySqlParameter("@tipo", mimeType),
                            new MySqlParameter("@contenido", fileBytes),
                            new MySqlParameter("@categoria", category),
                            new MySqlParameter("@obligatorio", false)
                        };
                    }

                    int rowsAffected = db.ExecuteNonQuery(query, parameters);

                    result.Success = rowsAffected > 0;
                    result.FileName = fileName;
                    result.FileSize = fileBytes.Length;
                    result.Message = result.Success
                        ? "Archivo subido exitosamente"
                        : "No se pudo subir el archivo";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error: {ex.Message}";
            }

            return result;
        }

        private string GetFileCategory(string mimeType, string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            if (mimeType.StartsWith("image/"))
                return "imagen";
            else if (extension == ".pdf")
                return "pdf";
            else if (extension == ".txt")
                return "texto";
            else if (extension == ".doc" || extension == ".docx")
                return "documento_word";
            else
                return "otro";
        }
    }

    public class FileUploadResult
    {
        public bool Success { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string Message { get; set; }
    }
}