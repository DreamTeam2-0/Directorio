namespace Perfil
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            logo = new PictureBox();
            panel1 = new Panel();
            Paginawebservicio = new Label();
            precioservicio = new Label();
            ubicacion = new Label();
            Descripcionservicio = new Label();
            puntaje = new Label();
            Nombreservicio = new Label();
            panel2 = new Panel();
            categoriaservicio = new Label();
            redesservicio = new Label();
            telefonoservidor = new Label();
            añosservicio = new Label();
            nombreservidor = new Label();
            imgservicio = new PictureBox();
            botoncambiardatos = new Button();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgservicio).BeginInit();
            SuspendLayout();
            // 
            // logo
            // 
            logo.Location = new Point(12, 59);
            logo.Name = "logo";
            logo.Size = new Size(113, 70);
            logo.TabIndex = 0;
            logo.TabStop = false;
            logo.Click += logo_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(Paginawebservicio);
            panel1.Controls.Add(precioservicio);
            panel1.Controls.Add(ubicacion);
            panel1.Controls.Add(Descripcionservicio);
            panel1.Controls.Add(puntaje);
            panel1.Controls.Add(Nombreservicio);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(152, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(742, 423);
            panel1.TabIndex = 1;

            // 
            // Paginawebservicio
            // 
            Paginawebservicio.AutoSize = true;
            Paginawebservicio.Location = new Point(318, 360);
            Paginawebservicio.Name = "Paginawebservicio";
            Paginawebservicio.Size = new Size(273, 25);
            Paginawebservicio.TabIndex = 8;
            Paginawebservicio.Text = "Dirección web en caso que tenga";
            Paginawebservicio.Click += Paginawebservicio_Click;
            // 
            // precioservicio
            // 
            precioservicio.AutoSize = true;
            precioservicio.BackColor = Color.White;
            precioservicio.BorderStyle = BorderStyle.Fixed3D;
            precioservicio.Font = new Font("Showcard Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            precioservicio.ForeColor = Color.DarkGreen;
            precioservicio.Location = new Point(418, 289);
            precioservicio.Name = "precioservicio";
            precioservicio.Size = new Size(69, 42);
            precioservicio.TabIndex = 7;
            precioservicio.Text = "30$";
            precioservicio.Click += precioservicio_Click;
            // 
            // ubicacion
            // 
            ubicacion.AutoSize = true;
            ubicacion.Location = new Point(398, 217);
            ubicacion.Name = "ubicacion";
            ubicacion.Size = new Size(89, 25);
            ubicacion.TabIndex = 6;
            ubicacion.Text = "Ubicacíon";
            ubicacion.Click += ubicacion_Click;
            // 
            // Descripcionservicio
            // 
            Descripcionservicio.AutoSize = true;
            Descripcionservicio.Location = new Point(251, 156);
            Descripcionservicio.Name = "Descripcionservicio";
            Descripcionservicio.Size = new Size(197, 25);
            Descripcionservicio.TabIndex = 5;
            Descripcionservicio.Text = "Descripcion del servicio";
            Descripcionservicio.Click += Descripcionservicio_Click;
            // 
            // puntaje
            // 
            puntaje.AutoSize = true;
            puntaje.BackColor = Color.White;
            puntaje.BorderStyle = BorderStyle.Fixed3D;
            puntaje.Font = new Font("Showcard Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            puntaje.ForeColor = Color.Salmon;
            puntaje.Location = new Point(418, 75);
            puntaje.Name = "puntaje";
            puntaje.Size = new Size(51, 30);
            puntaje.TabIndex = 4;
            puntaje.Text = "1 - 5";
            puntaje.Click += puntaje_Click;
            // 
            // Nombreservicio
            // 
            Nombreservicio.AutoSize = true;
            Nombreservicio.BackColor = SystemColors.Window;
            Nombreservicio.Font = new Font("Tahoma", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Nombreservicio.ForeColor = Color.DarkGreen;
            Nombreservicio.Location = new Point(284, 27);
            Nombreservicio.Name = "Nombreservicio";
            Nombreservicio.Size = new Size(347, 48);
            Nombreservicio.TabIndex = 3;
            Nombreservicio.Text = "Nombre servicio";
            Nombreservicio.Click += Nombreservicio_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SeaGreen;
            panel2.Controls.Add(categoriaservicio);
            panel2.Controls.Add(redesservicio);
            panel2.Controls.Add(telefonoservidor);
            panel2.Controls.Add(añosservicio);
            panel2.Controls.Add(nombreservidor);
            panel2.Controls.Add(imgservicio);
            panel2.Location = new Point(24, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(221, 361);
            panel2.TabIndex = 2;
     
            // 
            // categoriaservicio
            // 
            categoriaservicio.AutoSize = true;
            categoriaservicio.BackColor = Color.Sienna;
            categoriaservicio.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            categoriaservicio.ForeColor = Color.SeaShell;
            categoriaservicio.Location = new Point(40, 308);
            categoriaservicio.Name = "categoriaservicio";
            categoriaservicio.Size = new Size(88, 21);
            categoriaservicio.TabIndex = 13;
            categoriaservicio.Text = "Categoria";
            categoriaservicio.Click += categoriaservicio_Click;
            // 
            // redesservicio
            // 
            redesservicio.AutoSize = true;
            redesservicio.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            redesservicio.ForeColor = Color.SeaShell;
            redesservicio.Location = new Point(6, 265);
            redesservicio.Name = "redesservicio";
            redesservicio.Size = new Size(132, 21);
            redesservicio.TabIndex = 12;
            redesservicio.Text = "Redes sociales";
            redesservicio.Click += redesservicio_Click;
            // 
            // telefonoservidor
            // 
            telefonoservidor.AutoSize = true;
            telefonoservidor.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            telefonoservidor.ForeColor = Color.SeaShell;
            telefonoservidor.Location = new Point(3, 224);
            telefonoservidor.Name = "telefonoservidor";
            telefonoservidor.Size = new Size(164, 21);
            telefonoservidor.TabIndex = 11;
            telefonoservidor.Text = "numero de telefono";
            telefonoservidor.Click += telefonoservidor_Click;
            // 
            // añosservicio
            // 
            añosservicio.AutoSize = true;
            añosservicio.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            añosservicio.ForeColor = Color.SeaShell;
            añosservicio.Location = new Point(6, 171);
            añosservicio.Name = "añosservicio";
            añosservicio.Size = new Size(141, 21);
            añosservicio.TabIndex = 10;
            añosservicio.Text = "Años en servicio";
            añosservicio.Click += añosservicio_Click;
            // 
            // nombreservidor
            // 
            nombreservidor.AutoSize = true;
            nombreservidor.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nombreservidor.ForeColor = SystemColors.ButtonHighlight;
            nombreservidor.Location = new Point(6, 120);
            nombreservidor.Name = "nombreservidor";
            nombreservidor.Size = new Size(203, 21);
            nombreservidor.TabIndex = 9;
            nombreservidor.Text = "Nombre usuario servicio";
            nombreservidor.Click += nombreservidor_Click;
            // 
            // imgservicio
            // 
            imgservicio.Location = new Point(6, 3);
            imgservicio.Name = "imgservicio";
            imgservicio.Size = new Size(184, 99);
            imgservicio.TabIndex = 2;
            imgservicio.TabStop = false;
            imgservicio.Click += imgservicio_Click;
            // 
            // botoncambiardatos
            // 
            botoncambiardatos.Location = new Point(13, 411);
            botoncambiardatos.Name = "botoncambiardatos";
            botoncambiardatos.Size = new Size(112, 34);
            botoncambiardatos.TabIndex = 2;
            botoncambiardatos.Text = "Cambiar datos";
            botoncambiardatos.UseVisualStyleBackColor = true;
            botoncambiardatos.Click += botoncambiardatos_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            ClientSize = new Size(896, 475);
            Controls.Add(botoncambiardatos);
            Controls.Add(panel1);
            Controls.Add(logo);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgservicio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox logo;
        private Panel panel1;
        private Panel panel2;
        private PictureBox imgservicio;
        private Label Nombreservicio;
        private Label puntaje;
        private Label Paginawebservicio;
        private Label precioservicio;
        private Label ubicacion;
        private Label Descripcionservicio;
        private Label añosservicio;
        private Label nombreservidor;
        private Label categoriaservicio;
        private Label redesservicio;
        private Label telefonoservidor;
        private Button botoncambiardatos;
    }
}
