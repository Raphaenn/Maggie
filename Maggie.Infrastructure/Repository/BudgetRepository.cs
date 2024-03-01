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
            string SqlQuery = "INSERT INTO Budget (id, salary, light, water, internet, basic_food, health, leisure, clothes, transport, home_rent, home_tax, home_financing, car_tax, car_financing, medicines, education, home_spends, budget_date) VALUES (@id, @salary, @light, @water, @internet, @basic_food, @health, @leisure, @clothes, @transport, @home_rent, @home_tax, @home_financing, @car_tax, @car_financing, @medicines, @education, @home_spends, @budget_date)";

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
                command.Parameters.Add(new NpgsqlParameter("@home_spends", NpgsqlDbType.Numeric) { Value = (object)budget.HomeSpends ?? DBNull.Value });
                command.Parameters.Add(new NpgsqlParameter("@budget_date", NpgsqlDbType.Date) { Value = (object)budget.BudgetDate ?? DateTime.Now });
                
                var insertedId = await command.ExecuteScalarAsync();
                Console.WriteLine($"The id created: {insertedId}");
                return budget;
            }
        }
    }

    public async Task<PersonalBudget> GetBudgetByUserId(Guid id)
    {
        await using (var connect = await _postgresContext.DataSource.OpenConnectionAsync())
        {
            await using (var command = new NpgsqlCommand())
            {
                command.Connection = connect;
                command.CommandText = "SELECT * FROM budget_user bu JOIN users u ON bu.user_id = u.id JOIN budget b ON b.id = bu.budget_id WHERE bu.user_id = @Id";
                command.Parameters.AddWithValue("Id", id);

                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    Guid budgetId = (Guid)reader["id"];
                    decimal salary = (decimal)reader["salary"];
                    decimal light = (decimal)reader["light"];
                    decimal water = (decimal)reader["water"];
                    decimal basicFood = (decimal)reader["basic_food"];
                    decimal internet = (decimal)reader["internet"];
                    decimal leisure = (decimal)reader["leisure"];
                    decimal health = (decimal)reader["health"];
                    decimal homeRent = (decimal)reader["home_rent"];
                    decimal transport = (decimal)reader["transport"];
                    decimal clothes = (decimal)reader["clothes"];
                    DateTime budgetDate = (DateTime)reader["budget_date"];
                    PersonalBudget mapperBudget = new PersonalBudget(id: budgetId, salary: salary, light: light, water: water, internet: internet, basicFood: basicFood, leisure: leisure, health: health, clothes: clothes, budgetDate: budgetDate, homeRent: homeRent, transport: transport);
                    return mapperBudget;
                }
            }
        }
        return null;
    }

    public async Task<List<PersonalBudget>> GetYearBudget(Guid id, int year)
    {
        List<PersonalBudget> budgetResult = new List<PersonalBudget>();
        
        await using (var conn = await _postgresContext.DataSource.OpenConnectionAsync())
        {
            await using (var command = new NpgsqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT * FROM budget_user bu JOIN users u ON bu.user_id = u.id JOIN budget b ON b.id = bu.budget_id WHERE bu.user_id = @Id AND EXTRACT(YEAR FROM b.budget_date) = @Year";
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("Year", year);

                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Guid budgetId = (Guid)reader["id"];
                    decimal salary = (decimal)reader["salary"];
                    decimal light = (decimal)reader["light"];
                    decimal water = (decimal)reader["water"];
                    decimal basicFood = (decimal)reader["basic_food"];
                    decimal internet = (decimal)reader["internet"];
                    decimal leisure = (decimal)reader["leisure"];
                    decimal health = (decimal)reader["health"];
                    decimal homeRent = (decimal)reader["home_rent"];
                    decimal transport = (decimal)reader["transport"];
                    decimal clothes = (decimal)reader["clothes"];
                    DateTime budgetDate = (DateTime)reader["budget_date"];
                    PersonalBudget mapperBudget = new PersonalBudget(id: budgetId, salary: salary, light: light, water: water, internet: internet, basicFood: basicFood, leisure: leisure, health: health, clothes: clothes, budgetDate: budgetDate, homeRent: homeRent, transport: transport);
                    budgetResult.Add(mapperBudget);
                }
            }
        }
        return budgetResult;
    }
}