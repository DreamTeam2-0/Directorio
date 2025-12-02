using System;
using System.Windows.Forms;

namespace LoginDirectorio.RegistroFases
{
    partial class FaseCertificado
    {
        private void InitializeComponent()
        {
            this.cmbNivelEstudios = new System.Windows.Forms.ComboBox();
            this.txtAnosExperienciaCert = new System.Windows.Forms.TextBox();
            this.txtEmpresasAnteriores = new System.Windows.Forms.TextBox();
            this.txtProyectosDestacados = new System.Windows.Forms.TextBox();
            this.txtReferenciasLaborales = new System.Windows.Forms.TextBox();
            this.btnUploadCertificados = new System.Windows.Forms.Button();
            this.btnUploadTitulos = new System.Windows.Forms.Button();
            this.btnUploadLicencias = new System.Windows.Forms.Button();
            this.btnUploadInternacionales = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblNivelEstudios = new System.Windows.Forms.Label();
            this.lblAnosExperiencia = new System.Windows.Forms.Label();
            this.lblEmpresasAnteriores = new System.Windows.Forms.Label();
            this.lblProyectosDestacados = new System.Windows.Forms.Label();
            this.lblReferenciasLaborales = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbNivelEstudios
            // 
            this.cmbNivelEstudios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelEstudios.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbNivelEstudios.Items.AddRange(new object[] {
            "Técnico",
            "Tecnólogo",
            "Profesional",
            "Especialización",
            "Maestría",
            "Doctorado"});
            this.cmbNivelEstudios.Location = new System.Drawing.Point(30, 40);
            this.cmbNivelEstudios.Name = "cmbNivelEstudios";
            this.cmbNivelEstudios.Size = new System.Drawing.Size(300, 24);
            this.cmbNivelEstudios.TabIndex = 0;
            // 
            // txtAnosExperienciaCert
            // 
            this.txtAnosExperienciaCert.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAnosExperienciaCert.Location = new System.Drawing.Point(30, 100);
            this.txtAnosExperienciaCert.Name = "txtAnosExperienciaCert";
            this.txtAnosExperienciaCert.Size = new System.Drawing.Size(300, 23);
            this.txtAnosExperienciaCert.TabIndex = 2;
            // 
            // txtEmpresasAnteriores
            // 
            this.txtEmpresasAnteriores.Font = new System.Drawing.Font("Arial", 10F);
            this.txtEmpresasAnteriores.Location = new System.Drawing.Point(30, 160);
            this.txtEmpresasAnteriores.Multiline = true;
            this.txtEmpresasAnteriores.Name = "txtEmpresasAnteriores";
            this.txtEmpresasAnteriores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmpresasAnteriores.Size = new System.Drawing.Size(300, 50);
            this.txtEmpresasAnteriores.TabIndex = 4;
            // 
            // txtProyectosDestacados
            // 
            this.txtProyectosDestacados.Font = new System.Drawing.Font("Arial", 10F);
            this.txtProyectosDestacados.Location = new System.Drawing.Point(30, 230);
            this.txtProyectosDestacados.Multiline = true;
            this.txtProyectosDestacados.Name = "txtProyectosDestacados";
            this.txtProyectosDestacados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProyectosDestacados.Size = new System.Drawing.Size(300, 50);
            this.txtProyectosDestacados.TabIndex = 6;
            // 
            // txtReferenciasLaborales
            // 
            this.txtReferenciasLaborales.Font = new System.Drawing.Font("Arial", 10F);
            this.txtReferenciasLaborales.Location = new System.Drawing.Point(30, 300);
            this.txtReferenciasLaborales.Multiline = true;
            this.txtReferenciasLaborales.Name = "txtReferenciasLaborales";
            this.txtReferenciasLaborales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReferenciasLaborales.Size = new System.Drawing.Size(300, 50);
            this.txtReferenciasLaborales.TabIndex = 8;
            // 
            // btnUploadCertificados
            // 
            this.btnUploadCertificados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnUploadCertificados.FlatAppearance.BorderSize = 0;
            this.btnUploadCertificados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadCertificados.Font = new System.Drawing.Font("Arial", 9F);
            this.btnUploadCertificados.ForeColor = System.Drawing.Color.White;
            this.btnUploadCertificados.Location = new System.Drawing.Point(30, 370);
            this.btnUploadCertificados.Name = "btnUploadCertificados";
            this.btnUploadCertificados.Size = new System.Drawing.Size(300, 30);
            this.btnUploadCertificados.TabIndex = 10;
            this.btnUploadCertificados.Text = "Subir Certificados (Opcional)";
            this.btnUploadCertificados.UseVisualStyleBackColor = false;
            this.btnUploadCertificados.Click += new System.EventHandler(this.btnUploadCertificados_Click);
            // 
            // btnUploadTitulos
            // 
            this.btnUploadTitulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnUploadTitulos.FlatAppearance.BorderSize = 0;
            this.btnUploadTitulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadTitulos.Font = new System.Drawing.Font("Arial", 9F);
            this.btnUploadTitulos.ForeColor = System.Drawing.Color.White;
            this.btnUploadTitulos.Location = new System.Drawing.Point(30, 410);
            this.btnUploadTitulos.Name = "btnUploadTitulos";
            this.btnUploadTitulos.Size = new System.Drawing.Size(300, 30);
            this.btnUploadTitulos.TabIndex = 11;
            this.btnUploadTitulos.Text = "Subir Títulos Profesionales (Obligatorio)";
            this.btnUploadTitulos.UseVisualStyleBackColor = false;
            this.btnUploadTitulos.Click += new System.EventHandler(this.btnUploadTitulos_Click);
            // 
            // btnUploadLicencias
            // 
            this.btnUploadLicencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnUploadLicencias.FlatAppearance.BorderSize = 0;
            this.btnUploadLicencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadLicencias.Font = new System.Drawing.Font("Arial", 9F);
            this.btnUploadLicencias.ForeColor = System.Drawing.Color.White;
            this.btnUploadLicencias.Location = new System.Drawing.Point(30, 450);
            this.btnUploadLicencias.Name = "btnUploadLicencias";
            this.btnUploadLicencias.Size = new System.Drawing.Size(300, 30);
            this.btnUploadLicencias.TabIndex = 12;
            this.btnUploadLicencias.Text = "Subir Licencias Especiales (Opcional)";
            this.btnUploadLicencias.UseVisualStyleBackColor = false;
            this.btnUploadLicencias.Click += new System.EventHandler(this.btnUploadLicencias_Click);
            // 
            // btnUploadInternacionales
            // 
            this.btnUploadInternacionales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnUploadInternacionales.FlatAppearance.BorderSize = 0;
            this.btnUploadInternacionales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadInternacionales.Font = new System.Drawing.Font("Arial", 9F);
            this.btnUploadInternacionales.ForeColor = System.Drawing.Color.White;
            this.btnUploadInternacionales.Location = new System.Drawing.Point(30, 490);
            this.btnUploadInternacionales.Name = "btnUploadInternacionales";
            this.btnUploadInternacionales.Size = new System.Drawing.Size(300, 30);
            this.btnUploadInternacionales.TabIndex = 13;
            this.btnUploadInternacionales.Text = "Subir Certificaciones Internacionales (Opcional)";
            this.btnUploadInternacionales.UseVisualStyleBackColor = false;
            this.btnUploadInternacionales.Click += new System.EventHandler(this.btnUploadInternacionales_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSiguiente.Location = new System.Drawing.Point(30, 530);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(150, 25);
            this.btnSiguiente.TabIndex = 15;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnVolver.FlatAppearance.BorderSize = 2;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnVolver.Location = new System.Drawing.Point(180, 530);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(150, 25);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblNivelEstudios
            // 
            this.lblNivelEstudios.AutoSize = true;
            this.lblNivelEstudios.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblNivelEstudios.Location = new System.Drawing.Point(30, 20);
            this.lblNivelEstudios.Name = "lblNivelEstudios";
            this.lblNivelEstudios.Size = new System.Drawing.Size(106, 15);
            this.lblNivelEstudios.TabIndex = 1;
            this.lblNivelEstudios.Text = "Nivel de Estudios:";
            // 
            // lblAnosExperiencia
            // 
            this.lblAnosExperiencia.AutoSize = true;
            this.lblAnosExperiencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblAnosExperiencia.Location = new System.Drawing.Point(30, 80);
            this.lblAnosExperiencia.Name = "lblAnosExperiencia";
            this.lblAnosExperiencia.Size = new System.Drawing.Size(126, 15);
            this.lblAnosExperiencia.TabIndex = 3;
            this.lblAnosExperiencia.Text = "Años de Experiencia:";
            // 
            // lblEmpresasAnteriores
            // 
            this.lblEmpresasAnteriores.AutoSize = true;
            this.lblEmpresasAnteriores.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmpresasAnteriores.Location = new System.Drawing.Point(30, 140);
            this.lblEmpresasAnteriores.Name = "lblEmpresasAnteriores";
            this.lblEmpresasAnteriores.Size = new System.Drawing.Size(131, 15);
            this.lblEmpresasAnteriores.TabIndex = 5;
            this.lblEmpresasAnteriores.Text = "Empresas Anteriores:";
            // 
            // lblProyectosDestacados
            // 
            this.lblProyectosDestacados.AutoSize = true;
            this.lblProyectosDestacados.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblProyectosDestacados.Location = new System.Drawing.Point(30, 210);
            this.lblProyectosDestacados.Name = "lblProyectosDestacados";
            this.lblProyectosDestacados.Size = new System.Drawing.Size(139, 15);
            this.lblProyectosDestacados.TabIndex = 7;
            this.lblProyectosDestacados.Text = "Proyectos Destacados:";
            // 
            // lblReferenciasLaborales
            // 
            this.lblReferenciasLaborales.AutoSize = true;
            this.lblReferenciasLaborales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblReferenciasLaborales.Location = new System.Drawing.Point(30, 280);
            this.lblReferenciasLaborales.Name = "lblReferenciasLaborales";
            this.lblReferenciasLaborales.Size = new System.Drawing.Size(139, 15);
            this.lblReferenciasLaborales.TabIndex = 9;
            this.lblReferenciasLaborales.Text = "Referencias Laborales:";
            // 
            // FaseCertificado
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblNivelEstudios);
            this.Controls.Add(this.cmbNivelEstudios);
            this.Controls.Add(this.lblAnosExperiencia);
            this.Controls.Add(this.txtAnosExperienciaCert);
            this.Controls.Add(this.lblEmpresasAnteriores);
            this.Controls.Add(this.txtEmpresasAnteriores);
            this.Controls.Add(this.lblProyectosDestacados);
            this.Controls.Add(this.txtProyectosDestacados);
            this.Controls.Add(this.lblReferenciasLaborales);
            this.Controls.Add(this.txtReferenciasLaborales);
            this.Controls.Add(this.btnUploadCertificados);
            this.Controls.Add(this.btnUploadTitulos);
            this.Controls.Add(this.btnUploadLicencias);
            this.Controls.Add(this.btnUploadInternacionales);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnSiguiente);
            this.Size = new System.Drawing.Size(360, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        // MÉTODOS DE EVENTOS CORREGIDOS:
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            SiguienteClick?.Invoke(this, e);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverClick?.Invoke(this, e);
        }

        private void btnUploadCertificados_Click(object sender, EventArgs e)
        {
            // CORREGIDO: Usar SubirArchivoEventArgs
            SubirArchivo?.Invoke(this, new SubirArchivoEventArgs("certificado", false));
        }

        private void btnUploadTitulos_Click(object sender, EventArgs e)
        {
            // CORREGIDO: Usar SubirArchivoEventArgs
            SubirArchivo?.Invoke(this, new SubirArchivoEventArgs("titulo", true));
        }

        private void btnUploadLicencias_Click(object sender, EventArgs e)
        {
            // CORREGIDO: Usar SubirArchivoEventArgs
            SubirArchivo?.Invoke(this, new SubirArchivoEventArgs("licencia", false));
        }

        private void btnUploadInternacionales_Click(object sender, EventArgs e)
        {
            // CORREGIDO: Usar SubirArchivoEventArgs
            SubirArchivo?.Invoke(this, new SubirArchivoEventArgs("internacional", false));
        }

        private Label lblNivelEstudios;
        private Label lblAnosExperiencia;
        private Label lblEmpresasAnteriores;
        private Label lblProyectosDestacados;
        private Label lblReferenciasLaborales;
    }
}