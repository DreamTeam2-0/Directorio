// BDConector.cs
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class BDConector : IDisposable
    {
        private MySqlConnection _connection;
        private const string ConnectionString = "Server=localhost;Database=directorio_servicios;Uid=root;Pwd=Shadow27#;Port=3306;";

        public BDConector()
        {
            _connection = new MySqlConnection(ConnectionString);
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
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
            var command = new MySqlCommand(query, _connection);
            command.Parameters.AddRange(parameters);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
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

        public DataTable ExecuteDataTable(string query, params MySqlParameter[] parameters)
        {
            using (var command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddRange(parameters);
                DataTable dt = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
                return dt;
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}