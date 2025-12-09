// CrudUsuariosSistema.cs
using System;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudUsuariosSistema
    {
        private CrudTabPage parentControl;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtIDRol;
        private TextBox txtNombres;
        private TextBox txtApellidos;
        private TextBox txtTelefono;
        private CheckBox chkActivo;

        public CrudUsuariosSistema()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtUsername, TextBox txtEmail, TextBox txtPassword,
                              TextBox txtIDRol, TextBox txtNombres, TextBox txtApellidos,
                              TextBox txtTelefono, CheckBox chkActivo)
        {
            this.txtUsername = txtUsername;
            this.txtEmail = txtEmail;
            this.txtPassword = txtPassword;
            this.txtIDRol = txtIDRol;
            this.txtNombres = txtNombres;
            this.txtApellidos = txtApellidos;
            this.txtTelefono = txtTelefono;
            this.chkActivo = chkActivo;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (txtUsername == null || txtEmail == null || txtNombres == null ||
                txtApellidos == null || txtTelefono == null || txtIDRol == null) return;

            if (row.Cells["username"] != null && row.Cells["username"].Value != null)
                txtUsername.Text = row.Cells["username"].Value.ToString();

            if (row.Cells["email"] != null && row.Cells["email"].Value != null)
                txtEmail.Text = row.Cells["email"].Value.ToString();

            if (row.Cells["nombres"] != null && row.Cells["nombres"].Value != null)
                txtNombres.Text = row.Cells["nombres"].Value.ToString();

            if (row.Cells["apellidos"] != null && row.Cells["apellidos"].Value != null)
                txtApellidos.Text = row.Cells["apellidos"].Value.ToString();

            if (row.Cells["telefono"] != null && row.Cells["telefono"].Value != null)
                txtTelefono.Text = row.Cells["telefono"].Value.ToString();

            if (row.Cells["ID_Rol"] != null && row.Cells["ID_Rol"].Value != null)
                txtIDRol.Text = row.Cells["ID_Rol"].Value.ToString();

            if (chkActivo != null && row.Cells["activo"] != null && row.Cells["activo"].Value != null)
                chkActivo.Checked = Convert.ToBoolean(row.Cells["activo"].Value);

            currentEditId = Convert.ToInt32(row.Cells["ID_Usuario_Sistema"].Value);
        }

        public bool ValidateForm()
        {
            if (txtUsername == null || txtEmail == null || txtNombres == null || txtApellidos == null)
                return false;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("El campo Username es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El campo Email es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("El campo Nombres es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("El campo Apellidos es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return false;
            }

            return true;
        }

        public bool InsertRecord(BDConector db)
        {
            if (txtUsername == null || txtEmail == null || txtNombres == null ||
                txtApellidos == null || txtIDRol == null) return false;

            string query = @"INSERT INTO usuarios_sistema (username, email, password_hash, ID_Rol, nombres, apellidos, telefono, activo) 
                           VALUES (@username, @email, @password, @rol, @nombres, @apellidos, @telefono, @activo)";

            MySqlParameter[] parameters = {
                new MySqlParameter("@username", txtUsername.Text),
                new MySqlParameter("@email", txtEmail.Text),
                new MySqlParameter("@password", HashHelper.ComputeSha256Hash("default123")),
                new MySqlParameter("@rol", string.IsNullOrEmpty(txtIDRol.Text) ? 1 : Convert.ToInt32(txtIDRol.Text)),
                new MySqlParameter("@nombres", txtNombres.Text),
                new MySqlParameter("@apellidos", txtApellidos.Text),
                new MySqlParameter("@telefono", txtTelefono?.Text ?? ""),
                new MySqlParameter("@activo", chkActivo?.Checked ?? true)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (txtUsername == null || txtEmail == null || txtNombres == null ||
                txtApellidos == null || txtIDRol == null) return false;

            string query = "UPDATE usuarios_sistema SET username = @username, email = @email, nombres = @nombres, apellidos = @apellidos, telefono = @telefono, ID_Rol = @rol, activo = @activo WHERE ID_Usuario_Sistema = @id";

            MySqlParameter[] parameters = {
                new MySqlParameter("@username", txtUsername.Text),
                new MySqlParameter("@email", txtEmail.Text),
                new MySqlParameter("@nombres", txtNombres.Text),
                new MySqlParameter("@apellidos", txtApellidos.Text),
                new MySqlParameter("@telefono", txtTelefono?.Text ?? ""),
                new MySqlParameter("@rol", string.IsNullOrEmpty(txtIDRol.Text) ? 1 : Convert.ToInt32(txtIDRol.Text)),
                new MySqlParameter("@activo", chkActivo?.Checked ?? true),
                new MySqlParameter("@id", currentEditId)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}