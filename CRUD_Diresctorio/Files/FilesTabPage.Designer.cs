// FilesTabPage.Designer.cs
namespace CRUD_Directorio.Files
{
    partial class FilesTabPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvArchivos;
        private System.Windows.Forms.Button btnSubirArchivo;
        private System.Windows.Forms.Button btnDescargarArchivo;
        private System.Windows.Forms.Button btnEliminarArchivo;
        private System.Windows.Forms.Button btnRefreshArchivos;
        private System.Windows.Forms.Label lblTotalArchivos;
        private System.Windows.Forms.TextBox txtBuscarArchivo;
        private System.Windows.Forms.Label label8;

        // Botones adicionales que faltaban
        private System.Windows.Forms.Button btnVerArchivo;
       

        private System.Windows.Forms.DataGridViewTextBoxColumn colIDArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTamanio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDUsuario;

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
            this.dgvArchivos = new System.Windows.Forms.DataGridView();
            this.colIDArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTamanio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubirArchivo = new System.Windows.Forms.Button();
            this.btnDescargarArchivo = new System.Windows.Forms.Button();
            this.btnEliminarArchivo = new System.Windows.Forms.Button();
            this.btnRefreshArchivos = new System.Windows.Forms.Button();
            this.lblTotalArchivos = new System.Windows.Forms.Label();
            this.txtBuscarArchivo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();

            // Inicialización de botones adicionales
            this.btnVerArchivo = new System.Windows.Forms.Button();
            

            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArchivos
            // 
            this.dgvArchivos.AllowUserToAddRows = false;
            this.dgvArchivos.AllowUserToDeleteRows = false;
            this.dgvArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArchivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArchivos.BackgroundColor = System.Drawing.Color.White;
            this.dgvArchivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArchivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIDArchivo,
            this.colNombre,
            this.colTipo,
            this.colCategoria,
            this.colUsuario,
            this.colFecha,
            this.colTamanio,
            this.colOrigen,
            this.colIDUsuario});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArchivos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArchivos.Location = new System.Drawing.Point(8, 50);
            this.dgvArchivos.MultiSelect = false;
            this.dgvArchivos.Name = "dgvArchivos";
            this.dgvArchivos.ReadOnly = true;
            this.dgvArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArchivos.Size = new System.Drawing.Size(1176, 520);
            this.dgvArchivos.TabIndex = 0;
            this.dgvArchivos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArchivos_CellDoubleClick);
            // 
            // colIDArchivo
            // 
            this.colIDArchivo.DataPropertyName = "ID_Archivo";
            this.colIDArchivo.FillWeight = 60F;
            this.colIDArchivo.HeaderText = "ID";
            this.colIDArchivo.Name = "colIDArchivo";
            this.colIDArchivo.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "nombre_archivo";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colTipo
            // 
            this.colTipo.DataPropertyName = "tipo_archivo";
            this.colTipo.FillWeight = 120F;
            this.colTipo.HeaderText = "Tipo MIME";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            // 
            // colCategoria
            // 
            this.colCategoria.DataPropertyName = "categoria_archivo";
            this.colCategoria.FillWeight = 90F;
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // colUsuario
            // 
            this.colUsuario.DataPropertyName = "usuario_nombre";
            this.colUsuario.FillWeight = 120F;
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "fecha_creacion";
            this.colFecha.FillWeight = 100F;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colTamanio
            // 
            this.colTamanio.DataPropertyName = "tamanio_kb";
            this.colTamanio.FillWeight = 80F;
            this.colTamanio.HeaderText = "Tamaño";
            this.colTamanio.Name = "colTamanio";
            this.colTamanio.ReadOnly = true;
            // 
            // colOrigen
            // 
            this.colOrigen.DataPropertyName = "origen";
            this.colOrigen.FillWeight = 80F;
            this.colOrigen.HeaderText = "Origen";
            this.colOrigen.Name = "colOrigen";
            this.colOrigen.ReadOnly = true;
            // 
            // colIDUsuario
            // 
            this.colIDUsuario.DataPropertyName = "ID_Usuario";
            this.colIDUsuario.FillWeight = 80F;
            this.colIDUsuario.HeaderText = "ID Usuario";
            this.colIDUsuario.Name = "colIDUsuario";
            this.colIDUsuario.ReadOnly = true;
            this.colIDUsuario.Visible = false;
            // 
            // btnSubirArchivo
            // 
            this.btnSubirArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubirArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSubirArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirArchivo.ForeColor = System.Drawing.Color.White;
            this.btnSubirArchivo.Location = new System.Drawing.Point(8, 575);
            this.btnSubirArchivo.Name = "btnSubirArchivo";
            this.btnSubirArchivo.Size = new System.Drawing.Size(120, 35);
            this.btnSubirArchivo.TabIndex = 1;
            this.btnSubirArchivo.Text = "Subir Archivo";
            this.btnSubirArchivo.UseVisualStyleBackColor = false;
            this.btnSubirArchivo.Click += new System.EventHandler(this.btnSubirArchivo_Click);
            // 
            // btnDescargarArchivo
            // 
            this.btnDescargarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDescargarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnDescargarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargarArchivo.ForeColor = System.Drawing.Color.White;
            this.btnDescargarArchivo.Location = new System.Drawing.Point(134, 575);
            this.btnDescargarArchivo.Name = "btnDescargarArchivo";
            this.btnDescargarArchivo.Size = new System.Drawing.Size(120, 35);
            this.btnDescargarArchivo.TabIndex = 2;
            this.btnDescargarArchivo.Text = "Descargar";
            this.btnDescargarArchivo.UseVisualStyleBackColor = false;
            this.btnDescargarArchivo.Click += new System.EventHandler(this.btnDescargarArchivo_Click);
            // 
            // btnEliminarArchivo
            // 
            this.btnEliminarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnEliminarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArchivo.ForeColor = System.Drawing.Color.White;
            this.btnEliminarArchivo.Location = new System.Drawing.Point(260, 575);
            this.btnEliminarArchivo.Name = "btnEliminarArchivo";
            this.btnEliminarArchivo.Size = new System.Drawing.Size(120, 35);
            this.btnEliminarArchivo.TabIndex = 3;
            this.btnEliminarArchivo.Text = "Eliminar";
            this.btnEliminarArchivo.UseVisualStyleBackColor = false;
            this.btnEliminarArchivo.Click += new System.EventHandler(this.btnEliminarArchivo_Click);
            // 
            // btnRefreshArchivos
            // 
            this.btnRefreshArchivos.Location = new System.Drawing.Point(250, 10);
            this.btnRefreshArchivos.Name = "btnRefreshArchivos";
            this.btnRefreshArchivos.Size = new System.Drawing.Size(40, 25);
            this.btnRefreshArchivos.TabIndex = 4;
            this.btnRefreshArchivos.Text = "↻";
            this.btnRefreshArchivos.UseVisualStyleBackColor = true;
            this.btnRefreshArchivos.Click += new System.EventHandler(this.btnRefreshArchivos_Click);
            // 
            // lblTotalArchivos
            // 
            this.lblTotalArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalArchivos.AutoSize = true;
            this.lblTotalArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArchivos.Location = new System.Drawing.Point(1000, 15);
            this.lblTotalArchivos.Name = "lblTotalArchivos";
            this.lblTotalArchivos.Size = new System.Drawing.Size(114, 15);
            this.lblTotalArchivos.TabIndex = 5;
            this.lblTotalArchivos.Text = "Total archivos: 0";
            // 
            // txtBuscarArchivo
            // 
            this.txtBuscarArchivo.Location = new System.Drawing.Point(100, 12);
            this.txtBuscarArchivo.Name = "txtBuscarArchivo";
            this.txtBuscarArchivo.Size = new System.Drawing.Size(140, 20);
            this.txtBuscarArchivo.TabIndex = 6;
            this.txtBuscarArchivo.TextChanged += new System.EventHandler(this.txtBuscarArchivo_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Buscar:";
            // 
            // btnVerArchivo
            // 
            this.btnVerArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnVerArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerArchivo.ForeColor = System.Drawing.Color.White;
            this.btnVerArchivo.Location = new System.Drawing.Point(386, 575);
            this.btnVerArchivo.Name = "btnVerArchivo";
            this.btnVerArchivo.Size = new System.Drawing.Size(120, 35);
            this.btnVerArchivo.TabIndex = 8;
            this.btnVerArchivo.Text = "Ver Archivo";
            this.btnVerArchivo.UseVisualStyleBackColor = false;
            this.btnVerArchivo.Click += new System.EventHandler(this.btnVerArchivo_Click);
            // 
            // FilesTabPage
            // 
            this.Controls.Add(this.btnVerArchivo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBuscarArchivo);
            this.Controls.Add(this.lblTotalArchivos);
            this.Controls.Add(this.btnRefreshArchivos);
            this.Controls.Add(this.btnEliminarArchivo);
            this.Controls.Add(this.btnDescargarArchivo);
            this.Controls.Add(this.btnSubirArchivo);
            this.Controls.Add(this.dgvArchivos);
            this.Name = "FilesTabPage";
            this.Size = new System.Drawing.Size(1192, 628);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}