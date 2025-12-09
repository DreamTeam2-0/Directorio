// CrudArchivosProveedor.cs
using System;
using System.IO;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudArchivosProveedor
    {
        private CrudTabPage parentControl;
        private TextBox txtIDUsuarioArchivo;
        private TextBox txtNombreArchivo;
        private ComboBox cmbTipoArchivo;
        private ComboBox cmbCategoriaArchivo;
        private CheckBox chkObligatorio;
        private Label lblArchivoSeleccionado;
        private byte[] fileContent;

        public CrudArchivosProveedor()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtIDUsuarioArchivo, TextBox txtNombreArchivo,
                               ComboBox cmbTipoArchivo, ComboBox cmbCategoriaArchivo,
                               CheckBox chkObligatorio, Label lblArchivoSeleccionado)
        {
            this.txtIDUsuarioArchivo = txtIDUsuarioArchivo;
            this.txtNombreArchivo = txtNombreArchivo;
            this.cmbTipoArchivo = cmbTipoArchivo;
            this.cmbCategoriaArchivo = cmbCategoriaArchivo;
            this.chkObligatorio = chkObligatorio;
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

            if (row.Cells["ID_Usuario"] != null && row.Cells["ID_Usuario"].Value != null)
                txtIDUsuarioArchivo.Text = row.Cells["ID_Usuario"].Value.ToString();

            if (row.Cells["nombre_archivo"] != null && row.Cells["nombre_archivo"].Value != null)
                txtNombreArchivo.Text = row.Cells["nombre_archivo"].Value.ToString();

            if (row.Cells["tipo_archivo"] != null && row.Cells["tipo_archivo"].Value != null)
            {
                string tipoArchivo = row.Cells["tipo_archivo"].Value.ToString();
                cmbTipoArchivo.SelectedItem = tipoArchivo;
            }

            if (row.Cells["categoria_archivo"] != null && row.Cells["categoria_archivo"].Value != null)
            {
                string categoriaArchivo = row.Cells["categoria_archivo"].Value.ToString();
                cmbCategoriaArchivo.SelectedItem = categoriaArchivo;
            }

            if (chkObligatorio != null && row.Cells["obligatorio"] != null && row.Cells["obligatorio"].Value != null)
                chkObligatorio.Checked = Convert.ToBoolean(row.Cells["obligatorio"].Value);

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

            if (cmbCategoriaArchivo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Categoría de Archivo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoriaArchivo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIDUsuarioArchivo.Text))
            {
                MessageBox.Show("El campo ID Usuario es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDUsuarioArchivo.Focus();
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

            string query = @"INSERT INTO archivos_proveedor (ID_Usuario, nombre_archivo, tipo_archivo, 
                           contenido, categoria_archivo, obligatorio) 
                           VALUES (@idUsuario, @nombre, @tipo, @contenido, @categoria, @obligatorio)";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idUsuario", Convert.ToInt32(txtIDUsuarioArchivo.Text)),
                new MySqlParameter("@nombre", txtNombreArchivo.Text),
                new MySqlParameter("@tipo", cmbTipoArchivo.SelectedItem.ToString()),
                new MySqlParameter("@contenido", fileContent),
                new MySqlParameter("@categoria", cmbCategoriaArchivo.SelectedItem.ToString()),
                new MySqlParameter("@obligatorio", chkObligatorio?.Checked ?? false)
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
                string query = @"UPDATE archivos_proveedor SET nombre_archivo = @nombre, tipo_archivo = @tipo, 
                               contenido = @contenido, categoria_archivo = @categoria, 
                               ID_Usuario = @idUsuario, obligatorio = @obligatorio 
                               WHERE ID_Archivo = @id";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@nombre", txtNombreArchivo.Text),
                    new MySqlParameter("@tipo", cmbTipoArchivo.SelectedItem.ToString()),
                    new MySqlParameter("@contenido", fileContent),
                    new MySqlParameter("@categoria", cmbCategoriaArchivo.SelectedItem.ToString()),
                    new MySqlParameter("@idUsuario", Convert.ToInt32(txtIDUsuarioArchivo.Text)),
                    new MySqlParameter("@obligatorio", chkObligatorio?.Checked ?? false),
                    new MySqlParameter("@id", currentEditId)
                };

                int result = db.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            else
            {
                // Solo actualizar metadatos
                string query = @"UPDATE archivos_proveedor SET nombre_archivo = @nombre, tipo_archivo = @tipo, 
                               categoria_archivo = @categoria, ID_Usuario = @idUsuario, obligatorio = @obligatorio 
                               WHERE ID_Archivo = @id";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@nombre", txtNombreArchivo.Text),
                    new MySqlParameter("@tipo", cmbTipoArchivo.SelectedItem.ToString()),
                    new MySqlParameter("@categoria", cmbCategoriaArchivo.SelectedItem.ToString()),
                    new MySqlParameter("@idUsuario", Convert.ToInt32(txtIDUsuarioArchivo.Text)),
                    new MySqlParameter("@obligatorio", chkObligatorio?.Checked ?? false),
                    new MySqlParameter("@id", currentEditId)
                };

                int result = db.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
        }
    }
}