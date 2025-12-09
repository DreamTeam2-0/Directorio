using LoginDirectorio.RegistroFases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            // LISTA BLANCA ESTRICTA
            var tiposPermitidos = new Dictionary<string, string>
            {
                { ".pdf", "application/pdf" },
                { ".jpg", "image/jpeg" },
                { ".jpeg", "image/jpeg" },
                { ".png", "image/png" },
                { ".doc", "application/msword" },
                { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { ".txt", "text/plain" }
            };

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Crear filtro solo con extensiones permitidas
                string filtro = $"Archivos permitidos|{string.Join(";", tiposPermitidos.Keys.Select(k => $"*{k}"))}";
                ofd.Filter = filtro;
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<string> errores = new List<string>();

                    foreach (string file in ofd.FileNames)
                    {
                        string extension = Path.GetExtension(file).ToLower();

                        // VALIDACIÓN PRINCIPAL: ¿Está en la lista blanca?
                        if (!tiposPermitidos.ContainsKey(extension))
                        {
                            errores.Add($"{Path.GetFileName(file)}: Extensión '{extension}' no permitida");
                            continue;
                        }

                        // VALIDACIÓN DE TAMAÑO (10MB máximo)
                        FileInfo fi = new FileInfo(file);
                        if (fi.Length > 10 * 1024 * 1024)
                        {
                            errores.Add($"{Path.GetFileName(file)}: Excede 10MB");
                            continue;
                        }

                        try
                        {
                            // PROCESAR ARCHIVO VÁLIDO
                            byte[] bytes = File.ReadAllBytes(file);
                            archivosBytes.Add(bytes);
                            nombresArchivos.Add(Path.GetFileName(file));
                            tiposArchivos.Add(tiposPermitidos[extension]);
                            categoriasArchivos.Add(categoria);
                        }
                        catch
                        {
                            errores.Add($"{Path.GetFileName(file)}: Error al leer");
                        }
                    }

                    // Mostrar resultados
                    if (errores.Count == 0)
                    {
                        MessageBox.Show("Todos los archivos se subieron correctamente",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Se subieron {ofd.FileNames.Length - errores.Count} de {ofd.FileNames.Length} archivos.\n\nErrores:\n{string.Join("\n", errores)}",
                            "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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