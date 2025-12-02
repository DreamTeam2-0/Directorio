// Program.cs
using CRUD_Directorio.Login;
using System;
using System.Windows.Forms; 

namespace CRUD_Directorio
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configurar manejo de excepciones no controladas
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Iniciar con el formulario de login
            Application.Run(new LoginAdminForm());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Error no controlado: {e.Exception.Message}\n\n{e.Exception.StackTrace}",
                "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show($"Error crítico: {ex?.Message}\n\n{ex?.StackTrace}",
                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}