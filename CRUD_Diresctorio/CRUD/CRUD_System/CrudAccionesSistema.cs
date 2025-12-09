// CrudAccionesSistema.cs
using System;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudAccionesSistema
    {
        private CrudTabPage parentControl;
        private TextBox txtIDUsuarioSistemaAccion;
        private TextBox txtAccion;
        private TextBox txtTablaAfectada;
        private TextBox txtRegistroAfectado;
        private TextBox txtDetalles;

        public CrudAccionesSistema()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtIDUsuarioSistemaAccion, TextBox txtAccion,
                               TextBox txtTablaAfectada, TextBox txtRegistroAfectado, TextBox txtDetalles)
        {
            this.txtIDUsuarioSistemaAccion = txtIDUsuarioSistemaAccion;
            this.txtAccion = txtAccion;
            this.txtTablaAfectada = txtTablaAfectada;
            this.txtRegistroAfectado = txtRegistroAfectado;
            this.txtDetalles = txtDetalles;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (txtAccion == null) return;

            if (row.Cells["ID_Usuario_Sistema"] != null && row.Cells["ID_Usuario_Sistema"].Value != null)
                txtIDUsuarioSistemaAccion.Text = row.Cells["ID_Usuario_Sistema"].Value.ToString();

            if (row.Cells["accion"] != null && row.Cells["accion"].Value != null)
                txtAccion.Text = row.Cells["accion"].Value.ToString();

            if (row.Cells["tabla_afectada"] != null && row.Cells["tabla_afectada"].Value != null)
                txtTablaAfectada.Text = row.Cells["tabla_afectada"].Value.ToString();

            if (row.Cells["registro_afectado_id"] != null && row.Cells["registro_afectado_id"].Value != null)
                txtRegistroAfectado.Text = row.Cells["registro_afectado_id"].Value.ToString();

            if (row.Cells["detalles"] != null && row.Cells["detalles"].Value != null)
                txtDetalles.Text = row.Cells["detalles"].Value.ToString();

            currentEditId = Convert.ToInt32(row.Cells["ID_Accion"].Value);
        }

        public bool ValidateForm()
        {
            if (txtAccion == null) return false;

            if (string.IsNullOrWhiteSpace(txtAccion.Text))
            {
                MessageBox.Show("El campo Acción es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTablaAfectada.Text))
            {
                MessageBox.Show("El campo Tabla Afectada es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTablaAfectada.Focus();
                return false;
            }

            return true;
        }

        public bool InsertRecord(BDConector db)
        {
            if (txtAccion == null) return false;

            string query = @"INSERT INTO acciones_sistema (ID_Usuario_Sistema, accion, tabla_afectada, registro_afectado_id, detalles) 
                           VALUES (@idUsuario, @accion, @tabla, @registroId, @detalles)";

            object registroIdValue = string.IsNullOrEmpty(txtRegistroAfectado.Text) ?
                DBNull.Value : (object)Convert.ToInt32(txtRegistroAfectado.Text);

            MySqlParameter[] parameters = {
                new MySqlParameter("@idUsuario", string.IsNullOrEmpty(txtIDUsuarioSistemaAccion.Text) ? 1 : Convert.ToInt32(txtIDUsuarioSistemaAccion.Text)),
                new MySqlParameter("@accion", txtAccion.Text),
                new MySqlParameter("@tabla", txtTablaAfectada.Text),
                new MySqlParameter("@registroId", registroIdValue),
                new MySqlParameter("@detalles", txtDetalles?.Text ?? "")
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (txtAccion == null) return false;

            string query = @"UPDATE acciones_sistema SET accion = @accion, tabla_afectada = @tabla, 
                           registro_afectado_id = @registroId, detalles = @detalles, ID_Usuario_Sistema = @idUsuario 
                           WHERE ID_Accion = @id";

            object registroIdValue = string.IsNullOrEmpty(txtRegistroAfectado.Text) ?
                DBNull.Value : (object)Convert.ToInt32(txtRegistroAfectado.Text);

            MySqlParameter[] parameters = {
                new MySqlParameter("@accion", txtAccion.Text),
                new MySqlParameter("@tabla", txtTablaAfectada.Text),
                new MySqlParameter("@registroId", registroIdValue),
                new MySqlParameter("@detalles", txtDetalles?.Text ?? ""),
                new MySqlParameter("@idUsuario", string.IsNullOrEmpty(txtIDUsuarioSistemaAccion.Text) ? 1 : Convert.ToInt32(txtIDUsuarioSistemaAccion.Text)),
                new MySqlParameter("@id", currentEditId)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}