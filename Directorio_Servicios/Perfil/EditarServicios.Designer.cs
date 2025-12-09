using System.Drawing;

namespace Perfil
{
    partial class EditarServicios
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label lblTotalServicios;
        private System.Windows.Forms.FlowLayoutPanel flpServicios;
        private System.Windows.Forms.Button btnNuevoServicio;
        private System.Windows.Forms.GroupBox gbServicio;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblSeleccionado;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbDenominacion;
        private System.Windows.Forms.ComboBox cmbTipoPrecio;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.TextBox txtDisponibilidad;
        private System.Windows.Forms.TextBox txtRadioCobertura;
        private System.Windows.Forms.TextBox txtExperiencia;
        private System.Windows.Forms.Button btnGuardarServicio;
        private System.Windows.Forms.Button btnEliminarServicio;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblDenominacion;
        private System.Windows.Forms.Label lblTipoPrecio;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblDisponibilidad;
        private System.Windows.Forms.Label lblRadioCobertura;
        private System.Windows.Forms.Label lblExpServicio;
        private System.Windows.Forms.GroupBox gbExperiencia;
        private System.Windows.Forms.ComboBox cmbTipoExperiencia;
        private System.Windows.Forms.ComboBox cmbNivelEstudios;
        private System.Windows.Forms.TextBox txtAnosExperiencia;
        private System.Windows.Forms.TextBox txtEmpresasAnteriores;
        private System.Windows.Forms.TextBox txtProyectosDestacados;
        private System.Windows.Forms.TextBox txtReferenciasLaborales;
        private System.Windows.Forms.TextBox txtTipoExperiencia;
        private System.Windows.Forms.TextBox txtDescripcionOtro;
        private System.Windows.Forms.Button btnGuardarExperiencia;
        private System.Windows.Forms.Label lblTipoExperiencia;
        private System.Windows.Forms.Label lblNivelEstudios;
        private System.Windows.Forms.Label lblAnosExperiencia;
        private System.Windows.Forms.Label lblEmpresasAnteriores;
        private System.Windows.Forms.Label lblProyectosDestacados;
        private System.Windows.Forms.Label lblReferenciasLaborales;
        private System.Windows.Forms.Label lblTipoExp;
        private System.Windows.Forms.Label lblDescripcionOtro;
        private System.Windows.Forms.Label lblEstadoExperiencia;
        private System.Windows.Forms.Label lblInstrucciones;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.lblTotalServicios = new System.Windows.Forms.Label();
            this.flpServicios = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevoServicio = new System.Windows.Forms.Button();
            this.gbServicio = new System.Windows.Forms.GroupBox();
            this.txtExperiencia = new System.Windows.Forms.TextBox();
            this.lblExpServicio = new System.Windows.Forms.Label();
            this.txtRadioCobertura = new System.Windows.Forms.TextBox();
            this.lblRadioCobertura = new System.Windows.Forms.Label();
            this.txtDisponibilidad = new System.Windows.Forms.TextBox();
            this.lblDisponibilidad = new System.Windows.Forms.Label();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.cmbTipoPrecio = new System.Windows.Forms.ComboBox();
            this.lblTipoPrecio = new System.Windows.Forms.Label();
            this.cmbDenominacion = new System.Windows.Forms.ComboBox();
            this.lblDenominacion = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnEliminarServicio = new System.Windows.Forms.Button();
            this.btnGuardarServicio = new System.Windows.Forms.Button();
            this.lblSeleccionado = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.gbExperiencia = new System.Windows.Forms.GroupBox();
            this.lblEstadoExperiencia = new System.Windows.Forms.Label();
            this.txtDescripcionOtro = new System.Windows.Forms.TextBox();
            this.lblDescripcionOtro = new System.Windows.Forms.Label();
            this.txtTipoExperiencia = new System.Windows.Forms.TextBox();
            this.lblTipoExp = new System.Windows.Forms.Label();
            this.txtReferenciasLaborales = new System.Windows.Forms.TextBox();
            this.lblReferenciasLaborales = new System.Windows.Forms.Label();
            this.txtProyectosDestacados = new System.Windows.Forms.TextBox();
            this.lblProyectosDestacados = new System.Windows.Forms.Label();
            this.txtEmpresasAnteriores = new System.Windows.Forms.TextBox();
            this.lblEmpresasAnteriores = new System.Windows.Forms.Label();
            this.txtAnosExperiencia = new System.Windows.Forms.TextBox();
            this.lblAnosExperiencia = new System.Windows.Forms.Label();
            this.cmbNivelEstudios = new System.Windows.Forms.ComboBox();
            this.lblNivelEstudios = new System.Windows.Forms.Label();
            this.cmbTipoExperiencia = new System.Windows.Forms.ComboBox();
            this.lblTipoExperiencia = new System.Windows.Forms.Label();
            this.btnGuardarExperiencia = new System.Windows.Forms.Button();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.gbServicio.SuspendLayout();
            this.gbExperiencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTituloForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTituloForm.Location = new System.Drawing.Point(15, 15);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(194, 30);
            this.lblTituloForm.TabIndex = 0;
            this.lblTituloForm.Text = "Gestión de Servicios";
            // 
            // lblTotalServicios
            // 
            this.lblTotalServicios.AutoSize = true;
            this.lblTotalServicios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalServicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblTotalServicios.Location = new System.Drawing.Point(220, 25);
            this.lblTotalServicios.Name = "lblTotalServicios";
            this.lblTotalServicios.Size = new System.Drawing.Size(105, 19);
            this.lblTotalServicios.TabIndex = 1;
            this.lblTotalServicios.Text = "Tienes 0 servicios";
            // 
            // flpServicios
            // 
            this.flpServicios.AutoScroll = true;
            this.flpServicios.Location = new System.Drawing.Point(20, 100);
            this.flpServicios.Name = "flpServicios";
            this.flpServicios.Size = new System.Drawing.Size(300, 450);
            this.flpServicios.TabIndex = 2;
            // 
            // btnNuevoServicio
            // 
            this.btnNuevoServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnNuevoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoServicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoServicio.ForeColor = System.Drawing.Color.White;
            this.btnNuevoServicio.Location = new System.Drawing.Point(20, 60);
            this.btnNuevoServicio.Name = "btnNuevoServicio";
            this.btnNuevoServicio.Size = new System.Drawing.Size(140, 30);
            this.btnNuevoServicio.TabIndex = 3;
            this.btnNuevoServicio.Text = "➕ Nuevo Servicio";
            this.btnNuevoServicio.UseVisualStyleBackColor = false;
            this.btnNuevoServicio.Click += new System.EventHandler(this.btnNuevoServicio_Click);
            // 
            // gbServicio
            // 
            this.gbServicio.Controls.Add(this.txtExperiencia);
            this.gbServicio.Controls.Add(this.lblExpServicio);
            this.gbServicio.Controls.Add(this.txtRadioCobertura);
            this.gbServicio.Controls.Add(this.lblRadioCobertura);
            this.gbServicio.Controls.Add(this.txtDisponibilidad);
            this.gbServicio.Controls.Add(this.lblDisponibilidad);
            this.gbServicio.Controls.Add(this.txtMoneda);
            this.gbServicio.Controls.Add(this.lblMoneda);
            this.gbServicio.Controls.Add(this.cmbTipoPrecio);
            this.gbServicio.Controls.Add(this.lblTipoPrecio);
            this.gbServicio.Controls.Add(this.cmbDenominacion);
            this.gbServicio.Controls.Add(this.lblDenominacion);
            this.gbServicio.Controls.Add(this.cmbCategoria);
            this.gbServicio.Controls.Add(this.lblCategoria);
            this.gbServicio.Controls.Add(this.txtDescripcion);
            this.gbServicio.Controls.Add(this.lblDescripcion);
            this.gbServicio.Controls.Add(this.txtTitulo);
            this.gbServicio.Controls.Add(this.lblTitulo);
            this.gbServicio.Controls.Add(this.btnEliminarServicio);
            this.gbServicio.Controls.Add(this.btnGuardarServicio);
            this.gbServicio.Controls.Add(this.lblSeleccionado);
            this.gbServicio.Controls.Add(this.txtId);
            this.gbServicio.Location = new System.Drawing.Point(340, 60);
            this.gbServicio.Name = "gbServicio";
            this.gbServicio.Size = new System.Drawing.Size(400, 490);
            this.gbServicio.TabIndex = 4;
            this.gbServicio.TabStop = false;
            this.gbServicio.Text = "Formulario de Servicio";
            // 
            // txtExperiencia
            // 
            this.txtExperiencia.Location = new System.Drawing.Point(20, 370);
            this.txtExperiencia.Multiline = true;
            this.txtExperiencia.Name = "txtExperiencia";
            this.txtExperiencia.Size = new System.Drawing.Size(360, 50);
            this.txtExperiencia.TabIndex = 22;
            // 
            // lblExpServicio
            // 
            this.lblExpServicio.AutoSize = true;
            this.lblExpServicio.Location = new System.Drawing.Point(20, 350);
            this.lblExpServicio.Name = "lblExpServicio";
            this.lblExpServicio.Size = new System.Drawing.Size(136, 15);
            this.lblExpServicio.TabIndex = 21;
            this.lblExpServicio.Text = "Experiencia (opcional)";
            // 
            // txtRadioCobertura
            // 
            this.txtRadioCobertura.Location = new System.Drawing.Point(200, 280);
            this.txtRadioCobertura.Name = "txtRadioCobertura";
            this.txtRadioCobertura.Size = new System.Drawing.Size(180, 25);
            this.txtRadioCobertura.TabIndex = 20;
            // 
            // lblRadioCobertura
            // 
            this.lblRadioCobertura.AutoSize = true;
            this.lblRadioCobertura.Location = new System.Drawing.Point(200, 260);
            this.lblRadioCobertura.Name = "lblRadioCobertura";
            this.lblRadioCobertura.Size = new System.Drawing.Size(108, 15);
            this.lblRadioCobertura.TabIndex = 19;
            this.lblRadioCobertura.Text = "Radio de Cobertura";
            // 
            // txtDisponibilidad
            // 
            this.txtDisponibilidad.Location = new System.Drawing.Point(20, 280);
            this.txtDisponibilidad.Name = "txtDisponibilidad";
            this.txtDisponibilidad.Size = new System.Drawing.Size(170, 25);
            this.txtDisponibilidad.TabIndex = 18;
            // 
            // lblDisponibilidad
            // 
            this.lblDisponibilidad.AutoSize = true;
            this.lblDisponibilidad.Location = new System.Drawing.Point(20, 260);
            this.lblDisponibilidad.Name = "lblDisponibilidad";
            this.lblDisponibilidad.Size = new System.Drawing.Size(87, 15);
            this.lblDisponibilidad.TabIndex = 17;
            this.lblDisponibilidad.Text = "Disponibilidad";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(200, 220);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(60, 25);
            this.txtMoneda.TabIndex = 16;
            this.txtMoneda.Text = "USD";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(200, 200);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(50, 15);
            this.lblMoneda.TabIndex = 15;
            this.lblMoneda.Text = "Moneda";
            // 
            // cmbTipoPrecio
            // 
            this.cmbTipoPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPrecio.FormattingEnabled = true;
            this.cmbTipoPrecio.Items.AddRange(new object[] {
            "fijo",
            "por_hora",
            "presupuesto",
            "consultar"});
            this.cmbTipoPrecio.Location = new System.Drawing.Point(20, 220);
            this.cmbTipoPrecio.Name = "cmbTipoPrecio";
            this.cmbTipoPrecio.Size = new System.Drawing.Size(170, 25);
            this.cmbTipoPrecio.TabIndex = 14;
            // 
            // lblTipoPrecio
            // 
            this.lblTipoPrecio.AutoSize = true;
            this.lblTipoPrecio.Location = new System.Drawing.Point(20, 200);
            this.lblTipoPrecio.Name = "lblTipoPrecio";
            this.lblTipoPrecio.Size = new System.Drawing.Size(71, 15);
            this.lblTipoPrecio.TabIndex = 13;
            this.lblTipoPrecio.Text = "Tipo Precio";
            // 
            // cmbDenominacion
            // 
            this.cmbDenominacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDenominacion.FormattingEnabled = true;
            this.cmbDenominacion.Location = new System.Drawing.Point(20, 160);
            this.cmbDenominacion.Name = "cmbDenominacion";
            this.cmbDenominacion.Size = new System.Drawing.Size(360, 25);
            this.cmbDenominacion.TabIndex = 12;
            // 
            // lblDenominacion
            // 
            this.lblDenominacion.AutoSize = true;
            this.lblDenominacion.Location = new System.Drawing.Point(20, 140);
            this.lblDenominacion.Name = "lblDenominacion";
            this.lblDenominacion.Size = new System.Drawing.Size(83, 15);
            this.lblDenominacion.TabIndex = 11;
            this.lblDenominacion.Text = "Denominación";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(20, 100);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(360, 25);
            this.cmbCategoria.TabIndex = 10;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(20, 80);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(58, 15);
            this.lblCategoria.TabIndex = 9;
            this.lblCategoria.Text = "Categoría";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(200, 40);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(180, 25);
            this.txtDescripcion.TabIndex = 8;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(200, 20);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(69, 15);
            this.lblDescripcion.TabIndex = 7;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(20, 40);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(170, 25);
            this.txtTitulo.TabIndex = 6;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(38, 15);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Título";
            // 
            // btnEliminarServicio
            // 
            this.btnEliminarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnEliminarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarServicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarServicio.ForeColor = System.Drawing.Color.White;
            this.btnEliminarServicio.Location = new System.Drawing.Point(220, 440);
            this.btnEliminarServicio.Name = "btnEliminarServicio";
            this.btnEliminarServicio.Size = new System.Drawing.Size(160, 35);
            this.btnEliminarServicio.TabIndex = 3;
            this.btnEliminarServicio.Text = "🗑️ Eliminar Servicio";
            this.btnEliminarServicio.UseVisualStyleBackColor = false;
            this.btnEliminarServicio.Click += new System.EventHandler(this.btnEliminarServicio_Click);
            // 
            // btnGuardarServicio
            // 
            this.btnGuardarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGuardarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarServicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarServicio.ForeColor = System.Drawing.Color.White;
            this.btnGuardarServicio.Location = new System.Drawing.Point(20, 440);
            this.btnGuardarServicio.Name = "btnGuardarServicio";
            this.btnGuardarServicio.Size = new System.Drawing.Size(160, 35);
            this.btnGuardarServicio.TabIndex = 2;
            this.btnGuardarServicio.Text = "💾 Guardar Servicio";
            this.btnGuardarServicio.UseVisualStyleBackColor = false;
            this.btnGuardarServicio.Click += new System.EventHandler(this.btnGuardarServicio_Click);
            // 
            // lblSeleccionado
            // 
            this.lblSeleccionado.AutoSize = true;
            this.lblSeleccionado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSeleccionado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblSeleccionado.Location = new System.Drawing.Point(20, 440);
            this.lblSeleccionado.Name = "lblSeleccionado";
            this.lblSeleccionado.Size = new System.Drawing.Size(118, 15);
            this.lblSeleccionado.TabIndex = 1;
            this.lblSeleccionado.Text = "Seleccione un servicio";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(350, 20);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(30, 25);
            this.txtId.TabIndex = 0;
            this.txtId.Visible = false;
            // 
            // gbExperiencia
            // 
            this.gbExperiencia.Controls.Add(this.lblEstadoExperiencia);
            this.gbExperiencia.Controls.Add(this.txtDescripcionOtro);
            this.gbExperiencia.Controls.Add(this.lblDescripcionOtro);
            this.gbExperiencia.Controls.Add(this.txtTipoExperiencia);
            this.gbExperiencia.Controls.Add(this.lblTipoExp);
            this.gbExperiencia.Controls.Add(this.txtReferenciasLaborales);
            this.gbExperiencia.Controls.Add(this.lblReferenciasLaborales);
            this.gbExperiencia.Controls.Add(this.txtProyectosDestacados);
            this.gbExperiencia.Controls.Add(this.lblProyectosDestacados);
            this.gbExperiencia.Controls.Add(this.txtEmpresasAnteriores);
            this.gbExperiencia.Controls.Add(this.lblEmpresasAnteriores);
            this.gbExperiencia.Controls.Add(this.txtAnosExperiencia);
            this.gbExperiencia.Controls.Add(this.lblAnosExperiencia);
            this.gbExperiencia.Controls.Add(this.cmbNivelEstudios);
            this.gbExperiencia.Controls.Add(this.lblNivelEstudios);
            this.gbExperiencia.Controls.Add(this.cmbTipoExperiencia);
            this.gbExperiencia.Controls.Add(this.lblTipoExperiencia);
            this.gbExperiencia.Controls.Add(this.btnGuardarExperiencia);
            this.gbExperiencia.Location = new System.Drawing.Point(760, 60);
            this.gbExperiencia.Name = "gbExperiencia";
            this.gbExperiencia.Size = new System.Drawing.Size(400, 490);
            this.gbExperiencia.TabIndex = 5;
            this.gbExperiencia.TabStop = false;
            this.gbExperiencia.Text = "Formulario de Experiencia";
            // 
            // lblEstadoExperiencia
            // 
            this.lblEstadoExperiencia.AutoSize = true;
            this.lblEstadoExperiencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstadoExperiencia.Location = new System.Drawing.Point(20, 440);
            this.lblEstadoExperiencia.Name = "lblEstadoExperiencia";
            this.lblEstadoExperiencia.Size = new System.Drawing.Size(180, 15);
            this.lblEstadoExperiencia.TabIndex = 17;
            this.lblEstadoExperiencia.Text = "Sin experiencia registrada";
            // 
            // txtDescripcionOtro
            // 
            this.txtDescripcionOtro.Location = new System.Drawing.Point(20, 380);
            this.txtDescripcionOtro.Multiline = true;
            this.txtDescripcionOtro.Name = "txtDescripcionOtro";
            this.txtDescripcionOtro.Size = new System.Drawing.Size(360, 50);
            this.txtDescripcionOtro.TabIndex = 16;
            // 
            // lblDescripcionOtro
            // 
            this.lblDescripcionOtro.AutoSize = true;
            this.lblDescripcionOtro.Location = new System.Drawing.Point(20, 320);
            this.lblDescripcionOtro.Name = "lblDescripcionOtro";
            this.lblDescripcionOtro.Size = new System.Drawing.Size(130, 15);
            this.lblDescripcionOtro.TabIndex = 15;
            this.lblDescripcionOtro.Text = "Descripción adicional";
            // 
            // txtTipoExperiencia
            // 
            this.txtTipoExperiencia.Location = new System.Drawing.Point(20, 280);
            this.txtTipoExperiencia.Name = "txtTipoExperiencia";
            this.txtTipoExperiencia.Size = new System.Drawing.Size(360, 25);
            this.txtTipoExperiencia.TabIndex = 14;
            // 
            // lblTipoExp
            // 
            this.lblTipoExp.AutoSize = true;
            this.lblTipoExp.Location = new System.Drawing.Point(20, 260);
            this.lblTipoExp.Name = "lblTipoExp";
            this.lblTipoExp.Size = new System.Drawing.Size(117, 15);
            this.lblTipoExp.TabIndex = 13;
            this.lblTipoExp.Text = "Tipo de experiencia";
            // 
            // txtReferenciasLaborales
            // 
            this.txtReferenciasLaborales.Location = new System.Drawing.Point(20, 220);
            this.txtReferenciasLaborales.Multiline = true;
            this.txtReferenciasLaborales.Name = "txtReferenciasLaborales";
            this.txtReferenciasLaborales.Size = new System.Drawing.Size(360, 30);
            this.txtReferenciasLaborales.TabIndex = 12;
            // 
            // lblReferenciasLaborales
            // 
            this.lblReferenciasLaborales.AutoSize = true;
            this.lblReferenciasLaborales.Location = new System.Drawing.Point(20, 200);
            this.lblReferenciasLaborales.Name = "lblReferenciasLaborales";
            this.lblReferenciasLaborales.Size = new System.Drawing.Size(130, 15);
            this.lblReferenciasLaborales.TabIndex = 11;
            this.lblReferenciasLaborales.Text = "Referencias laborales";
            // 
            // txtProyectosDestacados
            // 
            this.txtProyectosDestacados.Location = new System.Drawing.Point(20, 160);
            this.txtProyectosDestacados.Multiline = true;
            this.txtProyectosDestacados.Name = "txtProyectosDestacados";
            this.txtProyectosDestacados.Size = new System.Drawing.Size(360, 30);
            this.txtProyectosDestacados.TabIndex = 10;
            // 
            // lblProyectosDestacados
            // 
            this.lblProyectosDestacados.AutoSize = true;
            this.lblProyectosDestacados.Location = new System.Drawing.Point(20, 140);
            this.lblProyectosDestacados.Name = "lblProyectosDestacados";
            this.lblProyectosDestacados.Size = new System.Drawing.Size(135, 15);
            this.lblProyectosDestacados.TabIndex = 9;
            this.lblProyectosDestacados.Text = "Proyectos destacados";
            // 
            // txtEmpresasAnteriores
            // 
            this.txtEmpresasAnteriores.Location = new System.Drawing.Point(20, 100);
            this.txtEmpresasAnteriores.Multiline = true;
            this.txtEmpresasAnteriores.Name = "txtEmpresasAnteriores";
            this.txtEmpresasAnteriores.Size = new System.Drawing.Size(360, 30);
            this.txtEmpresasAnteriores.TabIndex = 8;
            // 
            // lblEmpresasAnteriores
            // 
            this.lblEmpresasAnteriores.AutoSize = true;
            this.lblEmpresasAnteriores.Location = new System.Drawing.Point(20, 80);
            this.lblEmpresasAnteriores.Name = "lblEmpresasAnteriores";
            this.lblEmpresasAnteriores.Size = new System.Drawing.Size(120, 15);
            this.lblEmpresasAnteriores.TabIndex = 7;
            this.lblEmpresasAnteriores.Text = "Empresas anteriores";
            // 
            // txtAnosExperiencia
            // 
            this.txtAnosExperiencia.Location = new System.Drawing.Point(20, 40);
            this.txtAnosExperiencia.Name = "txtAnosExperiencia";
            this.txtAnosExperiencia.Size = new System.Drawing.Size(180, 25);
            this.txtAnosExperiencia.TabIndex = 6;
            // 
            // lblAnosExperiencia
            // 
            this.lblAnosExperiencia.AutoSize = true;
            this.lblAnosExperiencia.Location = new System.Drawing.Point(20, 20);
            this.lblAnosExperiencia.Name = "lblAnosExperiencia";
            this.lblAnosExperiencia.Size = new System.Drawing.Size(108, 15);
            this.lblAnosExperiencia.TabIndex = 5;
            this.lblAnosExperiencia.Text = "Años de experiencia";
            // 
            // cmbNivelEstudios
            // 
            this.cmbNivelEstudios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelEstudios.FormattingEnabled = true;
            this.cmbNivelEstudios.Location = new System.Drawing.Point(220, 40);
            this.cmbNivelEstudios.Name = "cmbNivelEstudios";
            this.cmbNivelEstudios.Size = new System.Drawing.Size(160, 25);
            this.cmbNivelEstudios.TabIndex = 4;
            this.cmbNivelEstudios.Visible = false;
            // 
            // lblNivelEstudios
            // 
            this.lblNivelEstudios.AutoSize = true;
            this.lblNivelEstudios.Location = new System.Drawing.Point(220, 20);
            this.lblNivelEstudios.Name = "lblNivelEstudios";
            this.lblNivelEstudios.Size = new System.Drawing.Size(105, 15);
            this.lblNivelEstudios.TabIndex = 3;
            this.lblNivelEstudios.Text = "Nivel de estudios";
            this.lblNivelEstudios.Visible = false;
            // 
            // cmbTipoExperiencia
            // 
            this.cmbTipoExperiencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoExperiencia.FormattingEnabled = true;
            this.cmbTipoExperiencia.Items.AddRange(new object[] {
            "certificado",
            "empirico"});
            this.cmbTipoExperiencia.Location = new System.Drawing.Point(20, 40);
            this.cmbTipoExperiencia.Name = "cmbTipoExperiencia";
            this.cmbTipoExperiencia.Size = new System.Drawing.Size(180, 25);
            this.cmbTipoExperiencia.TabIndex = 2;
            this.cmbTipoExperiencia.SelectedIndexChanged += new System.EventHandler(this.cmbTipoExperiencia_SelectedIndexChanged);
            // 
            // lblTipoExperiencia
            // 
            this.lblTipoExperiencia.AutoSize = true;
            this.lblTipoExperiencia.Location = new System.Drawing.Point(20, 20);
            this.lblTipoExperiencia.Name = "lblTipoExperiencia";
            this.lblTipoExperiencia.Size = new System.Drawing.Size(99, 15);
            this.lblTipoExperiencia.TabIndex = 1;
            this.lblTipoExperiencia.Text = "Tipo de registro";
            // 
            // btnGuardarExperiencia
            // 
            this.btnGuardarExperiencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnGuardarExperiencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarExperiencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarExperiencia.ForeColor = System.Drawing.Color.White;
            this.btnGuardarExperiencia.Location = new System.Drawing.Point(220, 440);
            this.btnGuardarExperiencia.Name = "btnGuardarExperiencia";
            this.btnGuardarExperiencia.Size = new System.Drawing.Size(160, 35);
            this.btnGuardarExperiencia.TabIndex = 0;
            this.btnGuardarExperiencia.Text = "💾 Guardar Experiencia";
            this.btnGuardarExperiencia.UseVisualStyleBackColor = false;
            this.btnGuardarExperiencia.Click += new System.EventHandler(this.btnGuardarExperiencia_Click);
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.AutoSize = true;
            this.lblInstrucciones.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblInstrucciones.ForeColor = System.Drawing.Color.Gray;
            this.lblInstrucciones.Location = new System.Drawing.Point(20, 560);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(300, 30);
            this.lblInstrucciones.TabIndex = 6;
            this.lblInstrucciones.Text = "👈 Haz clic en un servicio para editarlo\n➕ Usa 'Nuevo Servicio' para crear uno nuevo";
            // 
            // EditarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 650);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.gbExperiencia);
            this.Controls.Add(this.gbServicio);
            this.Controls.Add(this.btnNuevoServicio);
            this.Controls.Add(this.flpServicios);
            this.Controls.Add(this.lblTotalServicios);
            this.Controls.Add(this.lblTituloForm);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Servicios y Experiencia";
            this.Load += new System.EventHandler(this.EditarServicios_Load);
            this.gbServicio.ResumeLayout(false);
            this.gbServicio.PerformLayout();
            this.gbExperiencia.ResumeLayout(false);
            this.gbExperiencia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}