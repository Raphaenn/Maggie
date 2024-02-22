using Maggie.Domain.Entities;
using Maggie.Domain.Interfaces.Repository;

namespace Maggie.Domain.Services;

public class BudgetService : IBudgetRepository
{
	private readonly IBudgetRepository _budgetRepository;

	public BudgetService(IBudgetRepository budgetRepository)
	{
		_budgetRepository = budgetRepository;
	}

	public async Task<PersonalBudget> CreateBudget(PersonalBudget budget)
	{
		PersonalBudget response = await _budgetRepository.CreateBudget(budget);
		return response;
	}
}