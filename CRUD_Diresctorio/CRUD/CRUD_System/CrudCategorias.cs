// CrudCategorias.cs
using System;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudCategorias
    {
        private CrudTabPage parentControl;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtIcono;
        private TextBox txtColor;
        private CheckBox chkActiva;

        public CrudCategorias()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtNombre, TextBox txtDescripcion,
                               TextBox txtIcono, TextBox txtColor, CheckBox chkActiva)
        {
            this.txtNombre = txtNombre;
            this.txtDescripcion = txtDescripcion;
            this.txtIcono = txtIcono;
            this.txtColor = txtColor;
            this.chkActiva = chkActiva;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (txtNombre == null || txtDescripcion == null || txtIcono == null || txtColor == null)
                return;

            if (row.Cells["nombre"] != null && row.Cells["nombre"].Value != null)
                txtNombre.Text = row.Cells["nombre"].Value.ToString();

            if (row.Cells["descripcion"] != null && row.Cells["descripcion"].Value != null)
                txtDescripcion.Text = row.Cells["descripcion"].Value.ToString();

            if (row.Cells["icono"] != null && row.Cells["icono"].Value != null)
                txtIcono.Text = row.Cells["icono"].Value.ToString();

            if (row.Cells["color"] != null && row.Cells["color"].Value != null)
                txtColor.Text = row.Cells["color"].Value.ToString();

            if (chkActiva != null && row.Cells["activa"] != null && row.Cells["activa"].Value != null)
                chkActiva.Checked = Convert.ToBoolean(row.Cells["activa"].Value);

            currentEditId = Convert.ToInt32(row.Cells["ID_Categoria"].Value);
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
            if (txtNombre == null) return false;

            string query = "INSERT INTO categorias (nombre, descripcion, icono, color, activa) VALUES (@nombre, @descripcion, @icono, @color, @activa)";

            MySqlParameter[] parameters = {
                new MySqlParameter("@nombre", txtNombre.Text),
                new MySqlParameter("@descripcion", txtDescripcion?.Text ?? ""),
                new MySqlParameter("@icono", txtIcono?.Text ?? ""),
                new MySqlParameter("@color", txtColor?.Text ?? ""),
                new MySqlParameter("@activa", chkActiva?.Checked ?? true)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (txtNombre == null) return false;

            string query = "UPDATE categorias SET nombre = @nombre, descripcion = @descripcion, icono = @icono, color = @color, activa = @activa WHERE ID_Categoria = @id";

            MySqlParameter[] parameters = {
                new MySqlParameter("@nombre", txtNombre.Text),
                new MySqlParameter("@descripcion", txtDescripcion?.Text ?? ""),
                new MySqlParameter("@icono", txtIcono?.Text ?? ""),
                new MySqlParameter("@color", txtColor?.Text ?? ""),
                new MySqlParameter("@activa", chkActiva?.Checked ?? true),
                new MySqlParameter("@id", currentEditId)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}