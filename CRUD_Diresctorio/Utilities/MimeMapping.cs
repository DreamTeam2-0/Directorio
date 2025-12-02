// MimeMapping.cs
using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class MimeMapping
    {
        private static Dictionary<string, string> mimeTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            // Imágenes
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".png", "image/png" },
            { ".gif", "image/gif" },
            { ".bmp", "image/bmp" },
            { ".tiff", "image/tiff" },
            { ".tif", "image/tiff" },
            { ".ico", "image/x-icon" },
            { ".svg", "image/svg+xml" },
            { ".webp", "image/webp" },
            
            // Documentos
            { ".pdf", "application/pdf" },
            { ".doc", "application/msword" },
            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { ".xls", "application/vnd.ms-excel" },
            { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            { ".ppt", "application/vnd.ms-powerpoint" },
            { ".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
            { ".odt", "application/vnd.oasis.opendocument.text" },
            { ".ods", "application/vnd.oasis.opendocument.spreadsheet" },
            
            // Texto
            { ".txt", "text/plain" },
            { ".html", "text/html" },
            { ".htm", "text/html" },
            { ".css", "text/css" },
            { ".js", "application/javascript" },
            { ".json", "application/json" },
            { ".xml", "application/xml" },
            { ".csv", "text/csv" },
            { ".rtf", "application/rtf" },
            
            // Archivos comprimidos
            { ".zip", "application/zip" },
            { ".rar", "application/x-rar-compressed" },
            { ".7z", "application/x-7z-compressed" },
            { ".tar", "application/x-tar" },
            { ".gz", "application/gzip" },
            
            // Audio
            { ".mp3", "audio/mpeg" },
            { ".wav", "audio/wav" },
            { ".ogg", "audio/ogg" },
            { ".flac", "audio/flac" },
            
            // Video
            { ".mp4", "video/mp4" },
            { ".avi", "video/x-msvideo" },
            { ".mov", "video/quicktime" },
            { ".wmv", "video/x-ms-wmv" },
            { ".flv", "video/x-flv" },
            { ".webm", "video/webm" },
            
            // Base de datos
            { ".sql", "application/sql" },
            { ".db", "application/x-sqlite3" },
            { ".mdb", "application/x-msaccess" },
            
            // Otros
            { ".exe", "application/x-msdownload" },
            { ".dll", "application/x-msdownload" }
        };

        public static string GetMimeMapping(string fileName)
        {
            string extension = System.IO.Path.GetExtension(fileName);

            if (string.IsNullOrEmpty(extension))
                return "application/octet-stream";

            if (mimeTypes.TryGetValue(extension, out string mimeType))
                return mimeType;

            return "application/octet-stream";
        }

        public static string GetExtensionFromMimeType(string mimeType)
        {
            foreach (var kvp in mimeTypes)
            {
                if (kvp.Value.Equals(mimeType, StringComparison.OrdinalIgnoreCase))
                    return kvp.Key;
            }

            return ".bin";
        }

        public static bool IsImage(string mimeType)
        {
            return mimeType.StartsWith("image/", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsDocument(string mimeType)
        {
            return mimeType.Contains("pdf") ||
                   mimeType.Contains("word") ||
                   mimeType.Contains("excel") ||
                   mimeType.Contains("powerpoint") ||
                   mimeType.Contains("officedocument") ||
                   mimeType.Contains("opendocument");
        }

        public static bool IsText(string mimeType)
        {
            return mimeType.StartsWith("text/", StringComparison.OrdinalIgnoreCase) ||
                   mimeType.Contains("json") ||
                   mimeType.Contains("xml");
        }
    }
}