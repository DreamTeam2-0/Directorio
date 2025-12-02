// FileHelper.cs
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Utilities
{
    public static class FileHelper
    {
        public static string GetMimeType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();

            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".bmp":
                    return "image/bmp";
                case ".pdf":
                    return "application/pdf";
                case ".doc":
                    return "application/msword";
                case ".docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".xls":
                    return "application/vnd.ms-excel";
                case ".xlsx":
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case ".txt":
                    return "text/plain";
                case ".html":
                case ".htm":
                    return "text/html";
                case ".csv":
                    return "text/csv";
                case ".zip":
                    return "application/zip";
                case ".rar":
                    return "application/x-rar-compressed";
                case ".sql":
                    return "application/sql";
                default:
                    return "application/octet-stream";
            }
        }

        public static string GetFileCategory(string mimeType)
        {
            if (mimeType.StartsWith("image/"))
                return "imagen";
            else if (mimeType.Contains("pdf"))
                return "documento";
            else if (mimeType.Contains("word") || mimeType.Contains("excel") || mimeType.Contains("powerpoint"))
                return "office";
            else if (mimeType.StartsWith("text/"))
                return "texto";
            else if (mimeType.Contains("zip") || mimeType.Contains("rar"))
                return "comprimido";
            else
                return "otro";
        }

        public static string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            double len = bytes;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        public static bool IsImageFile(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            return extension == ".jpg" || extension == ".jpeg" ||
                   extension == ".png" || extension == ".gif" ||
                   extension == ".bmp";
        }

        public static bool IsValidFileSize(long fileSize, long maxSizeMB = 10)
        {
            long maxSizeBytes = maxSizeMB * 1024 * 1024;
            return fileSize <= maxSizeBytes;
        }

        public static string GetSafeFileName(string fileName)
        {
            // Reemplazar caracteres no válidos
            string invalidChars = new string(Path.GetInvalidFileNameChars());
            string safeName = fileName;

            foreach (char c in invalidChars)
            {
                safeName = safeName.Replace(c, '_');
            }

            // Limitar longitud
            if (safeName.Length > 100)
            {
                string extension = Path.GetExtension(safeName);
                string nameWithoutExtension = Path.GetFileNameWithoutExtension(safeName);
                nameWithoutExtension = nameWithoutExtension.Substring(0, 100 - extension.Length - 10) + "_" + Guid.NewGuid().ToString().Substring(0, 8);
                safeName = nameWithoutExtension + extension;
            }

            return safeName;
        }

        public static byte[] ImageToByteArray(Image image)
        {
            if (image == null) return new byte[0];

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}