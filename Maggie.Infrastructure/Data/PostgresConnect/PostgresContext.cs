using System.Data;
using Npgsql;

namespace Maggie.Infrastructure.Data.PostgresConnect;

public class PostgresContext : IDisposable
{
        private readonly NpgsqlConnection _connection;
        
        public PostgresContext(string connection)
        {
                _connection = new NpgsqlConnection(connection);;
        }

        public void OpenConnection()
        {
                if(_connection.State == ConnectionState.Closed) 
                        _connection.Open();
        }

        public void CloseConnection()
        {
                if(_connection.State == ConnectionState.Open)
                        _connection.Close();
        }

        public IDbCommand CreateCommand()
        {
                return _connection.CreateCommand();
        }

        public void Dispose()
        {
                CloseConnection();
                _connection.Dispose();
        }
}