using System;
using System.Windows.Forms;

namespace LoginDirectorio.RegistroFases
{
    public partial class FaseEmpirico : Panel
    {
        public event EventHandler SiguienteClick;
        public event EventHandler VolverClick;
        public event EventHandler<string> SubirArchivo; // (sender, categoria)

        // Propiedades EXISTENTES
        public string AnosExperiencia => cmbAnosExperienciaEmp.Text;
        public string DescripcionOtro => txtDescripcionOtro.Text.Trim();

        // NUEVA PROPIEDAD para obtener el valor formateado para BD
        public string AnosExperienciaBD => GetAnosExperienciaBD();

        // MÉTODO NUEVO para convertir a formato BD
        public string GetAnosExperienciaBD()
        {
            string valorUI = cmbAnosExperienciaEmp.Text;

            if (string.IsNullOrEmpty(valorUI))
                return "1_3"; // Valor por defecto

            valorUI = valorUI.ToLower().Trim();

            switch (valorUI)
            {
                case "menos de 1 año":
                case "menos de 1":
                case "menos_1":
                    return "menos_1";
                case "1-3 años":
                case "1-3":
                case "1_3":
                    return "1_3";
                case "3-5 años":
                case "3-5":
                case "3_5":
                    return "3_5";
                case "más de 5 años":
                case "más de 5":
                case "mas de 5":
                case "mas_5":
                    return "mas_5";
                default:
                    // Si el ComboBox tiene otros valores, agregar casos aquí
                    return "1_3"; // Valor por defecto
            }
        }

        // Métodos existentes
        public bool TieneTipoExperienciaSeleccionado()
        {
            return chkIndependiente.Checked || chkEmpresa.Checked ||
                   chkFamiliar.Checked || chkOtro.Checked;
        }

        public string GetTipoExperienciaString()
        {
            string tipos = "";
            if (chkIndependiente.Checked) tipos += "independiente,";
            if (chkEmpresa.Checked) tipos += "empresa,";
            if (chkFamiliar.Checked) tipos += "familiar,";
            if (chkOtro.Checked) tipos += "otro,";

            if (tipos.EndsWith(","))
                tipos = tipos.Substring(0, tipos.Length - 1);

            return tipos;
        }

        // Controles (ya los tienes)
        private ComboBox cmbAnosExperienciaEmp;
        private CheckBox chkIndependiente;
        private CheckBox chkEmpresa;
        private CheckBox chkFamiliar;
        private CheckBox chkOtro;
        private TextBox txtDescripcionOtro;
        private Button btnUploadFotosTrabajos;
        private Button btnUploadTestimonios;
        private Button btnUploadReferencias;
        private Button btnSiguiente;
        private Button btnVolver;

        public FaseEmpirico()
        {
            InitializeComponent();
        }
    }
}