// AuthHelper.cs
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Perfil
{
    public static class AuthHelper
    {
        // Cadena de conexión centralizada
        public static string ConnectionString =
            "Data Source=TU_SERVIDOR;Initial Catalog=TU_BASE_DE_DATOS;Integrated Security=True";

        // Usuario actual simulado (en un sistema real esto vendría del login)
        public static int CurrentUserId = 1; // ID del usuario logueado
        public static string CurrentUserRole = "servidor"; // "usuario" o "servidor"

        /// <summary>
        /// Verifica si el usuario actual puede editar el servicio
        /// </summary>
        public static bool CanEditService(int servicioUserId)
        {
            return CurrentUserRole == "servidor" && CurrentUserId == servicioUserId;
        }

        /// <summary>
        /// Verifica si el usuario actual puede editar su perfil
        /// </summary>
        public static bool CanEditProfile(int profileUserId)
        {
            return CurrentUserId == profileUserId;
        }
    }
}