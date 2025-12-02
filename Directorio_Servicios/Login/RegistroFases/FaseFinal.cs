using System;
using System.Windows.Forms;

namespace LoginDirectorio.RegistroFases
{
    public partial class FaseFinal : Panel
    {
        public event EventHandler RegistrarClick;
        public event EventHandler VolverClick;

        // Propiedades
        public string Categorias => txtCategorias.Text.Trim();
        public string SubEspecialidades => txtSubEspecialidades.Text.Trim();
        public string Herramientas => txtHerramientas.Text.Trim();
        public string DescripcionServicios => txtDescripcionServicios.Text.Trim();

        // Controles
        private TextBox txtCategorias;
        private TextBox txtSubEspecialidades;
        private TextBox txtHerramientas;
        private TextBox txtDescripcionServicios;
        private Button btnRegistrar;
        private Button btnVolver;

        public FaseFinal()
        {
            InitializeComponent();
        }
    }
}