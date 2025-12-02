using System;
using System.Windows.Forms;
using LoginDirectorio.RegistroFases;

namespace LoginDirectorio
{
    public partial class RegistroProveedorForm : Form
    {
        public RegistroProveedorForm()
        {
            InitializeComponent();
        }

        private void btnCertificado_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmCertificado = new RegistroCertificadoForm();
            frmCertificado.FormClosed += (s, args) => this.Close();
            frmCertificado.Show();
        }

        private void btnEmpirico_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmEmpirico = new RegistroEmpiricoForm();
            frmEmpirico.FormClosed += (s, args) => this.Close();
            frmEmpirico.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}