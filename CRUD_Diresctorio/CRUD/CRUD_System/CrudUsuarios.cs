// CrudUsuarios.cs
using System;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudUsuarios
    {
        private CrudTabPage parentControl;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtIDRol;
        private CheckBox chkActivo;

        public CrudUsuarios()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtUsername, TextBox txtPassword,
                               TextBox txtIDRol, CheckBox chkActivo)
        {
            this.txtUsername = txtUsername;
            this.txtPassword = txtPassword;
            this.txtIDRol = txtIDRol;
            this.chkActivo = chkActivo;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (txtUsername == null || txtIDRol == null) return;

            if (row.Cells["username"] != null && row.Cells["username"].Value != null)
                txtUsername.Text = row.Cells["username"].Value.ToString();

            if (row.Cells["ID_Rol"] != null && row.Cells["ID_Rol"].Value != null)
                txtIDRol.Text = row.Cells["ID_Rol"].Value.ToString();

            if (chkActivo != null && row.Cells["activo"] != null && row.Cells["activo"].Value != null)
                chkActivo.Checked = Convert.ToBoolean(row.Cells["activo"].Value);

            currentEditId = Convert.ToInt32(row.Cells["ID_Usuario"].Value);
        }

        public bool ValidateForm()
        {
            if (txtUsername == null || txtIDRol == null) return false;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("El campo Username es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIDRol.Text))
            {
                MessageBox.Show("El campo ID Rol es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDRol.Focus();
                return false;
            }

            if (!int.TryParse(txtIDRol.Text, out _))
            {
                MessageBox.Show("El campo ID Rol debe ser un número", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDRol.Focus();
                return false;
            }

            return true;
        }

        public bool InsertRecord(BDConector db)
        {
            if (txtUsername == null || txtIDRol == null) return false;

            string query = "INSERT INTO usuarios (username, password_hash, ID_Rol, activo) VALUES (@username, @password, @rol, @activo)";

            MySqlParameter[] parameters = {
                new MySqlParameter("@username", txtUsername.Text),
                new MySqlParameter("@password", HashHelper.ComputeSha256Hash(txtPassword?.Text ?? "default123")),
                new MySqlParameter("@rol", Convert.ToInt32(txtIDRol.Text)),
                new MySqlParameter("@activo", chkActivo?.Checked ?? true)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (txtUsername == null || txtIDRol == null) return false;

            string query = "UPDATE usuarios SET username = @username, ID_Rol = @rol, activo = @activo WHERE ID_Usuario = @id";

            MySqlParameter[] parameters = {
                new MySqlParameter("@username", txtUsername.Text),
                new MySqlParameter("@rol", Convert.ToInt32(txtIDRol.Text)),
                new MySqlParameter("@activo", chkActivo?.Checked ?? true),
                new MySqlParameter("@id", currentEditId)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}