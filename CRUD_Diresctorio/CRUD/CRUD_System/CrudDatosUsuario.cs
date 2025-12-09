// CrudDatosUsuario.cs
using System;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;

namespace CRUD_Directorio.CRUD.CRUD_System
{
    public class CrudDatosUsuario
    {
        private CrudTabPage parentControl;
        private TextBox txtIDUsuario;
        private TextBox txtNombres;
        private TextBox txtApellidos;
        private TextBox txtCiudad;
        private TextBox txtDireccion;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtWhatsapp;
        private TextBox txtOtroContacto;
        private TextBox txtIdentificacionOficial;
        private TextBox txtZonasServicio;

        public CrudDatosUsuario()
        {
        }

        public void SetParentControl(CrudTabPage control)
        {
            parentControl = control;
        }

        public void SetControls(TextBox txtIDUsuario, TextBox txtNombres, TextBox txtApellidos,
                               TextBox txtCiudad, TextBox txtDireccion, TextBox txtEmail,
                               TextBox txtTelefono, TextBox txtWhatsapp, TextBox txtOtroContacto,
                               TextBox txtIdentificacionOficial, TextBox txtZonasServicio)
        {
            this.txtIDUsuario = txtIDUsuario;
            this.txtNombres = txtNombres;
            this.txtApellidos = txtApellidos;
            this.txtCiudad = txtCiudad;
            this.txtDireccion = txtDireccion;
            this.txtEmail = txtEmail;
            this.txtTelefono = txtTelefono;
            this.txtWhatsapp = txtWhatsapp;
            this.txtOtroContacto = txtOtroContacto;
            this.txtIdentificacionOficial = txtIdentificacionOficial;
            this.txtZonasServicio = txtZonasServicio;
        }

        public void LoadDataForEdit(DataGridViewRow row, ref int currentEditId)
        {
            if (txtIDUsuario == null || txtNombres == null || txtApellidos == null ||
                txtCiudad == null || txtEmail == null || txtTelefono == null) return;

            if (row.Cells["ID_Usuario"] != null && row.Cells["ID_Usuario"].Value != null)
                txtIDUsuario.Text = row.Cells["ID_Usuario"].Value.ToString();

            if (row.Cells["nombres"] != null && row.Cells["nombres"].Value != null)
                txtNombres.Text = row.Cells["nombres"].Value.ToString();

            if (row.Cells["apellidos"] != null && row.Cells["apellidos"].Value != null)
                txtApellidos.Text = row.Cells["apellidos"].Value.ToString();

            if (row.Cells["ciudad"] != null && row.Cells["ciudad"].Value != null)
                txtCiudad.Text = row.Cells["ciudad"].Value.ToString();

            if (row.Cells["email"] != null && row.Cells["email"].Value != null)
                txtEmail.Text = row.Cells["email"].Value.ToString();

            if (row.Cells["telefono"] != null && row.Cells["telefono"].Value != null)
                txtTelefono.Text = row.Cells["telefono"].Value.ToString();

            if (txtDireccion != null && row.Cells["direccion_aproximada"] != null && row.Cells["direccion_aproximada"].Value != null)
                txtDireccion.Text = row.Cells["direccion_aproximada"].Value.ToString();

            if (txtWhatsapp != null && row.Cells["whatsapp"] != null && row.Cells["whatsapp"].Value != null)
                txtWhatsapp.Text = row.Cells["whatsapp"].Value.ToString();

            if (txtOtroContacto != null && row.Cells["otro_contacto"] != null && row.Cells["otro_contacto"].Value != null)
                txtOtroContacto.Text = row.Cells["otro_contacto"].Value.ToString();

            if (txtIdentificacionOficial != null && row.Cells["identificacion_oficial"] != null && row.Cells["identificacion_oficial"].Value != null)
                txtIdentificacionOficial.Text = row.Cells["identificacion_oficial"].Value.ToString();

            if (txtZonasServicio != null && row.Cells["zonas_servicio"] != null && row.Cells["zonas_servicio"].Value != null)
                txtZonasServicio.Text = row.Cells["zonas_servicio"].Value.ToString();

            currentEditId = Convert.ToInt32(row.Cells["ID_Datos_Usuario"].Value);
        }

        public bool ValidateForm()
        {
            if (txtIDUsuario == null || txtNombres == null || txtApellidos == null ||
                txtCiudad == null || txtEmail == null) return false;

            if (string.IsNullOrWhiteSpace(txtIDUsuario.Text))
            {
                MessageBox.Show("El campo ID Usuario es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDUsuario.Focus();
                return false;
            }

            if (!int.TryParse(txtIDUsuario.Text, out _))
            {
                MessageBox.Show("El campo ID Usuario debe ser un número", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDUsuario.Focus();
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

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El campo Email es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                MessageBox.Show("El campo Ciudad es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCiudad.Focus();
                return false;
            }

            return true;
        }

        public bool InsertRecord(BDConector db)
        {
            if (txtIDUsuario == null || txtNombres == null || txtApellidos == null ||
                txtCiudad == null || txtEmail == null) return false;

            string query = @"INSERT INTO datos_usuario (ID_Usuario, nombres, apellidos, ciudad, direccion, email, telefono, whatsapp, otro_contacto, identificacion_oficial, zonas_servicio) 
                           VALUES (@idUsuario, @nombres, @apellidos, @ciudad, @direccion_aproximada, @email, @telefono, @whatsapp, @otroContacto, @identificacion, @zonas)";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idUsuario", Convert.ToInt32(txtIDUsuario.Text)),
                new MySqlParameter("@nombres", txtNombres.Text),
                new MySqlParameter("@apellidos", txtApellidos.Text),
                new MySqlParameter("@ciudad", txtCiudad.Text),
                new MySqlParameter("@direccion_aproximada", txtDireccion?.Text ?? ""),
                new MySqlParameter("@email", txtEmail.Text),
                new MySqlParameter("@telefono", txtTelefono?.Text ?? ""),
                new MySqlParameter("@whatsapp", txtWhatsapp?.Text ?? ""),
                new MySqlParameter("@otroContacto", txtOtroContacto?.Text ?? ""),
                new MySqlParameter("@identificacion", txtIdentificacionOficial?.Text ?? ""),
                new MySqlParameter("@zonas", txtZonasServicio?.Text ?? "")
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateRecord(BDConector db, int currentEditId)
        {
            if (txtIDUsuario == null || txtNombres == null || txtApellidos == null ||
                txtCiudad == null || txtEmail == null) return false;

            string query = @"UPDATE datos_usuario SET ID_Usuario = @idUsuario, nombres = @nombres, apellidos = @apellidos, 
                           ciudad = @ciudad, direccion = @direccion_aproximada, email = @email, telefono = @telefono, 
                           whatsapp = @whatsapp, otro_contacto = @otroContacto, 
                           identificacion_oficial = @identificacion, zonas_servicio = @zonas 
                           WHERE ID_Datos_Usuario = @id";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idUsuario", Convert.ToInt32(txtIDUsuario.Text)),
                new MySqlParameter("@nombres", txtNombres.Text),
                new MySqlParameter("@apellidos", txtApellidos.Text),
                new MySqlParameter("@ciudad", txtCiudad.Text),
                new MySqlParameter("@direccion_aproximada", txtDireccion?.Text ?? ""),
                new MySqlParameter("@email", txtEmail.Text),
                new MySqlParameter("@telefono", txtTelefono?.Text ?? ""),
                new MySqlParameter("@whatsapp", txtWhatsapp?.Text ?? ""),
                new MySqlParameter("@otroContacto", txtOtroContacto?.Text ?? ""),
                new MySqlParameter("@identificacion", txtIdentificacionOficial?.Text ?? ""),
                new MySqlParameter("@zonas", txtZonasServicio?.Text ?? ""),
                new MySqlParameter("@id", currentEditId)
            };

            int result = db.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}