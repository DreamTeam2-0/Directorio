using Homepage.Modelos;
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
                using (var db = new DatabaseConnection())
                {
                    db.Open();

                    string query = "SELECT ID_Categoria, nombre, color FROM categorias WHERE activa = 1 ORDER BY nombre";
                    using (var reader = db.ExecuteReader(query))
                    {
                        _categorias.Clear();

                        while (reader.Read())
                        {
                            var categoria = new Categoria
                            {
                                Id = reader.GetInt32("ID_Categoria"),
                                Nombre = reader.GetString("nombre"),
                                ColorFondo = ColorFromString(reader.IsDBNull("color") ? "" : reader.GetString("color"))
                            };
                            _categorias.Add(categoria);
                        }
                    }
                }

                // Si no se cargaron categorías, usar datos mock como respaldo
                if (_categorias.Count == 0)
                {
                    CargarDatosMock();
                }
            }
            catch (Exception ex)
            {
                // Si hay error con la BD, cargar datos mock
                System.Diagnostics.Debug.WriteLine($"Error cargando categorías desde BD: {ex.Message}");
                CargarDatosMock();
            }
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
                return Color.LightGray; // Color por defecto en caso de error
            }
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