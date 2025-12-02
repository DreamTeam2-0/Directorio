using Homepage.Modelos;
using DataBase;
using MySql.Data.MySqlClient;
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
            CargarDatosDesdeBD();
        }

        private void CargarDatosDesdeBD()
        {
            try
            {
                using (var db = new BDConector())
                {
                    db.Open();

                    string query = "SELECT ID_Categoria, nombre, color FROM categorias WHERE activa = 1 ORDER BY ID_Categoria";
                    using (var reader = db.ExecuteReader(query))
                    {
                        _categorias.Clear();

                        while (reader.Read())
                        {
                            int id = reader.GetInt32("ID_Categoria");
                            string nombre = reader.GetString("nombre");
                            string colorHex = reader["color"] == DBNull.Value ? "#CCCCCC" : reader["color"].ToString();

                            var categoria = new Categoria
                            {
                                Id = id,
                                Nombre = nombre,
                                ColorFondo = ColorFromString(colorHex)
                            };
                            _categorias.Add(categoria);
                        }
                    }
                }

                if (_categorias.Count == 0)
                {
                    CargarDatosMock();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando categorías desde BD: {ex.Message}");
                CargarDatosMock();
            }
        }

        private void CargarDatosMock()
        {
            _categorias = new List<Categoria>
            {
                new Categoria { Id = 1, Nombre = "Vehículos",   ColorFondo = Color.Red },
                new Categoria { Id = 2, Nombre = "Comida",      ColorFondo = Color.Green },
                new Categoria { Id = 3, Nombre = "Ferretería",  ColorFondo = Color.Blue },
                new Categoria { Id = 4, Nombre = "Limpieza",    ColorFondo = Color.Orange },
                new Categoria { Id = 5, Nombre = "Ropa",        ColorFondo = Color.Purple },
                new Categoria { Id = 6, Nombre = "Juguetes",    ColorFondo = Color.Coral },
                new Categoria { Id = 7, Nombre = "Tecnología",  ColorFondo = Color.Teal },
                new Categoria { Id = 8, Nombre = "Salud",       ColorFondo = Color.Pink },
                new Categoria { Id = 9, Nombre = "Educación",   ColorFondo = Color.Brown },
                new Categoria { Id = 10, Nombre = "Deportes",   ColorFondo = Color.Navy },
                new Categoria { Id = 11, Nombre = "Hogar",      ColorFondo = Color.Gold },
                new Categoria { Id = 12, Nombre = "Belleza",    ColorFondo = Color.Violet },
                new Categoria { Id = 13, Nombre = "Mascotas",   ColorFondo = Color.Salmon },
                new Categoria { Id = 14, Nombre = "Viajes",     ColorFondo = Color.SkyBlue }
            };
        }

        private Color ColorFromString(string colorString)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(colorString))
                    return Color.LightGray;

                return ColorTranslator.FromHtml(colorString);
            }
            catch
            {
                return Color.LightGray;
            }
        }

        public List<Categoria> ObtenerTodas() => _categorias.OrderBy(c => c.Id).ToList();

        public List<Categoria> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto) || texto.Equals("Buscar Categorías", StringComparison.OrdinalIgnoreCase))
                return _categorias.OrderBy(c => c.Id).ToList();

            return _categorias
                .Where(c => !string.IsNullOrEmpty(c.Nombre) &&
                            c.Nombre.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(c => c.Id)
                .ToList();
        }

        // Método para obtener categorías en orden circular (para el carrusel)
        public List<Categoria> ObtenerCarrusel(int indiceInicio, int cantidad)
        {
            if (_categorias.Count == 0)
                return new List<Categoria>();

            var resultado = new List<Categoria>();
            int totalCategorias = _categorias.Count;

            // Obtener categorías en orden circular
            for (int i = 0; i < cantidad; i++)
            {
                int indiceCircular = (indiceInicio + i) % totalCategorias;
                resultado.Add(_categorias[indiceCircular]);
            }

            return resultado;
        }

        public int TotalCategorias() => _categorias.Count;
    }
}