using System;

namespace Shared.Session
{
    public static class UserSession
    {
        private static int _idUsuario;
        private static string _username;
        private static string _nombreCompleto;
        private static string _rol;
        private static DateTime _fechaLogin;

        public static int IdUsuario
        {
            get => _idUsuario;
            private set => _idUsuario = value;
        }

        public static string Username
        {
            get => _username;
            private set => _username = value;
        }

        public static string NombreCompleto
        {
            get => _nombreCompleto;
            private set => _nombreCompleto = value;
        }

        public static string Rol
        {
            get => _rol;
            private set => _rol = value;
        }

        public static DateTime FechaLogin
        {
            get => _fechaLogin;
            private set => _fechaLogin = value;
        }

        public static void IniciarSesion(int idUsuario, string username, string nombreCompleto, string rol)
        {
            IdUsuario = idUsuario;
            Username = username;
            NombreCompleto = nombreCompleto;
            Rol = rol;
            FechaLogin = DateTime.Now;
        }

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            Username = string.Empty;
            NombreCompleto = string.Empty;
            Rol = string.Empty;
            FechaLogin = DateTime.MinValue;
        }

        public static bool SesionActiva => IdUsuario > 0;
    }
}