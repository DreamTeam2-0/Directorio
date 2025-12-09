// CrudArchivosGenerales.cs
using System;
using System.IO;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudArchivosGenerales
    {
        private CrudTabPage parentControl;
        private TextBox txtNombreArchivo;
        private ComboBox cmbTipoArchivo;
        private TextBox txtCategoriaArchivo;
        private TextBox txtDescripcionArchivo;
        private Label lblArchivoSeleccionado;
        private byte[] fileContent;

        public CrudArchivosGenerales()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtNombreArchivo, ComboBox cmbTipoArchivo,
                               TextBox txtCategoriaArchivo, TextBox txtDescripcionArchivo,
                               Label lblArchivoSeleccionado)
        {
            this.txtNombreArchivo = txtNombreArchivo;
            this.cmbTipoArchivo = cmbTipoArchivo;
            this.txtCategoriaArchivo = txtCategoriaArchivo;
            this.txtDescripcionArchivo = txtDescripcionArchivo;
            this.lblArchivoSeleccionado = lblArchivoSeleccionado;
        }

        public void SetSelectedFilePath(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    fileContent = File.ReadAllBytes(filePath);
                    lblArchivoSeleccionado.Text = Path.GetFileName(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetFileContent(byte[] content)
        {
            fileContent = content;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (txtNombreArchivo == null) return;

            if (row.Cells["nombre_archivo"] != null && row.Cells["nombre_archivo"].Value != null)
                txtNombreArchivo.Text = row.Cells["nombre_archivo"].Value.ToString();

            if (row.Cells["tipo_archivo"] != null && row.Cells["tipo_archivo"].Value != null)
            {
                string tipoArchivo = row.Cells["tipo_archivo"].Value.ToString();
                cmbTipoArchivo.SelectedItem = tipoArchivo;
            }

            if (row.Cells["categoria_archivo"] != null && row.Cells["categoria_archivo"].Value != null)
                txtCategoriaArchivo.Text = row.Cells["categoria_archivo"].Value.ToString();

            if (row.Cells["descripcion"] != null && row.Cells["descripcion"].Value != null)
                txtDescripcionArchivo.Text = row.Cells["descripcion"].Value.ToString();

            lblArchivoSeleccionado.Text = row.Cells["nombre_archivo"].Value?.ToString() ?? "Archivo cargado desde BD";

            currentEditId = Convert.ToInt32(row.Cells["ID_Archivo"].Value);
        }

        public bool ValidateForm()
        {
            if (txtNombreArchivo == null) return false;

            if (string.IsNullOrWhiteSpace(txtNombreArchivo.Text))
            {
                MessageBox.Show("El campo Nombre Archivo es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreArchivo.Focus();
                return false;
            }

            if (cmbTipoArchivo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Archivo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoArchivo.Focus();
                return false;
            }

            // Para inserción, verificar que haya archivo seleccionado
            if (fileContent == null || fileContent.Length == 0)
            {
                MessageBox.Show("Debe seleccionar un archivo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public bool InsertRecord(BDConector db)
        {
            if (txtNombreArchivo == null || fileContent == null) return false;

            string query = @"INSERT INTO archivos_generales (nombre_archivo, tipo_archivo, contenido, categoria_archivo, descripcion) 
                           VALUES (@nombre, @tipo, @contenido, @categoria, @descripcion)";

            MySqlParameter[] parameters = {
                new MySqlParameter("@nombre", txtNombreArchivo.Text),
                new MySqlParameter("@tipo", cmbTipoArchivo.SelectedItem.ToString()),
                new MySqlParameter("@contenido", fileContent),
                new MySqlParameter("@categoria", txtCategoriaArchivo?.Text ?? ""),
                new MySqlParameter("@descripcion", txtDescripcionArchivo?.Text ?? "")
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (txtNombreArchivo == null) return false;

            // Para actualización, solo actualizamos metadatos, no el contenido del archivo
            // a menos que se haya seleccionado un nuevo archivo
            if (fileContent != null && fileContent.Length > 0)
            {
                // Actualizar con nuevo contenido
                string query = @"UPDATE archivos_generales SET nombre_archivo = @nombre, tipo_archivo = @tipo, 
                               contenido = @contenido, categoria_archivo = @categoria, descripcion = @descripcion 
                               WHERE ID_Archivo = @id";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@nombre", txtNombreArchivo.Text),
                    new MySqlParameter("@tipo", cmbTipoArchivo.SelectedItem.ToString()),
                    new MySqlParameter("@contenido", fileContent),
                    new MySqlParameter("@categoria", txtCategoriaArchivo?.Text ?? ""),
                    new MySqlParameter("@descripcion", txtDescripcionArchivo?.Text ?? ""),
                    new MySqlParameter("@id", currentEditId)
                };

                int result = db.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            else
            {
                // Solo actualizar metadatos
                string query = @"UPDATE archivos_generales SET nombre_archivo = @nombre, tipo_archivo = @tipo, 
                               categoria_archivo = @categoria, descripcion = @descripcion 
                               WHERE ID_Archivo = @id";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@nombre", txtNombreArchivo.Text),
                    new MySqlParameter("@tipo", cmbTipoArchivo.SelectedItem.ToString()),
                    new MySqlParameter("@categoria", txtCategoriaArchivo?.Text ?? ""),
                    new MySqlParameter("@descripcion", txtDescripcionArchivo?.Text ?? ""),
                    new MySqlParameter("@id", currentEditId)
                };

                int result = db.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
        }
    }
}