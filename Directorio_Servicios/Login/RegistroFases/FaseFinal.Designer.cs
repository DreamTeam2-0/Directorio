using System;
using System.Windows.Forms;

namespace LoginDirectorio.RegistroFases
{
    partial class FaseFinal
    {
        private void InitializeComponent()
        {
            this.txtCategorias = new System.Windows.Forms.TextBox();
            this.txtSubEspecialidades = new System.Windows.Forms.TextBox();
            this.txtHerramientas = new System.Windows.Forms.TextBox();
            this.txtDescripcionServicios = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();

            // txtCategorias
            this.txtCategorias.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCategorias.Location = new System.Drawing.Point(30, 40);
            this.txtCategorias.Name = "txtCategorias";
            this.txtCategorias.Size = new System.Drawing.Size(300, 23);
            this.txtCategorias.TabIndex = 0;

            // Label para Categorias
            Label lblCategorias = new Label();
            lblCategorias.AutoSize = true;
            lblCategorias.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            lblCategorias.Location = new System.Drawing.Point(30, 20);
            lblCategorias.Name = "lblCategorias";
            lblCategorias.Size = new System.Drawing.Size(80, 15);
            lblCategorias.TabIndex = 1;
            lblCategorias.Text = "Categorías:";

            // txtSubEspecialidades
            this.txtSubEspecialidades.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSubEspecialidades.Location = new System.Drawing.Point(30, 100);
            this.txtSubEspecialidades.Name = "txtSubEspecialidades";
            this.txtSubEspecialidades.Size = new System.Drawing.Size(300, 23);
            this.txtSubEspecialidades.TabIndex = 2;

            // Label para SubEspecialidades
            Label lblSubEspecialidades = new Label();
            lblSubEspecialidades.AutoSize = true;
            lblSubEspecialidades.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            lblSubEspecialidades.Location = new System.Drawing.Point(30, 80);
            lblSubEspecialidades.Name = "lblSubEspecialidades";
            lblSubEspecialidades.Size = new System.Drawing.Size(130, 15);
            lblSubEspecialidades.TabIndex = 3;
            lblSubEspecialidades.Text = "Sub-especialidades:";

            // txtHerramientas
            this.txtHerramientas.Font = new System.Drawing.Font("Arial", 10F);
            this.txtHerramientas.Location = new System.Drawing.Point(30, 160);
            this.txtHerramientas.Name = "txtHerramientas";
            this.txtHerramientas.Size = new System.Drawing.Size(300, 23);
            this.txtHerramientas.TabIndex = 4;

            // Label para Herramientas
            Label lblHerramientas = new Label();
            lblHerramientas.AutoSize = true;
            lblHerramientas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            lblHerramientas.Location = new System.Drawing.Point(30, 140);
            lblHerramientas.Name = "lblHerramientas";
            lblHerramientas.Size = new System.Drawing.Size(100, 15);
            lblHerramientas.TabIndex = 5;
            lblHerramientas.Text = "Herramientas:";

            // txtDescripcionServicios
            this.txtDescripcionServicios.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDescripcionServicios.Location = new System.Drawing.Point(30, 220);
            this.txtDescripcionServicios.Multiline = true;
            this.txtDescripcionServicios.Name = "txtDescripcionServicios";
            this.txtDescripcionServicios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionServicios.Size = new System.Drawing.Size(300, 100);
            this.txtDescripcionServicios.TabIndex = 6;

            // Label para DescripcionServicios
            Label lblDescripcionServicios = new Label();
            lblDescripcionServicios.AutoSize = true;
            lblDescripcionServicios.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            lblDescripcionServicios.Location = new System.Drawing.Point(30, 200);
            lblDescripcionServicios.Name = "lblDescripcionServicios";
            lblDescripcionServicios.Size = new System.Drawing.Size(160, 15);
            lblDescripcionServicios.TabIndex = 7;
            lblDescripcionServicios.Text = "Descripción de Servicios:";

            // btnVolver
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnVolver.FlatAppearance.BorderSize = 2;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnVolver.Location = new System.Drawing.Point(180, 340);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(150, 30);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // btnRegistrar
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(30, 340);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(150, 30);
            this.btnRegistrar.TabIndex = 9;
            this.btnRegistrar.Text = "Registrarse";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            // Configurar panel
            this.Size = new System.Drawing.Size(360, 600);
            this.BackColor = System.Drawing.Color.White;

            // Agregar todos los controles
            this.Controls.Add(lblCategorias);
            this.Controls.Add(txtCategorias);
            this.Controls.Add(lblSubEspecialidades);
            this.Controls.Add(txtSubEspecialidades);
            this.Controls.Add(lblHerramientas);
            this.Controls.Add(txtHerramientas);
            this.Controls.Add(lblDescripcionServicios);
            this.Controls.Add(txtDescripcionServicios);
            this.Controls.Add(btnVolver);
            this.Controls.Add(btnRegistrar);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarClick?.Invoke(this, e);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverClick?.Invoke(this, e);
        }
    }
}