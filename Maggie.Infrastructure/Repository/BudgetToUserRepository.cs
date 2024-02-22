using Maggie.Domain.Entities;
using Maggie.Domain.Interfaces.Repository;
using Maggie.Infrastructure.Data.PostgresConnect;
using Npgsql;

namespace Maggie.Infrastructure.Repository;

public class BudgetToUserRepository : IBudgetToUserRepository
{
    private readonly PostgresContext _postgresContext;

    public BudgetToUserRepository(PostgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }
    
    public async Task<BudgetUser> LinkBudgetToUser(Guid userId, Guid budgetId)
    {
        Console.WriteLine(userId);
        Console.WriteLine(budgetId);
        await using (var connect = await _postgresContext.DataSource.OpenConnectionAsync())
        {
            await using (var command = new NpgsqlCommand())
            {
                command.Connection = connect;
                command.CommandText = "INSERT INTO budget_user (id, user_id, budget_id) VALUES (@id, @user_id, @budget_id)";
                // string relationshipSql = "INSERT INTO BudgetUser (UserId, BudgetId) VALUES (@userId, @budgetId)";

                Guid relationsShipId = Guid.NewGuid();
                command.Parameters.AddWithValue("@id", relationsShipId);
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@budget_id", budgetId);

                await command.ExecuteNonQueryAsync();
            }
        }
        Guid one = Guid.NewGuid();
        Guid two = Guid.NewGuid();
        Guid three = Guid.NewGuid();
        BudgetUser test = new BudgetUser(one, two, three);
        return test;
    }
}