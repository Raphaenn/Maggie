using Maggie.Domain.Entities;

namespace Maggie.Domain.Interfaces.Repository;

public interface IBudgetRepository
{
	Task<PersonalBudget> CreateBudget(PersonalBudget budget);

	// Task<PersonalBudget> GetBudgetById(string id);
	// Task<PersonalBudget> GenerateBudget(PersonalBudget obj, LocalCoefficient local);
}