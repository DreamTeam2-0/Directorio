using System;
using System.Drawing;
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
            CargarListaCategorias();
        }

        private void CargarDatosProveedor()
        {
            try
            {
                _datosActuales = _datosService.ObtenerDatosProveedor();

                if (_datosActuales != null)
                {
                    // Datos personales
                    txtNombres.Text = _datosActuales.Nombres;
                    txtApellidos.Text = _datosActuales.Apellidos;
                    txtEmail.Text = _datosActuales.Email;
                    txtTelefono.Text = _datosActuales.Telefono;
                    txtWhatsApp.Text = _datosActuales.Whatsapp;
                    txtCiudad.Text = _datosActuales.Ciudad;
                    txtDireccion.Text = _datosActuales.Direccion;
                    txtZonasServicio.Text = _datosActuales.ZonasServicio;
                    txtOtroContacto.Text = _datosActuales.OtroContacto;

                    // Datos de experiencia
                    if (_datosActuales.Experiencia != null)
                    {
                        txtAnosExperiencia.Text = _datosActuales.Experiencia.AnosExperiencia;
                        txtEmpresasAnteriores.Text = _datosActuales.Experiencia.EmpresasAnteriores;
                        txtProyectosDestacados.Text = _datosActuales.Experiencia.ProyectosDestacados;
                        txtReferencias.Text = _datosActuales.Experiencia.ReferenciasLaborales;

                        // Tipo de proveedor
                        if (_datosActuales.Experiencia.TipoRegistro == "certificado")
                        {
                            rbCertificado.Checked = true;
                            CargarNivelEstudios();
                        }
                        else
                        {
                            rbEmpirico.Checked = true;
                            txtTipoExperiencia.Text = _datosActuales.Experiencia.TipoExperiencia;
                            txtDescripcionOtro.Text = _datosActuales.Experiencia.DescripcionOtro;
                        }
                    }

                    // Cargar especialidades existentes
                    if (_datosActuales.Especialidades != null)
                    {
                        foreach (var especialidad in _datosActuales.Especialidades)
                        {
                            // Marcar categorías seleccionadas
                            foreach (var item in lbCategorias.Items)
                            {
                                if (item.ToString() == especialidad.NombreCategoria)
                                {
                                    lbCategorias.SelectedItem = item;
                                    break;
                                }
                            }

                            txtHerramientas.Text = especialidad.Herramientas;
                            txtDescripcionServicios.Text = especialidad.DescripcionServicios;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarListaCategorias()
        {
            try
            {
                var categorias = _datosService.ObtenerCategorias();
                lbCategorias.Items.Clear();

                foreach (var categoria in categorias)
                {
                    lbCategorias.Items.Add($"{categoria.Id} - {categoria.Nombre}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (_datosActuales?.Experiencia != null && !string.IsNullOrEmpty(_datosActuales.Experiencia.NivelEstudios))
            {
                cbNivelEstudios.Text = _datosActuales.Experiencia.NivelEstudios;
            }
        }

        private void rbCertificado_CheckedChanged(object sender, EventArgs e)
        {
            pnlCertificado.Visible = rbCertificado.Checked;
            pnlEmpirico.Visible = rbEmpirico.Checked;

            if (rbCertificado.Checked)
            {
                CargarNivelEstudios();
            }
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
                    },

                    // Especialidades
                    Especialidades = new System.Collections.Generic.List<EspecialidadProveedorModel>()
                };

                // Agregar categorías seleccionadas
                foreach (var item in lbCategorias.SelectedItems)
                {
                    var itemStr = item.ToString();
                    var idCategoria = int.Parse(itemStr.Split('-')[0].Trim());

                    datosActualizados.Especialidades.Add(new EspecialidadProveedorModel
                    {
                        IdCategoria = idCategoria,
                        NombreCategoria = itemStr.Split('-')[1].Trim(),
                        Herramientas = txtHerramientas.Text.Trim(),
                        DescripcionServicios = txtDescripcionServicios.Text.Trim()
                    });
                }

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

            // Validar al menos una categoría seleccionada
            if (lbCategorias.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una categoría de servicio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Métodos adicionales que necesitan ser agregados a EditarDatosProveedorForm.cs

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            // Seleccionar/deseleccionar todas las categorías
            if (lbCategorias.SelectedItems.Count == lbCategorias.Items.Count)
            {
                // Si todas están seleccionadas, deseleccionar todas
                for (int i = 0; i < lbCategorias.Items.Count; i++)
                {
                    lbCategorias.SetSelected(i, false);
                }
                btnAgregarCategoria.Text = "Seleccionar Todo";
            }
            else
            {
                // Si no todas están seleccionadas, seleccionar todas
                for (int i = 0; i < lbCategorias.Items.Count; i++)
                {
                    lbCategorias.SetSelected(i, true);
                }
                btnAgregarCategoria.Text = "Deseleccionar Todo";
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Ajustar tamaño del formulario si es necesario
            if (lbCategorias.Items.Count > 10)
            {
                lbCategorias.Height = 250;
                this.Height = 650;
                btnGuardar.Location = new Point(btnGuardar.Location.X, btnGuardar.Location.Y + 50);
                btnCancelar.Location = new Point(btnCancelar.Location.X, btnCancelar.Location.Y + 50);
            }
        }
    }
}