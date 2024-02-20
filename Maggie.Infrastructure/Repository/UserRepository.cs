using Maggie.Domain.Entities;
using Maggie.Domain.Interfaces.Repository;
using Maggie.Infrastructure.Data.PostgresConnect;
using Npgsql;
using NpgsqlTypes;

namespace Maggie.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly PostgresContext _postgresContext;
    
    public UserRepository(PostgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public async Task<Users> Add(Users obj)
    {
        await using (var conn = await _postgresContext.DataSource.OpenConnectionAsync())
        {
            await using (var command = new NpgsqlCommand("INSERT INTO users (Name, Email, Birthdate, Status) VALUES (@Name, @Email, @Birthdate, @Status) RETURNING Id", conn))
            {
                command.Parameters.Add(new NpgsqlParameter("@Name", NpgsqlDbType.Text) { Value = obj.Name });
                command.Parameters.Add(new NpgsqlParameter("@Email", NpgsqlDbType.Text) { Value = obj.Email });
                command.Parameters.Add(new NpgsqlParameter("@Birthdate", NpgsqlDbType.Date) { Value = obj.BirthDate });
                command.Parameters.Add(new NpgsqlParameter("@Status", NpgsqlDbType.Boolean) { Value = obj.Status });
            
                
                var insertedId = await command.ExecuteScalarAsync();
                Console.WriteLine($"The id created: {insertedId}");
                return obj;
            };
        }
    }

    public Task<Users> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Users>> GetAll()
    {
        List<Users> users = new List<Users>();
        await using (var conn = await _postgresContext.DataSource.OpenConnectionAsync())
        {
            await using(var command = new NpgsqlCommand("SELECT * FROM users", conn))
            {
                await using(var reader = await command.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync())
                    {
                        // var cepIndex = reader.GetOrdinal("Cep"); // Get the index of the Cep column, -1 if not found
                        string name = reader["Name"].ToString();
                        string email = reader["Email"].ToString();
                        DateTime birthdate = DateTime.Parse(reader["BirthDate"].ToString());
                        // Assuming UserRole.Default is a valid enum value for your UserRole
                        var role = UserRole.Default;

                        // Handle nullable Cep
                        // string cep = reader["Cep"] is DBNull ? null : reader["Cep"].ToString();

                        Users user = new Users(name, email, birthdate, false, role, cep: null);
    
                        users.Add(user);
                    }
                
                    return users;
                };
            };
        }
    }

    public Task Update(Users obj)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Users obj)
    {
        throw new NotImplementedException();
    }
}