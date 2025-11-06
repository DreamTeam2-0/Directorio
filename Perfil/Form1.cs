using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Perfil
{
    public partial class Form1 : Form
    {
        private int servicioId;
        private string connectionString =
        "Data Source=TU_SERVIDOR;Initial Catalog=TU_BASE_DE_DATOS;Integrated Security=True";


        public Form1(int id)
        {
            InitializeComponent();
        }


private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        // Eventos de clics (copiar al portapapeles, abrir enlaces, etc.)
        private void Nombreservicio_Click(object sender, EventArgs e) => Clipboard.SetText(Nombreservicio.Text);
        private void puntaje_Click(object sender, EventArgs e) => Clipboard.SetText(puntaje.Text);
        private void Descripcionservicio_Click(object sender, EventArgs e) => Clipboard.SetText(Descripcionservicio.Text);
        private void ubicacion_Click(object sender, EventArgs e) => Clipboard.SetText(ubicacion.Text);
        private void precioservicio_Click(object sender, EventArgs e) => Clipboard.SetText(precioservicio.Text.Replace("$", "").Trim());
        private void Paginawebservicio_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Paginawebservicio.Text) && (Paginawebservicio.Text.Contains("http") || Paginawebservicio.Text.Contains("www")))
            {
                try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(Paginawebservicio.Text) { UseShellExecute = true }); }
                catch { MostrarError("No se pudo abrir el enlace."); }
            }
        }
        private void nombreservidor_Click(object sender, EventArgs e) => Clipboard.SetText(nombreservidor.Text);
        private void añosservicio_Click(object sender, EventArgs e) => Clipboard.SetText(añosservicio.Text);
        private void telefonoservidor_Click(object sender, EventArgs e) => Clipboard.SetText(telefonoservidor.Text);
        private void redesservicio_Click(object sender, EventArgs e) => Clipboard.SetText(redesservicio.Text);
        private void categoriaservicio_Click(object sender, EventArgs e) => Clipboard.SetText(categoriaservicio.Text);


        private void logo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logo de la empresa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void imgservicio_Click(object sender, EventArgs e)
        {
            if (imgservicio.Image != null)
            {
                Form vista = new Form { Text = "Vista previa", Size = new Size(600, 400), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog };
                PictureBox pb = new PictureBox { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, Image = imgservicio.Image };
                vista.Controls.Add(pb);
                vista.ShowDialog();
            }
        }


        private void botoncambiardatos_Click(object sender, EventArgs e)
        {
            // Abrir el Form2 para editar el perfil del servicio.
            if (!UserContext.IsAuthorizedForService(servicioId))
            {
                MostrarError("No tienes permiso para modificar estos datos.");
                return;
            }


            using (var formEdicion = new Form2(servicioId))
            {
                var res = formEdicion.ShowDialog(this);
                // Si se guardaron cambios, recargar (en la demo solo refrescamos labels simulados)
                if (res == DialogResult.OK)
                {
                    CargarDatosServicio();
                }
            }
        }

        private void CargarDatosServicio()
        {
            throw new NotImplementedException();
        }
    }
}