// FileDownloadManager.cs
using System;
using System.IO;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace Utilities
{
    public class FileDownloadManager
    {
        public FileDownloadResult DownloadFile(int fileId, string sourceTable, string destinationPath)
        {
            var result = new FileDownloadResult();

            try
            {
                byte[] fileBytes = GetFileBytes(fileId, sourceTable);

                if (fileBytes == null || fileBytes.Length == 0)
                {
                    result.Success = false;
                    result.Message = "El archivo está vacío o no existe";
                    return result;
                }

                File.WriteAllBytes(destinationPath, fileBytes);

                result.Success = true;
                result.FilePath = destinationPath;
                result.FileSize = fileBytes.Length;
                result.Message = "Archivo descargado exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error: {ex.Message}";
            }

            return result;
        }

        public byte[] GetFileBytes(int fileId, string sourceTable)
        {
            using (BDConector db = new BDConector())
            {
                db.Open();

                string query = sourceTable == "archivos_proveedor"
                    ? "SELECT contenido FROM archivos_proveedor WHERE ID_Archivo = @id"
                    : "SELECT contenido FROM archivos_generales WHERE ID_Archivo = @id";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@id", fileId)
                };

                object result = db.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    return (byte[])result;
                }
            }

            return null;
        }

        public string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double len = bytes;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }
    }

    public class FileDownloadResult
    {
        public bool Success { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string Message { get; set; }
    }
}