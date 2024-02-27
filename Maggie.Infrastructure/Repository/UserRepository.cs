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
    
    public async Task<bool> CheckEmailUsage(string email)
    {
        await using (var connection = await _postgresContext.DataSource.OpenConnectionAsync())
        {
            await using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM users WHERE Email = @Email";
                command.Parameters.AddWithValue("Email", email);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    string? name = reader["Name"].ToString();
                    string? mail = reader["Email"].ToString();
                    new Users(id: reader.GetGuid(reader.GetOrdinal("Id")), name, mail, false);
                    return true;
                }
                return false;
            }
        } 
    }

    public async Task<Users> Add(Users obj)
    {
        await using (var conn = await _postgresContext.DataSource.OpenConnectionAsync())
        {
            await using (var command = new NpgsqlCommand("INSERT INTO users (Id, Name, Email, Status) VALUES (@Id, @Name, @Email, @Status) RETURNING Id", conn))
            {
                command.Parameters.Add(new NpgsqlParameter("@Id", NpgsqlDbType.Uuid) { Value = obj.Id });
                command.Parameters.Add(new NpgsqlParameter("@Name", NpgsqlDbType.Text) { Value = obj.Name });
                command.Parameters.Add(new NpgsqlParameter("@Email", NpgsqlDbType.Text) { Value = obj.Email });
                command.Parameters.Add(new NpgsqlParameter("@Status", NpgsqlDbType.Boolean) { Value = obj.Status });

                // Check if the email is already used
                // var existingUser = await GetByEmailAsync(obj.Email);
                // if (existingUser != null)
                // {
                //     throw new InvalidOperationException("Email is already used.");
                // }
            
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
                        Guid id = (Guid)reader["Id"];
                        string name = reader["Name"].ToString();
                        string email = reader["Email"].ToString();
                        DateTime birthdate = DateTime.Parse(reader["BirthDate"].ToString());
                        // Assuming UserRole.Default is a valid enum value for your UserRole
                        var role = UserRole.Default;

                        // Handle nullable Cep
                        // string cep = reader["Cep"] is DBNull ? null : reader["Cep"].ToString();

                        Users user = new Users(id, name, email, false);
    
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