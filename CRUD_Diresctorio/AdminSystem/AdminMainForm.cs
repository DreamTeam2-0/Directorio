// AdminMainForm.cs
using CRUD_Directorio.CRUD;
using CRUD_Directorio.Files;
using Verification;
using CRUD_Directorio.Login;
using Shared.Session;
using System;
using System.Windows.Forms;

namespace CRUD_Directorio.AdminSystem
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"Usuario: {UserSession.NombreCompleto}";
            lblRol.Text = $"Rol: {UserSession.Rol}";
            lblFecha.Text = $"Conectado: {UserSession.FechaLogin:g}";

            // Cargar las pestañas
            LoadTabPages();
        }

        private void LoadTabPages()
        {
            // Pestaña CRUD
            var crudTabPage = new CrudTabPage();
            crudTabPage.Dock = DockStyle.Fill;
            tabPageCRUD.Controls.Add(crudTabPage);

            // Pestaña Verificación
            var verificationTabPage = new VerificationTabPage();
            verificationTabPage.Dock = DockStyle.Fill;
            tabPageVerificacion.Controls.Add(verificationTabPage);

            // Pestaña Archivos
            var filesTabPage = new FilesTabPage();
            filesTabPage.Dock = DockStyle.Fill;
            tabPageArchivos.Controls.Add(filesTabPage);
        }

        // MÉTODO COMÚN PARA CERRAR SESIÓN
        private void CerrarSesionYVolverAlLogin()
        {
            if (MessageBox.Show("¿Está seguro de cerrar sesión?", "Cerrar Sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserSession.CerrarSesion();
                var loginForm = new LoginAdminForm();
                loginForm.Show();

                // Desvincular el evento FormClosing para evitar el bucle
                this.FormClosing -= AdminMainForm_FormClosing;
                this.Close(); // Ahora esto no disparará el evento
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarSesionYVolverAlLogin();
        }

        private void AdminMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancelar el cierre automático
            e.Cancel = true;
            // Usar nuestro método común
            CerrarSesionYVolverAlLogin();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Sistema de Administración - Directorio de Servicios\n" +
                "Versión 1.0\n" +
                $"Usuario: {UserSession.NombreCompleto}\n" +
                $"Rol: {UserSession.Rol}\n\n" +
                "© 2024 Directorio de Servicios",
                "Acerca del Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void cRUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageCRUD;
        }

        private void verificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageVerificacion;
        }

        private void archivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageArchivos;
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Perfil de {UserSession.NombreCompleto}\nRol: {UserSession.Rol}\nUsuario: {UserSession.Username}",
                "Mi Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}