using LoginDirectorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Directorio_Servicios
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                LoginDirectorio.LoginDirectory login = new LoginDirectorio.LoginDirectory();
                Application.Run(login);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Asegurar que todo se cierra
                Application.Exit();
            }
        }
    }
}
