// CrudCalificaciones.cs
using System;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudCalificaciones
    {
        private CrudTabPage parentControl;
        private TextBox txtIDEmpleado;
        private TextBox txtIDCliente;
        private TextBox txtIDServicio;
        private NumericUpDown nudPuntuacion;
        private TextBox txtComentario;

        public CrudCalificaciones()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtIDEmpleado, TextBox txtIDCliente,
                               TextBox txtIDServicio, NumericUpDown nudPuntuacion,
                               TextBox txtComentario)
        {
            this.txtIDEmpleado = txtIDEmpleado;
            this.txtIDCliente = txtIDCliente;
            this.txtIDServicio = txtIDServicio;
            this.nudPuntuacion = nudPuntuacion;
            this.txtComentario = txtComentario;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (txtIDEmpleado == null) return;

            if (row.Cells["ID_Empleado"] != null && row.Cells["ID_Empleado"].Value != null)
                txtIDEmpleado.Text = row.Cells["ID_Empleado"].Value.ToString();

            if (row.Cells["ID_Cliente"] != null && row.Cells["ID_Cliente"].Value != null)
                txtIDCliente.Text = row.Cells["ID_Cliente"].Value.ToString();

            if (row.Cells["ID_Servicio"] != null && row.Cells["ID_Servicio"].Value != null)
                txtIDServicio.Text = row.Cells["ID_Servicio"].Value.ToString();

            if (nudPuntuacion != null && row.Cells["puntuacion"] != null && row.Cells["puntuacion"].Value != null)
            {
                if (int.TryParse(row.Cells["puntuacion"].Value.ToString(), out int puntuacion))
                    nudPuntuacion.Value = puntuacion;
            }

            if (row.Cells["comentario"] != null && row.Cells["comentario"].Value != null)
                txtComentario.Text = row.Cells["comentario"].Value.ToString();

            currentEditId = Convert.ToInt32(row.Cells["ID_Calificacion"].Value);
        }

        public bool ValidateForm()
        {
            if (txtIDEmpleado == null) return false;

            if (string.IsNullOrWhiteSpace(txtIDEmpleado.Text))
            {
                MessageBox.Show("El campo ID Empleado es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDEmpleado.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIDCliente.Text))
            {
                MessageBox.Show("El campo ID Cliente es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDCliente.Focus();
                return false;
            }

            if (!int.TryParse(txtIDEmpleado.Text, out _))
            {
                MessageBox.Show("El campo ID Empleado debe ser un número", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDEmpleado.Focus();
                return false;
            }

            if (!int.TryParse(txtIDCliente.Text, out _))
            {
                MessageBox.Show("El campo ID Cliente debe ser un número", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDCliente.Focus();
                return false;
            }

            if (nudPuntuacion.Value < 1 || nudPuntuacion.Value > 5)
            {
                MessageBox.Show("La puntuación debe ser un número entre 1 y 5", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudPuntuacion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtComentario.Text))
            {
                MessageBox.Show("El campo Comentario es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComentario.Focus();
                return false;
            }

            return true;
        }

        public bool InsertRecord(BDConector db)
        {
            if (txtIDEmpleado == null) return false;

            string query = @"INSERT INTO sistema_calificacion (ID_Empleado, ID_Cliente, ID_Servicio, puntuacion, comentario) 
                           VALUES (@idEmpleado, @idCliente, @idServicio, @puntuacion, @comentario)";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idEmpleado", Convert.ToInt32(txtIDEmpleado.Text)),
                new MySqlParameter("@idCliente", Convert.ToInt32(txtIDCliente.Text)),
                new MySqlParameter("@idServicio", string.IsNullOrEmpty(txtIDServicio.Text) ? 1 : Convert.ToInt32(txtIDServicio.Text)),
                new MySqlParameter("@puntuacion", Convert.ToInt32(nudPuntuacion.Value)),
                new MySqlParameter("@comentario", txtComentario.Text)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (txtIDEmpleado == null) return false;

            string query = @"UPDATE sistema_calificacion SET ID_Empleado = @idEmpleado, ID_Cliente = @idCliente, 
                           puntuacion = @puntuacion, comentario = @comentario, ID_Servicio = @idServicio 
                           WHERE ID_Calificacion = @id";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idEmpleado", Convert.ToInt32(txtIDEmpleado.Text)),
                new MySqlParameter("@idCliente", Convert.ToInt32(txtIDCliente.Text)),
                new MySqlParameter("@puntuacion", Convert.ToInt32(nudPuntuacion.Value)),
                new MySqlParameter("@comentario", txtComentario.Text),
                new MySqlParameter("@idServicio", string.IsNullOrEmpty(txtIDServicio.Text) ? 1 : Convert.ToInt32(txtIDServicio.Text)),
                new MySqlParameter("@id", currentEditId)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}