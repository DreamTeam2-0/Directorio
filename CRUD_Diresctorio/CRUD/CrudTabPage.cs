// CrudTabPage.cs
using System;
using System.Data;
using System.Windows.Forms;
using DataBase;
using MySql.Data.MySqlClient;
using Utilities;
using System.Collections.Generic;
using CRUD_Directorio.CRUD.CRUD_System;

namespace CRUD_Directorio.CRUD
{
    public partial class CrudTabPage : UserControl
    {
        private DataTable currentDataTable;
        private bool isEditing = false;
        private int currentEditId = 0;
        private string currentTable = "";

        // Instancias de controladores específicos
        private CrudRoles crudRoles;
        private CrudUsuariosSistema crudUsuariosSistema;
        private CrudUsuarios crudUsuarios;
        private CrudCategorias crudCategorias;
        private CrudDenominaciones crudDenominaciones;
        private CrudDatosUsuario crudDatosUsuario;
        private CrudServicios crudServicios;
        private CrudCalificaciones crudCalificaciones;
        private CrudAccionesSistema crudAccionesSistema;
        private CrudExperienciaUsuario crudExperienciaUsuario;
        private CrudArchivosProveedor crudArchivosProveedor;
        private CrudArchivosGenerales crudArchivosGenerales;


        public CrudTabPage()
        {
            InitializeComponent();

            // Depuración: mostrar posiciones
            MessageBox.Show($"Botón Nuevo: {btnNuevo.Location}, Visible: {btnNuevo.Visible}");
            MessageBox.Show($"Panel Formulario: {panelFormulario.Location}, Visible: {panelFormulario.Visible}");

            // Forzar visibilidad y posición
            btnNuevo.Visible = true;
            btnNuevo.BringToFront(); // Traer al frente

            InitializeCrudControllers();
            LoadTables();
            ConfigureDataGridView();

            // Suscribir eventos
            cmbTablas.SelectedIndexChanged += cmbTablas_SelectedIndexChanged;
            btnRefresh.Click += btnRefresh_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void InitializeCrudControllers()
        {
            crudRoles = new CrudRoles();
            crudUsuariosSistema = new CrudUsuariosSistema();
            crudUsuarios = new CrudUsuarios();
            crudCategorias = new CrudCategorias();
            crudDenominaciones = new CrudDenominaciones();
            crudDatosUsuario = new CrudDatosUsuario();
            crudServicios = new CrudServicios();
            crudCalificaciones = new CrudCalificaciones();
            crudAccionesSistema = new CrudAccionesSistema();
            crudExperienciaUsuario = new CrudExperienciaUsuario();
            crudArchivosProveedor = new CrudArchivosProveedor();
            crudArchivosGenerales = new CrudArchivosGenerales();

            // Pasar referencias del formulario padre
            crudRoles.SetParentControl(this);
            crudUsuariosSistema.SetParentControl(this);
            crudUsuarios.SetParentControl(this);
            crudCategorias.SetParentControl(this);
            crudDenominaciones.SetParentControl(this);
            crudDatosUsuario.SetParentControl(this);
            crudServicios.SetParentControl(this);
            crudCalificaciones.SetParentControl(this);
            crudAccionesSistema.SetParentControl(this);
            crudExperienciaUsuario.SetParentControl(this);
            crudArchivosProveedor.SetParentControl(this);
            crudArchivosGenerales.SetParentControl(this);

            // Configurar controles específicos para cada controlador
            crudRoles.SetControls(txtNombreRol, txtDescripcionRol);

            crudUsuariosSistema.SetControls(
                txtUsernameSistema, txtEmailSistema, txtPasswordSistema,
                txtIDRolSistema, txtNombresSistema, txtApellidosSistema,
                txtTelefonoSistema, chkActivoSistema);

            crudUsuarios.SetControls(
                txtUsernameUsuario, txtPasswordUsuario,
                txtIDRolUsuario, chkActivoUsuario);

            crudCategorias.SetControls(
                txtNombreCategoria, txtDescripcionCategoria,
                txtIconoCategoria, txtColorCategoria, chkActivaCategoria);

            crudDenominaciones.SetControls(
                txtIDCategoriaDenominacion, txtNombreDenominacion,
                txtDescripcionDenominacion);

            crudDatosUsuario.SetControls(
                txtIDUsuarioDatos, txtNombresDatos, txtApellidosDatos,
                txtCiudadDatos, txtDireccionDatos, txtEmailDatos,
                txtTelefonoDatos, txtWhatsappDatos, txtOtroContactoDatos,
                txtIdentificacionOficial, txtZonasServicio);

            crudServicios.SetControls(
                txtIDUsuarioServicio, txtIDCategoriaServicio,
                txtIDDenominacionServicio, txtTituloServicio,
                txtDescripcionServicio, cmbTipoPrecioServicio,
                txtMonedaServicio, txtDisponibilidadServicio,
                txtRadioCoberturaServicio, txtExperienciaServicio);

            crudCalificaciones.SetControls(
                txtIDEmpleadoCalificacion, txtIDClienteCalificacion,
                txtIDServicioCalificacion, nudPuntuacionCalificacion,
                txtComentarioCalificacion);

            crudAccionesSistema.SetControls(
                txtIDUsuarioSistemaAccion, txtAccionSistema,
                txtTablaAfectadaAccion, txtRegistroAfectadoAccion,
                txtDetallesAccion);

            crudExperienciaUsuario.SetControls(
                txtIDUsuarioExperiencia, cmbTipoRegistroExperiencia,
                cmbNivelEstudiosExperiencia, txtAnosExperiencia,
                txtEmpresasAnteriores, txtProyectosDestacados,
                txtReferenciasLaborales, txtTipoExperiencia,
                txtDescripcionOtro);

            crudArchivosProveedor.SetControls(
                txtIDUsuarioArchivoProveedor, txtNombreArchivoProveedor,
                cmbTipoArchivoProveedor, cmbCategoriaArchivoProveedor,
                chkObligatorioArchivo, lblArchivoSeleccionadoProveedor);

            crudArchivosGenerales.SetControls(
                txtNombreArchivoGeneral, cmbTipoArchivoGeneral,
                txtCategoriaArchivoGeneral, txtDescripcionArchivoGeneral,
                lblArchivoSeleccionadoGeneral);
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

                    // FILTRAR COLUMNAS BINARIAS (BLOB)
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
            DataTable filteredTable = originalTable.Clone();
            List<string> binaryColumns = new List<string>();

            foreach (DataColumn column in filteredTable.Columns)
            {
                if (column.DataType == typeof(byte[]))
                {
                    binaryColumns.Add(column.ColumnName);
                }
            }

            foreach (string columnName in binaryColumns)
            {
                filteredTable.Columns.Remove(columnName);
            }

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

        private void ConfigureDataGridView()
        {
            dgvCrud.AutoGenerateColumns = true;
            dgvCrud.AllowUserToAddRows = false;
            dgvCrud.AllowUserToDeleteRows = false;
            dgvCrud.ReadOnly = true;
            dgvCrud.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCrud.MultiSelect = false;
            dgvCrud.DataError += dgvCrud_DataError;
        }

        private void dgvCrud_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
            Logger.LogWarning($"DataGridView error suppressed: {e.Exception.Message}");
        }

        private void cmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTablas.SelectedItem == null) return;

                currentTable = cmbTablas.SelectedItem.ToString();
                ClearAllPanels();
                DisableForm();
                LoadTableData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar tabla: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTableData();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearAllPanels();
            EnableForm();
            isEditing = false;
            currentEditId = 0;
            lblAccion.Text = "NUEVO REGISTRO";
            ShowPanelForCurrentTable();
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
            ShowPanelForCurrentTable();
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
            try
            {
                ShowPanelForCurrentTable();

                switch (currentTable)
                {
                    case "roles":
                        crudRoles.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "usuarios_sistema":
                        crudUsuariosSistema.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "usuarios":
                        crudUsuarios.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "categorias":
                        crudCategorias.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "denominaciones":
                        crudDenominaciones.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "datos_usuario":
                        crudDatosUsuario.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "servicios":
                        crudServicios.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "sistema_calificacion":
                        crudCalificaciones.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "acciones_sistema":
                        crudAccionesSistema.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "experiencia_usuario":
                        crudExperienciaUsuario.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "archivos_proveedor":
                        crudArchivosProveedor.LoadDataForEdit(row, ref currentEditId);
                        break;
                    case "archivos_generales":
                        crudArchivosGenerales.LoadDataForEdit(row, ref currentEditId);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos para edición: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error loading data for edit: {ex.Message}");
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
            panelFormulario.Visible = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void DisableForm()
        {
            panelFormulario.Visible = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            HideAllPanels();
        }

        private bool ValidateForm()
        {
            switch (currentTable)
            {
                case "roles":
                    return crudRoles.ValidateForm();
                case "usuarios_sistema":
                    return crudUsuariosSistema.ValidateForm();
                case "usuarios":
                    return crudUsuarios.ValidateForm();
                case "categorias":
                    return crudCategorias.ValidateForm();
                case "denominaciones":
                    return crudDenominaciones.ValidateForm();
                case "datos_usuario":
                    return crudDatosUsuario.ValidateForm();
                case "servicios":
                    return crudServicios.ValidateForm();
                case "sistema_calificacion":
                    return crudCalificaciones.ValidateForm();
                case "acciones_sistema":
                    return crudAccionesSistema.ValidateForm();
                case "experiencia_usuario":
                    return crudExperienciaUsuario.ValidateForm();
                case "archivos_proveedor":
                    return crudArchivosProveedor.ValidateForm();
                case "archivos_generales":
                    return crudArchivosGenerales.ValidateForm();
                default:
                    return ValidateBasicForm();
            }
        }

        private bool ValidateBasicForm()
        {
            // Validaciones básicas para tablas no implementadas
            MessageBox.Show("Validación no implementada para esta tabla", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void InsertRecord()
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();
                    bool success = false;

                    switch (currentTable)
                    {
                        case "roles":
                            success = crudRoles.InsertRecord(db);
                            break;
                        case "usuarios_sistema":
                            success = crudUsuariosSistema.InsertRecord(db);
                            break;
                        case "usuarios":
                            success = crudUsuarios.InsertRecord(db);
                            break;
                        case "categorias":
                            success = crudCategorias.InsertRecord(db);
                            break;
                        case "denominaciones":
                            success = crudDenominaciones.InsertRecord(db);
                            break;
                        case "datos_usuario":
                            success = crudDatosUsuario.InsertRecord(db);
                            break;
                        case "servicios":
                            success = crudServicios.InsertRecord(db);
                            break;
                        case "sistema_calificacion":
                            success = crudCalificaciones.InsertRecord(db);
                            break;
                        case "acciones_sistema":
                            success = crudAccionesSistema.InsertRecord(db);
                            break;
                        case "experiencia_usuario":
                            success = crudExperienciaUsuario.InsertRecord(db);
                            break;
                        case "archivos_proveedor":
                            success = crudArchivosProveedor.InsertRecord(db);
                            break;
                        case "archivos_generales":
                            success = crudArchivosGenerales.InsertRecord(db);
                            break;
                    }

                    if (success)
                    {
                        MessageBox.Show("Registro insertado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.LogInfo($"Inserted new record in {currentTable}");
                        LoadTableData();
                        ClearForm();
                        DisableForm();
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
                    bool success = false;

                    switch (currentTable)
                    {
                        case "roles":
                            success = crudRoles.UpdateRecord(db, currentEditId);
                            break;
                        case "usuarios_sistema":
                            success = crudUsuariosSistema.UpdateRecord(db, currentEditId);
                            break;
                        case "usuarios":
                            success = crudUsuarios.UpdateRecord(db, currentEditId);
                            break;
                        case "categorias":
                            success = crudCategorias.UpdateRecord(db, currentEditId);
                            break;
                        case "denominaciones":
                            success = crudDenominaciones.UpdateRecord(db, currentEditId);
                            break;
                        case "datos_usuario":
                            success = crudDatosUsuario.UpdateRecord(db, currentEditId);
                            break;
                        case "servicios":
                            success = crudServicios.UpdateRecord(db, currentEditId);
                            break;
                        case "sistema_calificacion":
                            success = crudCalificaciones.UpdateRecord(db, currentEditId);
                            break;
                        case "acciones_sistema":
                            success = crudAccionesSistema.UpdateRecord(db, currentEditId);
                            break;
                        case "experiencia_usuario":
                            success = crudExperienciaUsuario.UpdateRecord(db, currentEditId);
                            break;
                        case "archivos_proveedor":
                            success = crudArchivosProveedor.UpdateRecord(db, currentEditId);
                            break;
                        case "archivos_generales":
                            success = crudArchivosGenerales.UpdateRecord(db, currentEditId);
                            break;
                    }

                    if (success)
                    {
                        MessageBox.Show("Registro actualizado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.LogInfo($"Updated record in {currentTable} ID: {currentEditId}");
                        LoadTableData();
                        ClearForm();
                        DisableForm();
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
                string warningMessage = $"¿Está seguro de eliminar este registro de {currentTable}?\nID: {id}";

                if (currentTable == "usuarios_sistema" || currentTable == "usuarios")
                {
                    warningMessage += "\n\n¡ADVERTENCIA! Esta acción puede afectar a otros registros relacionados.";
                }

                if (MessageBox.Show(warningMessage,
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar registro: {ex.Message}\n\nPuede que existan registros relacionados.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError($"Error deleting record: {ex.Message}");
            }
        }

        private void ShowPanelForCurrentTable()
        {
            HideAllPanels();

            switch (currentTable)
            {
                case "roles":
                    panelRoles.Visible = true;
                    break;
                case "usuarios_sistema":
                    panelUsuariosSistema.Visible = true;
                    break;
                case "usuarios":
                    panelUsuarios.Visible = true;
                    break;
                case "categorias":
                    panelCategorias.Visible = true;
                    break;
                case "denominaciones":
                    panelDenominaciones.Visible = true;
                    break;
                case "datos_usuario":
                    panelDatosUsuario.Visible = true;
                    break;
                case "servicios":
                    panelServicios.Visible = true;
                    break;
                case "sistema_calificacion":
                    panelCalificaciones.Visible = true;
                    break;
                case "acciones_sistema":
                    panelAccionesSistema.Visible = true;
                    break;
                case "experiencia_usuario":
                    panelExperienciaUsuario.Visible = true;
                    break;
                case "archivos_proveedor":
                    panelArchivosProveedor.Visible = true;
                    break;
                case "archivos_generales":
                    panelArchivosGenerales.Visible = true;
                    break;
            }
        }

        private void HideAllPanels()
        {
            panelRoles.Visible = false;
            panelUsuariosSistema.Visible = false;
            panelUsuarios.Visible = false;
            panelCategorias.Visible = false;
            panelDenominaciones.Visible = false;
            panelDatosUsuario.Visible = false;
            panelServicios.Visible = false;
            panelCalificaciones.Visible = false;
            panelAccionesSistema.Visible = false;
            panelExperienciaUsuario.Visible = false;
            panelArchivosProveedor.Visible = false;
            panelArchivosGenerales.Visible = false;
        }

        private void ClearAllPanels()
        {
            // Limpiar panel Roles
            txtNombreRol.Clear();
            txtDescripcionRol.Clear();

            // Limpiar panel Usuarios Sistema
            txtUsernameSistema.Clear();
            txtEmailSistema.Clear();
            txtPasswordSistema.Clear();
            txtIDRolSistema.Clear();
            txtNombresSistema.Clear();
            txtApellidosSistema.Clear();
            txtTelefonoSistema.Clear();
            chkActivoSistema.Checked = false;

            // Limpiar panel Usuarios
            txtUsernameUsuario.Clear();
            txtPasswordUsuario.Clear();
            txtIDRolUsuario.Clear();
            chkActivoUsuario.Checked = false;

            // Limpiar panel Categorias
            txtNombreCategoria.Clear();
            txtDescripcionCategoria.Clear();
            txtIconoCategoria.Clear();
            txtColorCategoria.Clear();
            chkActivaCategoria.Checked = false;

            // Limpiar panel Denominaciones
            txtIDCategoriaDenominacion.Clear();
            txtNombreDenominacion.Clear();
            txtDescripcionDenominacion.Clear();

            // Limpiar panel Datos Usuario
            txtIDUsuarioDatos.Clear();
            txtNombresDatos.Clear();
            txtApellidosDatos.Clear();
            txtCiudadDatos.Clear();
            txtDireccionDatos.Clear();
            txtEmailDatos.Clear();
            txtTelefonoDatos.Clear();
            txtWhatsappDatos.Clear();
            txtOtroContactoDatos.Clear();
            txtIdentificacionOficial.Clear();
            txtZonasServicio.Clear();

            // Limpiar panel Servicios
            txtIDUsuarioServicio.Clear();
            txtIDCategoriaServicio.Clear();
            txtIDDenominacionServicio.Clear();
            txtTituloServicio.Clear();
            txtDescripcionServicio.Clear();
            cmbTipoPrecioServicio.SelectedIndex = -1;
            txtMonedaServicio.Clear();
            txtDisponibilidadServicio.Clear();
            txtRadioCoberturaServicio.Clear();
            txtExperienciaServicio.Clear();

            // Limpiar panel Calificaciones
            txtIDEmpleadoCalificacion.Clear();
            txtIDClienteCalificacion.Clear();
            txtIDServicioCalificacion.Clear();
            nudPuntuacionCalificacion.Value = 5;
            txtComentarioCalificacion.Clear();

            // Limpiar panel Acciones Sistema
            txtIDUsuarioSistemaAccion.Clear();
            txtAccionSistema.Clear();
            txtTablaAfectadaAccion.Clear();
            txtRegistroAfectadoAccion.Clear();
            txtDetallesAccion.Clear();

            // Limpiar panel Experiencia Usuario
            txtIDUsuarioExperiencia.Clear();
            cmbTipoRegistroExperiencia.SelectedIndex = -1;
            cmbNivelEstudiosExperiencia.SelectedIndex = -1;
            txtAnosExperiencia.Clear();
            txtEmpresasAnteriores.Clear();
            txtProyectosDestacados.Clear();
            txtReferenciasLaborales.Clear();
            txtTipoExperiencia.Clear();
            txtDescripcionOtro.Clear();

            // Limpiar panel Archivos Proveedor
            txtIDUsuarioArchivoProveedor.Clear();
            txtNombreArchivoProveedor.Clear();
            cmbTipoArchivoProveedor.SelectedIndex = -1;
            cmbCategoriaArchivoProveedor.SelectedIndex = -1;
            chkObligatorioArchivo.Checked = false;
            lblArchivoSeleccionadoProveedor.Text = "Ningún archivo seleccionado";

            // Limpiar panel Archivos Generales
            txtNombreArchivoGeneral.Clear();
            cmbTipoArchivoGeneral.SelectedIndex = -1;
            txtCategoriaArchivoGeneral.Clear();
            txtDescripcionArchivoGeneral.Clear();
            lblArchivoSeleccionadoGeneral.Text = "Ningún archivo seleccionado";
        }

        
        
    }
}