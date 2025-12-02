// VerificationTabPage.Designer.cs
namespace Verification
{
    partial class VerificationTabPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvRegistrosTemp;
        private System.Windows.Forms.TextBox txtBuscarTemp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.Button btnConfirmarRegistro;
        private System.Windows.Forms.Button btnRechazarRegistro;
        private System.Windows.Forms.ComboBox cmbRolAsignar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRefreshTemp;
        private System.Windows.Forms.Label lblInfoTemp;

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
            this.dgvRegistrosTemp = new System.Windows.Forms.DataGridView();
            this.txtBuscarTemp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.btnConfirmarRegistro = new System.Windows.Forms.Button();
            this.btnRechazarRegistro = new System.Windows.Forms.Button();
            this.cmbRolAsignar = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefreshTemp = new System.Windows.Forms.Button();
            this.lblInfoTemp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRegistrosTemp
            // 
            this.dgvRegistrosTemp.AllowUserToAddRows = false;
            this.dgvRegistrosTemp.AllowUserToDeleteRows = false;
            this.dgvRegistrosTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegistrosTemp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistrosTemp.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegistrosTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegistrosTemp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegistrosTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegistrosTemp.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegistrosTemp.Location = new System.Drawing.Point(8, 50);
            this.dgvRegistrosTemp.MultiSelect = false;
            this.dgvRegistrosTemp.Name = "dgvRegistrosTemp";
            this.dgvRegistrosTemp.ReadOnly = true;
            this.dgvRegistrosTemp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistrosTemp.Size = new System.Drawing.Size(1176, 520);
            this.dgvRegistrosTemp.TabIndex = 0;
            this.dgvRegistrosTemp.SelectionChanged += new System.EventHandler(this.dgvRegistrosTemp_SelectionChanged);
            // 
            // txtBuscarTemp
            // 
            this.txtBuscarTemp.Location = new System.Drawing.Point(100, 12);
            this.txtBuscarTemp.Name = "txtBuscarTemp";
            this.txtBuscarTemp.Size = new System.Drawing.Size(140, 20);
            this.txtBuscarTemp.TabIndex = 1;
            this.txtBuscarTemp.TextChanged += new System.EventHandler(this.txtBuscarTemp_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Buscar:";
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerDetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnVerDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalles.ForeColor = System.Drawing.Color.White;
            this.btnVerDetalles.Location = new System.Drawing.Point(8, 575);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(120, 35);
            this.btnVerDetalles.TabIndex = 3;
            this.btnVerDetalles.Text = "Ver Detalles";
            this.btnVerDetalles.UseVisualStyleBackColor = false;
            this.btnVerDetalles.Click += new System.EventHandler(this.btnVerDetalles_Click);
            // 
            // btnConfirmarRegistro
            // 
            this.btnConfirmarRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirmarRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnConfirmarRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarRegistro.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarRegistro.Location = new System.Drawing.Point(480, 575);
            this.btnConfirmarRegistro.Name = "btnConfirmarRegistro";
            this.btnConfirmarRegistro.Size = new System.Drawing.Size(140, 35);
            this.btnConfirmarRegistro.TabIndex = 4;
            this.btnConfirmarRegistro.Text = "Confirmar Registro";
            this.btnConfirmarRegistro.UseVisualStyleBackColor = false;
            this.btnConfirmarRegistro.Click += new System.EventHandler(this.btnConfirmarRegistro_Click);
            // 
            // btnRechazarRegistro
            // 
            this.btnRechazarRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRechazarRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnRechazarRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazarRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazarRegistro.ForeColor = System.Drawing.Color.White;
            this.btnRechazarRegistro.Location = new System.Drawing.Point(134, 575);
            this.btnRechazarRegistro.Name = "btnRechazarRegistro";
            this.btnRechazarRegistro.Size = new System.Drawing.Size(140, 35);
            this.btnRechazarRegistro.TabIndex = 5;
            this.btnRechazarRegistro.Text = "Rechazar Registro";
            this.btnRechazarRegistro.UseVisualStyleBackColor = false;
            this.btnRechazarRegistro.Click += new System.EventHandler(this.btnRechazarRegistro_Click);
            // 
            // cmbRolAsignar
            // 
            this.cmbRolAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbRolAsignar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRolAsignar.FormattingEnabled = true;
            this.cmbRolAsignar.Location = new System.Drawing.Point(340, 580);
            this.cmbRolAsignar.Name = "cmbRolAsignar";
            this.cmbRolAsignar.Size = new System.Drawing.Size(130, 21);
            this.cmbRolAsignar.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 583);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Asignar a:";
            // 
            // btnRefreshTemp
            // 
            this.btnRefreshTemp.Location = new System.Drawing.Point(250, 10);
            this.btnRefreshTemp.Name = "btnRefreshTemp";
            this.btnRefreshTemp.Size = new System.Drawing.Size(40, 25);
            this.btnRefreshTemp.TabIndex = 8;
            this.btnRefreshTemp.Text = "↻";
            this.btnRefreshTemp.UseVisualStyleBackColor = true;
            this.btnRefreshTemp.Click += new System.EventHandler(this.btnRefreshTemp_Click);
            // 
            // lblInfoTemp
            // 
            this.lblInfoTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoTemp.AutoSize = true;
            this.lblInfoTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoTemp.Location = new System.Drawing.Point(900, 15);
            this.lblInfoTemp.Name = "lblInfoTemp";
            this.lblInfoTemp.Size = new System.Drawing.Size(41, 15);
            this.lblInfoTemp.TabIndex = 9;
            this.lblInfoTemp.Text = "label8";
            // 
            // VerificationTabPage
            // 
            this.Controls.Add(this.lblInfoTemp);
            this.Controls.Add(this.btnRefreshTemp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbRolAsignar);
            this.Controls.Add(this.btnRechazarRegistro);
            this.Controls.Add(this.btnConfirmarRegistro);
            this.Controls.Add(this.btnVerDetalles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBuscarTemp);
            this.Controls.Add(this.dgvRegistrosTemp);
            this.Name = "VerificationTabPage";
            this.Size = new System.Drawing.Size(1192, 628);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrosTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}