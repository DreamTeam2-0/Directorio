using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace Perfil
{
    public partial class Form2 : Form
    {
        private int servicioId;
        private string connectionString =
        "Data Source=TU_SERVIDOR;Initial Catalog=TU_BASE_DE_DATOS;Integrated Security=True";


        // Controles de edición dinámicos
        private TextBox txtNombre;
        private TextBox txtUbicacion;
        private TextBox txtTelefono;
        private bool isEditing = false;
        private Button btnCancelarEdicion;


        public Form2(int id)
        {
            InitializeComponent();
            this.servicioId = id;
            this.Load += Form2_Load;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            CargarDatosServicio();


            // Solo el propietario autorizado puede ver el botón
            botoncambiardatos.Visible = UserContext.IsAuthorizedForService(servicioId);
            botoncambiardatos.Enabled = botoncambiardatos.Visible;
        }


        private void CargarDatosServicio()
        {
            try
            {
                SimularDatosDesdeBaseDeDatos();
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar los datos del servicio: " + ex.Message);
            }
        }


        private void SimularDatosDesdeBaseDeDatos()
        {
            Nombreservicio.Text = "Jardinería Profesiona";
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
