using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LoginDirectorio.RegistroFases;

namespace LoginDirectorio
{
    public partial class RegistroEmpiricoForm : Form
    {
        private FaseDatosBasicos faseDatos;
        private FaseEmpirico faseEmpirico;
        private FaseFinal faseFinal;
        private Panel panelActual;
        private List<byte[]> archivosBytes = new List<byte[]>();
        private List<string> nombresArchivos = new List<string>();
        private List<string> tiposArchivos = new List<string>();
        private List<string> categoriasArchivos = new List<string>();

        public RegistroEmpiricoForm()
        {
            InitializeComponent();
            InicializarFases();
            MostrarFaseDatosBasicos();
        }

        private void InicializarFases()
        {
            faseDatos = new FaseDatosBasicos();
            faseEmpirico = new FaseEmpirico();
            faseFinal = new FaseFinal();

            // Configurar eventos
            faseDatos.SiguienteClick += FaseDatos_SiguienteClick;
            faseDatos.VolverClick += FaseDatos_VolverClick;

            faseEmpirico.SiguienteClick += FaseEmpirico_SiguienteClick;
            faseEmpirico.VolverClick += FaseEmpirico_VolverClick;
            faseEmpirico.SubirArchivo += SubirArchivo;

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
                MostrarFase(faseEmpirico);
            }
        }

        private void FaseDatos_VolverClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FaseEmpirico_SiguienteClick(object sender, EventArgs e)
        {
            if (Validaciones.ValidarEmpirico(faseEmpirico))
            {
                MostrarFase(faseFinal);
            }
        }

        private void FaseEmpirico_VolverClick(object sender, EventArgs e)
        {
            MostrarFaseDatosBasicos();
        }

        private void SubirArchivo(object sender, string categoria)
        {
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
                var resultado = DatabaseHelperExtensions.RegistrarProveedorEmpirico(
                    faseDatos, faseEmpirico, faseFinal,
                    archivosBytes, nombresArchivos, tiposArchivos, categoriasArchivos
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
            MostrarFase(faseEmpirico);
        }
    }
}