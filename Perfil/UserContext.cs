using System;


namespace Perfil
{
    /// <summary>
    /// Simula el contexto del usuario actual: id, rol y utilidades para
    /// determinar si puede editar un servicio.
    /// En la app real esto provendría del módulo de autenticación / base de datos.
    /// </summary>
    public static class UserContext
    {
        public static int CurrentUserId { get; set; } = 100; // id por defecto
        public static string CurrentUserRole { get; set; } = "Server"; // "User" o "Server" u otros


        // Simulación: mapear qué servicio pertenece a qué usuario (en producción mirar la BD)
        public static int GetOwnerIdForService(int servicioId)
        {
            // Simulación simple: servicioId 1 -> owner 100
            if (servicioId == 1) return 100;
            // Otros servicios, por ejemplo servicioId 2 -> owner 200
            if (servicioId == 2) return 200;
            return -1; // desconocido
        }


        public static bool IsOwnerOfService(int servicioId)
        {
            return CurrentUserId == GetOwnerIdForService(servicioId);
        }


        /// <summary>
        /// Determina si el usuario actual está autorizado para editar un servicio.
        /// Reglas (simples): debe ser el propietario y además tener un rol que permita cambios (por ejemplo "Server").
        /// </summary>
        public static bool IsAuthorizedForService(int servicioId)
        {
            if (!IsOwnerOfService(servicioId)) return false;
            if (string.Equals(CurrentUserRole, "Server", StringComparison.OrdinalIgnoreCase)) return true;
            // Aquí podrías añadir más roles con permisos.
            return false;
        }
    }
}