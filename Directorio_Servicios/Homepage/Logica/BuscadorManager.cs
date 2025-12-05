using Homepage.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Homepage.Logica
{
    public class BuscadorManager
    {
        private TextBox _txtBuscar;
        private Action _accionBuscar;

        public BuscadorManager(TextBox txtBuscar, Action accionBuscar)
        {
            _txtBuscar = txtBuscar;
            _accionBuscar = accionBuscar;
        }

        public void ConfigurarBuscador()
        {
            // Configurar color inicial
            _txtBuscar.ForeColor = Color.Gray;
            _txtBuscar.Text = "BUSCAR CATEGORÍAS";

            // Evento Enter (GotFocus)
            _txtBuscar.Enter += (s, e) => {
                // Si es el placeholder, limpiar
                if (_txtBuscar.Text == "BUSCAR CATEGORÍAS")
                {
                    _txtBuscar.Text = "";
                    _txtBuscar.ForeColor = Color.Black;
                }
            };

            // Evento Leave (LostFocus)
            _txtBuscar.Leave += (s, e) => {
                // Si está vacío, restaurar placeholder
                if (string.IsNullOrWhiteSpace(_txtBuscar.Text))
                {
                    _txtBuscar.Text = "BUSCAR CATEGORÍAS";
                    _txtBuscar.ForeColor = Color.Gray;
                }
            };

            // Evento KeyPress - Solo validar cuando hay texto real
            _txtBuscar.KeyPress += (s, e) =>
            {
                // Permitir siempre backspace y delete
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
                    return;

                // Permitir empezar a escribir (el placeholder ya fue limpiado en Enter)
                if (_txtBuscar.Text == "BUSCAR CATEGORÍAS")
                {
                    // El placeholder ya debería haberse limpiado en el evento Enter
                    // Pero por si acaso, limpiarlo aquí también
                    _txtBuscar.Text = "";
                    _txtBuscar.ForeColor = Color.Black;
                    return;
                }

                // Validar solo caracteres permitidos
                if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true;
                    CrearBoton.MostrarError("Solo se permiten letras y espacios.");
                }
            };

            // Evento Validating
            _txtBuscar.Validating += (s, e) =>
            {
                // Solo validar si no es placeholder y tiene menos de 3 caracteres
                if (_txtBuscar.Text != "BUSCAR CATEGORÍAS" &&
                    _txtBuscar.Text.Length < 3 &&
                    !string.IsNullOrWhiteSpace(_txtBuscar.Text))
                {
                    e.Cancel = true;
                    CrearBoton.MostrarError("El texto debe tener al menos 3 letras.");
                }
            };

            // Evento KeyDown para Enter
            _txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // No buscar si es el placeholder
                    if (_txtBuscar.Text == "BUSCAR CATEGORÍAS")
                        return;

                    _accionBuscar?.Invoke();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
        }
    }
}