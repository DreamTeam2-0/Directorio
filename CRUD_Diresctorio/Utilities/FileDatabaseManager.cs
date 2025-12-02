// FileDatabaseManager.cs
using System;
using System.Data;
using DataBase;
using MySql.Data.MySqlClient;

namespace Utilities
{
    public class FileDatabaseManager
    {
        public DataTable GetAllFiles()
        {
            using (BDConector db = new BDConector())
            {
                db.Open();

                string query = @"
                    SELECT 
                        ap.ID_Archivo,
                        ap.nombre_archivo,
                        ap.tipo_archivo,
                        ap.categoria_archivo,
                        CONCAT(du.nombres, ' ', du.apellidos) as usuario_nombre,
                        du.ID_Usuario,
                        DATE_FORMAT(ap.fecha_creacion, '%d/%m/%Y %H:%i') as fecha_creacion,
                        FORMAT(ROUND(LENGTH(ap.contenido)/1024, 2), 2) as tamanio_kb,
                        'proveedor' as origen
                    FROM archivos_proveedor ap
                    LEFT JOIN datos_usuario du ON ap.ID_Usuario = du.ID_Usuario
                    UNION ALL
                    SELECT 
                        ag.ID_Archivo,
                        ag.nombre_archivo,
                        ag.tipo_archivo,
                        ag.categoria_archivo,
                        'Sistema' as usuario_nombre,
                        NULL as ID_Usuario,
                        DATE_FORMAT(ag.fecha_creacion, '%d/%m/%Y %H:%i') as fecha_creacion,
                        FORMAT(ROUND(LENGTH(ag.contenido)/1024, 2), 2) as tamanio_kb,
                        'sistema' as origen
                    FROM archivos_generales ag
                    ORDER BY fecha_creacion DESC";

                return db.ExecuteDataTable(query);
            }
        }

        public bool DeleteFile(int fileId, string sourceTable)
        {
            using (BDConector db = new BDConector())
            {
                db.Open();

                string query = sourceTable == "archivos_proveedor"
                    ? "DELETE FROM archivos_proveedor WHERE ID_Archivo = @id"
                    : "DELETE FROM archivos_generales WHERE ID_Archivo = @id";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@id", fileId)
                };

                int rowsAffected = db.ExecuteNonQuery(query, parameters);

                return rowsAffected > 0;
            }
        }

        public int GetTotalFileCount()
        {
            using (BDConector db = new BDConector())
            {
                db.Open();

                string query = @"
                    SELECT 
                        (SELECT COUNT(*) FROM archivos_proveedor) + 
                        (SELECT COUNT(*) FROM archivos_generales) as total";

                object result = db.ExecuteScalar(query);

                return Convert.ToInt32(result);
            }
        }
    }
}