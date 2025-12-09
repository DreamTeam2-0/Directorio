using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginDirectorio
{
    public partial class SeleccionRegistroForm : Form
    {
        public enum TipoRegistro
        {
            Ninguno,
            Cliente,
            Proveedor
        }

        public TipoRegistro TipoSeleccionado { get; private set; }

        public SeleccionRegistroForm()
        {
            InitializeComponent();
            TipoSeleccionado = TipoRegistro.Ninguno;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = TipoRegistro.Cliente;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = TipoRegistro.Proveedor;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = TipoRegistro.Ninguno;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SeleccionRegistroForm_Load(object sender, EventArgs e)
        {
            // Enfocar el botón cancelar por defecto
            btnCancelar.Focus();
        }

        private void SeleccionRegistroForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Permitir cerrar con ESC
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar.PerformClick();
            }
        }
    }
}