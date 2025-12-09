using System.Drawing;
using System.Windows.Forms;

namespace CRUD_Directorio.CRUD
{
    partial class CrudTabPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbTablas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvCrud;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.Label lblAccion;
        private System.Windows.Forms.Label lblTotalRegistros;

        // PANELES DINÁMICOS PARA CADA TABLA
        private System.Windows.Forms.Panel panelRoles;
        private System.Windows.Forms.Panel panelUsuariosSistema;
        private System.Windows.Forms.Panel panelUsuarios;
        private System.Windows.Forms.Panel panelCategorias;
        private System.Windows.Forms.Panel panelDenominaciones;
        private System.Windows.Forms.Panel panelDatosUsuario;
        private System.Windows.Forms.Panel panelServicios;
        private System.Windows.Forms.Panel panelCalificaciones;
        private System.Windows.Forms.Panel panelAccionesSistema;
        private System.Windows.Forms.Panel panelExperienciaUsuario;
        private System.Windows.Forms.Panel panelArchivosProveedor;
        private System.Windows.Forms.Panel panelArchivosGenerales;

        // CONTROLES PARA panelRoles
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcionRol;
        private System.Windows.Forms.Label label3;

        // CONTROLES PARA panelUsuariosSistema
        private System.Windows.Forms.TextBox txtUsernameSistema;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmailSistema;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPasswordSistema;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIDRolSistema;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombresSistema;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtApellidosSistema;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTelefonoSistema;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkActivoSistema;

        // CONTROLES PARA panelUsuarios
        private System.Windows.Forms.TextBox txtUsernameUsuario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPasswordUsuario;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIDRolUsuario;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkActivoUsuario;

        // CONTROLES PARA panelCategorias
        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDescripcionCategoria;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtIconoCategoria;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtColorCategoria;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkActivaCategoria;

        // CONTROLES PARA panelDenominaciones
        private System.Windows.Forms.TextBox txtIDCategoriaDenominacion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNombreDenominacion;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDescripcionDenominacion;
        private System.Windows.Forms.Label label20;

        // CONTROLES PARA panelDatosUsuario
        private System.Windows.Forms.TextBox txtIDUsuarioDatos;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtNombresDatos;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtApellidosDatos;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtCiudadDatos;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtDireccionDatos;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtEmailDatos;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtTelefonoDatos;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtWhatsappDatos;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtOtroContactoDatos;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtIdentificacionOficial;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtZonasServicio;
        private System.Windows.Forms.Label label31;

        // CONTROLES PARA panelServicios
        private System.Windows.Forms.TextBox txtIDUsuarioServicio;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtIDCategoriaServicio;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtIDDenominacionServicio;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtTituloServicio;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtDescripcionServicio;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox cmbTipoPrecioServicio;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtMonedaServicio;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtDisponibilidadServicio;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtRadioCoberturaServicio;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtExperienciaServicio;
        private System.Windows.Forms.Label label41;

        // CONTROLES PARA panelCalificaciones
        private System.Windows.Forms.TextBox txtIDEmpleadoCalificacion;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtIDClienteCalificacion;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtIDServicioCalificacion;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.NumericUpDown nudPuntuacionCalificacion;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtComentarioCalificacion;
        private System.Windows.Forms.Label label46;

        // CONTROLES PARA panelAccionesSistema
        private System.Windows.Forms.TextBox txtIDUsuarioSistemaAccion;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtAccionSistema;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtTablaAfectadaAccion;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox txtRegistroAfectadoAccion;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox txtDetallesAccion;
        private System.Windows.Forms.Label label51;

        // CONTROLES PARA panelExperienciaUsuario
        private System.Windows.Forms.TextBox txtIDUsuarioExperiencia;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.ComboBox cmbTipoRegistroExperiencia;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.ComboBox cmbNivelEstudiosExperiencia;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox txtAnosExperiencia;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox txtEmpresasAnteriores;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox txtProyectosDestacados;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox txtReferenciasLaborales;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox txtTipoExperiencia;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox txtDescripcionOtro;
        private System.Windows.Forms.Label label60;

        // CONTROLES PARA panelArchivosProveedor
        private System.Windows.Forms.TextBox txtIDUsuarioArchivoProveedor;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.TextBox txtNombreArchivoProveedor;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.ComboBox cmbTipoArchivoProveedor;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.ComboBox cmbCategoriaArchivoProveedor;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.CheckBox chkObligatorioArchivo;
        private System.Windows.Forms.Button btnSeleccionarArchivoProveedor;
        private System.Windows.Forms.Label lblArchivoSeleccionadoProveedor;
        private System.Windows.Forms.OpenFileDialog openFileDialogProveedor;

        // CONTROLES PARA panelArchivosGenerales
        private System.Windows.Forms.TextBox txtNombreArchivoGeneral;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.ComboBox cmbTipoArchivoGeneral;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox txtCategoriaArchivoGeneral;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtDescripcionArchivoGeneral;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Button btnSeleccionarArchivoGeneral;
        private System.Windows.Forms.Label lblArchivoSeleccionadoGeneral;
        private System.Windows.Forms.OpenFileDialog openFileDialogGeneral;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrudTabPage));
            this.cmbTablas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvCrud = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelFormulario = new System.Windows.Forms.Panel();
            this.lblAccion = new System.Windows.Forms.Label();
            this.lblTotalRegistros = new System.Windows.Forms.Label();

            // Crear instancias de todos los paneles
            this.panelRoles = new System.Windows.Forms.Panel();
            this.panelUsuariosSistema = new System.Windows.Forms.Panel();
            this.panelUsuarios = new System.Windows.Forms.Panel();
            this.panelCategorias = new System.Windows.Forms.Panel();
            this.panelDenominaciones = new System.Windows.Forms.Panel();
            this.panelDatosUsuario = new System.Windows.Forms.Panel();
            this.panelServicios = new System.Windows.Forms.Panel();
            this.panelCalificaciones = new System.Windows.Forms.Panel();
            this.panelAccionesSistema = new System.Windows.Forms.Panel();
            this.panelExperienciaUsuario = new System.Windows.Forms.Panel();
            this.panelArchivosProveedor = new System.Windows.Forms.Panel();
            this.panelArchivosGenerales = new System.Windows.Forms.Panel();

            // Inicializar controles de cada panel
            InitializeRolesPanel();
            InitializeUsuariosSistemaPanel();
            InitializeUsuariosPanel();
            InitializeCategoriasPanel();
            InitializeDenominacionesPanel();
            InitializeDatosUsuarioPanel();
            InitializeServiciosPanel();
            InitializeCalificacionesPanel();
            InitializeAccionesSistemaPanel();
            InitializeExperienciaUsuarioPanel();
            InitializeArchivosProveedorPanel();
            InitializeArchivosGeneralesPanel();

            // Configuración básica de controles comunes
            this.cmbTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTablas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTablas.FormattingEnabled = true;
            this.cmbTablas.Location = new System.Drawing.Point(120, 15);
            this.cmbTablas.Name = "cmbTablas";
            this.cmbTablas.Size = new System.Drawing.Size(180, 23);
            this.cmbTablas.TabIndex = 0;

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar tabla:";

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(310, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(40, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "↻";
            this.btnRefresh.UseVisualStyleBackColor = false;

            // Configuración de DataGridView
            this.dgvCrud.AllowUserToAddRows = false;
            this.dgvCrud.AllowUserToDeleteRows = false;
            this.dgvCrud.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCrud.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCrud.BackgroundColor = System.Drawing.Color.White;
            this.dgvCrud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCrud.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCrud.ColumnHeadersHeight = 35;
            this.dgvCrud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCrud.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCrud.Location = new System.Drawing.Point(15, 80);
            this.dgvCrud.MultiSelect = false;
            this.dgvCrud.Name = "dgvCrud";
            this.dgvCrud.ReadOnly = true;
            this.dgvCrud.RowHeadersVisible = false;
            this.dgvCrud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCrud.Size = new System.Drawing.Size(1180, 320);
            this.dgvCrud.TabIndex = 3;

            // Configuración de botones
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnNuevo.Location = new Point(15, this.Height - 60);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 40);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;

            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnEditar.Location = new Point(125, this.Height - 60);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 40);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;

            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnEliminar.Location = new Point(235, this.Height - 60);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 40);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;

            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnGuardar.Location = new Point(this.Width - 215, this.Height - 60);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnCancelar.Location = new Point(this.Width - 105, this.Height - 60);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            // Configuración del panelFormulario
            this.panelFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelFormulario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFormulario.Controls.Add(this.panelArchivosGenerales);
            this.panelFormulario.Controls.Add(this.panelArchivosProveedor);
            this.panelFormulario.Controls.Add(this.panelExperienciaUsuario);
            this.panelFormulario.Controls.Add(this.panelAccionesSistema);
            this.panelFormulario.Controls.Add(this.panelCalificaciones);
            this.panelFormulario.Controls.Add(this.panelServicios);
            this.panelFormulario.Controls.Add(this.panelDatosUsuario);
            this.panelFormulario.Controls.Add(this.panelDenominaciones);
            this.panelFormulario.Controls.Add(this.panelCategorias);
            this.panelFormulario.Controls.Add(this.panelUsuarios);
            this.panelFormulario.Controls.Add(this.panelUsuariosSistema);
            this.panelFormulario.Controls.Add(this.panelRoles);
            this.panelFormulario.Controls.Add(this.lblAccion);
            this.panelFormulario.Location = new System.Drawing.Point(15, -100);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Size = new System.Drawing.Size(1180, 190);
            this.panelFormulario.TabIndex = 9;
            this.panelFormulario.Visible = false;

            this.lblAccion.AutoSize = true;
            this.lblAccion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblAccion.Location = new System.Drawing.Point(20, 10);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(137, 20);
            this.lblAccion.TabIndex = 0;
            this.lblAccion.Text = "NUEVO REGISTRO";

            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalRegistros.Location = new System.Drawing.Point(1010, 18);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(115, 17);
            this.lblTotalRegistros.TabIndex = 10;
            this.lblTotalRegistros.Text = "Total: 0 registros";

            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.panelFormulario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvCrud);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTablas);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CrudTabPage";
            this.Size = new System.Drawing.Size(1210, 800);
        }

        // ============ MÉTODOS PARA INICIALIZAR CADA PANEL ============

        private void InitializeRolesPanel()
        {
            this.panelRoles = new System.Windows.Forms.Panel();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcionRol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();

            this.panelRoles.SuspendLayout();

            // Configuración del panel
            this.panelRoles.Location = new System.Drawing.Point(20, 40);
            this.panelRoles.Name = "panelRoles";
            this.panelRoles.Size = new System.Drawing.Size(1100, 80);
            this.panelRoles.TabIndex = 1;
            this.panelRoles.Visible = false;

            // txtNombreRol
            this.txtNombreRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreRol.Location = new System.Drawing.Point(80, 10);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(200, 23);
            this.txtNombreRol.TabIndex = 1;

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";

            // txtDescripcionRol
            this.txtDescripcionRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionRol.Location = new System.Drawing.Point(380, 10);
            this.txtDescripcionRol.Multiline = true;
            this.txtDescripcionRol.Name = "txtDescripcionRol";
            this.txtDescripcionRol.Size = new System.Drawing.Size(400, 60);
            this.txtDescripcionRol.TabIndex = 3;

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(300, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción:";

            // Agregar controles al panel
            this.panelRoles.Controls.Add(this.txtNombreRol);
            this.panelRoles.Controls.Add(this.label2);
            this.panelRoles.Controls.Add(this.txtDescripcionRol);
            this.panelRoles.Controls.Add(this.label3);

            this.panelRoles.ResumeLayout(false);
            this.panelRoles.PerformLayout();
        }

        private void InitializeUsuariosSistemaPanel()
        {
            this.panelUsuariosSistema = new System.Windows.Forms.Panel();
            this.txtUsernameSistema = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmailSistema = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPasswordSistema = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIDRolSistema = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombresSistema = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtApellidosSistema = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTelefonoSistema = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkActivoSistema = new System.Windows.Forms.CheckBox();

            this.panelUsuariosSistema.SuspendLayout();

            // Configuración del panel
            this.panelUsuariosSistema.Location = new System.Drawing.Point(20, 40);
            this.panelUsuariosSistema.Name = "panelUsuariosSistema";
            this.panelUsuariosSistema.Size = new System.Drawing.Size(1100, 80);
            this.panelUsuariosSistema.TabIndex = 2;
            this.panelUsuariosSistema.Visible = false;

            // txtUsernameSistema
            this.txtUsernameSistema.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsernameSistema.Location = new System.Drawing.Point(80, 10);
            this.txtUsernameSistema.Name = "txtUsernameSistema";
            this.txtUsernameSistema.Size = new System.Drawing.Size(120, 23);
            this.txtUsernameSistema.TabIndex = 1;

            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(20, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Username:";

            // txtEmailSistema
            this.txtEmailSistema.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmailSistema.Location = new System.Drawing.Point(270, 10);
            this.txtEmailSistema.Name = "txtEmailSistema";
            this.txtEmailSistema.Size = new System.Drawing.Size(150, 23);
            this.txtEmailSistema.TabIndex = 3;

            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(210, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Email:";

            // txtPasswordSistema
            this.txtPasswordSistema.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPasswordSistema.Location = new System.Drawing.Point(500, 10);
            this.txtPasswordSistema.Name = "txtPasswordSistema";
            this.txtPasswordSistema.PasswordChar = '*';
            this.txtPasswordSistema.Size = new System.Drawing.Size(120, 23);
            this.txtPasswordSistema.TabIndex = 5;

            // label6
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(430, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Password:";

            // txtIDRolSistema
            this.txtIDRolSistema.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDRolSistema.Location = new System.Drawing.Point(80, 40);
            this.txtIDRolSistema.Name = "txtIDRolSistema";
            this.txtIDRolSistema.Size = new System.Drawing.Size(70, 23);
            this.txtIDRolSistema.TabIndex = 7;

            // label7
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(20, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "ID Rol:";

            // txtNombresSistema
            this.txtNombresSistema.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombresSistema.Location = new System.Drawing.Point(220, 40);
            this.txtNombresSistema.Name = "txtNombresSistema";
            this.txtNombresSistema.Size = new System.Drawing.Size(120, 23);
            this.txtNombresSistema.TabIndex = 9;

            // label8
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(160, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Nombres:";

            // txtApellidosSistema
            this.txtApellidosSistema.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtApellidosSistema.Location = new System.Drawing.Point(410, 40);
            this.txtApellidosSistema.Name = "txtApellidosSistema";
            this.txtApellidosSistema.Size = new System.Drawing.Size(120, 23);
            this.txtApellidosSistema.TabIndex = 11;

            // label9
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(350, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Apellidos:";

            // txtTelefonoSistema
            this.txtTelefonoSistema.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefonoSistema.Location = new System.Drawing.Point(600, 40);
            this.txtTelefonoSistema.Name = "txtTelefonoSistema";
            this.txtTelefonoSistema.Size = new System.Drawing.Size(100, 23);
            this.txtTelefonoSistema.TabIndex = 13;

            // label10
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.Location = new System.Drawing.Point(540, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Teléfono:";

            // chkActivoSistema
            this.chkActivoSistema.AutoSize = true;
            this.chkActivoSistema.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkActivoSistema.Location = new System.Drawing.Point(720, 42);
            this.chkActivoSistema.Name = "chkActivoSistema";
            this.chkActivoSistema.Size = new System.Drawing.Size(58, 19);
            this.chkActivoSistema.TabIndex = 14;
            this.chkActivoSistema.Text = "Activo";
            this.chkActivoSistema.UseVisualStyleBackColor = true;

            // Agregar controles al panel
            this.panelUsuariosSistema.Controls.Add(this.txtUsernameSistema);
            this.panelUsuariosSistema.Controls.Add(this.label4);
            this.panelUsuariosSistema.Controls.Add(this.txtEmailSistema);
            this.panelUsuariosSistema.Controls.Add(this.label5);
            this.panelUsuariosSistema.Controls.Add(this.txtPasswordSistema);
            this.panelUsuariosSistema.Controls.Add(this.label6);
            this.panelUsuariosSistema.Controls.Add(this.txtIDRolSistema);
            this.panelUsuariosSistema.Controls.Add(this.label7);
            this.panelUsuariosSistema.Controls.Add(this.txtNombresSistema);
            this.panelUsuariosSistema.Controls.Add(this.label8);
            this.panelUsuariosSistema.Controls.Add(this.txtApellidosSistema);
            this.panelUsuariosSistema.Controls.Add(this.label9);
            this.panelUsuariosSistema.Controls.Add(this.txtTelefonoSistema);
            this.panelUsuariosSistema.Controls.Add(this.label10);
            this.panelUsuariosSistema.Controls.Add(this.chkActivoSistema);

            this.panelUsuariosSistema.ResumeLayout(false);
            this.panelUsuariosSistema.PerformLayout();
        }

        private void InitializeUsuariosPanel()
        {
            this.panelUsuarios = new System.Windows.Forms.Panel();
            this.txtUsernameUsuario = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPasswordUsuario = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIDRolUsuario = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkActivoUsuario = new System.Windows.Forms.CheckBox();

            this.panelUsuarios.SuspendLayout();

            // Configuración del panel
            this.panelUsuarios.Location = new System.Drawing.Point(20, 40);
            this.panelUsuarios.Name = "panelUsuarios";
            this.panelUsuarios.Size = new System.Drawing.Size(800, 80);
            this.panelUsuarios.TabIndex = 3;
            this.panelUsuarios.Visible = false;

            // txtUsernameUsuario
            this.txtUsernameUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsernameUsuario.Location = new System.Drawing.Point(80, 10);
            this.txtUsernameUsuario.Name = "txtUsernameUsuario";
            this.txtUsernameUsuario.Size = new System.Drawing.Size(150, 23);
            this.txtUsernameUsuario.TabIndex = 1;

            // label11
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.Location = new System.Drawing.Point(20, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Username:";

            // txtPasswordUsuario
            this.txtPasswordUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPasswordUsuario.Location = new System.Drawing.Point(300, 10);
            this.txtPasswordUsuario.Name = "txtPasswordUsuario";
            this.txtPasswordUsuario.PasswordChar = '*';
            this.txtPasswordUsuario.Size = new System.Drawing.Size(150, 23);
            this.txtPasswordUsuario.TabIndex = 3;

            // label12
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.Location = new System.Drawing.Point(240, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Password:";

            // txtIDRolUsuario
            this.txtIDRolUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDRolUsuario.Location = new System.Drawing.Point(80, 40);
            this.txtIDRolUsuario.Name = "txtIDRolUsuario";
            this.txtIDRolUsuario.Size = new System.Drawing.Size(70, 23);
            this.txtIDRolUsuario.TabIndex = 5;

            // label13
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label13.Location = new System.Drawing.Point(20, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "ID Rol:";

            // chkActivoUsuario
            this.chkActivoUsuario.AutoSize = true;
            this.chkActivoUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkActivoUsuario.Location = new System.Drawing.Point(180, 42);
            this.chkActivoUsuario.Name = "chkActivoUsuario";
            this.chkActivoUsuario.Size = new System.Drawing.Size(58, 19);
            this.chkActivoUsuario.TabIndex = 6;
            this.chkActivoUsuario.Text = "Activo";
            this.chkActivoUsuario.UseVisualStyleBackColor = true;

            // Agregar controles al panel
            this.panelUsuarios.Controls.Add(this.txtUsernameUsuario);
            this.panelUsuarios.Controls.Add(this.label11);
            this.panelUsuarios.Controls.Add(this.txtPasswordUsuario);
            this.panelUsuarios.Controls.Add(this.label12);
            this.panelUsuarios.Controls.Add(this.txtIDRolUsuario);
            this.panelUsuarios.Controls.Add(this.label13);
            this.panelUsuarios.Controls.Add(this.chkActivoUsuario);

            this.panelUsuarios.ResumeLayout(false);
            this.panelUsuarios.PerformLayout();
        }

        private void InitializeCategoriasPanel()
        {
            this.panelCategorias = new System.Windows.Forms.Panel();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDescripcionCategoria = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIconoCategoria = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtColorCategoria = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.chkActivaCategoria = new System.Windows.Forms.CheckBox();

            this.panelCategorias.SuspendLayout();

            // Configuración del panel
            this.panelCategorias.Location = new System.Drawing.Point(20, 40);
            this.panelCategorias.Name = "panelCategorias";
            this.panelCategorias.Size = new System.Drawing.Size(1100, 80);
            this.panelCategorias.TabIndex = 4;
            this.panelCategorias.Visible = false;

            // txtNombreCategoria
            this.txtNombreCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreCategoria.Location = new System.Drawing.Point(80, 10);
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(200, 23);
            this.txtNombreCategoria.TabIndex = 1;

            // label14
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label14.Location = new System.Drawing.Point(20, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Nombre:";

            // txtDescripcionCategoria
            this.txtDescripcionCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcionCategoria.Location = new System.Drawing.Point(350, 10);
            this.txtDescripcionCategoria.Multiline = true;
            this.txtDescripcionCategoria.Name = "txtDescripcionCategoria";
            this.txtDescripcionCategoria.Size = new System.Drawing.Size(250, 60);
            this.txtDescripcionCategoria.TabIndex = 3;

            // label15
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.Location = new System.Drawing.Point(290, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "Descripción:";

            // txtIconoCategoria
            this.txtIconoCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIconoCategoria.Location = new System.Drawing.Point(680, 10);
            this.txtIconoCategoria.Name = "txtIconoCategoria";
            this.txtIconoCategoria.Size = new System.Drawing.Size(150, 23);
            this.txtIconoCategoria.TabIndex = 5;

            // label16
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label16.Location = new System.Drawing.Point(620, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 15);
            this.label16.TabIndex = 4;
            this.label16.Text = "Icono:";

            // txtColorCategoria
            this.txtColorCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtColorCategoria.Location = new System.Drawing.Point(900, 10);
            this.txtColorCategoria.Name = "txtColorCategoria";
            this.txtColorCategoria.Size = new System.Drawing.Size(100, 23);
            this.txtColorCategoria.TabIndex = 7;

            // label17
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label17.Location = new System.Drawing.Point(850, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 15);
            this.label17.TabIndex = 6;
            this.label17.Text = "Color:";

            // chkActivaCategoria
            this.chkActivaCategoria.AutoSize = true;
            this.chkActivaCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkActivaCategoria.Location = new System.Drawing.Point(1020, 12);
            this.chkActivaCategoria.Name = "chkActivaCategoria";
            this.chkActivaCategoria.Size = new System.Drawing.Size(58, 19);
            this.chkActivaCategoria.TabIndex = 8;
            this.chkActivaCategoria.Text = "Activa";
            this.chkActivaCategoria.UseVisualStyleBackColor = true;

            // Agregar controles al panel
            this.panelCategorias.Controls.Add(this.txtNombreCategoria);
            this.panelCategorias.Controls.Add(this.label14);
            this.panelCategorias.Controls.Add(this.txtDescripcionCategoria);
            this.panelCategorias.Controls.Add(this.label15);
            this.panelCategorias.Controls.Add(this.txtIconoCategoria);
            this.panelCategorias.Controls.Add(this.label16);
            this.panelCategorias.Controls.Add(this.txtColorCategoria);
            this.panelCategorias.Controls.Add(this.label17);
            this.panelCategorias.Controls.Add(this.chkActivaCategoria);

            this.panelCategorias.ResumeLayout(false);
            this.panelCategorias.PerformLayout();
        }

        private void InitializeDenominacionesPanel()
        {
            this.panelDenominaciones = new System.Windows.Forms.Panel();
            this.txtIDCategoriaDenominacion = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNombreDenominacion = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDescripcionDenominacion = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();

            this.panelDenominaciones.SuspendLayout();

            // Configuración del panel
            this.panelDenominaciones.Location = new System.Drawing.Point(20, 40);
            this.panelDenominaciones.Name = "panelDenominaciones";
            this.panelDenominaciones.Size = new System.Drawing.Size(1100, 80);
            this.panelDenominaciones.TabIndex = 5;
            this.panelDenominaciones.Visible = false;

            // txtIDCategoriaDenominacion
            this.txtIDCategoriaDenominacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDCategoriaDenominacion.Location = new System.Drawing.Point(100, 10);
            this.txtIDCategoriaDenominacion.Name = "txtIDCategoriaDenominacion";
            this.txtIDCategoriaDenominacion.Size = new System.Drawing.Size(70, 23);
            this.txtIDCategoriaDenominacion.TabIndex = 1;

            // label18
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label18.Location = new System.Drawing.Point(20, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "ID Categoría:";

            // txtNombreDenominacion
            this.txtNombreDenominacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreDenominacion.Location = new System.Drawing.Point(280, 10);
            this.txtNombreDenominacion.Name = "txtNombreDenominacion";
            this.txtNombreDenominacion.Size = new System.Drawing.Size(200, 23);
            this.txtNombreDenominacion.TabIndex = 3;

            // label19
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label19.Location = new System.Drawing.Point(180, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "Denominación:";

            // txtDescripcionDenominacion
            this.txtDescripcionDenominacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcionDenominacion.Location = new System.Drawing.Point(550, 10);
            this.txtDescripcionDenominacion.Multiline = true;
            this.txtDescripcionDenominacion.Name = "txtDescripcionDenominacion";
            this.txtDescripcionDenominacion.Size = new System.Drawing.Size(400, 60);
            this.txtDescripcionDenominacion.TabIndex = 5;

            // label20
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label20.Location = new System.Drawing.Point(490, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 15);
            this.label20.TabIndex = 4;
            this.label20.Text = "Descripción:";

            // Agregar controles al panel
            this.panelDenominaciones.Controls.Add(this.txtIDCategoriaDenominacion);
            this.panelDenominaciones.Controls.Add(this.label18);
            this.panelDenominaciones.Controls.Add(this.txtNombreDenominacion);
            this.panelDenominaciones.Controls.Add(this.label19);
            this.panelDenominaciones.Controls.Add(this.txtDescripcionDenominacion);
            this.panelDenominaciones.Controls.Add(this.label20);

            this.panelDenominaciones.ResumeLayout(false);
            this.panelDenominaciones.PerformLayout();
        }

        private void InitializeDatosUsuarioPanel()
        {
            this.panelDatosUsuario = new System.Windows.Forms.Panel();
            this.txtIDUsuarioDatos = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNombresDatos = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtApellidosDatos = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtCiudadDatos = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDireccionDatos = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtEmailDatos = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtTelefonoDatos = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtWhatsappDatos = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtOtroContactoDatos = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtIdentificacionOficial = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtZonasServicio = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();

            this.panelDatosUsuario.SuspendLayout();

            // Configuración del panel
            this.panelDatosUsuario.Location = new System.Drawing.Point(20, 40);
            this.panelDatosUsuario.Name = "panelDatosUsuario";
            this.panelDatosUsuario.Size = new System.Drawing.Size(1100, 110);
            this.panelDatosUsuario.TabIndex = 6;
            this.panelDatosUsuario.Visible = false;

            // Fila 1
            // txtIDUsuarioDatos
            this.txtIDUsuarioDatos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDUsuarioDatos.Location = new System.Drawing.Point(100, 10);
            this.txtIDUsuarioDatos.Name = "txtIDUsuarioDatos";
            this.txtIDUsuarioDatos.Size = new System.Drawing.Size(70, 23);
            this.txtIDUsuarioDatos.TabIndex = 1;

            // label21
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label21.Location = new System.Drawing.Point(20, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 15);
            this.label21.TabIndex = 0;
            this.label21.Text = "ID Usuario:";

            // txtNombresDatos
            this.txtNombresDatos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombresDatos.Location = new System.Drawing.Point(250, 10);
            this.txtNombresDatos.Name = "txtNombresDatos";
            this.txtNombresDatos.Size = new System.Drawing.Size(120, 23);
            this.txtNombresDatos.TabIndex = 3;

            // label22
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label22.Location = new System.Drawing.Point(180, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 15);
            this.label22.TabIndex = 2;
            this.label22.Text = "Nombres:";

            // txtApellidosDatos
            this.txtApellidosDatos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtApellidosDatos.Location = new System.Drawing.Point(450, 10);
            this.txtApellidosDatos.Name = "txtApellidosDatos";
            this.txtApellidosDatos.Size = new System.Drawing.Size(120, 23);
            this.txtApellidosDatos.TabIndex = 5;

            // label23
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label23.Location = new System.Drawing.Point(380, 13);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 15);
            this.label23.TabIndex = 4;
            this.label23.Text = "Apellidos:";

            // txtCiudadDatos
            this.txtCiudadDatos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCiudadDatos.Location = new System.Drawing.Point(650, 10);
            this.txtCiudadDatos.Name = "txtCiudadDatos";
            this.txtCiudadDatos.Size = new System.Drawing.Size(120, 23);
            this.txtCiudadDatos.TabIndex = 7;

            // label24
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label24.Location = new System.Drawing.Point(580, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 15);
            this.label24.TabIndex = 6;
            this.label24.Text = "Ciudad:";

            // Fila 2
            // txtDireccionDatos
            this.txtDireccionDatos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccionDatos.Location = new System.Drawing.Point(100, 40);
            this.txtDireccionDatos.Name = "txtDireccionDatos";
            this.txtDireccionDatos.Size = new System.Drawing.Size(150, 23);
            this.txtDireccionDatos.TabIndex = 9;

            // label25
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label25.Location = new System.Drawing.Point(20, 43);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 15);
            this.label25.TabIndex = 8;
            this.label25.Text = "Dirección:";

            // txtEmailDatos
            this.txtEmailDatos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmailDatos.Location = new System.Drawing.Point(320, 40);
            this.txtEmailDatos.Name = "txtEmailDatos";
            this.txtEmailDatos.Size = new System.Drawing.Size(150, 23);
            this.txtEmailDatos.TabIndex = 11;

            // label26
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label26.Location = new System.Drawing.Point(260, 43);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(39, 15);
            this.label26.TabIndex = 10;
            this.label26.Text = "Email:";

            // txtTelefonoDatos
            this.txtTelefonoDatos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefonoDatos.Location = new System.Drawing.Point(550, 40);
            this.txtTelefonoDatos.Name = "txtTelefonoDatos";
            this.txtTelefonoDatos.Size = new System.Drawing.Size(100, 23);
            this.txtTelefonoDatos.TabIndex = 13;

            // label27
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label27.Location = new System.Drawing.Point(480, 43);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 15);
            this.label27.TabIndex = 12;
            this.label27.Text = "Teléfono:";

            // txtWhatsappDatos
            this.txtWhatsappDatos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWhatsappDatos.Location = new System.Drawing.Point(730, 40);
            this.txtWhatsappDatos.Name = "txtWhatsappDatos";
            this.txtWhatsappDatos.Size = new System.Drawing.Size(100, 23);
            this.txtWhatsappDatos.TabIndex = 15;

            // label28
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label28.Location = new System.Drawing.Point(660, 43);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 15);
            this.label28.TabIndex = 14;
            this.label28.Text = "WhatsApp:";

            // Fila 3
            // txtOtroContactoDatos
            this.txtOtroContactoDatos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOtroContactoDatos.Location = new System.Drawing.Point(100, 70);
            this.txtOtroContactoDatos.Name = "txtOtroContactoDatos";
            this.txtOtroContactoDatos.Size = new System.Drawing.Size(150, 23);
            this.txtOtroContactoDatos.TabIndex = 17;

            // label29
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label29.Location = new System.Drawing.Point(20, 73);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(79, 15);
            this.label29.TabIndex = 16;
            this.label29.Text = "Otro Contacto:";

            // txtIdentificacionOficial
            this.txtIdentificacionOficial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdentificacionOficial.Location = new System.Drawing.Point(320, 70);
            this.txtIdentificacionOficial.Name = "txtIdentificacionOficial";
            this.txtIdentificacionOficial.Size = new System.Drawing.Size(150, 23);
            this.txtIdentificacionOficial.TabIndex = 19;

            // label30
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label30.Location = new System.Drawing.Point(260, 73);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(54, 15);
            this.label30.TabIndex = 18;
            this.label30.Text = "ID Oficial:";

            // txtZonasServicio
            this.txtZonasServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtZonasServicio.Location = new System.Drawing.Point(550, 70);
            this.txtZonasServicio.Name = "txtZonasServicio";
            this.txtZonasServicio.Size = new System.Drawing.Size(150, 23);
            this.txtZonasServicio.TabIndex = 21;

            // label31
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label31.Location = new System.Drawing.Point(480, 73);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 15);
            this.label31.TabIndex = 20;
            this.label31.Text = "Zonas Serv:";

            // Agregar controles al panel
            this.panelDatosUsuario.Controls.Add(this.txtIDUsuarioDatos);
            this.panelDatosUsuario.Controls.Add(this.label21);
            this.panelDatosUsuario.Controls.Add(this.txtNombresDatos);
            this.panelDatosUsuario.Controls.Add(this.label22);
            this.panelDatosUsuario.Controls.Add(this.txtApellidosDatos);
            this.panelDatosUsuario.Controls.Add(this.label23);
            this.panelDatosUsuario.Controls.Add(this.txtCiudadDatos);
            this.panelDatosUsuario.Controls.Add(this.label24);
            this.panelDatosUsuario.Controls.Add(this.txtDireccionDatos);
            this.panelDatosUsuario.Controls.Add(this.label25);
            this.panelDatosUsuario.Controls.Add(this.txtEmailDatos);
            this.panelDatosUsuario.Controls.Add(this.label26);
            this.panelDatosUsuario.Controls.Add(this.txtTelefonoDatos);
            this.panelDatosUsuario.Controls.Add(this.label27);
            this.panelDatosUsuario.Controls.Add(this.txtWhatsappDatos);
            this.panelDatosUsuario.Controls.Add(this.label28);
            this.panelDatosUsuario.Controls.Add(this.txtOtroContactoDatos);
            this.panelDatosUsuario.Controls.Add(this.label29);
            this.panelDatosUsuario.Controls.Add(this.txtIdentificacionOficial);
            this.panelDatosUsuario.Controls.Add(this.label30);
            this.panelDatosUsuario.Controls.Add(this.txtZonasServicio);
            this.panelDatosUsuario.Controls.Add(this.label31);

            this.panelDatosUsuario.ResumeLayout(false);
            this.panelDatosUsuario.PerformLayout();
        }

        private void InitializeServiciosPanel()
        {
            this.panelServicios = new System.Windows.Forms.Panel();
            this.txtIDUsuarioServicio = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtIDCategoriaServicio = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtIDDenominacionServicio = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtTituloServicio = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtDescripcionServicio = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cmbTipoPrecioServicio = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtMonedaServicio = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtDisponibilidadServicio = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtRadioCoberturaServicio = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtExperienciaServicio = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();

            this.panelServicios.SuspendLayout();

            // Configuración del panel
            this.panelServicios.Location = new System.Drawing.Point(20, 40);
            this.panelServicios.Name = "panelServicios";
            this.panelServicios.Size = new System.Drawing.Size(1100, 80);
            this.panelServicios.TabIndex = 7;
            this.panelServicios.Visible = false;

            // Fila 1
            // txtIDUsuarioServicio
            this.txtIDUsuarioServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDUsuarioServicio.Location = new System.Drawing.Point(100, 10);
            this.txtIDUsuarioServicio.Name = "txtIDUsuarioServicio";
            this.txtIDUsuarioServicio.Size = new System.Drawing.Size(70, 23);
            this.txtIDUsuarioServicio.TabIndex = 1;

            // label32
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label32.Location = new System.Drawing.Point(20, 13);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(69, 15);
            this.label32.TabIndex = 0;
            this.label32.Text = "ID Usuario:";

            // txtIDCategoriaServicio
            this.txtIDCategoriaServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDCategoriaServicio.Location = new System.Drawing.Point(250, 10);
            this.txtIDCategoriaServicio.Name = "txtIDCategoriaServicio";
            this.txtIDCategoriaServicio.Size = new System.Drawing.Size(70, 23);
            this.txtIDCategoriaServicio.TabIndex = 3;

            // label33
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label33.Location = new System.Drawing.Point(180, 13);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(74, 15);
            this.label33.TabIndex = 2;
            this.label33.Text = "ID Categoría:";

            // txtIDDenominacionServicio
            this.txtIDDenominacionServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDDenominacionServicio.Location = new System.Drawing.Point(400, 10);
            this.txtIDDenominacionServicio.Name = "txtIDDenominacionServicio";
            this.txtIDDenominacionServicio.Size = new System.Drawing.Size(70, 23);
            this.txtIDDenominacionServicio.TabIndex = 5;

            // label34
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label34.Location = new System.Drawing.Point(330, 13);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(64, 15);
            this.label34.TabIndex = 4;
            this.label34.Text = "ID Denom.:";

            // txtTituloServicio
            this.txtTituloServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTituloServicio.Location = new System.Drawing.Point(550, 10);
            this.txtTituloServicio.Name = "txtTituloServicio";
            this.txtTituloServicio.Size = new System.Drawing.Size(200, 23);
            this.txtTituloServicio.TabIndex = 7;

            // label35
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label35.Location = new System.Drawing.Point(480, 13);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(64, 15);
            this.label35.TabIndex = 6;
            this.label35.Text = "Título Serv:";

            // Fila 2
            // txtDescripcionServicio
            this.txtDescripcionServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcionServicio.Location = new System.Drawing.Point(100, 40);
            this.txtDescripcionServicio.Name = "txtDescripcionServicio";
            this.txtDescripcionServicio.Size = new System.Drawing.Size(150, 23);
            this.txtDescripcionServicio.TabIndex = 9;

            // label36
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label36.Location = new System.Drawing.Point(20, 43);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 15);
            this.label36.TabIndex = 8;
            this.label36.Text = "Descripción:";

            // cmbTipoPrecioServicio
            this.cmbTipoPrecioServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPrecioServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoPrecioServicio.FormattingEnabled = true;
            this.cmbTipoPrecioServicio.Items.AddRange(new object[] {
            "fijo",
            "por_hora",
            "presupuesto",
            "consultar"});
            this.cmbTipoPrecioServicio.Location = new System.Drawing.Point(320, 40);
            this.cmbTipoPrecioServicio.Name = "cmbTipoPrecioServicio";
            this.cmbTipoPrecioServicio.Size = new System.Drawing.Size(100, 23);
            this.cmbTipoPrecioServicio.TabIndex = 11;

            // label37
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label37.Location = new System.Drawing.Point(260, 43);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(54, 15);
            this.label37.TabIndex = 10;
            this.label37.Text = "Tipo Precio:";

            // txtMonedaServicio
            this.txtMonedaServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMonedaServicio.Location = new System.Drawing.Point(500, 40);
            this.txtMonedaServicio.Name = "txtMonedaServicio";
            this.txtMonedaServicio.Size = new System.Drawing.Size(50, 23);
            this.txtMonedaServicio.TabIndex = 13;
            this.txtMonedaServicio.Text = "USD";

            // label38
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label38.Location = new System.Drawing.Point(430, 43);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(64, 15);
            this.label38.TabIndex = 12;
            this.label38.Text = "Moneda:";

            // txtDisponibilidadServicio
            this.txtDisponibilidadServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDisponibilidadServicio.Location = new System.Drawing.Point(630, 40);
            this.txtDisponibilidadServicio.Name = "txtDisponibilidadServicio";
            this.txtDisponibilidadServicio.Size = new System.Drawing.Size(120, 23);
            this.txtDisponibilidadServicio.TabIndex = 15;

            // label39
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label39.Location = new System.Drawing.Point(560, 43);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(64, 15);
            this.label39.TabIndex = 14;
            this.label39.Text = "Disponible:";

            // Fila 3
            // txtRadioCoberturaServicio
            this.txtRadioCoberturaServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRadioCoberturaServicio.Location = new System.Drawing.Point(100, 70);
            this.txtRadioCoberturaServicio.Name = "txtRadioCoberturaServicio";
            this.txtRadioCoberturaServicio.Size = new System.Drawing.Size(120, 23);
            this.txtRadioCoberturaServicio.TabIndex = 17;

            // label40
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label40.Location = new System.Drawing.Point(20, 73);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(74, 15);
            this.label40.TabIndex = 16;
            this.label40.Text = "Radio Cob.:";

            // txtExperienciaServicio
            this.txtExperienciaServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtExperienciaServicio.Location = new System.Drawing.Point(300, 70);
            this.txtExperienciaServicio.Name = "txtExperienciaServicio";
            this.txtExperienciaServicio.Size = new System.Drawing.Size(200, 23);
            this.txtExperienciaServicio.TabIndex = 19;

            // label41
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label41.Location = new System.Drawing.Point(230, 73);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(64, 15);
            this.label41.TabIndex = 18;
            this.label41.Text = "Experiencia:";

            // Agregar controles al panel
            this.panelServicios.Controls.Add(this.txtIDUsuarioServicio);
            this.panelServicios.Controls.Add(this.label32);
            this.panelServicios.Controls.Add(this.txtIDCategoriaServicio);
            this.panelServicios.Controls.Add(this.label33);
            this.panelServicios.Controls.Add(this.txtIDDenominacionServicio);
            this.panelServicios.Controls.Add(this.label34);
            this.panelServicios.Controls.Add(this.txtTituloServicio);
            this.panelServicios.Controls.Add(this.label35);
            this.panelServicios.Controls.Add(this.txtDescripcionServicio);
            this.panelServicios.Controls.Add(this.label36);
            this.panelServicios.Controls.Add(this.cmbTipoPrecioServicio);
            this.panelServicios.Controls.Add(this.label37);
            this.panelServicios.Controls.Add(this.txtMonedaServicio);
            this.panelServicios.Controls.Add(this.label38);
            this.panelServicios.Controls.Add(this.txtDisponibilidadServicio);
            this.panelServicios.Controls.Add(this.label39);
            this.panelServicios.Controls.Add(this.txtRadioCoberturaServicio);
            this.panelServicios.Controls.Add(this.label40);
            this.panelServicios.Controls.Add(this.txtExperienciaServicio);
            this.panelServicios.Controls.Add(this.label41);

            this.panelServicios.ResumeLayout(false);
            this.panelServicios.PerformLayout();
        }

        private void InitializeCalificacionesPanel()
        {
            this.panelCalificaciones = new System.Windows.Forms.Panel();
            this.txtIDEmpleadoCalificacion = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtIDClienteCalificacion = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtIDServicioCalificacion = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.nudPuntuacionCalificacion = new System.Windows.Forms.NumericUpDown();
            this.label45 = new System.Windows.Forms.Label();
            this.txtComentarioCalificacion = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();

            this.panelCalificaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuntuacionCalificacion)).BeginInit();

            // Configuración del panel
            this.panelCalificaciones.Location = new System.Drawing.Point(20, 40);
            this.panelCalificaciones.Name = "panelCalificaciones";
            this.panelCalificaciones.Size = new System.Drawing.Size(1100, 80);
            this.panelCalificaciones.TabIndex = 8;
            this.panelCalificaciones.Visible = false;

            // Fila 1
            // txtIDEmpleadoCalificacion
            this.txtIDEmpleadoCalificacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDEmpleadoCalificacion.Location = new System.Drawing.Point(100, 10);
            this.txtIDEmpleadoCalificacion.Name = "txtIDEmpleadoCalificacion";
            this.txtIDEmpleadoCalificacion.Size = new System.Drawing.Size(70, 23);
            this.txtIDEmpleadoCalificacion.TabIndex = 1;

            // label42
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label42.Location = new System.Drawing.Point(20, 13);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(74, 15);
            this.label42.TabIndex = 0;
            this.label42.Text = "ID Empleado:";

            // txtIDClienteCalificacion
            this.txtIDClienteCalificacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDClienteCalificacion.Location = new System.Drawing.Point(250, 10);
            this.txtIDClienteCalificacion.Name = "txtIDClienteCalificacion";
            this.txtIDClienteCalificacion.Size = new System.Drawing.Size(70, 23);
            this.txtIDClienteCalificacion.TabIndex = 3;

            // label43
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label43.Location = new System.Drawing.Point(180, 13);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(64, 15);
            this.label43.TabIndex = 2;
            this.label43.Text = "ID Cliente:";

            // txtIDServicioCalificacion
            this.txtIDServicioCalificacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDServicioCalificacion.Location = new System.Drawing.Point(400, 10);
            this.txtIDServicioCalificacion.Name = "txtIDServicioCalificacion";
            this.txtIDServicioCalificacion.Size = new System.Drawing.Size(70, 23);
            this.txtIDServicioCalificacion.TabIndex = 5;

            // label44
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label44.Location = new System.Drawing.Point(330, 13);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(64, 15);
            this.label44.TabIndex = 4;
            this.label44.Text = "ID Servicio:";

            // nudPuntuacionCalificacion
            this.nudPuntuacionCalificacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudPuntuacionCalificacion.Location = new System.Drawing.Point(550, 10);
            this.nudPuntuacionCalificacion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPuntuacionCalificacion.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPuntuacionCalificacion.Name = "nudPuntuacionCalificacion";
            this.nudPuntuacionCalificacion.Size = new System.Drawing.Size(50, 23);
            this.nudPuntuacionCalificacion.TabIndex = 7;
            this.nudPuntuacionCalificacion.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});

            // label45
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label45.Location = new System.Drawing.Point(480, 13);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(64, 15);
            this.label45.TabIndex = 6;
            this.label45.Text = "Puntuación:";

            // Fila 2
            // txtComentarioCalificacion
            this.txtComentarioCalificacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtComentarioCalificacion.Location = new System.Drawing.Point(100, 40);
            this.txtComentarioCalificacion.Multiline = true;
            this.txtComentarioCalificacion.Name = "txtComentarioCalificacion";
            this.txtComentarioCalificacion.Size = new System.Drawing.Size(500, 30);
            this.txtComentarioCalificacion.TabIndex = 9;

            // label46
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label46.Location = new System.Drawing.Point(20, 43);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(74, 15);
            this.label46.TabIndex = 8;
            this.label46.Text = "Comentario:";

            // Agregar controles al panel
            this.panelCalificaciones.Controls.Add(this.txtIDEmpleadoCalificacion);
            this.panelCalificaciones.Controls.Add(this.label42);
            this.panelCalificaciones.Controls.Add(this.txtIDClienteCalificacion);
            this.panelCalificaciones.Controls.Add(this.label43);
            this.panelCalificaciones.Controls.Add(this.txtIDServicioCalificacion);
            this.panelCalificaciones.Controls.Add(this.label44);
            this.panelCalificaciones.Controls.Add(this.nudPuntuacionCalificacion);
            this.panelCalificaciones.Controls.Add(this.label45);
            this.panelCalificaciones.Controls.Add(this.txtComentarioCalificacion);
            this.panelCalificaciones.Controls.Add(this.label46);

            this.panelCalificaciones.ResumeLayout(false);
            this.panelCalificaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuntuacionCalificacion)).EndInit();
        }

        private void InitializeAccionesSistemaPanel()
        {
            this.panelAccionesSistema = new System.Windows.Forms.Panel();
            this.txtIDUsuarioSistemaAccion = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtAccionSistema = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtTablaAfectadaAccion = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtRegistroAfectadoAccion = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtDetallesAccion = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();

            this.panelAccionesSistema.SuspendLayout();

            // Configuración del panel
            this.panelAccionesSistema.Location = new System.Drawing.Point(20, 40);
            this.panelAccionesSistema.Name = "panelAccionesSistema";
            this.panelAccionesSistema.Size = new System.Drawing.Size(1100, 80);
            this.panelAccionesSistema.TabIndex = 9;
            this.panelAccionesSistema.Visible = false;

            // Fila 1
            // txtIDUsuarioSistemaAccion
            this.txtIDUsuarioSistemaAccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDUsuarioSistemaAccion.Location = new System.Drawing.Point(120, 10);
            this.txtIDUsuarioSistemaAccion.Name = "txtIDUsuarioSistemaAccion";
            this.txtIDUsuarioSistemaAccion.Size = new System.Drawing.Size(70, 23);
            this.txtIDUsuarioSistemaAccion.TabIndex = 1;

            // label47
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label47.Location = new System.Drawing.Point(20, 13);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(94, 15);
            this.label47.TabIndex = 0;
            this.label47.Text = "ID Usuario Sis.:";

            // txtAccionSistema
            this.txtAccionSistema.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAccionSistema.Location = new System.Drawing.Point(280, 10);
            this.txtAccionSistema.Name = "txtAccionSistema";
            this.txtAccionSistema.Size = new System.Drawing.Size(150, 23);
            this.txtAccionSistema.TabIndex = 3;

            // label48
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label48.Location = new System.Drawing.Point(200, 13);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(74, 15);
            this.label48.TabIndex = 2;
            this.label48.Text = "Acción Real.:";

            // txtTablaAfectadaAccion
            this.txtTablaAfectadaAccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTablaAfectadaAccion.Location = new System.Drawing.Point(520, 10);
            this.txtTablaAfectadaAccion.Name = "txtTablaAfectadaAccion";
            this.txtTablaAfectadaAccion.Size = new System.Drawing.Size(100, 23);
            this.txtTablaAfectadaAccion.TabIndex = 5;

            // label49
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label49.Location = new System.Drawing.Point(440, 13);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(74, 15);
            this.label49.TabIndex = 4;
            this.label49.Text = "Tabla Afect.:";

            // Fila 2
            // txtRegistroAfectadoAccion
            this.txtRegistroAfectadoAccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRegistroAfectadoAccion.Location = new System.Drawing.Point(120, 40);
            this.txtRegistroAfectadoAccion.Name = "txtRegistroAfectadoAccion";
            this.txtRegistroAfectadoAccion.Size = new System.Drawing.Size(70, 23);
            this.txtRegistroAfectadoAccion.TabIndex = 7;

            // label50
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label50.Location = new System.Drawing.Point(20, 43);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(94, 15);
            this.label50.TabIndex = 6;
            this.label50.Text = "Registro Afect.:";

            // txtDetallesAccion
            this.txtDetallesAccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetallesAccion.Location = new System.Drawing.Point(280, 40);
            this.txtDetallesAccion.Multiline = true;
            this.txtDetallesAccion.Name = "txtDetallesAccion";
            this.txtDetallesAccion.Size = new System.Drawing.Size(400, 30);
            this.txtDetallesAccion.TabIndex = 9;

            // label51
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label51.Location = new System.Drawing.Point(200, 43);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(74, 15);
            this.label51.TabIndex = 8;
            this.label51.Text = "Detalles:";

            // Agregar controles al panel
            this.panelAccionesSistema.Controls.Add(this.txtIDUsuarioSistemaAccion);
            this.panelAccionesSistema.Controls.Add(this.label47);
            this.panelAccionesSistema.Controls.Add(this.txtAccionSistema);
            this.panelAccionesSistema.Controls.Add(this.label48);
            this.panelAccionesSistema.Controls.Add(this.txtTablaAfectadaAccion);
            this.panelAccionesSistema.Controls.Add(this.label49);
            this.panelAccionesSistema.Controls.Add(this.txtRegistroAfectadoAccion);
            this.panelAccionesSistema.Controls.Add(this.label50);
            this.panelAccionesSistema.Controls.Add(this.txtDetallesAccion);
            this.panelAccionesSistema.Controls.Add(this.label51);

            this.panelAccionesSistema.ResumeLayout(false);
            this.panelAccionesSistema.PerformLayout();
        }

        private void InitializeExperienciaUsuarioPanel()
        {
            this.panelExperienciaUsuario = new System.Windows.Forms.Panel();
            this.txtIDUsuarioExperiencia = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.cmbTipoRegistroExperiencia = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.cmbNivelEstudiosExperiencia = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.txtAnosExperiencia = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.txtEmpresasAnteriores = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.txtProyectosDestacados = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.txtReferenciasLaborales = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.txtTipoExperiencia = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.txtDescripcionOtro = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();

            this.panelExperienciaUsuario.SuspendLayout();

            // Configuración del panel
            this.panelExperienciaUsuario.Location = new System.Drawing.Point(20, 40);
            this.panelExperienciaUsuario.Name = "panelExperienciaUsuario";
            this.panelExperienciaUsuario.Size = new System.Drawing.Size(1100, 80);
            this.panelExperienciaUsuario.TabIndex = 10;
            this.panelExperienciaUsuario.Visible = false;

            // Fila 1
            // txtIDUsuarioExperiencia
            this.txtIDUsuarioExperiencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDUsuarioExperiencia.Location = new System.Drawing.Point(120, 10);
            this.txtIDUsuarioExperiencia.Name = "txtIDUsuarioExperiencia";
            this.txtIDUsuarioExperiencia.Size = new System.Drawing.Size(70, 23);
            this.txtIDUsuarioExperiencia.TabIndex = 1;

            // label52
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label52.Location = new System.Drawing.Point(20, 13);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(69, 15);
            this.label52.TabIndex = 0;
            this.label52.Text = "ID Usuario:";

            // cmbTipoRegistroExperiencia
            this.cmbTipoRegistroExperiencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRegistroExperiencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoRegistroExperiencia.FormattingEnabled = true;
            this.cmbTipoRegistroExperiencia.Items.AddRange(new object[] {
            "certificado",
            "empirico"});
            this.cmbTipoRegistroExperiencia.Location = new System.Drawing.Point(320, 10);
            this.cmbTipoRegistroExperiencia.Name = "cmbTipoRegistroExperiencia";
            this.cmbTipoRegistroExperiencia.Size = new System.Drawing.Size(100, 23);
            this.cmbTipoRegistroExperiencia.TabIndex = 3;

            // label53
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label53.Location = new System.Drawing.Point(200, 13);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(114, 15);
            this.label53.TabIndex = 2;
            this.label53.Text = "Tipo de Registro:";

            // cmbNivelEstudiosExperiencia
            this.cmbNivelEstudiosExperiencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelEstudiosExperiencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbNivelEstudiosExperiencia.FormattingEnabled = true;
            this.cmbNivelEstudiosExperiencia.Items.AddRange(new object[] {
            "tecnico",
            "tecnologo",
            "profesional",
            "especializacion",
            "maestria",
            "doctorado"});
            this.cmbNivelEstudiosExperiencia.Location = new System.Drawing.Point(550, 10);
            this.cmbNivelEstudiosExperiencia.Name = "cmbNivelEstudiosExperiencia";
            this.cmbNivelEstudiosExperiencia.Size = new System.Drawing.Size(120, 23);
            this.cmbNivelEstudiosExperiencia.TabIndex = 5;

            // label54
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label54.Location = new System.Drawing.Point(430, 13);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(114, 15);
            this.label54.TabIndex = 4;
            this.label54.Text = "Nivel de Estudios:";

            // Fila 2
            // txtAnosExperiencia
            this.txtAnosExperiencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAnosExperiencia.Location = new System.Drawing.Point(120, 40);
            this.txtAnosExperiencia.Name = "txtAnosExperiencia";
            this.txtAnosExperiencia.Size = new System.Drawing.Size(100, 23);
            this.txtAnosExperiencia.TabIndex = 7;

            // label55
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label55.Location = new System.Drawing.Point(20, 43);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(94, 15);
            this.label55.TabIndex = 6;
            this.label55.Text = "Años Experiencia:";

            // txtEmpresasAnteriores
            this.txtEmpresasAnteriores.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmpresasAnteriores.Location = new System.Drawing.Point(320, 40);
            this.txtEmpresasAnteriores.Name = "txtEmpresasAnteriores";
            this.txtEmpresasAnteriores.Size = new System.Drawing.Size(150, 23);
            this.txtEmpresasAnteriores.TabIndex = 9;

            // label56
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label56.Location = new System.Drawing.Point(230, 43);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(84, 15);
            this.label56.TabIndex = 8;
            this.label56.Text = "Empresas Ant.:";

            // txtProyectosDestacados
            this.txtProyectosDestacados.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProyectosDestacados.Location = new System.Drawing.Point(550, 40);
            this.txtProyectosDestacados.Name = "txtProyectosDestacados";
            this.txtProyectosDestacados.Size = new System.Drawing.Size(150, 23);
            this.txtProyectosDestacados.TabIndex = 11;

            // label57
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label57.Location = new System.Drawing.Point(480, 43);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(64, 15);
            this.label57.TabIndex = 10;
            this.label57.Text = "Proyectos:";

            // Fila 3
            // txtReferenciasLaborales
            this.txtReferenciasLaborales.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReferenciasLaborales.Location = new System.Drawing.Point(120, 70);
            this.txtReferenciasLaborales.Name = "txtReferenciasLaborales";
            this.txtReferenciasLaborales.Size = new System.Drawing.Size(150, 23);
            this.txtReferenciasLaborales.TabIndex = 13;

            // label58
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label58.Location = new System.Drawing.Point(20, 73);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(94, 15);
            this.label58.TabIndex = 12;
            this.label58.Text = "Referencias:";

            // txtTipoExperiencia
            this.txtTipoExperiencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTipoExperiencia.Location = new System.Drawing.Point(320, 70);
            this.txtTipoExperiencia.Name = "txtTipoExperiencia";
            this.txtTipoExperiencia.Size = new System.Drawing.Size(150, 23);
            this.txtTipoExperiencia.TabIndex = 15;

            // label59
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label59.Location = new System.Drawing.Point(280, 73);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(34, 15);
            this.label59.TabIndex = 14;
            this.label59.Text = "Tipo:";

            // txtDescripcionOtro
            this.txtDescripcionOtro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcionOtro.Location = new System.Drawing.Point(550, 70);
            this.txtDescripcionOtro.Name = "txtDescripcionOtro";
            this.txtDescripcionOtro.Size = new System.Drawing.Size(200, 23);
            this.txtDescripcionOtro.TabIndex = 17;

            // label60
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label60.Location = new System.Drawing.Point(480, 73);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(64, 15);
            this.label60.TabIndex = 16;
            this.label60.Text = "Descripción:";

            // Agregar controles al panel
            this.panelExperienciaUsuario.Controls.Add(this.txtIDUsuarioExperiencia);
            this.panelExperienciaUsuario.Controls.Add(this.label52);
            this.panelExperienciaUsuario.Controls.Add(this.cmbTipoRegistroExperiencia);
            this.panelExperienciaUsuario.Controls.Add(this.label53);
            this.panelExperienciaUsuario.Controls.Add(this.cmbNivelEstudiosExperiencia);
            this.panelExperienciaUsuario.Controls.Add(this.label54);
            this.panelExperienciaUsuario.Controls.Add(this.txtAnosExperiencia);
            this.panelExperienciaUsuario.Controls.Add(this.label55);
            this.panelExperienciaUsuario.Controls.Add(this.txtEmpresasAnteriores);
            this.panelExperienciaUsuario.Controls.Add(this.label56);
            this.panelExperienciaUsuario.Controls.Add(this.txtProyectosDestacados);
            this.panelExperienciaUsuario.Controls.Add(this.label57);
            this.panelExperienciaUsuario.Controls.Add(this.txtReferenciasLaborales);
            this.panelExperienciaUsuario.Controls.Add(this.label58);
            this.panelExperienciaUsuario.Controls.Add(this.txtTipoExperiencia);
            this.panelExperienciaUsuario.Controls.Add(this.label59);
            this.panelExperienciaUsuario.Controls.Add(this.txtDescripcionOtro);
            this.panelExperienciaUsuario.Controls.Add(this.label60);

            this.panelExperienciaUsuario.ResumeLayout(false);
            this.panelExperienciaUsuario.PerformLayout();
        }

        private void InitializeArchivosProveedorPanel()
        {
            this.panelArchivosProveedor = new System.Windows.Forms.Panel();
            this.txtIDUsuarioArchivoProveedor = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.txtNombreArchivoProveedor = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.cmbTipoArchivoProveedor = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.cmbCategoriaArchivoProveedor = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.chkObligatorioArchivo = new System.Windows.Forms.CheckBox();
            this.btnSeleccionarArchivoProveedor = new System.Windows.Forms.Button();
            this.lblArchivoSeleccionadoProveedor = new System.Windows.Forms.Label();
            this.openFileDialogProveedor = new System.Windows.Forms.OpenFileDialog();

            this.panelArchivosProveedor.SuspendLayout();

            // Configuración del panel
            this.panelArchivosProveedor.Location = new System.Drawing.Point(20, 40);
            this.panelArchivosProveedor.Name = "panelArchivosProveedor";
            this.panelArchivosProveedor.Size = new System.Drawing.Size(1100, 80);
            this.panelArchivosProveedor.TabIndex = 11;
            this.panelArchivosProveedor.Visible = false;

            // Fila 1
            // txtIDUsuarioArchivoProveedor
            this.txtIDUsuarioArchivoProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDUsuarioArchivoProveedor.Location = new System.Drawing.Point(120, 10);
            this.txtIDUsuarioArchivoProveedor.Name = "txtIDUsuarioArchivoProveedor";
            this.txtIDUsuarioArchivoProveedor.Size = new System.Drawing.Size(70, 23);
            this.txtIDUsuarioArchivoProveedor.TabIndex = 1;

            // label61
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label61.Location = new System.Drawing.Point(20, 13);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(69, 15);
            this.label61.TabIndex = 0;
            this.label61.Text = "ID Usuario:";

            // txtNombreArchivoProveedor
            this.txtNombreArchivoProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreArchivoProveedor.Location = new System.Drawing.Point(320, 10);
            this.txtNombreArchivoProveedor.Name = "txtNombreArchivoProveedor";
            this.txtNombreArchivoProveedor.Size = new System.Drawing.Size(200, 23);
            this.txtNombreArchivoProveedor.TabIndex = 3;

            // label62
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label62.Location = new System.Drawing.Point(200, 13);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(114, 15);
            this.label62.TabIndex = 2;
            this.label62.Text = "Nombre Archivo:";

            // cmbTipoArchivoProveedor
            this.cmbTipoArchivoProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoArchivoProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoArchivoProveedor.FormattingEnabled = true;
            this.cmbTipoArchivoProveedor.Items.AddRange(new object[] {
            "image/jpeg",
            "image/png",
            "application/pdf",
            "application/msword"});
            this.cmbTipoArchivoProveedor.Location = new System.Drawing.Point(620, 10);
            this.cmbTipoArchivoProveedor.Name = "cmbTipoArchivoProveedor";
            this.cmbTipoArchivoProveedor.Size = new System.Drawing.Size(150, 23);
            this.cmbTipoArchivoProveedor.TabIndex = 5;

            // label63
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label63.Location = new System.Drawing.Point(530, 13);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(84, 15);
            this.label63.TabIndex = 4;
            this.label63.Text = "Tipo Archivo:";

            // Fila 2
            // cmbCategoriaArchivoProveedor
            this.cmbCategoriaArchivoProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaArchivoProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCategoriaArchivoProveedor.FormattingEnabled = true;
            this.cmbCategoriaArchivoProveedor.Items.AddRange(new object[] {
            "certificado",
            "titulo",
            "licencia",
            "internacional",
            "foto_trabajo",
            "testimonio",
            "referencia"});
            this.cmbCategoriaArchivoProveedor.Location = new System.Drawing.Point(120, 40);
            this.cmbCategoriaArchivoProveedor.Name = "cmbCategoriaArchivoProveedor";
            this.cmbCategoriaArchivoProveedor.Size = new System.Drawing.Size(150, 23);
            this.cmbCategoriaArchivoProveedor.TabIndex = 7;

            // label64
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label64.Location = new System.Drawing.Point(20, 43);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(94, 15);
            this.label64.TabIndex = 6;
            this.label64.Text = "Categoría Archivo:";

            // chkObligatorioArchivo
            this.chkObligatorioArchivo.AutoSize = true;
            this.chkObligatorioArchivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkObligatorioArchivo.Location = new System.Drawing.Point(320, 42);
            this.chkObligatorioArchivo.Name = "chkObligatorioArchivo";
            this.chkObligatorioArchivo.Size = new System.Drawing.Size(84, 19);
            this.chkObligatorioArchivo.TabIndex = 8;
            this.chkObligatorioArchivo.Text = "Obligatorio";
            this.chkObligatorioArchivo.UseVisualStyleBackColor = true;

            // btnSeleccionarArchivoProveedor
            this.btnSeleccionarArchivoProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSeleccionarArchivoProveedor.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarArchivoProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarArchivoProveedor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionarArchivoProveedor.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarArchivoProveedor.Location = new System.Drawing.Point(450, 40);
            this.btnSeleccionarArchivoProveedor.Name = "btnSeleccionarArchivoProveedor";
            this.btnSeleccionarArchivoProveedor.Size = new System.Drawing.Size(140, 23);
            this.btnSeleccionarArchivoProveedor.TabIndex = 9;
            this.btnSeleccionarArchivoProveedor.Text = "Seleccionar Archivo";
            this.btnSeleccionarArchivoProveedor.UseVisualStyleBackColor = false;

            // lblArchivoSeleccionadoProveedor
            this.lblArchivoSeleccionadoProveedor.AutoSize = true;
            this.lblArchivoSeleccionadoProveedor.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblArchivoSeleccionadoProveedor.ForeColor = System.Drawing.Color.Gray;
            this.lblArchivoSeleccionadoProveedor.Location = new System.Drawing.Point(610, 45);
            this.lblArchivoSeleccionadoProveedor.Name = "lblArchivoSeleccionadoProveedor";
            this.lblArchivoSeleccionadoProveedor.Size = new System.Drawing.Size(120, 13);
            this.lblArchivoSeleccionadoProveedor.TabIndex = 10;
            this.lblArchivoSeleccionadoProveedor.Text = "Ningún archivo seleccionado";

            // Agregar controles al panel
            this.panelArchivosProveedor.Controls.Add(this.txtIDUsuarioArchivoProveedor);
            this.panelArchivosProveedor.Controls.Add(this.label61);
            this.panelArchivosProveedor.Controls.Add(this.txtNombreArchivoProveedor);
            this.panelArchivosProveedor.Controls.Add(this.label62);
            this.panelArchivosProveedor.Controls.Add(this.cmbTipoArchivoProveedor);
            this.panelArchivosProveedor.Controls.Add(this.label63);
            this.panelArchivosProveedor.Controls.Add(this.cmbCategoriaArchivoProveedor);
            this.panelArchivosProveedor.Controls.Add(this.label64);
            this.panelArchivosProveedor.Controls.Add(this.chkObligatorioArchivo);
            this.panelArchivosProveedor.Controls.Add(this.btnSeleccionarArchivoProveedor);
            this.panelArchivosProveedor.Controls.Add(this.lblArchivoSeleccionadoProveedor);

            this.panelArchivosProveedor.ResumeLayout(false);
            this.panelArchivosProveedor.PerformLayout();
        }

        private void InitializeArchivosGeneralesPanel()
        {
            this.panelArchivosGenerales = new System.Windows.Forms.Panel();
            this.txtNombreArchivoGeneral = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.cmbTipoArchivoGeneral = new System.Windows.Forms.ComboBox();
            this.label66 = new System.Windows.Forms.Label();
            this.txtCategoriaArchivoGeneral = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.txtDescripcionArchivoGeneral = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.btnSeleccionarArchivoGeneral = new System.Windows.Forms.Button();
            this.lblArchivoSeleccionadoGeneral = new System.Windows.Forms.Label();
            this.openFileDialogGeneral = new System.Windows.Forms.OpenFileDialog();

            this.panelArchivosGenerales.SuspendLayout();

            // Configuración del panel
            this.panelArchivosGenerales.Location = new System.Drawing.Point(20, 40);
            this.panelArchivosGenerales.Name = "panelArchivosGenerales";
            this.panelArchivosGenerales.Size = new System.Drawing.Size(1100, 80);
            this.panelArchivosGenerales.TabIndex = 12;
            this.panelArchivosGenerales.Visible = false;

            // Fila 1
            // txtNombreArchivoGeneral
            this.txtNombreArchivoGeneral.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreArchivoGeneral.Location = new System.Drawing.Point(120, 10);
            this.txtNombreArchivoGeneral.Name = "txtNombreArchivoGeneral";
            this.txtNombreArchivoGeneral.Size = new System.Drawing.Size(200, 23);
            this.txtNombreArchivoGeneral.TabIndex = 1;

            // label65
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label65.Location = new System.Drawing.Point(20, 13);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(94, 15);
            this.label65.TabIndex = 0;
            this.label65.Text = "Nombre Archivo:";

            // cmbTipoArchivoGeneral
            this.cmbTipoArchivoGeneral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoArchivoGeneral.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoArchivoGeneral.FormattingEnabled = true;
            this.cmbTipoArchivoGeneral.Items.AddRange(new object[] {
            "image/jpeg",
            "image/png",
            "image/gif",
            "application/pdf",
            "application/msword",
            "text/plain"});
            this.cmbTipoArchivoGeneral.Location = new System.Drawing.Point(420, 10);
            this.cmbTipoArchivoGeneral.Name = "cmbTipoArchivoGeneral";
            this.cmbTipoArchivoGeneral.Size = new System.Drawing.Size(150, 23);
            this.cmbTipoArchivoGeneral.TabIndex = 3;

            // label66
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label66.Location = new System.Drawing.Point(330, 13);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(84, 15);
            this.label66.TabIndex = 2;
            this.label66.Text = "Tipo Archivo:";

            // txtCategoriaArchivoGeneral
            this.txtCategoriaArchivoGeneral.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCategoriaArchivoGeneral.Location = new System.Drawing.Point(670, 10);
            this.txtCategoriaArchivoGeneral.Name = "txtCategoriaArchivoGeneral";
            this.txtCategoriaArchivoGeneral.Size = new System.Drawing.Size(150, 23);
            this.txtCategoriaArchivoGeneral.TabIndex = 5;

            // label67
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label67.Location = new System.Drawing.Point(580, 13);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(84, 15);
            this.label67.TabIndex = 4;
            this.label67.Text = "Categoría:";

            // Fila 2
            // txtDescripcionArchivoGeneral
            this.txtDescripcionArchivoGeneral.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcionArchivoGeneral.Location = new System.Drawing.Point(120, 40);
            this.txtDescripcionArchivoGeneral.Multiline = true;
            this.txtDescripcionArchivoGeneral.Name = "txtDescripcionArchivoGeneral";
            this.txtDescripcionArchivoGeneral.Size = new System.Drawing.Size(300, 30);
            this.txtDescripcionArchivoGeneral.TabIndex = 7;

            // label68
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label68.Location = new System.Drawing.Point(20, 43);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(94, 15);
            this.label68.TabIndex = 6;
            this.label68.Text = "Descripción:";

            // btnSeleccionarArchivoGeneral
            this.btnSeleccionarArchivoGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSeleccionarArchivoGeneral.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarArchivoGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarArchivoGeneral.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionarArchivoGeneral.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarArchivoGeneral.Location = new System.Drawing.Point(450, 40);
            this.btnSeleccionarArchivoGeneral.Name = "btnSeleccionarArchivoGeneral";
            this.btnSeleccionarArchivoGeneral.Size = new System.Drawing.Size(140, 23);
            this.btnSeleccionarArchivoGeneral.TabIndex = 8;
            this.btnSeleccionarArchivoGeneral.Text = "Seleccionar Archivo";
            this.btnSeleccionarArchivoGeneral.UseVisualStyleBackColor = false;

            // lblArchivoSeleccionadoGeneral
            this.lblArchivoSeleccionadoGeneral.AutoSize = true;
            this.lblArchivoSeleccionadoGeneral.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblArchivoSeleccionadoGeneral.ForeColor = System.Drawing.Color.Gray;
            this.lblArchivoSeleccionadoGeneral.Location = new System.Drawing.Point(610, 45);
            this.lblArchivoSeleccionadoGeneral.Name = "lblArchivoSeleccionadoGeneral";
            this.lblArchivoSeleccionadoGeneral.Size = new System.Drawing.Size(120, 13);
            this.lblArchivoSeleccionadoGeneral.TabIndex = 9;
            this.lblArchivoSeleccionadoGeneral.Text = "Ningún archivo seleccionado";

            // Agregar controles al panel
            this.panelArchivosGenerales.Controls.Add(this.txtNombreArchivoGeneral);
            this.panelArchivosGenerales.Controls.Add(this.label65);
            this.panelArchivosGenerales.Controls.Add(this.cmbTipoArchivoGeneral);
            this.panelArchivosGenerales.Controls.Add(this.label66);
            this.panelArchivosGenerales.Controls.Add(this.txtCategoriaArchivoGeneral);
            this.panelArchivosGenerales.Controls.Add(this.label67);
            this.panelArchivosGenerales.Controls.Add(this.txtDescripcionArchivoGeneral);
            this.panelArchivosGenerales.Controls.Add(this.label68);
            this.panelArchivosGenerales.Controls.Add(this.btnSeleccionarArchivoGeneral);
            this.panelArchivosGenerales.Controls.Add(this.lblArchivoSeleccionadoGeneral);

            this.panelArchivosGenerales.ResumeLayout(false);
            this.panelArchivosGenerales.PerformLayout();
        }
    }
}