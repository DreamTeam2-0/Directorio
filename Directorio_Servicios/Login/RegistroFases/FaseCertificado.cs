using System;
using System.Runtime;
using System.Windows.Forms;

namespace LoginDirectorio.RegistroFases
{
    // Clase para los argumentos del evento SubirArchivo
    public class SubirArchivoEventArgs : EventArgs
    {
        public string Categoria { get; }
        public bool Obligatorio { get; }

        public SubirArchivoEventArgs(string categoria, bool obligatorio)
        {
            Categoria = categoria;
            Obligatorio = obligatorio;
        }
    }

    public partial class FaseCertificado : Panel
    {
        public event EventHandler SiguienteClick;
        public event EventHandler VolverClick;
        public event EventHandler<SubirArchivoEventArgs> SubirArchivo; // Corregido

        // Propiedades (mantener igual)
        public string NivelEstudios => cmbNivelEstudios.Text;
        public string AnosExperiencia => txtAnosExperienciaCert.Text.Trim();
        public string EmpresasAnteriores => txtEmpresasAnteriores.Text.Trim();
        public string ProyectosDestacados => txtProyectosDestacados.Text.Trim();
        public string ReferenciasLaborales => txtReferenciasLaborales.Text.Trim();

        // Controles (mantener igual)
        private ComboBox cmbNivelEstudios;
        private TextBox txtAnosExperienciaCert;
        private TextBox txtEmpresasAnteriores;
        private TextBox txtProyectosDestacados;
        private TextBox txtReferenciasLaborales;
        private Button btnUploadCertificados;
        private Button btnUploadTitulos;
        private Button btnUploadLicencias;
        private Button btnUploadInternacionales;
        private Button btnSiguiente;
        private Button btnVolver;

        public FaseCertificado()
        {
            InitializeComponent();
        }
    }
}