// CrudServicios.cs
using System;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD
{
    public class CrudServicios
    {
        private CrudTabPage parentControl;
        private TextBox txtTitulo;
        private TextBox txtDescripcionServicio;
        private TextBox txtIDCategoria;
        private TextBox txtIDDenominacion;
        private ComboBox cmbTipoPrecio;

        public CrudServicios()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox titulo, TextBox descripcion, TextBox idCategoria,
                               TextBox idDenominacion, TextBox txtDescripcionServicio, ComboBox tipoPrecio, TextBox txtMonedaServicio, TextBox txtDisponibilidadServicio, TextBox txtRadioCoberturaServicio, TextBox txtExperienciaServicio)
        {
            txtTitulo = titulo;
            txtDescripcionServicio = descripcion;
            txtIDCategoria = idCategoria;
            txtIDDenominacion = idDenominacion;
            cmbTipoPrecio = tipoPrecio;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (txtTitulo == null) return;

            if (row.Cells["titulo"] != null && row.Cells["titulo"].Value != null)
                txtTitulo.Text = row.Cells["titulo"].Value.ToString();

            if (row.Cells["descripcion"] != null && row.Cells["descripcion"].Value != null)
                txtDescripcionServicio.Text = row.Cells["descripcion"].Value.ToString();

            if (row.Cells["ID_Categoria"] != null && row.Cells["ID_Categoria"].Value != null)
                txtIDCategoria.Text = row.Cells["ID_Categoria"].Value.ToString();

            if (row.Cells["ID_Denominacion"] != null && row.Cells["ID_Denominacion"].Value != null)
                txtIDDenominacion.Text = row.Cells["ID_Denominacion"].Value.ToString();

            if (row.Cells["tipo_precio"] != null && row.Cells["tipo_precio"].Value != null)
            {
                string tipoPrecio = row.Cells["tipo_precio"].Value.ToString();
                cmbTipoPrecio.SelectedItem = tipoPrecio;
            }

            currentEditId = Convert.ToInt32(row.Cells["ID_Servicio"].Value);
        }

        public bool ValidateForm()
        {
            if (txtTitulo == null) return false;

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El campo Título es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcionServicio.Text))
            {
                MessageBox.Show("El campo Descripción es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcionServicio.Focus();
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
            if (txtTitulo == null) return false;

            string query = @"INSERT INTO servicios (ID_Usuario, ID_Categoria, ID_Denominacion, titulo, descripcion, tipo_precio) 
                           VALUES (@idUsuario, @idCategoria, @idDenominacion, @titulo, @descripcion, @tipoPrecio)";

            object idDenominacionValue = string.IsNullOrEmpty(txtIDDenominacion.Text) ?
                DBNull.Value : (object)Convert.ToInt32(txtIDDenominacion.Text);

            MySqlParameter[] parameters = {
                new MySqlParameter("@idUsuario", 1), // Valor por defecto
                new MySqlParameter("@idCategoria", Convert.ToInt32(txtIDCategoria.Text)),
                new MySqlParameter("@idDenominacion", idDenominacionValue),
                new MySqlParameter("@titulo", txtTitulo.Text),
                new MySqlParameter("@descripcion", txtDescripcionServicio.Text),
                new MySqlParameter("@tipoPrecio", cmbTipoPrecio.SelectedItem?.ToString() ?? "fijo")
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (txtTitulo == null) return false;

            string query = @"UPDATE servicios SET titulo = @titulo, descripcion = @descripcion, 
                           ID_Categoria = @idCategoria, ID_Denominacion = @idDenominacion, tipo_precio = @tipoPrecio 
                           WHERE ID_Servicio = @id";

            object idDenominacionValue = string.IsNullOrEmpty(txtIDDenominacion.Text) ?
                DBNull.Value : (object)Convert.ToInt32(txtIDDenominacion.Text);

            MySqlParameter[] parameters = {
                new MySqlParameter("@titulo", txtTitulo.Text),
                new MySqlParameter("@descripcion", txtDescripcionServicio.Text),
                new MySqlParameter("@idCategoria", Convert.ToInt32(txtIDCategoria.Text)),
                new MySqlParameter("@idDenominacion", idDenominacionValue),
                new MySqlParameter("@tipoPrecio", cmbTipoPrecio.SelectedItem?.ToString() ?? "fijo"),
                new MySqlParameter("@id", currentEditId)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}