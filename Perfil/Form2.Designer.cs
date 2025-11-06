namespace Perfil
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            Nombreservicio = new Label();
            panel2 = new Panel();
            telefonoservidor = new Label();
            añosservicio = new Label();
            ubicacion = new Label();
            nombreservidor = new Label();
            imgservicio = new PictureBox();
            logo = new PictureBox();
            botoncambiardatos = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgservicio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(Nombreservicio);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(138, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(665, 402);
            panel1.TabIndex = 3;
            // 
            // Nombreservicio
            // 
            Nombreservicio.AutoSize = true;
            Nombreservicio.BackColor = SystemColors.Window;
            Nombreservicio.Font = new Font("Tahoma", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Nombreservicio.ForeColor = Color.DarkGreen;
            Nombreservicio.Location = new Point(284, 27);
            Nombreservicio.Name = "Nombreservicio";
            Nombreservicio.Size = new Size(343, 48);
            Nombreservicio.TabIndex = 3;
            Nombreservicio.Text = "Nombre usuario";

            // 
            // panel2
            // 
            panel2.BackColor = Color.SeaGreen;
            panel2.Controls.Add(telefonoservidor);
            panel2.Controls.Add(añosservicio);
            panel2.Controls.Add(ubicacion);
            panel2.Controls.Add(nombreservidor);
            panel2.Controls.Add(imgservicio);
            panel2.Location = new Point(24, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(193, 361);
            panel2.TabIndex = 2;
            // 
            // telefonoservidor
            // 
            telefonoservidor.AutoSize = true;
            telefonoservidor.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            telefonoservidor.ForeColor = Color.SeaShell;
            telefonoservidor.Location = new Point(16, 209);
            telefonoservidor.Name = "telefonoservidor";
            telefonoservidor.Size = new Size(164, 21);
            telefonoservidor.TabIndex = 11;
            telefonoservidor.Text = "numero de telefono";
            // 
            // añosservicio
            // 
            añosservicio.AutoSize = true;
            añosservicio.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            añosservicio.ForeColor = Color.SeaShell;
            añosservicio.Location = new Point(26, 336);
            añosservicio.Name = "añosservicio";
            añosservicio.Size = new Size(0, 21);
            añosservicio.TabIndex = 10;
            // 
            // ubicacion
            // 
            ubicacion.AutoSize = true;
            ubicacion.Location = new Point(51, 278);
            ubicacion.Name = "ubicacion";
            ubicacion.Size = new Size(89, 25);
            ubicacion.TabIndex = 6;
            ubicacion.Text = "Ubicacíon";
            // 
            // nombreservidor
            // 
            nombreservidor.AutoSize = true;
            nombreservidor.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nombreservidor.ForeColor = SystemColors.ButtonHighlight;
            nombreservidor.Location = new Point(25, 132);
            nombreservidor.Name = "nombreservidor";
            nombreservidor.Size = new Size(142, 21);
            nombreservidor.TabIndex = 9;
            nombreservidor.Text = "Nombre usuario ";
         
            // 
            // imgservicio
            // 
            imgservicio.Location = new Point(6, 3);
            imgservicio.Name = "imgservicio";
            imgservicio.Size = new Size(184, 99);
            imgservicio.TabIndex = 2;
            imgservicio.TabStop = false;
            // 
            // logo
            // 
            logo.Location = new Point(12, 48);
            logo.Name = "logo";
            logo.Size = new Size(113, 70);
            logo.TabIndex = 2;
            logo.TabStop = false;
            // 
            // botoncambiardatos
            // 
            botoncambiardatos.Location = new Point(28, 454);
            botoncambiardatos.Name = "botoncambiardatos";
            botoncambiardatos.Size = new Size(184, 34);
            botoncambiardatos.TabIndex = 4;
            botoncambiardatos.Text = "Cambiar datos";
            botoncambiardatos.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1003, 518);
            Controls.Add(botoncambiardatos);
            Controls.Add(panel1);
            Controls.Add(logo);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgservicio).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label ubicacion;
        private Label Nombreservicio;
        private Panel panel2;
        private Label telefonoservidor;
        private Label añosservicio;
        private Label nombreservidor;
        private PictureBox imgservicio;
        private PictureBox logo;
        private Button botoncambiardatos;
    }
}