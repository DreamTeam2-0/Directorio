using System.Drawing;
using System.Windows.Forms;

namespace Homepage.Logica
{
    public class FranjaManager
    {
        private Form _form;
        private Label _lblBienvenida;
        private TextBox _txtBuscar;
        private Button _btnBuscar;

        public FranjaManager(Form form, Label lblBienvenida, TextBox txtBuscar, Button btnBuscar)
        {
            _form = form;
            _lblBienvenida = lblBienvenida;
            _txtBuscar = txtBuscar;
            _btnBuscar = btnBuscar;
        }

        public void CrearFranjaVerde()
        {
            // 1. Crear panel verde
            Panel panelFranja = new Panel
            {
                Name = "panelFranjaVerde",
                BackColor = Color.FromArgb(76, 175, 80),
                Location = new Point(0, 29),
                Size = new Size(_form.ClientSize.Width, 100),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // 2. Agregar al formulario
            _form.Controls.Add(panelFranja);

            // 3. Enviar al fondo
            panelFranja.SendToBack();

            // 4. Configurar label
            _lblBienvenida.BackColor = Color.FromArgb(76, 175, 80);
            _lblBienvenida.ForeColor = Color.White;

            // 5. Traer controles al frente
            _lblBienvenida.BringToFront();
            _txtBuscar.BringToFront();
            _btnBuscar.BringToFront();
        }
    }
}