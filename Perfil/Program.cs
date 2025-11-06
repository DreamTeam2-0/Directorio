using System;
using System.Windows.Forms;


namespace Perfil
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Simulamos un usuario autenticado.
            // Cambia estos valores para probar diferentes escenarios:
            UserContext.CurrentUserId = 100; // prueba con 100 (owner de servicio 1)
            UserContext.CurrentUserRole = "Server"; // prueba con "User" o "Server"


            // Iniciar la aplicación con Form1 (mostrar servicio con ID = 1)
            Application.Run(new Form1(1));
        }
    }
}