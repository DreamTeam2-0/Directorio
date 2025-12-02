using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homepage.UI
{
    public static class CrearBoton
    {
        public static Button CrearBotonCategoria(string texto, Color color)
        {
            return new Button
            {
                Text = texto,
                Size = new Size(100, 100),
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(6), // Reducido para que quepan 7 en línea
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        public static void MostrarError(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public static void MostrarInfo(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}