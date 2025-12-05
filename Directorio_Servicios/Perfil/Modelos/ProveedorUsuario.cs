using System;
using System.Collections.Generic;

namespace Perfil.Modelos
{
    public class ProveedorUsuario
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Whatsapp { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string ZonasServicio { get; set; }
        public string OtroContacto { get; set; }
        public string IdentificacionOficial { get; set; }
        public ExperienciaProveedorModel Experiencia { get; set; }
        public List<EspecialidadProveedorModel> Especialidades { get; set; }
    }

    public class ExperienciaProveedorModel
    {
        public string TipoRegistro { get; set; } // "certificado" o "empirico"
        public string NivelEstudios { get; set; } // Solo para certificado
        public string AnosExperiencia { get; set; }
        public string EmpresasAnteriores { get; set; }
        public string ProyectosDestacados { get; set; }
        public string ReferenciasLaborales { get; set; }
        public string TipoExperiencia { get; set; } // Solo para empírico
        public string DescripcionOtro { get; set; } // Solo para empírico
    }

    public class EspecialidadProveedorModel
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string Herramientas { get; set; }
        public string DescripcionServicios { get; set; }
        public List<string> SubEspecialidades { get; set; }
    }

    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}