
using System;
using System.Drawing;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;
using Shared.Session;

namespace Homepage.UI
{
    public partial class CalificarServicioForm : Form
    {
        private int _idServicio;
        private int _idEmpleado;
        private string _tituloServicio;
        private string _nombreProveedor;
        private int _calificacionSeleccionada = 0;

        public CalificarServicioForm(int idServicio, int idEmpleado, string tituloServicio, string nombreProveedor)
        {
            InitializeComponent();
            _idServicio = idServicio;
            _idEmpleado = idEmpleado;
            _tituloServicio = tituloServicio;
            _nombreProveedor = nombreProveedor;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CalificarServicioForm_Load(object sender, EventArgs e)
        {
            // Configurar información del servicio
            lblTituloServicio.Text = _tituloServicio;
            lblProveedor.Text = _nombreProveedor;
            lblUsuario.Text = UserSession.NombreCompleto;

            // Configurar estrellas
            ConfigurarEstrellas();

            // Configurar validación
            txtComentario.TextChanged += ValidarFormulario;
            ValidarFormulario(null, EventArgs.Empty);
        }

        private void ConfigurarEstrellas()
        {
            // Inicializar etiquetas de estrellas
            lblEstrella1.Tag = 1;
            lblEstrella2.Tag = 2;
            lblEstrella3.Tag = 3;
            lblEstrella4.Tag = 4;
            lblEstrella5.Tag = 5;

            // Configurar cursor
            lblEstrella1.Cursor = Cursors.Hand;
            lblEstrella2.Cursor = Cursors.Hand;
            lblEstrella3.Cursor = Cursors.Hand;
            lblEstrella4.Cursor = Cursors.Hand;
            lblEstrella5.Cursor = Cursors.Hand;
        }

        private void EstrellaLabel_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            _calificacionSeleccionada = (int)label.Tag;

            // Actualizar visualización de estrellas
            ActualizarEstrellas();

            // Validar formulario
            ValidarFormulario(null, EventArgs.Empty);
        }

        private void EstrellaLabel_MouseEnter(object sender, EventArgs e)
        {
            var label = (Label)sender;
            int valorEstrella = (int)label.Tag;

            // Mostrar hover
            ResaltarEstrellasHover(valorEstrella);
        }

        private void EstrellaLabel_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar selección actual
            ActualizarEstrellas();
        }

        private void ResaltarEstrellasHover(int hastaEstrella)
        {
            lblEstrella1.Text = hastaEstrella >= 1 ? "★" : "☆";
            lblEstrella1.ForeColor = hastaEstrella >= 1 ? Color.Gold : Color.Gray;

            lblEstrella2.Text = hastaEstrella >= 2 ? "★" : "☆";
            lblEstrella2.ForeColor = hastaEstrella >= 2 ? Color.Gold : Color.Gray;

            lblEstrella3.Text = hastaEstrella >= 3 ? "★" : "☆";
            lblEstrella3.ForeColor = hastaEstrella >= 3 ? Color.Gold : Color.Gray;

            lblEstrella4.Text = hastaEstrella >= 4 ? "★" : "☆";
            lblEstrella4.ForeColor = hastaEstrella >= 4 ? Color.Gold : Color.Gray;

            lblEstrella5.Text = hastaEstrella >= 5 ? "★" : "☆";
            lblEstrella5.ForeColor = hastaEstrella >= 5 ? Color.Gold : Color.Gray;
        }

        private void ActualizarEstrellas()
        {
            lblEstrella1.Text = _calificacionSeleccionada >= 1 ? "★" : "☆";
            lblEstrella1.ForeColor = _calificacionSeleccionada >= 1 ? Color.Gold : Color.Gray;

            lblEstrella2.Text = _calificacionSeleccionada >= 2 ? "★" : "☆";
            lblEstrella2.ForeColor = _calificacionSeleccionada >= 2 ? Color.Gold : Color.Gray;

            lblEstrella3.Text = _calificacionSeleccionada >= 3 ? "★" : "☆";
            lblEstrella3.ForeColor = _calificacionSeleccionada >= 3 ? Color.Gold : Color.Gray;

            lblEstrella4.Text = _calificacionSeleccionada >= 4 ? "★" : "☆";
            lblEstrella4.ForeColor = _calificacionSeleccionada >= 4 ? Color.Gold : Color.Gray;

            lblEstrella5.Text = _calificacionSeleccionada >= 5 ? "★" : "☆";
            lblEstrella5.ForeColor = _calificacionSeleccionada >= 5 ? Color.Gold : Color.Gray;
        }

        private void ValidarFormulario(object sender, EventArgs e)
        {
            bool calificacionValida = _calificacionSeleccionada > 0;
            bool comentarioValido = !string.IsNullOrWhiteSpace(txtComentario.Text) && txtComentario.Text.Length >= 10;

            btnEnviar.Enabled = calificacionValida && comentarioValido;

            // Actualizar indicadores
            lblCalificacionValida.Text = calificacionValida ? "✓" : "✗";
            lblCalificacionValida.ForeColor = calificacionValida ? Color.Green : Color.Red;

            lblComentarioValido.Text = comentarioValido ? "✓" : "✗";
            lblComentarioValido.ForeColor = comentarioValido ? Color.Green : Color.Red;

            if (!comentarioValido && txtComentario.Text.Length > 0)
            {
                lblComentarioValido.Text += $" ({txtComentario.Text.Length}/10)";
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UserSession.SesionActiva)
                {
                    MessageBox.Show("Debe iniciar sesión para calificar un servicio.", "Sesión Requerida",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que el usuario no sea el propio proveedor
                if (UserSession.IdUsuario == _idEmpleado)
                {
                    MessageBox.Show("No puede calificar su propio servicio.", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar si ya calificó este servicio
                if (YaCalificadoEsteServicio())
                {
                    var respuesta = MessageBox.Show("Ya ha calificado este servicio anteriormente. ¿Desea actualizar su calificación?",
                                                  "Calificación Existente",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                    if (respuesta == DialogResult.No)
                    {
                        return;
                    }
                }

                // Guardar la calificación
                bool resultado = GuardarCalificacion();

                if (resultado)
                {
                    MessageBox.Show("¡Gracias por su calificación y comentario!", "Calificación Enviada",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la calificación. Por favor, intente nuevamente.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar calificación: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool YaCalificadoEsteServicio()
        {
            string query = @"
                SELECT COUNT(*) 
                FROM sistema_calificacion 
                WHERE ID_Cliente = @idCliente 
                AND ID_Servicio = @idServicio";

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();
                    using (var cmd = new MySqlCommand(query, db._connection))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", UserSession.IdUsuario);
                        cmd.Parameters.AddWithValue("@idServicio", _idServicio);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error verificando calificación existente: {ex.Message}");
                return false;
            }
        }

        private bool GuardarCalificacion()
        {
            string query = @"
                INSERT INTO sistema_calificacion 
                (ID_Empleado, ID_Cliente, ID_Servicio, puntuacion, comentario, fecha_creacion, fecha_modificacion)
                VALUES 
                (@idEmpleado, @idCliente, @idServicio, @puntuacion, @comentario, NOW(), NOW())
                ON DUPLICATE KEY UPDATE
                puntuacion = @puntuacion,
                comentario = @comentario,
                fecha_modificacion = NOW()";

            try
            {
                using (var db = new BDConector())
                {
                    db.Open();
                    using (var cmd = new MySqlCommand(query, db._connection))
                    {
                        cmd.Parameters.AddWithValue("@idEmpleado", _idEmpleado);
                        cmd.Parameters.AddWithValue("@idCliente", UserSession.IdUsuario);
                        cmd.Parameters.AddWithValue("@idServicio", _idServicio);
                        cmd.Parameters.AddWithValue("@puntuacion", _calificacionSeleccionada);
                        cmd.Parameters.AddWithValue("@comentario", txtComentario.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error guardando calificación: {ex.Message}");
                return false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar longitud máxima
            if (txtComentario.Text.Length >= 500 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }
    }
}
