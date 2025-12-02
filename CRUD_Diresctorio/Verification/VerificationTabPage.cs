// VerificationTabPage.cs
using System;
using System.Data;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;
using Utilities;
using DetallesRegistroTemp;
using Shared.Session;

namespace Verification
{
    public partial class VerificationTabPage : UserControl
    {
        private DataTable tempRegistrosData;

        public VerificationTabPage()
        {
            InitializeComponent();
            LoadRoles();
            LoadTempRegistros();
        }

        private void LoadRoles()
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();
                    string query = "SELECT ID_Rol, nombre FROM roles WHERE nombre IN ('empleado', 'cliente') ORDER BY nombre";

                    DataTable dt = db.ExecuteDataTable(query);
                    cmbRolAsignar.DataSource = dt;
                    cmbRolAsignar.DisplayMember = "nombre";
                    cmbRolAsignar.ValueMember = "ID_Rol";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error loading roles: {ex.Message}");
            }
        }

        private void LoadTempRegistros()
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();
                    string query = @"
                        SELECT 
                            r.ID_Temp,
                            r.tipo_registro,
                            r.username,
                            r.nombres,
                            r.apellidos,
                            r.email,
                            r.telefono,
                            r.ciudad,
                            r.estado,
                            DATE_FORMAT(r.fecha_creacion, '%d/%m/%Y %H:%i') as fecha_creacion,
                            CASE r.tipo_registro
                                WHEN 'certificado' THEN c.nivel_estudios
                                WHEN 'empirico' THEN e.anos_experiencia
                                ELSE 'No especificado'
                            END as info_adicional
                        FROM temp_registros r
                        LEFT JOIN temp_certificaciones c ON r.ID_Temp = c.ID_Temp
                        LEFT JOIN temp_experiencia_empirica e ON r.ID_Temp = e.ID_Temp
                        WHERE r.estado = 'pendiente'
                        ORDER BY r.fecha_creacion DESC";

                    tempRegistrosData = db.ExecuteDataTable(query);
                    dgvRegistrosTemp.DataSource = tempRegistrosData;

                    if (tempRegistrosData.Rows.Count == 0)
                    {
                        lblInfoTemp.Text = "No hay registros temporales pendientes";
                        lblInfoTemp.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        lblInfoTemp.Text = $"Hay {tempRegistrosData.Rows.Count} registros pendientes de revisión";
                        lblInfoTemp.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar registros temporales: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error loading temp registros: {ex.Message}");
            }
        }

        private void txtBuscarTemp_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarTemp.Text.ToLower();

            if (tempRegistrosData != null)
            {
                if (string.IsNullOrWhiteSpace(filtro))
                {
                    tempRegistrosData.DefaultView.RowFilter = "";
                }
                else
                {
                    string filterExpression =
                        $"nombres LIKE '%{filtro}%' OR " +
                        $"apellidos LIKE '%{filtro}%' OR " +
                        $"email LIKE '%{filtro}%' OR " +
                        $"username LIKE '%{filtro}%' OR " +
                        $"ciudad LIKE '%{filtro}%' OR " +
                        $"tipo_registro LIKE '%{filtro}%'";
                    tempRegistrosData.DefaultView.RowFilter = filterExpression;
                }
            }
        }

        private void btnRefreshTemp_Click(object sender, EventArgs e)
        {
            LoadTempRegistros();
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvRegistrosTemp.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para ver detalles", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvRegistrosTemp.SelectedRows[0];
            int idTemp = Convert.ToInt32(row.Cells["ID_Temp"].Value);
            string tipoRegistro = row.Cells["tipo_registro"].Value.ToString();

            DetallesRegistroTempForm detallesForm = new DetallesRegistroTempForm(idTemp, tipoRegistro);
            detallesForm.ShowDialog();

            // Refrescar después de ver detalles
            LoadTempRegistros();
        }

        private void btnConfirmarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvRegistrosTemp.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para confirmar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbRolAsignar.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un rol para asignar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvRegistrosTemp.SelectedRows[0];
            int idTemp = Convert.ToInt32(row.Cells["ID_Temp"].Value);
            string username = row.Cells["username"].Value.ToString();
            string tipoRegistro = row.Cells["tipo_registro"].Value.ToString();
            string rolAsignado = cmbRolAsignar.Text;
            int idRol = Convert.ToInt32(cmbRolAsignar.SelectedValue);

            // Validar que si es certificado o empírico, se asigne rol "empleado"
            if ((tipoRegistro == "certificado" || tipoRegistro == "empirico") && rolAsignado != "empleado")
            {
                MessageBox.Show($"Para el tipo '{tipoRegistro}' debe asignar el rol 'empleado'",
                    "Error de asignación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje = $"¿Confirmar registro de {username} como {rolAsignado}?\n\n" +
                           $"Tipo: {tipoRegistro}\n" +
                           $"Nombre: {row.Cells["nombres"].Value} {row.Cells["apellidos"].Value}\n" +
                           $"Email: {row.Cells["email"].Value}\n" +
                           $"Ciudad: {row.Cells["ciudad"].Value}";

            if (MessageBox.Show(mensaje, "Confirmar Registro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ConfirmarRegistro(idTemp, idRol, username);
            }
        }

        private void btnRechazarRegistro_Click(object sender, EventArgs e)
        {
            if (dgvRegistrosTemp.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para rechazar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvRegistrosTemp.SelectedRows[0];
            int idTemp = Convert.ToInt32(row.Cells["ID_Temp"].Value);
            string username = row.Cells["username"].Value.ToString();
            string nombres = row.Cells["nombres"].Value.ToString();
            string apellidos = row.Cells["apellidos"].Value.ToString();

            if (MessageBox.Show($"¿Rechazar registro de {username} ({nombres} {apellidos})?\n\nEsta acción no se puede deshacer.",
                "Rechazar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                RechazarRegistro(idTemp, username);
            }
        }

        private void ConfirmarRegistro(int idTemp, int idRol, string username)
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();

                    // Llamar al procedimiento almacenado
                    string query = "CALL confirmar_registro(@idTemp, @idRol)";

                    MySqlParameter[] parameters = {
                new MySqlParameter("@idTemp", idTemp),
                new MySqlParameter("@idRol", idRol)
            };

                    // Usar ExecuteScalar para capturar el mensaje de retorno
                    object result = db.ExecuteScalar(query, parameters);

                    if (result != null)
                    {
                        string mensaje = result.ToString();
                        MessageBox.Show(mensaje, "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Registrar acción en sistema
                        RegistrarAccionSistema($"Confirmó registro temporal ID: {idTemp} (Usuario: {username}) como rol ID: {idRol}");

                        Logger.LogInfo($"Confirmed temp registration ID: {idTemp} as role ID: {idRol}");
                        Logger.LogInfo($"Mensaje del procedimiento: {mensaje}");

                        // Actualizar la lista
                        LoadTempRegistros();
                    }
                    else
                    {
                        // Si no hay mensaje pero la ejecución fue exitosa
                        MessageBox.Show("Registro confirmado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RegistrarAccionSistema($"Confirmó registro temporal ID: {idTemp} (Usuario: {username}) como rol ID: {idRol}");
                        Logger.LogInfo($"Confirmed temp registration ID: {idTemp} as role ID: {idRol}");

                        LoadTempRegistros();
                    }
                }
            }
            catch (Exception ex)
            {
                // Verificar si fue un error de conexión después de una operación exitosa
                if (ex.Message.Contains("connection") || ex.Message.Contains("timeout"))
                {
                    // Podría haberse insertado pero perdido la conexión
                    MessageBox.Show("La operación se completó pero hubo un problema de comunicación. " +
                                  "Verifique en la base de datos si el registro fue procesado.",
                                  "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Recargar para verificar
                    LoadTempRegistros();
                }
                else
                {
                    MessageBox.Show($"Error al confirmar registro: {ex.Message}\n\n" +
                                  "Asegúrese de que el procedimiento 'confirmar_registro' existe en la base de datos.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.LogError($"Error confirming registration: {ex.Message}");
                }
            }
        }

        private void RechazarRegistro(int idTemp, string username)
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();

                    string query = "UPDATE temp_registros SET estado = 'rechazado' WHERE ID_Temp = @idTemp";
                    MySqlParameter[] parameters = {
                        new MySqlParameter("@idTemp", idTemp)
                    };

                    int result = db.ExecuteNonQuery(query, parameters);

                    if (result > 0)
                    {
                        MessageBox.Show("Registro rechazado", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RegistrarAccionSistema($"Rechazó registro temporal ID: {idTemp} (Usuario: {username})");
                        Logger.LogInfo($"Rejected temp registration ID: {idTemp}");

                        LoadTempRegistros();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al rechazar registro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error rejecting registration: {ex.Message}");
            }
        }

        private void RegistrarAccionSistema(string accion)
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();

                    string query = @"
                        INSERT INTO acciones_sistema 
                        (ID_Usuario_Sistema, accion, tabla_afectada, registro_afectado_id, detalles) 
                        VALUES (@idUsuario, @accion, 'temp_registros', NULL, @detalles)";

                    MySqlParameter[] parameters = {
                        new MySqlParameter("@idUsuario", UserSession.IdUsuario),
                        new MySqlParameter("@accion", accion),
                        new MySqlParameter("@detalles", $"Acción desde sistema admin: {accion}")
                    };

                    db.ExecuteNonQuery(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error registering system action: {ex.Message}");
            }
        }

        private void dgvRegistrosTemp_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRegistrosTemp.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvRegistrosTemp.SelectedRows[0];
                string tipoRegistro = row.Cells["tipo_registro"].Value.ToString();

                // Si es certificado o empírico, forzar rol "empleado"
                if (tipoRegistro == "certificado" || tipoRegistro == "empirico")
                {
                    // Buscar el índice del rol "empleado" en el combo
                    for (int i = 0; i < cmbRolAsignar.Items.Count; i++)
                    {
                        DataRowView item = (DataRowView)cmbRolAsignar.Items[i];
                        if (item["nombre"].ToString() == "empleado")
                        {
                            cmbRolAsignar.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }
    }
}