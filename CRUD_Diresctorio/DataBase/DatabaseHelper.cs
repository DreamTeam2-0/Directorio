// DatabaseHelper.cs
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataBase
{
    public static class DatabaseHelper
    {
        public static DataTable GetTableData(BDConector db, string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            return db.ExecuteDataTable(query);
        }

        public static string GetPrimaryKeyColumn(string tableName)
        {
            switch (tableName.ToLower())
            {
                case "roles": return "ID_Rol";
                case "usuarios_sistema": return "ID_Usuario_Sistema";
                case "usuarios": return "ID_Usuario";
                case "categorias": return "ID_Categoria";
                case "denominaciones": return "ID_Denominacion";
                case "datos_usuario": return "ID_Datos_Usuario";
                case "servicios": return "ID_Servicio";
                case "sistema_calificacion": return "ID_Calificacion";
                case "acciones_sistema": return "ID_Accion";
                case "experiencia_usuario": return "ID_Experiencia";
                case "archivos_proveedor": return "ID_Archivo";
                case "archivos_generales": return "ID_Archivo";
                case "temp_registros": return "ID_Temp";
                case "temp_certificaciones": return "ID_Temp_Cert";
                case "temp_experiencia_empirica": return "ID_Temp_Exp";
                case "temp_especialidades": return "ID_Temp_Esp";
                case "temp_archivos": return "ID_Temp_Archivo";
                default: return "ID";
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (BDConector db = new BDConector())
                {
                    db.Open();
                    db.ExecuteScalar("SELECT 1");
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}