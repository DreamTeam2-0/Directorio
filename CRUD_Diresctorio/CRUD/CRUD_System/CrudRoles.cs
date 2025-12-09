// CrudRoles.cs
using System;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudRoles
    {
        private CrudTabPage parentControl;
        private TextBox txtNombre;
        private TextBox txtDescripcion;

        public CrudRoles()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtNombre, TextBox txtDescripcion)
        {
            this.txtNombre = txtNombre;
            this.txtDescripcion = txtDescripcion;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (parentControl == null || txtNombre == null || txtDescripcion == null) return;

            if (row.Cells["nombre"] != null && row.Cells["nombre"].Value != null)
                txtNombre.Text = row.Cells["nombre"].Value.ToString();

            if (row.Cells["descripcion"] != null && row.Cells["descripcion"].Value != null)
                txtDescripcion.Text = row.Cells["descripcion"].Value.ToString();

            currentEditId = Convert.ToInt32(row.Cells["ID_Rol"].Value);
        }

        public bool ValidateForm()
        {
            if (txtNombre == null) return false;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        public bool InsertRecord(BDConector db)
        {
            if (txtNombre == null || txtDescripcion == null) return false;

            string query = "INSERT INTO roles (nombre, descripcion) VALUES (@nombre, @descripcion)";
            MySqlParameter[] parameters = {
                new MySqlParameter("@nombre", txtNombre.Text),
                new MySqlParameter("@descripcion", txtDescripcion.Text ?? "")
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (txtNombre == null || txtDescripcion == null) return false;

            string query = "UPDATE roles SET nombre = @nombre, descripcion = @descripcion WHERE ID_Rol = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter("@nombre", txtNombre.Text),
                new MySqlParameter("@descripcion", txtDescripcion.Text ?? ""),
                new MySqlParameter("@id", currentEditId)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}