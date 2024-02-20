using System.Data;
using Npgsql;

namespace Maggie.Infrastructure.Data.PostgresConnect;

public class PostgresContext : IDisposable
{
        private readonly NpgsqlDataSource _connection;
        
        public PostgresContext(string connection)
        { 
                _connection = NpgsqlDataSource.Create(connection);
        }

        public async void OpenConnectionAsync()
        {
                await using var connection = await _connection.OpenConnectionAsync();
        }
        
        public IDbCommand CreateCommand()
        {
                return _connection.CreateCommand();
        }

        public void Dispose()
        {
                // CloseConnection();
                _connection.Dispose();
        }
}