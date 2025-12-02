// CrudTabPage.cs
using System;
using System.Data;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;
using Utilities;
using System.Collections.Generic;

namespace CRUD_Directorio.CRUD
{
    public partial class CrudTabPage : UserControl
    {
        private DataTable currentDataTable;
        private bool isEditing = false;
        private int currentEditId = 0;
        private string currentTable = "";

        public CrudTabPage()
        {
            InitializeComponent();
            LoadTables();
            ConfigureDataGridView();
        }

        private void LoadTables()
        {
            cmbTablas.Items.Clear();

            string[] tablas = {
                "roles",
                "usuarios_sistema",
                "usuarios",
                "categorias",
                "denominaciones",
                "datos_usuario",
                "servicios",
                "sistema_calificacion",
                "acciones_sistema",
                "experiencia_usuario",
                "archivos_proveedor",
                "archivos_generales"
            };

            cmbTablas.Items.AddRange(tablas);

            if (cmbTablas.Items.Count > 0)
                cmbTablas.SelectedIndex = 0;
        }

        private void LoadTableData()
        {
            if (cmbTablas.SelectedItem == null) return;

            currentTable = cmbTablas.SelectedItem.ToString();

            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();
                    currentDataTable = DatabaseHelper.GetTableData(db, currentTable);

                    // FILTRAR COLUMNAS BINARIAS (BLOB) - SOLUCIÓN PRINCIPAL
                    DataTable filteredTable = FilterBinaryColumns(currentDataTable);

                    dgvCrud.DataSource = filteredTable;

                    lblTotalRegistros.Text = $"Total: {filteredTable.Rows.Count} registros";
                    ClearForm();
                    DisableForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error loading table data: {ex.Message}");
            }
        }

        private DataTable FilterBinaryColumns(DataTable originalTable)
        {
            // Crear una copia de la estructura de la tabla
            DataTable filteredTable = originalTable.Clone();

            // Identificar columnas binarias para excluir
            List<string> binaryColumns = new List<string>();
            foreach (DataColumn column in filteredTable.Columns)
            {
                if (column.DataType == typeof(byte[]))
                {
                    binaryColumns.Add(column.ColumnName);
                }
            }

            // Eliminar columnas binarias del clon
            foreach (string columnName in binaryColumns)
            {
                filteredTable.Columns.Remove(columnName);
            }

            // Copiar los datos excluyendo las columnas binarias
            foreach (DataRow row in originalTable.Rows)
            {
                DataRow newRow = filteredTable.NewRow();

                foreach (DataColumn column in filteredTable.Columns)
                {
                    newRow[column] = row[column.ColumnName];
                }

                filteredTable.Rows.Add(newRow);
            }

            return filteredTable;
        }


        private void ShowHiddenColumnsInfo(DataTable originalTable, DataTable filteredTable)
        {
            // Verificar si se ocultaron columnas
            int hiddenCount = originalTable.Columns.Count - filteredTable.Columns.Count;

            if (hiddenCount > 0)
            {
                // Crear lista de columnas ocultas
                List<string> hiddenColumns = new List<string>();
                foreach (DataColumn column in originalTable.Columns)
                {
                    if (column.DataType == typeof(byte[]) &&
                        !filteredTable.Columns.Contains(column.ColumnName))
                    {
                        hiddenColumns.Add(column.ColumnName);
                    }
                }

                // Mostrar información (puedes usar un Label adicional o un tooltip)
                string info = $"Columnas ocultas (archivos binarios): {string.Join(", ", hiddenColumns)}";

                // Opcional: Mostrar en un Label si tienes uno
                // lblInfoColumnas.Text = info;
                // lblInfoColumnas.Visible = true;

                Logger.LogInfo($"Tabla {currentTable}: Se ocultaron {hiddenCount} columnas binarias");
            }
        }

        private void ConfigureDataGridView()
        {
            // Configurar propiedades del DataGridView
            dgvCrud.AutoGenerateColumns = true;
            dgvCrud.AllowUserToAddRows = false;
            dgvCrud.AllowUserToDeleteRows = false;
            dgvCrud.ReadOnly = true;
            dgvCrud.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCrud.MultiSelect = false;

            // Manejar error de datos por si acaso
            dgvCrud.DataError += dgvCrud_DataError;
        }

        private void dgvCrud_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Manejar errores de datos silenciosamente
            e.ThrowException = false;
            e.Cancel = true;
            Logger.LogWarning($"DataGridView error suppressed: {e.Exception.Message}");
        }

        private void cmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTableData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTableData();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm();
            isEditing = false;
            currentEditId = 0;
            lblAccion.Text = "NUEVO REGISTRO";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCrud.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para editar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvCrud.SelectedRows[0];
            LoadDataForEdit(row);
            EnableForm();
            isEditing = true;
            lblAccion.Text = "EDITAR REGISTRO";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCrud.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvCrud.SelectedRows[0];
            object id = row.Cells[0].Value;

            if (MessageBox.Show($"¿Está seguro de eliminar este registro de {currentTable}?\nID: {id}",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteRecord(id);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (isEditing)
                {
                    UpdateRecord();
                }
                else
                {
                    InsertRecord();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm();
            DisableForm();
        }

        private void LoadDataForEdit(DataGridViewRow row)
        {
            switch (currentTable)
            {
                case "roles":
                    txtNombre.Text = row.Cells["nombre"].Value?.ToString() ?? "";
                    txtDescripcion.Text = row.Cells["descripcion"].Value?.ToString() ?? "";
                    currentEditId = Convert.ToInt32(row.Cells["ID_Rol"].Value);
                    break;

                case "categorias":
                    txtNombre.Text = row.Cells["nombre"].Value?.ToString() ?? "";
                    txtDescripcion.Text = row.Cells["descripcion"].Value?.ToString() ?? "";
                    txtIcono.Text = row.Cells["icono"].Value?.ToString() ?? "";
                    txtColor.Text = row.Cells["color"].Value?.ToString() ?? "";
                    currentEditId = Convert.ToInt32(row.Cells["ID_Categoria"].Value);
                    break;
            }
        }

        private void ClearForm()
        {
            foreach (Control control in panelFormulario.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).Clear();
                else if (control is ComboBox)
                    ((ComboBox)control).SelectedIndex = -1;
            }
        }

        private void EnableForm()
        {
            foreach (Control control in panelFormulario.Controls)
                control.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            panelFormulario.Visible = true;
        }

        private void DisableForm()
        {
            foreach (Control control in panelFormulario.Controls)
                control.Enabled = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            panelFormulario.Visible = false;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void InsertRecord()
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();
                    string query = "";
                    MySqlParameter[] parameters = null;

                    switch (currentTable)
                    {
                        case "roles":
                            query = "INSERT INTO roles (nombre, descripcion) VALUES (@nombre, @descripcion)";
                            parameters = new MySqlParameter[] {
                                new MySqlParameter("@nombre", txtNombre.Text),
                                new MySqlParameter("@descripcion", txtDescripcion.Text)
                            };
                            break;

                        case "categorias":
                            query = "INSERT INTO categorias (nombre, descripcion, icono, color) VALUES (@nombre, @descripcion, @icono, @color)";
                            parameters = new MySqlParameter[] {
                                new MySqlParameter("@nombre", txtNombre.Text),
                                new MySqlParameter("@descripcion", txtDescripcion.Text),
                                new MySqlParameter("@icono", txtIcono.Text),
                                new MySqlParameter("@color", txtColor.Text)
                            };
                            break;
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        int result = db.ExecuteNonQuery(query, parameters);

                        if (result > 0)
                        {
                            MessageBox.Show("Registro insertado exitosamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Logger.LogInfo($"Inserted new record in {currentTable}");
                            LoadTableData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar registro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error inserting record: {ex.Message}");
            }
        }

        private void UpdateRecord()
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();
                    string query = "";
                    MySqlParameter[] parameters = null;

                    switch (currentTable)
                    {
                        case "roles":
                            query = "UPDATE roles SET nombre = @nombre, descripcion = @descripcion WHERE ID_Rol = @id";
                            parameters = new MySqlParameter[] {
                                new MySqlParameter("@nombre", txtNombre.Text),
                                new MySqlParameter("@descripcion", txtDescripcion.Text),
                                new MySqlParameter("@id", currentEditId)
                            };
                            break;

                        case "categorias":
                            query = "UPDATE categorias SET nombre = @nombre, descripcion = @descripcion, icono = @icono, color = @color WHERE ID_Categoria = @id";
                            parameters = new MySqlParameter[] {
                                new MySqlParameter("@nombre", txtNombre.Text),
                                new MySqlParameter("@descripcion", txtDescripcion.Text),
                                new MySqlParameter("@icono", txtIcono.Text),
                                new MySqlParameter("@color", txtColor.Text),
                                new MySqlParameter("@id", currentEditId)
                            };
                            break;
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        int result = db.ExecuteNonQuery(query, parameters);

                        if (result > 0)
                        {
                            MessageBox.Show("Registro actualizado exitosamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Logger.LogInfo($"Updated record in {currentTable} ID: {currentEditId}");
                            LoadTableData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar registro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error updating record: {ex.Message}");
            }
        }

        private void DeleteRecord(object id)
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();
                    string pkColumn = DatabaseHelper.GetPrimaryKeyColumn(currentTable);
                    string query = $"DELETE FROM {currentTable} WHERE {pkColumn} = @id";

                    MySqlParameter[] parameters = {
                        new MySqlParameter("@id", id)
                    };

                    int result = db.ExecuteNonQuery(query, parameters);

                    if (result > 0)
                    {
                        MessageBox.Show("Registro eliminado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.LogInfo($"Deleted record from {currentTable} ID: {id}");
                        LoadTableData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar registro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error deleting record: {ex.Message}");
            }
        }
    }
}