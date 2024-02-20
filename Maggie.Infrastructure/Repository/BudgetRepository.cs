using Maggie.Domain.Entities;
using Maggie.Domain.Interfaces.Repository;
using Maggie.Infrastructure.Data.PostgresConnect;
using Npgsql;
using NpgsqlTypes;

namespace Maggie.Infrastructure.Repository;

public class BudgetRepository : IBudgetRepository
{
    private readonly PostgresContext _postgresContext;

    public BudgetRepository(PostgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public async Task<PersonalBudget> CreateBudget(PersonalBudget budget)
    {
        await using (var connect = await _postgresContext.DataSource.OpenConnectionAsync())
        {
            
            string SqlQuery = "INSERT INTO Budget (id, salary, light, water, internet, basic_food, health, leisure, clothes, transport, home_rent, home_tax, home_financing, car_tax, car_financing, gas, medicines, education, home_spends) VALUES (@id, @salary, @light, @water, @internet, @basic_food, @health, @leisure, @clothes, @transport, @home_rent, @home_tax, @home_financing, @car_tax, @car_financing, @gas, @medicines, @education, @home_spends)";

            await using (var command = new NpgsqlCommand(SqlQuery, connect))
            {
                command.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Uuid) { Value = budget.Id });
                command.Parameters.Add(new NpgsqlParameter("@salary", NpgsqlDbType.Numeric) { Value = budget.Salary });
                command.Parameters.Add(new NpgsqlParameter("@light", NpgsqlDbType.Numeric) { Value = budget.Light });
                command.Parameters.Add(new NpgsqlParameter("@water", NpgsqlDbType.Numeric) { Value = budget.Water });
                command.Parameters.Add(new NpgsqlParameter("@clothes", NpgsqlDbType.Numeric) { Value = budget.Clothes });
                command.Parameters.Add(new NpgsqlParameter("@internet", NpgsqlDbType.Numeric) { Value = budget.Internet });
                command.Parameters.Add(new NpgsqlParameter("@health", NpgsqlDbType.Numeric) { Value = budget.Health });
                command.Parameters.Add(new NpgsqlParameter("@leisure", NpgsqlDbType.Numeric) { Value = budget.Leisure });
                command.Parameters.Add(new NpgsqlParameter("@basic_food", NpgsqlDbType.Numeric) { Value = budget.BasicFood });
                
                command.Parameters.Add(new NpgsqlParameter("@transport", NpgsqlDbType.Numeric) { Value = (object)budget.Transport ?? DBNull.Value});
                command.Parameters.Add(new NpgsqlParameter("@education", NpgsqlDbType.Numeric) { Value = (object)budget.Education ?? DBNull.Value });
                command.Parameters.Add(new NpgsqlParameter("@medicines", NpgsqlDbType.Numeric) { Value = (object)budget.Medicines ?? DBNull.Value });
                command.Parameters.Add(new NpgsqlParameter("@home_rent", NpgsqlDbType.Numeric) { Value = (object)budget.HomeRent ?? DBNull.Value });
                command.Parameters.Add(new NpgsqlParameter("@home_tax", NpgsqlDbType.Numeric) { Value = (object)budget.HomeTax ?? DBNull.Value });
                command.Parameters.Add(new NpgsqlParameter("@home_financing", NpgsqlDbType.Numeric) { Value = (object)budget.HomeFinancing ?? DBNull.Value });
                command.Parameters.Add(new NpgsqlParameter("@car_tax", NpgsqlDbType.Numeric) { Value = (object)budget.CarTax ?? DBNull.Value });
                command.Parameters.Add(new NpgsqlParameter("@car_financing", NpgsqlDbType.Numeric) { Value = (object)budget.CarFinancing ?? DBNull.Value });
                command.Parameters.Add(new NpgsqlParameter("@gas", NpgsqlDbType.Numeric) { Value = (object)budget.Gas ?? DBNull.Value });
                command.Parameters.Add(new NpgsqlParameter("@home_spends", NpgsqlDbType.Numeric) { Value = (object)budget.HomeSpends ?? DBNull.Value });
                
                var insertedId = await command.ExecuteScalarAsync();
                Console.WriteLine($"The id created: {insertedId}");
                return budget;
            }
        }
    }

    // public async Task<PersonalBudget> GetBudget(PersonalBudget obj)
    // {
    //     await using (var conn = await _postgresContext.DataSource.OpenConnectionAsync())
    //     {
    //         await using (var command = new NpgsqlCommand("SELECT * FROM budgetitens", conn))
    //         {
    //             await using (var reader = await command.ExecuteReaderAsync())
    //             {
    //                 while (await reader.ReadAsync())
    //                 {
    //                     string light = reader["ligth"].ToString();
    //                     Console.WriteLine("Testando");
    //                     Console.WriteLine(reader);
    //                 }
    //             }
    //             
    //             PersonalBudget response = new PersonalBudget(
    //                 id: obj.Id,
    //                 salary: obj.Salary,
    //                 light: obj.Light,
    //                 water: obj.Water,
    //                 internet: obj.Internet,
    //                 basicFood: obj.BasicFood,
    //                 leisure: obj.Leisure,
    //                 health: obj.Health,
    //                 clothes: obj.Clothes
    //             );
    //             return response;
    //         }
    //     }
    // }
}