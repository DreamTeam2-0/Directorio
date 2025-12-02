using DBHelp.DatabaseHelper;
using PassHelp.PasswordHelper;
using System.Collections.Generic;
using System.Linq;

namespace LoginDirectorio.RegistroFases
{
    public static class DatabaseHelperExtensions
    {
        public static (bool success, string mensaje) RegistrarProveedorCertificado(
            FaseDatosBasicos datos, FaseCertificado certificado, FaseFinal final,
            List<byte[]> archivosBytes, List<string> nombresArchivos,
            List<string> tiposArchivos, List<string> categoriasArchivos, List<bool> obligatorios)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            string passwordEncriptado = PasswordHelper.EncriptarPassword(datos.Password);

            // Preparar campos específicos
            string tipoExperiencia = "";
            string descripcionOtro = "";

            // Preparar archivos si no se subieron títulos
            bool tieneTitulos = false;
            for (int i = 0; i < categoriasArchivos.Count; i++)
            {
                if (categoriasArchivos[i] == "titulo")
                {
                    tieneTitulos = true;
                    break;
                }
            }

            // Si no tiene títulos, agregar marcador para obligar subida
            if (!tieneTitulos)
            {
                archivosBytes.Add(new byte[0]); // Marcador vacío
                nombresArchivos.Add("TITULO_REQUERIDO.txt");
                tiposArchivos.Add("text/plain");
                categoriasArchivos.Add("titulo");
                obligatorios.Add(true);
            }

            return dbHelper.RegistrarProveedor(
                datos.Username, passwordEncriptado, datos.Nombres, datos.Apellidos,
                datos.Ciudad, datos.Email, datos.Telefono, "certificado",
                certificado.NivelEstudios, certificado.AnosExperiencia,
                certificado.EmpresasAnteriores, certificado.ProyectosDestacados,
                certificado.ReferenciasLaborales, "", "", "", // Campos para empírico vacíos
                final.Categorias, final.SubEspecialidades, final.Herramientas,
                final.DescripcionServicios, archivosBytes, nombresArchivos,
                tiposArchivos, categoriasArchivos, obligatorios,
                datos.IdentificacionOficial, datos.DireccionAproximada, datos.ZonasServicio
            );
        }

        public static (bool success, string mensaje) RegistrarProveedorEmpirico(
            FaseDatosBasicos datos, FaseEmpirico empirico, FaseFinal final,
            List<byte[]> archivosBytes, List<string> nombresArchivos,
            List<string> tiposArchivos, List<string> categoriasArchivos)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            string passwordEncriptado = PasswordHelper.EncriptarPassword(datos.Password);

            // Campos para certificado (vacíos)
            string nivelEstudios = "";
            string anosExperienciaCert = "";
            string empresasAnteriores = "";
            string proyectosDestacados = "";
            string referenciasLaborales = "";

            // Campos para empírico - USAR la nueva propiedad
            string tipoExperiencia = empirico.GetTipoExperienciaString();
            string descripcionOtro = empirico.DescripcionOtro;

            // NUEVO: Usar AnosExperienciaBD en lugar de AnosExperiencia
            string anosExperienciaEmp = empirico.AnosExperienciaBD;

            // Para empírico, todos los archivos son opcionales
            List<bool> obligatorios = new List<bool>();
            for (int i = 0; i < archivosBytes.Count; i++)
            {
                obligatorios.Add(false);
            }

            return dbHelper.RegistrarProveedor(
                datos.Username, passwordEncriptado, datos.Nombres, datos.Apellidos,
                datos.Ciudad, datos.Email, datos.Telefono, "empirico",
                nivelEstudios, anosExperienciaCert, empresasAnteriores,
                proyectosDestacados, referenciasLaborales, // Campos para certificado vacíos

                // NUEVO: Usar anosExperienciaEmp (convertido) en lugar de empirico.AnosExperiencia
                anosExperienciaEmp, // ← ESTE ES EL CAMBIO CLAVE
                tipoExperiencia,
                descripcionOtro,

                final.Categorias, final.SubEspecialidades, final.Herramientas,
                final.DescripcionServicios, archivosBytes, nombresArchivos,
                tiposArchivos, categoriasArchivos, obligatorios,
                datos.IdentificacionOficial, datos.DireccionAproximada, datos.ZonasServicio
            );
        }

        public static List<string> ObtenerCategoriasDisponibles()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            var categoriasData = dbHelper.ObtenerCategorias();

            return categoriasData.Select(c => c.nombre).ToList();
        }

        public static List<string> ObtenerDenominacionesPorCategoria(string categoriaNombre)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            var categoriasData = dbHelper.ObtenerCategorias();

            // Buscar ID de la categoría
            var categoria = categoriasData.FirstOrDefault(c => c.nombre == categoriaNombre);
            if (categoria.id == 0)
                return new List<string>();

            var denominacionesData = dbHelper.ObtenerDenominaciones(categoria.id);
            return denominacionesData.Select(d => d.nombre).ToList();
        }
    }
}