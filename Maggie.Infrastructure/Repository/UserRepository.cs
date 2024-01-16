﻿using Maggie.Domain.Entities;
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
        Console.WriteLine("testando");
        Console.WriteLine(obj.Status);
        _postgresContext.OpenConnection();
        using var command = _postgresContext.CreateCommand();
        command.CommandText = "INSERT INTO users (Name, Email, Birthdate, Status) VALUES (@Name, @Email, @Birthdate, @Status) RETURNING Id";
        command.Parameters.Add(new NpgsqlParameter("@Name", NpgsqlDbType.Text) { Value = obj.Name });
        command.Parameters.Add(new NpgsqlParameter("@Email", NpgsqlDbType.Text) { Value = obj.Email });
        command.Parameters.Add(new NpgsqlParameter("@Birthdate", NpgsqlDbType.Date) { Value = obj.BirthDate });
        command.Parameters.Add(new NpgsqlParameter("@Status", NpgsqlDbType.Boolean) { Value = obj.Status });

        var insertedId = (int)command.ExecuteScalar();
        Console.WriteLine(insertedId);
        return obj;
        // string connectionString = $"Host=localhost;Port=5432;Username=postgres;Password=1234;Database=maggie;";
        // _postgresContext.OpenConnection();
        //
        // using (var context = new PostgresContext(new NpgsqlConnection(connectionString)))
        // {
        //     var command = context.CreateCommand();
        //     string insertSql = "INSERT INTO users (Name, Cpf, Email, BirthDate, Status) VALUES (@Name, @Cpf, @Email, @BirthDate, @Status) RETURNING Id";
        //
        //     context.OpenConnection();
        //     command.CommandText = insertSql;
        //
        //     // Assuming obj is an instance of the User class
        //     command.Parameters.Add(new NpgsqlParameter("@Name", NpgsqlDbType.Text) { Value = obj.Name });
        //     command.Parameters.Add(new NpgsqlParameter("@Cpf", NpgsqlDbType.Text) { Value = obj.Cpf });
        //     command.Parameters.Add(new NpgsqlParameter("@Email", NpgsqlDbType.Text) { Value = obj.Email });
        //     command.Parameters.Add(new NpgsqlParameter("@Birthdate", NpgsqlDbType.Date) { Value = obj.BirthDate });
        //     command.Parameters.Add(new NpgsqlParameter("@Status", NpgsqlDbType.Boolean) { Value = obj.Status });
        //
        //     // Execute the command and retrieve the generated Id
        //     var insertedId = (int)command.ExecuteScalar();
        //     Console.WriteLine(insertedId);
        //     return obj;
        // }
    }

    public Task<Users> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Users>> GetAll()
    {
        throw new NotImplementedException();
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