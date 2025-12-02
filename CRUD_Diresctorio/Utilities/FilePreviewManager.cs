// FilePreviewManager.cs
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    public class FilePreviewManager
    {
        public bool CanPreview(string mimeType)
        {
            // Archivos que se pueden previsualizar internamente
            return mimeType.StartsWith("image/") ||
                   mimeType == "application/pdf" ||
                   mimeType == "text/plain" ||
                   mimeType == "text/html" ||
                   mimeType == "application/json" ||
                   mimeType == "application/xml";
        }

        public void PreviewFile(byte[] fileBytes, string fileName, string mimeType, Form parentForm)
        {
            if (fileBytes == null || fileBytes.Length == 0)
            {
                MessageBox.Show(parentForm, "El archivo está vacío o no se pudo cargar", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form previewForm = new Form();
            previewForm.Text = $"Previsualizar: {fileName}";
            previewForm.Size = new Size(900, 700);
            previewForm.StartPosition = FormStartPosition.CenterParent;
            previewForm.MinimumSize = new Size(400, 300);

            try
            {
                if (mimeType.StartsWith("image/"))
                {
                    PreviewImage(fileBytes, previewForm, fileName);
                }
                else if (mimeType == "application/pdf")
                {
                    PreviewPDF(fileBytes, previewForm, fileName);
                }
                else if (mimeType.StartsWith("text/"))
                {
                    PreviewText(fileBytes, previewForm, fileName, mimeType);
                }
                else
                {
                    // Para otros tipos, usar aplicación externa
                    previewForm.Dispose();
                    OpenFileExternally(fileBytes, fileName, mimeType);
                    return;
                }

                previewForm.ShowDialog(parentForm);
            }
            catch (Exception ex)
            {
                previewForm.Dispose();
                MessageBox.Show(parentForm,
                    $"Error al previsualizar archivo: {ex.Message}\n\nIntentando abrir con aplicación externa...",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                OpenFileExternally(fileBytes, fileName, mimeType);
            }
        }

        private void PreviewImage(byte[] imageBytes, Form previewForm, string fileName)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);

                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = image;

                ToolStrip toolStrip = CreateImageToolStrip(fileName, image, pictureBox);

                previewForm.Controls.Add(pictureBox);
                previewForm.Controls.Add(toolStrip);
            }
        }

        private ToolStrip CreateImageToolStrip(string fileName, Image image, PictureBox pictureBox)
        {
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Dock = DockStyle.Top;

            ToolStripLabel lblInfo = new ToolStripLabel();
            lblInfo.Text = $"{fileName} - {image.Width}x{image.Height} pixels";
            lblInfo.Font = new Font("Arial", 9, FontStyle.Bold);

            ToolStripButton btnZoomIn = new ToolStripButton("+");
            btnZoomIn.Click += (s, e) => pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

            ToolStripButton btnZoomOut = new ToolStripButton("-");
            btnZoomOut.Click += (s, e) => pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            ToolStripButton btnOriginal = new ToolStripButton("Original");
            btnOriginal.Click += (s, e) => pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            toolStrip.Items.AddRange(new ToolStripItem[] { lblInfo, new ToolStripSeparator(), btnZoomIn, btnZoomOut, btnOriginal });

            return toolStrip;
        }

        private void PreviewText(byte[] textBytes, Form previewForm, string fileName, string mimeType)
        {
            string content = Encoding.UTF8.GetString(textBytes);

            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Text = content;
            richTextBox.Font = new Font("Consolas", 10);
            richTextBox.ReadOnly = true;
            richTextBox.WordWrap = false;

            if (mimeType == "application/json" || mimeType == "application/xml")
            {
                richTextBox.BackColor = Color.Black;
                richTextBox.ForeColor = Color.White;
            }

            ToolStrip toolStrip = CreateTextToolStrip(fileName, textBytes.Length, richTextBox);

            previewForm.Controls.Add(richTextBox);
            previewForm.Controls.Add(toolStrip);
        }

        private ToolStrip CreateTextToolStrip(string fileName, long fileSize, RichTextBox richTextBox)
        {
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Dock = DockStyle.Top;

            ToolStripLabel lblInfo = new ToolStripLabel();
            lblInfo.Text = $"{fileName} - {FormatFileSize(fileSize)}";

            ToolStripButton btnSearch = new ToolStripButton("Buscar");
            btnSearch.Click += (s, e) => ShowSearchDialog(richTextBox);

            ToolStripButton btnCopy = new ToolStripButton("Copiar todo");
            btnCopy.Click += (s, e) => Clipboard.SetText(richTextBox.Text);

            toolStrip.Items.AddRange(new ToolStripItem[] { lblInfo, new ToolStripSeparator(), btnSearch, btnCopy });

            return toolStrip;
        }

        private void ShowSearchDialog(RichTextBox richTextBox)
        {
            Form searchForm = new Form();
            searchForm.Text = "Buscar texto";
            searchForm.Size = new Size(400, 150);
            searchForm.StartPosition = FormStartPosition.CenterParent;

            TextBox txtSearch = new TextBox();
            txtSearch.Location = new Point(10, 30);
            txtSearch.Size = new Size(365, 20);
            txtSearch.TabIndex = 0;

            CheckBox chkCaseSensitive = new CheckBox();
            chkCaseSensitive.Text = "Distinguir mayúsculas/minúsculas";
            chkCaseSensitive.Location = new Point(10, 60);
            chkCaseSensitive.Size = new Size(200, 20);

            Button btnSearch = new Button();
            btnSearch.Text = "Buscar siguiente";
            btnSearch.Location = new Point(280, 80);
            btnSearch.Size = new Size(100, 30);
            btnSearch.Click += (s, e) =>
            {
                StringComparison comparison = chkCaseSensitive.Checked ?
                    StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

                int startIndex = richTextBox.SelectionStart + richTextBox.SelectionLength;
                int foundIndex = richTextBox.Text.IndexOf(txtSearch.Text, startIndex, comparison);

                if (foundIndex >= 0)
                {
                    richTextBox.Select(foundIndex, txtSearch.Text.Length);
                    richTextBox.ScrollToCaret();
                    richTextBox.Focus();
                }
                else
                {
                    MessageBox.Show("Texto no encontrado", "Búsqueda",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            searchForm.Controls.AddRange(new Control[] {
                new Label { Text = "Texto a buscar:", Location = new Point(10, 10) },
                txtSearch, chkCaseSensitive, btnSearch
            });

            searchForm.ShowDialog();
        }

        private void PreviewPDF(byte[] pdfBytes, Form previewForm, string fileName)
        {
            Label lblMessage = new Label();
            lblMessage.Text = $"PDF: {fileName}\n\n" +
                             $"Tamaño: {FormatFileSize(pdfBytes.Length)}\n\n" +
                             "Los archivos PDF se abrirán con la aplicación predeterminada.\n" +
                             "¿Desea abrir este archivo ahora?";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Arial", 10);

            // Agregar botón para abrir en navegador
            Button btnOpenInBrowser = new Button();
            btnOpenInBrowser.Text = "Abrir en navegador";
            btnOpenInBrowser.Size = new Size(120, 30);
            btnOpenInBrowser.Location = new Point((previewForm.Width - 250) / 2, previewForm.Height - 100);
            btnOpenInBrowser.Click += (s, e) =>
            {
                previewForm.DialogResult = DialogResult.OK;
                previewForm.Close();

                Task.Delay(100).ContinueWith(t =>
                {
                    previewForm.Invoke(new Action(() =>
                    {
                        OpenPDFInBrowser(pdfBytes, fileName);
                    }));
                });
            };

            Button btnOpenDefault = new Button();
            btnOpenDefault.Text = "Abrir PDF";
            btnOpenDefault.Size = new Size(120, 30);
            btnOpenDefault.Location = new Point((previewForm.Width + 10) / 2, previewForm.Height - 100);
            btnOpenDefault.Click += (s, e) =>
            {
                previewForm.DialogResult = DialogResult.OK;
                previewForm.Close();

                Task.Delay(100).ContinueWith(t =>
                {
                    previewForm.Invoke(new Action(() =>
                    {
                        OpenFileExternally(pdfBytes, fileName, "application/pdf");
                    }));
                });
            };

            previewForm.Controls.Add(lblMessage);
            previewForm.Controls.Add(btnOpenInBrowser);
            previewForm.Controls.Add(btnOpenDefault);
        }

        private void OpenPDFInBrowser(byte[] pdfBytes, string fileName)
        {
            string tempPath = Path.GetTempPath();
            string tempFilePath = Path.Combine(tempPath, fileName);

            // Asegurarse de que el nombre del archivo tenga extensión .pdf
            if (!fileName.ToLower().EndsWith(".pdf"))
            {
                tempFilePath += ".pdf";
            }

            // Si el archivo ya existe, agregar GUID
            if (File.Exists(tempFilePath))
            {
                string guid = Guid.NewGuid().ToString().Substring(0, 8);
                tempFilePath = Path.Combine(tempPath,
                    $"{Path.GetFileNameWithoutExtension(fileName)}_{guid}.pdf");
            }

            try
            {
                // Guardar el archivo PDF temporalmente
                File.WriteAllBytes(tempFilePath, pdfBytes);

                // Crear una URL de archivo local
                string fileUrl = $"file:///{tempFilePath.Replace("\\", "/")}";

                // Intentar abrir en el navegador predeterminado
                try
                {
                    // Primero intentar con el navegador predeterminado
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = fileUrl,
                        UseShellExecute = true
                    });
                }
                catch
                {
                    // Si falla, intentar con navegadores específicos
                    try
                    {
                        // Intentar con Chrome
                        System.Diagnostics.Process.Start("chrome.exe", fileUrl);
                    }
                    catch
                    {
                        try
                        {
                            // Intentar con Firefox
                            System.Diagnostics.Process.Start("firefox.exe", fileUrl);
                        }
                        catch
                        {
                            try
                            {
                                // Intentar con Edge
                                System.Diagnostics.Process.Start("msedge.exe", fileUrl);
                            }
                            catch
                            {
                                // Si todo falla, mostrar mensaje
                                MessageBox.Show("No se pudo abrir el PDF en ningún navegador.\n" +
                                               "El archivo se guardó en: " + tempFilePath,
                                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                // Limpiar archivo temporal después de 10 minutos
                Task.Delay(600000).ContinueWith(t =>
                {
                    try
                    {
                        if (File.Exists(tempFilePath))
                        {
                            File.Delete(tempFilePath);
                        }
                    }
                    catch { }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el PDF: {ex.Message}\n\n" +
                               $"El archivo se guardó en: {tempFilePath}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenFileExternally(byte[] fileBytes, string originalFileName, string mimeType)
        {
            string tempPath = Path.GetTempPath();
            string extension = GetExtensionFromMimeType(mimeType);
            string fileName = Path.GetFileNameWithoutExtension(originalFileName) + extension;
            string tempFilePath = Path.Combine(tempPath, fileName);

            if (File.Exists(tempFilePath))
            {
                string guid = Guid.NewGuid().ToString().Substring(0, 8);
                fileName = $"{Path.GetFileNameWithoutExtension(originalFileName)}_{guid}{extension}";
                tempFilePath = Path.Combine(tempPath, fileName);
            }

            File.WriteAllBytes(tempFilePath, fileBytes);

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempFilePath,
                    UseShellExecute = true
                });

                // Limpiar archivo temporal después de 5 minutos
                Task.Delay(300000).ContinueWith(t =>
                {
                    try
                    {
                        if (File.Exists(tempFilePath))
                        {
                            File.Delete(tempFilePath);
                        }
                    }
                    catch { }
                });
            }
            catch (Exception ex)
            {
                // Si falla la apertura automática, ofrecer opciones
                if (mimeType == "application/pdf")
                {
                    DialogResult result = MessageBox.Show(
                        $"No se pudo abrir el PDF automáticamente.\n\n" +
                        $"¿Desea intentar abrirlo en el navegador?\n\n" +
                        $"Archivo: {tempFilePath}\n" +
                        $"Error: {ex.Message}",
                        "Abrir PDF",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        OpenPDFInBrowser(fileBytes, originalFileName);
                    }
                }
                else
                {
                    MessageBox.Show($"No se pudo abrir el archivo automáticamente.\n\n" +
                                   $"El archivo se guardó en: {tempFilePath}\n" +
                                   $"Puede abrirlo manualmente.\n\nError: {ex.Message}",
                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double len = bytes;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        private string GetExtensionFromMimeType(string mimeType)
        {
            return MimeMapping.GetExtensionFromMimeType(mimeType);
        }
    }
}