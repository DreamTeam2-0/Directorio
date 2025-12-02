using System;

using System.Windows.Forms;

namespace LoginDirectorio.RegistroFases
{
    partial class FaseEmpirico
    {
        private void InitializeComponent()
        {
            this.cmbAnosExperienciaEmp = new System.Windows.Forms.ComboBox();
            this.chkIndependiente = new System.Windows.Forms.CheckBox();
            this.chkEmpresa = new System.Windows.Forms.CheckBox();
            this.chkFamiliar = new System.Windows.Forms.CheckBox();
            this.chkOtro = new System.Windows.Forms.CheckBox();
            this.txtDescripcionOtro = new System.Windows.Forms.TextBox();
            this.btnUploadFotosTrabajos = new System.Windows.Forms.Button();
            this.btnUploadTestimonios = new System.Windows.Forms.Button();
            this.btnUploadReferencias = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();

            // cmbAnosExperienciaEmp
            this.cmbAnosExperienciaEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnosExperienciaEmp.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbAnosExperienciaEmp.Items.AddRange(new object[] {
                "Menos de 1 año",
                "1-3 años",
                "3-5 años",
                "Más de 5 años"
            });
            this.cmbAnosExperienciaEmp.Location = new System.Drawing.Point(30, 40);
            this.cmbAnosExperienciaEmp.Name = "cmbAnosExperienciaEmp";
            this.cmbAnosExperienciaEmp.Size = new System.Drawing.Size(300, 23);
            this.cmbAnosExperienciaEmp.TabIndex = 0;

            // Label para AnosExperiencia
            Label lblAnosExperienciaEmp = new Label();
            lblAnosExperienciaEmp.AutoSize = true;
            lblAnosExperienciaEmp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            lblAnosExperienciaEmp.Location = new System.Drawing.Point(30, 20);
            lblAnosExperienciaEmp.Name = "lblAnosExperienciaEmp";
            lblAnosExperienciaEmp.Size = new System.Drawing.Size(130, 15);
            lblAnosExperienciaEmp.TabIndex = 1;
            lblAnosExperienciaEmp.Text = "Años de Experiencia:";

            // Label para TipoExperiencia
            Label lblTipoExperiencia = new Label();
            lblTipoExperiencia.AutoSize = true;
            lblTipoExperiencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            lblTipoExperiencia.Location = new System.Drawing.Point(30, 80);
            lblTipoExperiencia.Name = "lblTipoExperiencia";
            lblTipoExperiencia.Size = new System.Drawing.Size(110, 15);
            lblTipoExperiencia.TabIndex = 2;
            lblTipoExperiencia.Text = "Tipo de Experiencia:";

            // chkIndependiente
            this.chkIndependiente.AutoSize = true;
            this.chkIndependiente.Font = new System.Drawing.Font("Arial", 9F);
            this.chkIndependiente.Location = new System.Drawing.Point(30, 110);
            this.chkIndependiente.Name = "chkIndependiente";
            this.chkIndependiente.Size = new System.Drawing.Size(140, 19);
            this.chkIndependiente.TabIndex = 3;
            this.chkIndependiente.Text = "Experiencia Independiente";
            this.chkIndependiente.UseVisualStyleBackColor = true;

            // chkEmpresa
            this.chkEmpresa.AutoSize = true;
            this.chkEmpresa.Font = new System.Drawing.Font("Arial", 9F);
            this.chkEmpresa.Location = new System.Drawing.Point(30, 140);
            this.chkEmpresa.Name = "chkEmpresa";
            this.chkEmpresa.Size = new System.Drawing.Size(120, 19);
            this.chkEmpresa.TabIndex = 4;
            this.chkEmpresa.Text = "Trabajo en Empresa";
            this.chkEmpresa.UseVisualStyleBackColor = true;

            // chkFamiliar
            this.chkFamiliar.AutoSize = true;
            this.chkFamiliar.Font = new System.Drawing.Font("Arial", 9F);
            this.chkFamiliar.Location = new System.Drawing.Point(30, 170);
            this.chkFamiliar.Name = "chkFamiliar";
            this.chkFamiliar.Size = new System.Drawing.Size(150, 19);
            this.chkFamiliar.TabIndex = 5;
            this.chkFamiliar.Text = "Aprendizaje Familiar/Tradicional";
            this.chkFamiliar.UseVisualStyleBackColor = true;

            // chkOtro
            this.chkOtro.AutoSize = true;
            this.chkOtro.Font = new System.Drawing.Font("Arial", 9F);
            this.chkOtro.Location = new System.Drawing.Point(30, 200);
            this.chkOtro.Name = "chkOtro";
            this.chkOtro.Size = new System.Drawing.Size(50, 19);
            this.chkOtro.TabIndex = 6;
            this.chkOtro.Text = "Otro";
            this.chkOtro.UseVisualStyleBackColor = true;
            this.chkOtro.CheckedChanged += new System.EventHandler(this.chkOtro_CheckedChanged);

            // txtDescripcionOtro
            this.txtDescripcionOtro.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDescripcionOtro.Location = new System.Drawing.Point(30, 240);
            this.txtDescripcionOtro.Name = "txtDescripcionOtro";
            this.txtDescripcionOtro.Size = new System.Drawing.Size(300, 23);
            this.txtDescripcionOtro.TabIndex = 7;
            this.txtDescripcionOtro.Visible = false;

            // btnUploadFotosTrabajos
            this.btnUploadFotosTrabajos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnUploadFotosTrabajos.FlatAppearance.BorderSize = 0;
            this.btnUploadFotosTrabajos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadFotosTrabajos.Font = new System.Drawing.Font("Arial", 9F);
            this.btnUploadFotosTrabajos.ForeColor = System.Drawing.Color.White;
            this.btnUploadFotosTrabajos.Location = new System.Drawing.Point(30, 290);
            this.btnUploadFotosTrabajos.Name = "btnUploadFotosTrabajos";
            this.btnUploadFotosTrabajos.Size = new System.Drawing.Size(300, 30);
            this.btnUploadFotosTrabajos.TabIndex = 8;
            this.btnUploadFotosTrabajos.Text = "Subir Fotos de Trabajos Realizados";
            this.btnUploadFotosTrabajos.UseVisualStyleBackColor = false;
            this.btnUploadFotosTrabajos.Click += new System.EventHandler(this.btnUploadFotosTrabajos_Click);

            // btnUploadTestimonios
            this.btnUploadTestimonios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnUploadTestimonios.FlatAppearance.BorderSize = 0;
            this.btnUploadTestimonios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadTestimonios.Font = new System.Drawing.Font("Arial", 9F);
            this.btnUploadTestimonios.ForeColor = System.Drawing.Color.White;
            this.btnUploadTestimonios.Location = new System.Drawing.Point(30, 330);
            this.btnUploadTestimonios.Name = "btnUploadTestimonios";
            this.btnUploadTestimonios.Size = new System.Drawing.Size(300, 30);
            this.btnUploadTestimonios.TabIndex = 9;
            this.btnUploadTestimonios.Text = "Subir Testimonios de Clientes";
            this.btnUploadTestimonios.UseVisualStyleBackColor = false;
            this.btnUploadTestimonios.Click += new System.EventHandler(this.btnUploadTestimonios_Click);

            // btnUploadReferencias
            this.btnUploadReferencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnUploadReferencias.FlatAppearance.BorderSize = 0;
            this.btnUploadReferencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadReferencias.Font = new System.Drawing.Font("Arial", 9F);
            this.btnUploadReferencias.ForeColor = System.Drawing.Color.White;
            this.btnUploadReferencias.Location = new System.Drawing.Point(30, 370);
            this.btnUploadReferencias.Name = "btnUploadReferencias";
            this.btnUploadReferencias.Size = new System.Drawing.Size(300, 30);
            this.btnUploadReferencias.TabIndex = 10;
            this.btnUploadReferencias.Text = "Subir Referencias Personales";
            this.btnUploadReferencias.UseVisualStyleBackColor = false;
            this.btnUploadReferencias.Click += new System.EventHandler(this.btnUploadReferencias_Click);

            // btnVolver
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnVolver.FlatAppearance.BorderSize = 2;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnVolver.Location = new System.Drawing.Point(180, 420);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(150, 25);
            this.btnVolver.TabIndex = 11;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // btnSiguiente
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSiguiente.Location = new System.Drawing.Point(30, 420);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(150, 25);
            this.btnSiguiente.TabIndex = 12;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);

            // Configurar panel
            this.Size = new System.Drawing.Size(360, 600);
            this.BackColor = System.Drawing.Color.White;

            // Agregar todos los controles
            this.Controls.Add(lblAnosExperienciaEmp);
            this.Controls.Add(cmbAnosExperienciaEmp);
            this.Controls.Add(lblTipoExperiencia);
            this.Controls.Add(chkIndependiente);
            this.Controls.Add(chkEmpresa);
            this.Controls.Add(chkFamiliar);
            this.Controls.Add(chkOtro);
            this.Controls.Add(txtDescripcionOtro);
            this.Controls.Add(btnUploadFotosTrabajos);
            this.Controls.Add(btnUploadTestimonios);
            this.Controls.Add(btnUploadReferencias);
            this.Controls.Add(btnVolver);
            this.Controls.Add(btnSiguiente);
        }

        private void chkOtro_CheckedChanged(object sender, EventArgs e)
        {
            txtDescripcionOtro.Visible = chkOtro.Checked;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            SiguienteClick?.Invoke(this, e);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverClick?.Invoke(this, e);
        }

        private void btnUploadFotosTrabajos_Click(object sender, EventArgs e)
        {
            SubirArchivo?.Invoke(this, "foto_trabajo");
        }

        private void btnUploadTestimonios_Click(object sender, EventArgs e)
        {
            SubirArchivo?.Invoke(this, "testimonio");
        }

        private void btnUploadReferencias_Click(object sender, EventArgs e)
        {
            SubirArchivo?.Invoke(this, "referencia");
        }
    }
}