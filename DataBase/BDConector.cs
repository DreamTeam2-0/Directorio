using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DataBase
{
    public class BDConector : IDisposable
    {
        public MySqlConnection _connection { get; private set; }
        private const string ConnectionString = "Server=localhost;Database=directorio_servicios;Uid=root;Pwd=J1234b;Port=3306;";

        public BDConector()
        {
            _connection = new MySqlConnection(ConnectionString);
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
                command.Parameters.AddRange(parameters);
                return command.ExecuteReader();
            }
        }

        public int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (var command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddRange(parameters);
                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddRange(parameters);
                return command.ExecuteScalar();
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}