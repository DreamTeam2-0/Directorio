using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LoginDirectorio.RegistroFases;

namespace LoginDirectorio
{
    public partial class RegistroCertificadoForm : Form
    {
        private FaseDatosBasicos faseDatos;
        private FaseCertificado faseCertificado;
        private FaseFinal faseFinal;
        private Panel panelActual;
        private List<byte[]> archivosBytes = new List<byte[]>();
        private List<string> nombresArchivos = new List<string>();
        private List<string> tiposArchivos = new List<string>();
        private List<string> categoriasArchivos = new List<string>();
        private List<bool> obligatorios = new List<bool>();

        public RegistroCertificadoForm()
        {
            InitializeComponent();
            InicializarFases();
            MostrarFaseDatosBasicos();
        }

        private void InicializarFases()
        {
            faseDatos = new FaseDatosBasicos();
            faseCertificado = new FaseCertificado();
            faseFinal = new FaseFinal();

            // Configurar eventos
            faseDatos.SiguienteClick += FaseDatos_SiguienteClick;
            faseDatos.VolverClick += FaseDatos_VolverClick;

            faseCertificado.SiguienteClick += FaseCertificado_SiguienteClick;
            faseCertificado.VolverClick += FaseCertificado_VolverClick;
            faseCertificado.SubirArchivo += SubirArchivo;

            faseFinal.RegistrarClick += FaseFinal_RegistrarClick;
            faseFinal.VolverClick += FaseFinal_VolverClick;
        }

        private void MostrarFase(Panel nuevaFase)
        {
            if (panelActual != null)
                Controls.Remove(panelActual);

            panelActual = nuevaFase;
            panelActual.Dock = DockStyle.Fill;
            Controls.Add(panelActual);
        }

        private void MostrarFaseDatosBasicos()
        {
            MostrarFase(faseDatos);
        }

        private void FaseDatos_SiguienteClick(object sender, EventArgs e)
        {
            if (Validaciones.ValidarDatosBasicos(faseDatos))
            {
                MostrarFase(faseCertificado);
            }
        }

        private void FaseDatos_VolverClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FaseCertificado_SiguienteClick(object sender, EventArgs e)
        {
            if (Validaciones.ValidarCertificado(faseCertificado, obligatorios, categoriasArchivos))
            {
                MostrarFase(faseFinal);
            }
        }

        private void FaseCertificado_VolverClick(object sender, EventArgs e)
        {
            MostrarFaseDatosBasicos();
        }

        private void SubirArchivo(object sender, SubirArchivoEventArgs e)
        {
            string categoria = e.Categoria;
            bool esObligatorio = e.Obligatorio;

            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Archivos permitidos|*.pdf;*.jpg;*.png",
                Multiselect = true
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        byte[] bytes = File.ReadAllBytes(file);
                        archivosBytes.Add(bytes);
                        nombresArchivos.Add(Path.GetFileName(file));
                        tiposArchivos.Add(Path.GetExtension(file).ToLower() == ".pdf" ? "application/pdf" : "image/" + Path.GetExtension(file).Substring(1));
                        categoriasArchivos.Add(categoria);
                        obligatorios.Add(esObligatorio);
                    }
                    MessageBox.Show($"Archivos subidos: {ofd.FileNames.Length}", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FaseFinal_RegistrarClick(object sender, EventArgs e)
        {
            if (Validaciones.ValidarFinal(faseFinal))
            {
                var resultado = DatabaseHelperExtensions.RegistrarProveedorCertificado(
                    faseDatos, faseCertificado, faseFinal,
                    archivosBytes, nombresArchivos, tiposArchivos,
                    categoriasArchivos, obligatorios
                );

                if (resultado.success)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(resultado.mensaje, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FaseFinal_VolverClick(object sender, EventArgs e)
        {
            MostrarFase(faseCertificado);
        }
    }
}