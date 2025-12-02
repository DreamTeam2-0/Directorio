using System.Linq;
using System.Windows.Forms;

namespace LoginDirectorio.RegistroFases
{
    public static class Validaciones
    {
        public static bool ValidarDatosBasicos(FaseDatosBasicos fase)
        {
            if (string.IsNullOrEmpty(fase.Username) || string.IsNullOrEmpty(fase.Password) ||
                string.IsNullOrEmpty(fase.ConfirmPassword) || string.IsNullOrEmpty(fase.Nombres) ||
                string.IsNullOrEmpty(fase.Apellidos) || string.IsNullOrEmpty(fase.Ciudad) ||
                string.IsNullOrEmpty(fase.Email) || string.IsNullOrEmpty(fase.Telefono))
            {
                MessageBox.Show("Complete todos los campos obligatorios", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fase.Password != fase.ConfirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fase.Password.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar formato de email
            if (!IsValidEmail(fase.Email))
            {
                MessageBox.Show("Ingrese un email válido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar teléfono (al menos 7 dígitos)
            if (fase.Telefono.Length < 7 || !fase.Telefono.All(c => char.IsDigit(c) || c == '+' || c == '-' || c == ' '))
            {
                MessageBox.Show("Ingrese un número de teléfono válido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public static bool ValidarCertificado(FaseCertificado fase,
            System.Collections.Generic.List<bool> obligatorios,
            System.Collections.Generic.List<string> categoriasArchivos)
        {
            if (string.IsNullOrEmpty(fase.NivelEstudios) ||
                string.IsNullOrEmpty(fase.AnosExperiencia))
            {
                MessageBox.Show("Complete los campos obligatorios para profesional certificado",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar años de experiencia (debe ser un número)
            if (!int.TryParse(fase.AnosExperiencia, out int anos) || anos < 0)
            {
                MessageBox.Show("Ingrese un número válido para años de experiencia",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verificar títulos obligatorios
            bool tieneTitulo = false;
            for (int i = 0; i < obligatorios.Count; i++)
            {
                if (obligatorios[i] && categoriasArchivos[i] == "titulo")
                {
                    tieneTitulo = true;
                    break;
                }
            }

            if (!tieneTitulo)
            {
                MessageBox.Show("Suba los títulos profesionales (obligatorio)", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public static bool ValidarEmpirico(FaseEmpirico fase)
        {
            if (string.IsNullOrEmpty(fase.AnosExperiencia) ||
                !fase.TieneTipoExperienciaSeleccionado())
            {
                MessageBox.Show("Complete los campos obligatorios para empírico",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public static bool ValidarFinal(FaseFinal fase)
        {
            if (string.IsNullOrEmpty(fase.Categorias))
            {
                MessageBox.Show("Ingrese al menos una categoría", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(fase.DescripcionServicios))
            {
                MessageBox.Show("Ingrese una descripción de sus servicios", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fase.DescripcionServicios.Length < 20)
            {
                MessageBox.Show("La descripción debe tener al menos 20 caracteres", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}