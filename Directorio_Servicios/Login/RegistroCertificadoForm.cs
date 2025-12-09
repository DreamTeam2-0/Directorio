using LoginDirectorio.RegistroFases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
                ofd.Title = $"Subir archivos - Categoría: {categoria}";

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
                            obligatorios.Add(esObligatorio);
                        }
                        catch
                        {
                            errores.Add($"{Path.GetFileName(file)}: Error al leer");
                        }
                    }

                    // Mostrar resultados
                    if (errores.Count == 0)
                    {
                        MessageBox.Show($"Se subieron {ofd.FileNames.Length} archivo(s) correctamente a la categoría '{categoria}'",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int subidosExitosos = ofd.FileNames.Length - errores.Count;
                        string mensaje = $"Se subieron {subidosExitosos} de {ofd.FileNames.Length} archivos a la categoría '{categoria}'";

                        if (subidosExitosos > 0)
                        {
                            mensaje += "\n\nArchivos rechazados:\n" + string.Join("\n", errores.Take(5));
                            if (errores.Count > 5)
                                mensaje += $"\n... y {errores.Count - 5} más";

                            MessageBox.Show(mensaje, "Resultado parcial",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show($"No se pudo subir ningún archivo.\n\nErrores:\n{string.Join("\n", errores)}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Usuario canceló la selección
                    if (esObligatorio)
                    {
                        MessageBox.Show($"Debe seleccionar al menos un archivo para la categoría '{categoria}' que es obligatoria",
                            "Archivo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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