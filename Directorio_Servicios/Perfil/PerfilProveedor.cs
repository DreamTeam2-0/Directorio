using System;
using System.Windows.Forms;
using Perfil.Logica;
using Perfil.Modelos;

namespace Perfil
{
    public partial class PerfilProveedor : Form
    {
        private ProveedorServicio _datosService;
        private ProveedorUsuario _datosActuales;

        public PerfilProveedor()
        {
            InitializeComponent();
            _datosService = new ProveedorServicio();
        }

        private void EditarDatosProveedorForm_Load(object sender, EventArgs e)
        {
            CargarDatosProveedor();
        }

        private void CargarDatosProveedor()
        {
            try
            {
                _datosActuales = _datosService.ObtenerDatosProveedor();

                if (_datosActuales == null)
                {
                    MessageBox.Show("No se pudieron cargar los datos del perfil.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Datos personales
                txtNombres.Text = _datosActuales.Nombres ?? "";
                txtApellidos.Text = _datosActuales.Apellidos ?? "";
                txtEmail.Text = _datosActuales.Email ?? "";
                txtTelefono.Text = _datosActuales.Telefono ?? "";
                txtWhatsApp.Text = _datosActuales.Whatsapp ?? "";
                txtCiudad.Text = _datosActuales.Ciudad ?? "";
                txtDireccion.Text = _datosActuales.Direccion ?? "";
                txtZonasServicio.Text = _datosActuales.ZonasServicio ?? "";
                txtOtroContacto.Text = _datosActuales.OtroContacto ?? "";

                // Datos de experiencia
                if (_datosActuales.Experiencia != null)
                {
                    txtAnosExperiencia.Text = _datosActuales.Experiencia.AnosExperiencia ?? "";
                    txtEmpresasAnteriores.Text = _datosActuales.Experiencia.EmpresasAnteriores ?? "";
                    txtProyectosDestacados.Text = _datosActuales.Experiencia.ProyectosDestacados ?? "";
                    txtReferencias.Text = _datosActuales.Experiencia.ReferenciasLaborales ?? "";

                    // Tipo de proveedor
                    if (_datosActuales.Experiencia.TipoRegistro == "certificado")
                    {
                        rbCertificado.Checked = true;
                        CargarNivelEstudios();
                        cbNivelEstudios.Text = _datosActuales.Experiencia.NivelEstudios ?? "";
                    }
                    else
                    {
                        rbEmpirico.Checked = true;
                        txtTipoExperiencia.Text = _datosActuales.Experiencia.TipoExperiencia ?? "";
                        txtDescripcionOtro.Text = _datosActuales.Experiencia.DescripcionOtro ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarNivelEstudios()
        {
            cbNivelEstudios.Items.Clear();
            cbNivelEstudios.Items.AddRange(new string[]
            {
                "Técnico",
                "Tecnólogo",
                "Profesional",
                "Especialización",
                "Maestría",
                "Doctorado"
            });
        }

        private void rbCertificado_CheckedChanged(object sender, EventArgs e)
        {
            pnlCertificado.Visible = rbCertificado.Checked;
            pnlEmpirico.Visible = rbEmpirico.Checked;
        }

        private void rbEmpirico_CheckedChanged(object sender, EventArgs e)
        {
            pnlCertificado.Visible = rbCertificado.Checked;
            pnlEmpirico.Visible = rbEmpirico.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            try
            {
                var datosActualizados = new ProveedorUsuario
                {
                    // Datos personales
                    Nombres = txtNombres.Text.Trim(),
                    Apellidos = txtApellidos.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Whatsapp = txtWhatsApp.Text.Trim(),
                    Ciudad = txtCiudad.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    ZonasServicio = txtZonasServicio.Text.Trim(),
                    OtroContacto = txtOtroContacto.Text.Trim(),

                    // Datos de experiencia
                    Experiencia = new ExperienciaProveedorModel
                    {
                        TipoRegistro = rbCertificado.Checked ? "certificado" : "empirico",
                        AnosExperiencia = txtAnosExperiencia.Text.Trim(),
                        EmpresasAnteriores = txtEmpresasAnteriores.Text.Trim(),
                        ProyectosDestacados = txtProyectosDestacados.Text.Trim(),
                        ReferenciasLaborales = txtReferencias.Text.Trim(),
                        NivelEstudios = rbCertificado.Checked ? cbNivelEstudios.Text : null,
                        TipoExperiencia = rbEmpirico.Checked ? txtTipoExperiencia.Text.Trim() : null,
                        DescripcionOtro = rbEmpirico.Checked ? txtDescripcionOtro.Text.Trim() : null
                    }
                };

                // Guardar en la base de datos
                bool resultado = _datosService.ActualizarDatosProveedor(datosActualizados);

                if (resultado)
                {
                    MessageBox.Show("Datos actualizados correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            // Validar datos personales obligatorios
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("El campo Nombres es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("El campo Apellidos es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidos.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El campo Email es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El campo Teléfono es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAnosExperiencia.Text))
            {
                MessageBox.Show("El campo Años de Experiencia es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnosExperiencia.Focus();
                return false;
            }

            // Validar tipo de proveedor
            if (!rbCertificado.Checked && !rbEmpirico.Checked)
            {
                MessageBox.Show("Seleccione el tipo de proveedor", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar nivel de estudios para certificado
            if (rbCertificado.Checked && string.IsNullOrWhiteSpace(cbNivelEstudios.Text))
            {
                MessageBox.Show("Seleccione el nivel de estudios", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbNivelEstudios.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}