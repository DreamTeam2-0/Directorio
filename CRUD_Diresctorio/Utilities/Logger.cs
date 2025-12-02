// Logger.cs
using System;
using System.IO;

namespace Utilities
{
    public static class Logger
    {
        private static string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        static Logger()
        {
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
        }

        public static void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public static void LogError(string message)
        {
            Log("ERROR", message);
        }

        public static void LogWarning(string message)
        {
            Log("WARNING", message);
        }

        private static void Log(string level, string message)
        {
            try
            {
                string logFile = Path.Combine(logPath, $"admin_system_{DateTime.Now:yyyy-MM-dd}.log");
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] - {message}\n";

                File.AppendAllText(logFile, logEntry);
            }
            catch
            {
                // Silently fail if logging fails
            }
        }
    }
}