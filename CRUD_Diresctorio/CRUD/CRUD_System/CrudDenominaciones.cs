// CrudDenominaciones.cs
using System;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudDenominaciones
    {
        private CrudTabPage parentControl;
        private TextBox txtIDCategoria;
        private TextBox txtNombre;
        private TextBox txtDescripcion;

        public CrudDenominaciones()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtIDCategoria, TextBox txtNombre, TextBox txtDescripcion)
        {
            this.txtIDCategoria = txtIDCategoria;
            this.txtNombre = txtNombre;
            this.txtDescripcion = txtDescripcion;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (txtIDCategoria == null || txtNombre == null || txtDescripcion == null) return;

            if (row.Cells["nombre"] != null && row.Cells["nombre"].Value != null)
                txtNombre.Text = row.Cells["nombre"].Value.ToString();

            if (row.Cells["descripcion"] != null && row.Cells["descripcion"].Value != null)
                txtDescripcion.Text = row.Cells["descripcion"].Value.ToString();

            if (row.Cells["ID_Categoria"] != null && row.Cells["ID_Categoria"].Value != null)
                txtIDCategoria.Text = row.Cells["ID_Categoria"].Value.ToString();

            currentEditId = Convert.ToInt32(row.Cells["ID_Denominacion"].Value);
        }

        public bool ValidateForm()
        {
            if (txtNombre == null || txtIDCategoria == null) return false;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIDCategoria.Text))
            {
                MessageBox.Show("El campo ID Categoría es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDCategoria.Focus();
                return false;
            }

            if (!int.TryParse(txtIDCategoria.Text, out _))
            {
                MessageBox.Show("El campo ID Categoría debe ser un número", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDCategoria.Focus();
                return false;
            }

            return true;
        }

        public bool InsertRecord(BDConector db)
        {
            if (txtNombre == null || txtIDCategoria == null) return false;

            string query = "INSERT INTO denominaciones (ID_Categoria, nombre, descripcion) VALUES (@idCategoria, @nombre, @descripcion)";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idCategoria", Convert.ToInt32(txtIDCategoria.Text)),
                new MySqlParameter("@nombre", txtNombre.Text),
                new MySqlParameter("@descripcion", txtDescripcion?.Text ?? "")
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (txtNombre == null || txtIDCategoria == null) return false;

            string query = "UPDATE denominaciones SET nombre = @nombre, descripcion = @descripcion, ID_Categoria = @idCategoria WHERE ID_Denominacion = @id";

            MySqlParameter[] parameters = {
                new MySqlParameter("@nombre", txtNombre.Text),
                new MySqlParameter("@descripcion", txtDescripcion?.Text ?? ""),
                new MySqlParameter("@idCategoria", Convert.ToInt32(txtIDCategoria.Text)),
                new MySqlParameter("@id", currentEditId)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}