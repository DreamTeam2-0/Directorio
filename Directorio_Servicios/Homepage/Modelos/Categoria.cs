using System.Drawing;

namespace Homepage.Modelos
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Color ColorFondo { get; set; }
        public int Visitas { get; set; }
        public string Descripcion { get; set; }
    }

    public class Denominacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Visitas { get; set; }
    }

    public class ServicioResumen
    {
        public int ID_Servicio { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string TipoPrecio { get; set; }
        public string Moneda { get; set; }
        public string ProveedorUsername { get; set; }
        public float RatingPromedio { get; set; }
        public int TotalCalificaciones { get; set; }
        public int Visitas { get; set; }
        public string CategoriaNombre { get; set; }
        public decimal PrecioMin { get; set; }
        public decimal PrecioMax { get; set; }
    }
}