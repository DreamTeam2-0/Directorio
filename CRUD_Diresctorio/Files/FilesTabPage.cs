// FilesTabPage.cs (versión simplificada)
using Utilities;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRUD_Directorio.Files
{
    public partial class FilesTabPage : UserControl
    {
        private FileDatabaseManager dbManager = new FileDatabaseManager();
        private FilePreviewManager previewManager = new FilePreviewManager();
        private FileUploadManager uploadManager = new FileUploadManager();
        private FileDownloadManager downloadManager = new FileDownloadManager();

        public FilesTabPage()
        {
            InitializeComponent();
            LoadFiles();
        }

        private void LoadFiles()
        {
            try
            {
                DataTable dt = dbManager.GetAllFiles();

                dgvArchivos.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvArchivos.Rows.Add(
                        row["ID_Archivo"],
                        row["nombre_archivo"],
                        row["tipo_archivo"],
                        row["categoria_archivo"],
                        row["usuario_nombre"],
                        row["fecha_creacion"],
                        $"{row["tamanio_kb"]} KB",
                        row["origen"],
                        row["ID_Usuario"] != DBNull.Value ? row["ID_Usuario"] : 0
                    );
                }

                lblTotalArchivos.Text = $"Total archivos: {dt.Rows.Count}";
                lblTotalArchivos.ForeColor = dt.Rows.Count == 0 ?
                    System.Drawing.Color.Gray : System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                ShowError("Error al cargar archivos", ex.Message);
                Logger.LogError($"Error loading files: {ex.Message}");
            }
        }

        private void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Filtros SEGUROS - solo tipos permitidos
                openFileDialog.Filter = "Archivos permitidos (*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf;*.txt;*.doc;*.docx)|" +
                                       "*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf;*.txt;*.doc;*.docx|" +
                                       "Imágenes (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|" +
                                       "Documentos PDF (*.pdf)|*.pdf|" +
                                       "Archivos de texto (*.txt)|*.txt|" +
                                       "Documentos Word (*.doc;*.docx)|*.doc;*.docx";

                openFileDialog.FilterIndex = 1; // Comenzar con "Archivos permitidos"
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Seleccionar archivos para subir al sistema";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    UploadFiles(openFileDialog.FileNames);
                }
            }
        }

        private void UploadFiles(string[] filePaths)
        {
            int uploaded = 0;
            int failed = 0;

            foreach (string filePath in filePaths)
            {
                var result = uploadManager.UploadFile(filePath, "archivos_generales");

                if (result.Success)
                {
                    uploaded++;
                    Logger.LogInfo($"Uploaded file: {result.FileName} ({result.FileSize} bytes)");
                }
                else
                {
                    failed++;
                    Logger.LogError($"Failed to upload {filePath}: {result.Message}");
                }
            }

            string message = $"Archivos procesados:\n" +
                           $"✓ Subidos exitosamente: {uploaded}\n" +
                           $"✗ Fallidos: {failed}";

            MessageBox.Show(message, "Resultado de subida",
                MessageBoxButtons.OK, failed == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            LoadFiles();
        }

        private void btnVerArchivo_Click(object sender, EventArgs e)
        {
            if (!ValidateSelection()) return;

            var selectedRow = GetSelectedRow();

            byte[] fileBytes = downloadManager.GetFileBytes(
                selectedRow.Id,
                selectedRow.Origin == "proveedor" ? "archivos_proveedor" : "archivos_generales"
            );

            // Para PDFs, siempre abrir directamente
            if (selectedRow.MimeType == "application/pdf")
            {
                previewManager.OpenFileExternally(fileBytes, selectedRow.FileName, selectedRow.MimeType);
            }
            else if (previewManager.CanPreview(selectedRow.MimeType))
            {
                previewManager.PreviewFile(fileBytes, selectedRow.FileName, selectedRow.MimeType, this.ParentForm);
            }
            else
            {
                previewManager.OpenFileExternally(fileBytes, selectedRow.FileName, selectedRow.MimeType);
            }
        }

        private void btnDescargarArchivo_Click(object sender, EventArgs e)
        {
            if (!ValidateSelection()) return;

            var selectedRow = GetSelectedRow();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = selectedRow.FileName;
                saveFileDialog.Filter = "Todos los archivos (*.*)|*.*";
                saveFileDialog.Title = "Guardar archivo";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var result = downloadManager.DownloadFile(
                        selectedRow.Id,
                        selectedRow.Origin == "proveedor" ? "archivos_proveedor" : "archivos_generales",
                        saveFileDialog.FileName
                    );

                    if (result.Success)
                    {
                        ShowSuccess($"Archivo descargado exitosamente\n\n" +
                                   $"Nombre: {selectedRow.FileName}\n" +
                                   $"Tamaño: {downloadManager.FormatFileSize(result.FileSize)}\n" +
                                   $"Destino: {result.FilePath}");
                    }
                    else
                    {
                        ShowError("Error al descargar", result.Message);
                    }
                }
            }
        }

        private void btnEliminarArchivo_Click(object sender, EventArgs e)
        {
            if (!ValidateSelection()) return;

            var selectedRow = GetSelectedRow();

            string message = $"¿Está seguro de eliminar el archivo?\n\n" +
                           $"Nombre: {selectedRow.FileName}\n" +
                           $"Tipo: {selectedRow.MimeType}\n" +
                           $"Origen: {selectedRow.Origin}\n" +
                           $"ID: {selectedRow.Id}";

            if (MessageBox.Show(message, "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool deleted = dbManager.DeleteFile(
                    selectedRow.Id,
                    selectedRow.Origin == "proveedor" ? "archivos_proveedor" : "archivos_generales"
                );

                if (deleted)
                {
                    ShowSuccess("Archivo eliminado exitosamente");
                    Logger.LogInfo($"Deleted file: {selectedRow.FileName}");
                    LoadFiles();
                }
                else
                {
                    ShowError("Error", "No se pudo eliminar el archivo");
                }
            }
        }

        private bool ValidateSelection()
        {
            if (dgvArchivos.SelectedRows.Count == 0)
            {
                ShowWarning("Seleccione un archivo primero");
                return false;
            }
            return true;
        }

        private SelectedFile GetSelectedRow()
        {
            DataGridViewRow row = dgvArchivos.SelectedRows[0];
            return new SelectedFile
            {
                // Usar los mismos nombres que en el Designer.cs
                Id = Convert.ToInt32(row.Cells["colIDArchivo"].Value),
                FileName = row.Cells["colNombre"].Value.ToString(),
                MimeType = row.Cells["colTipo"].Value.ToString(),
                Origin = row.Cells["colOrigen"].Value.ToString()
            };
        }

        private void ShowError(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefreshArchivos_Click(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private void txtBuscarArchivo_TextChanged(object sender, EventArgs e)
        {
            string filter = txtBuscarArchivo.Text.ToLower();

            foreach (DataGridViewRow row in dgvArchivos.Rows)
            {
                bool visible = string.IsNullOrWhiteSpace(filter);

                if (!visible)
                {
                    // Corregir los nombres de las columnas aquí también
                    string nombre = row.Cells["colNombre"].Value?.ToString().ToLower() ?? "";
                    string tipo = row.Cells["colTipo"].Value?.ToString().ToLower() ?? "";
                    string categoria = row.Cells["colCategoria"].Value?.ToString().ToLower() ?? "";
                    string usuario = row.Cells["colUsuario"].Value?.ToString().ToLower() ?? "";

                    visible = nombre.Contains(filter) || tipo.Contains(filter) ||
                             categoria.Contains(filter) || usuario.Contains(filter);
                }

                row.Visible = visible;
            }
        }

        private void dgvArchivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnVerArchivo_Click(sender, e);
            }
        }
    }

    public class SelectedFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string Origin { get; set; }
    }
}