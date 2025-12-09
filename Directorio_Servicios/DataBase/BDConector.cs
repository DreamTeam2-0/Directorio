using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DataBase
{
    public class BDConector : IDisposable
    {
        public MySqlConnection _connection { get; private set; }
        private const string ConnectionString = "Server=localhost;Database=directorio_servicios;Uid=root;Pwd=Shadow27#;Port=3306;";

        public BDConector()
        {
            _connection = new MySqlConnection(ConnectionString);
            Open(); // Abrir automáticamente al crear
        }

        public void Open()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void Close()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public MySqlDataReader ExecuteReader(string query, params MySqlParameter[] parameters)
        {
            using (var command = new MySqlCommand(query, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);
                return command.ExecuteReader();
            }
        }

        public int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (var command = new MySqlCommand(query, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);
                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var command = new MySqlCommand(query, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);
                return command.ExecuteScalar();
            }
        }

        // Método estático para obtener una conexión (para compatibilidad con código existente)
        public static MySqlConnection ObtenerConexion()
        {
            var conexion = new MySqlConnection(ConnectionString);
            conexion.Open();
            return conexion;
        }

        public void Dispose()
        {
            Close();
            _connection?.Dispose();
        }
    }
}