using System.Data;
using Npgsql;

namespace Maggie.Infrastructure.Data.PostgresConnect;

public class PostgresContext : IAsyncDisposable
{
	private readonly NpgsqlDataSource _connection;
        
	public PostgresContext(string connection)
	{
		_connection = NpgsqlDataSource.Create(connection);
	}
	
	public NpgsqlDataSource DataSource => _connection;

	
	public async ValueTask DisposeAsync()
	{
		if (_connection != null)
		{
			await _connection.DisposeAsync();
		}
	}
}