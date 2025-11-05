using Homepage.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Homepage.Logica
{
    public class CategoriaServicio 
    {
        private List<Categoria> _categorias = new List<Categoria>();

        public CategoriaServicio()
        {
            CargarDatosMock();
        }

        private void CargarDatosMock()
        {
            _categorias = new List<Categoria>
            {
                new Categoria { Id = 1, Nombre = "Vehículos",   ColorFondo = Color.FromArgb(244, 67, 54) },
                new Categoria { Id = 2, Nombre = "Comida",      ColorFondo = Color.LimeGreen },
                new Categoria { Id = 3, Nombre = "Ferretería",  ColorFondo = Color.SkyBlue },
                new Categoria { Id = 4, Nombre = "Limpieza",    ColorFondo = Color.Orange },
                new Categoria { Id = 5, Nombre = "Ropa",        ColorFondo = Color.MediumPurple },
                new Categoria { Id = 6, Nombre = "Juguetes",    ColorFondo = Color.Coral }
            };
        }

        public List<Categoria> ObtenerTodas() => _categorias;

        public List<Categoria> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto) || texto.Equals("Buscar Categorías", StringComparison.OrdinalIgnoreCase))
                return _categorias;

            return _categorias
                .Where(c => !string.IsNullOrEmpty(c.Nombre) &&
                            c.Nombre.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
    }
}
