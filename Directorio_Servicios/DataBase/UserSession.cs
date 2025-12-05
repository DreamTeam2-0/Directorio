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

        // NUEVAS PROPIEDADES para manejo de cambio de rol
        private static string _rolTemporal;
        private static string _rolAnterior;

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
            set => _rol = value; // Cambiado a set público para permitir cambio temporal
        }

        public static DateTime FechaLogin
        {
            get => _fechaLogin;
            private set => _fechaLogin = value;
        }

        // NUEVA PROPIEDAD: Rol temporal para cambio entre interfaces
        public static string RolTemporal
        {
            get => _rolTemporal;
            set => _rolTemporal = value;
        }

        // NUEVA PROPIEDAD: Guarda el rol original cuando se cambia temporalmente
        public static string RolAnterior
        {
            get => _rolAnterior;
            set => _rolAnterior = value;
        }

        public static void IniciarSesion(int idUsuario, string username, string nombreCompleto, string rol)
        {
            IdUsuario = idUsuario;
            Username = username;
            NombreCompleto = nombreCompleto;
            Rol = rol;
            FechaLogin = DateTime.Now;

            // Inicializar propiedades temporales
            RolTemporal = null;
            RolAnterior = null;
        }

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            Username = string.Empty;
            NombreCompleto = string.Empty;
            Rol = string.Empty;
            FechaLogin = DateTime.MinValue;

            // Limpiar propiedades temporales
            RolTemporal = null;
            RolAnterior = null;
        }

        public static bool SesionActiva => IdUsuario > 0;

        // NUEVO MÉTODO: Cambiar a vista temporal de cliente
        public static void CambiarAVistaCliente()
        {
            if (Rol.ToLower() == "empleado")
            {
                RolAnterior = Rol;
                RolTemporal = "cliente_vista";
                // Nota: No cambiamos Rol aquí, mantenemos "empleado" como rol real
            }
        }

        // NUEVO MÉTODO: Restaurar rol original
        public static void RestaurarRolOriginal()
        {
            if (!string.IsNullOrEmpty(RolAnterior))
            {
                Rol = RolAnterior;
                RolTemporal = null;
                RolAnterior = null;
            }
        }

        // NUEVO MÉTODO: Verificar si puede acceder a vista de proveedor
        public static bool PuedeAccederAProveedor()
        {
            // Puede acceder si:
            // 1. Es empleado (rol real)
            // 2. O viene de vista temporal de cliente (RolTemporal = "cliente_vista")
            return Rol.ToLower() == "empleado" ||
                   RolTemporal == "cliente_vista";
        }

        // NUEVO MÉTODO: Verificar si está en vista temporal de cliente
        public static bool EnVistaTemporalCliente()
        {
            return RolTemporal == "cliente_vista";
        }

        public static void VerificarYReiniciarSiEsNecesario()
        {
            // Si la sesión parece estar activa pero los datos están corruptos
            if (SesionActiva && (IdUsuario == 0 || string.IsNullOrEmpty(Username)))
            {
                // Reiniciar sesión
                CerrarSesion();
            }
        }

    }
}