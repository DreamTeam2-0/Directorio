using System.Drawing;
using System.Windows.Forms;

namespace ProveedorHome.Logica
{
    public class FranjaManager
    {
        private Form _form;
        private Label _lblBienvenida;

        public FranjaManager(Form form, Label lblBienvenida)
        {
            _form = form;
            _lblBienvenida = lblBienvenida;
        }

        public void CrearFranjaVerde()
        {
            // Crear un panel verde que ocupe todo el ancho de la parte superior
            Panel panelFranja = new Panel
            {
                Name = "panelFranjaVerde",
                BackColor = Color.FromArgb(76, 175, 80), // Verde igual al panel lateral
                Location = new Point(0, 29), // Empieza debajo del menú
                Size = new Size(_form.ClientSize.Width, 100), // Altura de 100px
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Agregar al formulario
            _form.Controls.Add(panelFranja);
            panelFranja.SendToBack();

            // Configurar el label de bienvenida
            _lblBienvenida.BackColor = Color.FromArgb(76, 175, 80);
            _lblBienvenida.ForeColor = Color.White;
            _lblBienvenida.BringToFront();
        }
    }
}