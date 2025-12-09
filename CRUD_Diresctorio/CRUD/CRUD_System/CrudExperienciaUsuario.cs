// CrudExperienciaUsuario.cs
using System;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudExperienciaUsuario
    {
        private CrudTabPage parentControl;
        private TextBox txtIDUsuario;
        private ComboBox cmbTipoRegistro;
        private ComboBox cmbNivelEstudios;
        private TextBox txtAnosExperiencia;
        private TextBox txtEmpresasAnteriores;
        private TextBox txtProyectosDestacados;
        private TextBox txtReferenciasLaborales;
        private TextBox txtTipoExperiencia;
        private TextBox txtDescripcionOtro;

        public CrudExperienciaUsuario()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtIDUsuario, ComboBox cmbTipoRegistro,
                               ComboBox cmbNivelEstudios, TextBox txtAnosExperiencia,
                               TextBox txtEmpresasAnteriores, TextBox txtProyectosDestacados,
                               TextBox txtReferenciasLaborales, TextBox txtTipoExperiencia,
                               TextBox txtDescripcionOtro)
        {
            this.txtIDUsuario = txtIDUsuario;
            this.cmbTipoRegistro = cmbTipoRegistro;
            this.cmbNivelEstudios = cmbNivelEstudios;
            this.txtAnosExperiencia = txtAnosExperiencia;
            this.txtEmpresasAnteriores = txtEmpresasAnteriores;
            this.txtProyectosDestacados = txtProyectosDestacados;
            this.txtReferenciasLaborales = txtReferenciasLaborales;
            this.txtTipoExperiencia = txtTipoExperiencia;
            this.txtDescripcionOtro = txtDescripcionOtro;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (cmbTipoRegistro == null) return;

            if (row.Cells["ID_Usuario"] != null && row.Cells["ID_Usuario"].Value != null)
                txtIDUsuario.Text = row.Cells["ID_Usuario"].Value.ToString();

            if (row.Cells["tipo_registro"] != null && row.Cells["tipo_registro"].Value != null)
            {
                string tipoRegistro = row.Cells["tipo_registro"].Value.ToString();
                cmbTipoRegistro.SelectedItem = tipoRegistro;
            }

            if (row.Cells["nivel_estudios"] != null && row.Cells["nivel_estudios"].Value != null)
            {
                string nivelEstudios = row.Cells["nivel_estudios"].Value.ToString();
                cmbNivelEstudios.SelectedItem = nivelEstudios;
            }

            if (row.Cells["anos_experiencia"] != null && row.Cells["anos_experiencia"].Value != null)
                txtAnosExperiencia.Text = row.Cells["anos_experiencia"].Value.ToString();

            if (row.Cells["empresas_anteriores"] != null && row.Cells["empresas_anteriores"].Value != null)
                txtEmpresasAnteriores.Text = row.Cells["empresas_anteriores"].Value.ToString();

            if (row.Cells["proyectos_destacados"] != null && row.Cells["proyectos_destacados"].Value != null)
                txtProyectosDestacados.Text = row.Cells["proyectos_destacados"].Value.ToString();

            if (row.Cells["referencias_laborales"] != null && row.Cells["referencias_laborales"].Value != null)
                txtReferenciasLaborales.Text = row.Cells["referencias_laborales"].Value.ToString();

            if (row.Cells["tipo_experiencia"] != null && row.Cells["tipo_experiencia"].Value != null)
                txtTipoExperiencia.Text = row.Cells["tipo_experiencia"].Value.ToString();

            if (row.Cells["descripcion_otro"] != null && row.Cells["descripcion_otro"].Value != null)
                txtDescripcionOtro.Text = row.Cells["descripcion_otro"].Value.ToString();

            currentEditId = Convert.ToInt32(row.Cells["ID_Experiencia"].Value);
        }

        public bool ValidateForm()
        {
            if (cmbTipoRegistro == null) return false;

            if (string.IsNullOrWhiteSpace(txtIDUsuario.Text))
            {
                MessageBox.Show("El campo ID Usuario es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDUsuario.Focus();
                return false;
            }

            if (cmbTipoRegistro.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Registro", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoRegistro.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAnosExperiencia.Text))
            {
                MessageBox.Show("El campo Años de Experiencia es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnosExperiencia.Focus();
                return false;
            }

            return true;
        }

        public bool InsertRecord(BDConector db)
        {
            if (cmbTipoRegistro == null) return false;

            string query = @"INSERT INTO experiencia_usuario (ID_Usuario, tipo_registro, nivel_estudios, 
                           anos_experiencia, empresas_anteriores, proyectos_destacados, 
                           referencias_laborales, tipo_experiencia, descripcion_otro) 
                           VALUES (@idUsuario, @tipo, @nivel, @anos, @empresas, @proyectos, @referencias, @tipoExp, @descripcion)";

            object nivelEstudiosValue = cmbNivelEstudios.SelectedIndex == -1 ?
                DBNull.Value : (object)cmbNivelEstudios.SelectedItem.ToString();

            MySqlParameter[] parameters = {
                new MySqlParameter("@idUsuario", Convert.ToInt32(txtIDUsuario.Text)),
                new MySqlParameter("@tipo", cmbTipoRegistro.SelectedItem.ToString()),
                new MySqlParameter("@nivel", nivelEstudiosValue),
                new MySqlParameter("@anos", txtAnosExperiencia.Text),
                new MySqlParameter("@empresas", txtEmpresasAnteriores?.Text ?? ""),
                new MySqlParameter("@proyectos", txtProyectosDestacados?.Text ?? ""),
                new MySqlParameter("@referencias", txtReferenciasLaborales?.Text ?? ""),
                new MySqlParameter("@tipoExp", txtTipoExperiencia?.Text ?? ""),
                new MySqlParameter("@descripcion", txtDescripcionOtro?.Text ?? "")
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (cmbTipoRegistro == null) return false;

            string query = @"UPDATE experiencia_usuario SET tipo_registro = @tipo, nivel_estudios = @nivel, 
                           anos_experiencia = @anos, empresas_anteriores = @empresas, 
                           proyectos_destacados = @proyectos, referencias_laborales = @referencias, 
                           tipo_experiencia = @tipoExp, descripcion_otro = @descripcion, 
                           ID_Usuario = @idUsuario WHERE ID_Experiencia = @id";

            object nivelEstudiosValue = cmbNivelEstudios.SelectedIndex == -1 ?
                DBNull.Value : (object)cmbNivelEstudios.SelectedItem.ToString();

            MySqlParameter[] parameters = {
                new MySqlParameter("@tipo", cmbTipoRegistro.SelectedItem.ToString()),
                new MySqlParameter("@nivel", nivelEstudiosValue),
                new MySqlParameter("@anos", txtAnosExperiencia.Text),
                new MySqlParameter("@empresas", txtEmpresasAnteriores?.Text ?? ""),
                new MySqlParameter("@proyectos", txtProyectosDestacados?.Text ?? ""),
                new MySqlParameter("@referencias", txtReferenciasLaborales?.Text ?? ""),
                new MySqlParameter("@tipoExp", txtTipoExperiencia?.Text ?? ""),
                new MySqlParameter("@descripcion", txtDescripcionOtro?.Text ?? ""),
                new MySqlParameter("@idUsuario", Convert.ToInt32(txtIDUsuario.Text)),
                new MySqlParameter("@id", currentEditId)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}