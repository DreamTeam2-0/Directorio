using System;
using System.Windows.Forms;

namespace LoginDirectorio
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginDirectory());
        }
    }
}