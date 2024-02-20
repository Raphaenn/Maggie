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

	// // public async Task<PersonalBudget> GenerateBudget(PersonalBudget obj, LocalCoefficient local)
	// // 	{
	// //
	// // 		PersonalBudget result = new PersonalBudget(
	// // 			salary: obj.Salary * local.factory,
	// // 			light: obj.Light * local.factory,
	// // 			water: obj.Water * local.factory,
	// // 			internet: obj.Internet * local.factory,
	// // 			basicFood: obj.BasicFood * local.factory,
	// // 			health: obj.Health * local.factory,
	// // 			leisure: obj.Leisure * local.factory,
	// // 			transport: obj.Transport * local.factory,
	// // 			homeRent: obj.HomeRent * local.factory,
	// // 			clothes: obj.Clothes * local.factory,
	// // 			homeTax: obj.HomeTax * local.factory);
	// // 		
	// // 		var budget = await _budgetRepository.GenerateBudget(result, local);
	// // 		return budget;
	// 	}
}