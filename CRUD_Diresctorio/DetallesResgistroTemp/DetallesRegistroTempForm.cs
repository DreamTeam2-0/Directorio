// DetallesRegistroTempForm.cs
using Utilities;
using DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DetallesRegistroTemp
{
    public partial class DetallesRegistroTempForm : Form
    {
        private int idTemp;
        private string tipoRegistro;

        public DetallesRegistroTempForm(int idTemp, string tipoRegistro)
        {
            this.idTemp = idTemp;
            this.tipoRegistro = tipoRegistro;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();

                    // Cargar datos básicos
                    LoadBasicData(db);

                    // Cargar datos específicos según tipo
                    if (tipoRegistro == "certificado")
                    {
                        LoadCertificadoData(db);
                        Text = "Detalles - Registro Certificado";
                    }
                    else if (tipoRegistro == "empirico")
                    {
                        LoadEmpiricoData(db);
                        Text = "Detalles - Registro Empírico";
                    }

                    // Cargar especialidades
                    LoadEspecialidades(db);

                    // Cargar archivos
                    LoadArchivos(db);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error loading temp details: {ex.Message}");
            }
        }

        private void LoadBasicData(BDConector db)
        {
            string query = @"
                SELECT 
                    username,
                    nombres,
                    apellidos,
                    email,
                    telefono,
                    ciudad,
                    direccion_aproximada,
                    zonas_servicio,
                    estado,
                    DATE_FORMAT(fecha_creacion, '%d/%m/%Y %H:%i:%s') as fecha_creacion,
                    DATE_FORMAT(fecha_modificacion, '%d/%m/%Y %H:%i:%s') as fecha_modificacion
                FROM temp_registros 
                WHERE ID_Temp = @idTemp";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idTemp", idTemp)
            };

            using (var reader = db.ExecuteReader(query, parameters))
            {
                if (reader.Read())
                {
                    lblUsername.Text = reader["username"].ToString();
                    lblNombres.Text = reader["nombres"].ToString();
                    lblApellidos.Text = reader["apellidos"].ToString();
                    lblEmail.Text = reader["email"].ToString();
                    lblTelefono.Text = reader["telefono"].ToString();
                    lblCiudad.Text = reader["ciudad"].ToString();
                    lblDireccion.Text = reader["direccion_aproximada"].ToString();
                    lblZonas.Text = reader["zonas_servicio"].ToString();
                    lblEstado.Text = reader["estado"].ToString();
                    lblFechaCreacion.Text = reader["fecha_creacion"].ToString();
                    lblFechaModificacion.Text = reader["fecha_modificacion"].ToString();

                    // Cambiar color según estado
                    switch (lblEstado.Text.ToLower())
                    {
                        case "pendiente":
                            lblEstado.ForeColor = Color.Orange;
                            break;
                        case "confirmado":
                            lblEstado.ForeColor = Color.Green;
                            break;
                        case "rechazado":
                            lblEstado.ForeColor = Color.Red;
                            break;
                    }
                }
            }
        }

        private void LoadCertificadoData(BDConector db)
        {
            string query = @"
                SELECT 
                    nivel_estudios,
                    anos_experiencia,
                    empresas_anteriores,
                    proyectos_destacados,
                    referencias_laborales,
                    DATE_FORMAT(fecha_creacion, '%d/%m/%Y %H:%i:%s') as fecha_creacion
                FROM temp_certificaciones 
                WHERE ID_Temp = @idTemp";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idTemp", idTemp)
            };

            using (var reader = db.ExecuteReader(query, parameters))
            {
                if (reader.Read())
                {
                    lblNivelEstudios.Text = reader["nivel_estudios"].ToString();
                    lblAnosExperiencia.Text = reader["anos_experiencia"].ToString() + " años";
                    lblEmpresas.Text = reader["empresas_anteriores"].ToString();
                    lblProyectos.Text = reader["proyectos_destacados"].ToString();
                    lblReferencias.Text = reader["referencias_laborales"].ToString();
                    lblFechaCert.Text = reader["fecha_creacion"].ToString();

                    // Mostrar pestaña de certificaciones
                    tabControl1.TabPages.Add(tabPageCertificaciones);
                }
            }
        }

        private void LoadEmpiricoData(BDConector db)
        {
            string query = @"
                SELECT 
                    anos_experiencia,
                    tipo_experiencia,
                    descripcion_otro,
                    DATE_FORMAT(fecha_creacion, '%d/%m/%Y %H:%i:%s') as fecha_creacion
                FROM temp_experiencia_empirica 
                WHERE ID_Temp = @idTemp";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idTemp", idTemp)
            };

            using (var reader = db.ExecuteReader(query, parameters))
            {
                if (reader.Read())
                {
                    lblExpAnos.Text = reader["anos_experiencia"].ToString();
                    lblTipoExp.Text = reader["tipo_experiencia"].ToString();
                    lblDescripcionOtro.Text = reader["descripcion_otro"].ToString();
                    lblFechaExp.Text = reader["fecha_creacion"].ToString();

                    // Mostrar pestaña de experiencia empírica
                    tabControl1.TabPages.Add(tabPageExperiencia);
                }
            }
        }

        private void LoadEspecialidades(BDConector db)
        {
            string query = @"
                SELECT 
                    categorias,
                    sub_especialidades,
                    herramientas,
                    descripcion_servicios,
                    DATE_FORMAT(fecha_creacion, '%d/%m/%Y %H:%i:%s') as fecha_creacion
                FROM temp_especialidades 
                WHERE ID_Temp = @idTemp";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idTemp", idTemp)
            };

            using (var reader = db.ExecuteReader(query, parameters))
            {
                if (reader.Read())
                {
                    lblCategorias.Text = reader["categorias"].ToString();
                    lblSubEspecialidades.Text = reader["sub_especialidades"].ToString();
                    lblHerramientas.Text = reader["herramientas"].ToString();
                    lblDescripcionServicios.Text = reader["descripcion_servicios"].ToString();
                    lblFechaEsp.Text = reader["fecha_creacion"].ToString();

                    // Mostrar pestaña de especialidades
                    tabControl1.TabPages.Add(tabPageEspecialidades);
                }
            }
        }

        private void LoadArchivos(BDConector db)
        {
            string query = @"
                SELECT 
                    ID_Temp_Archivo,
                    nombre_archivo,
                    tipo_archivo,
                    categoria_archivo,
                    obligatorio,
                    DATE_FORMAT(fecha_creacion, '%d/%m/%Y %H:%i:%s') as fecha_creacion,
                    LENGTH(contenido) as tamanio_bytes
                FROM temp_archivos 
                WHERE ID_Temp = @idTemp
                ORDER BY categoria_archivo, nombre_archivo";

            MySqlParameter[] parameters = {
                new MySqlParameter("@idTemp", idTemp)
            };

            DataTable dt = db.ExecuteDataTable(query, parameters);

            dgvArchivos.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                long tamanioBytes = Convert.ToInt64(row["tamanio_bytes"]);
                string tamanioFormateado = FormatFileSize(tamanioBytes);
                string obligatorio = (bool)row["obligatorio"] ? "Sí" : "No";

                dgvArchivos.Rows.Add(
                    row["ID_Temp_Archivo"],
                    row["nombre_archivo"],
                    row["tipo_archivo"],
                    row["categoria_archivo"],
                    tamanioFormateado,
                    obligatorio,
                    row["fecha_creacion"]
                );
            }

            lblTotalArchivos.Text = $"Total archivos: {dt.Rows.Count}";

            // Mostrar pestaña de archivos si hay
            if (dt.Rows.Count > 0)
            {
                tabControl1.TabPages.Add(tabPageArchivos);
            }
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double len = bytes;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        private void btnDescargarArchivo_Click(object sender, EventArgs e)
        {
            if (dgvArchivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un archivo para descargar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvArchivos.SelectedRows[0];
            int idArchivo = Convert.ToInt32(row.Cells["ID_Archivo"].Value);
            string nombreArchivo = row.Cells["Nombre"].Value.ToString();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = nombreArchivo;
            saveFileDialog.Filter = "Todos los archivos (*.*)|*.*";
            saveFileDialog.Title = "Guardar archivo";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DescargarArchivo(idArchivo, saveFileDialog.FileName, nombreArchivo);
            }
        }

        private void DescargarArchivo(int idArchivo, string destino, string nombreOriginal)
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();

                    string query = "SELECT contenido FROM temp_archivos WHERE ID_Temp_Archivo = @id";

                    MySqlParameter[] parameters = {
                        new MySqlParameter("@id", idArchivo)
                    };

                    object result = db.ExecuteScalar(query, parameters);

                    if (result != null && result != DBNull.Value)
                    {
                        byte[] fileBytes = (byte[])result;
                        File.WriteAllBytes(destino, fileBytes);

                        MessageBox.Show($"Archivo descargado exitosamente\n\n" +
                                      $"Nombre: {nombreOriginal}\n" +
                                      $"Tamaño: {FormatFileSize(fileBytes.Length)}\n" +
                                      $"Destino: {destino}",
                            "Descarga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Logger.LogInfo($"Downloaded temp file: {nombreOriginal} (ID: {idArchivo})");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al descargar archivo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error downloading temp file: {ex.Message}");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de impresión no implementada", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvArchivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnDescargarArchivo_Click(sender, e);
            }
        }
    }
}