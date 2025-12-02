using System;
using System.Windows.Forms;

namespace LoginDirectorio.RegistroFases
{
    public partial class FaseDatosBasicos : Panel
    {
        public event EventHandler SiguienteClick;
        public event EventHandler VolverClick;

        private TextBox txtUsername, txtPasswordReg, txtConfirmPassword;
        private TextBox txtNombres, txtApellidos, txtCiudad, txtEmail, txtTelefono;
        private TextBox txtIdentificacionOficial, txtDireccionAproximada, txtZonasServicio;
        private Button btnSiguiente, btnVolver;
        private Label lblUsername, lblPassword, lblConfirmPassword;
        private Label lblNombres, lblApellidos, lblCiudad, lblEmail, lblTelefono;
        private Label lblIdentificacionOficial, lblDireccionAproximada, lblZonasServicio;

        public FaseDatosBasicos()
        {
            InitializeComponent();
        }

        // Propiedades para acceder a los datos
        public string Username => txtUsername.Text.Trim();
        public string Password => txtPasswordReg.Text;
        public string ConfirmPassword => txtConfirmPassword.Text;
        public string Nombres => txtNombres.Text.Trim();
        public string Apellidos => txtApellidos.Text.Trim();
        public string Ciudad => txtCiudad.Text.Trim();
        public string Email => txtEmail.Text.Trim();
        public string Telefono => txtTelefono.Text.Trim();
        public string IdentificacionOficial => txtIdentificacionOficial.Text.Trim();
        public string DireccionAproximada => txtDireccionAproximada.Text.Trim();
        public string ZonasServicio => txtZonasServicio.Text.Trim();
    }
}