using Maggie.App.Interfaces;
using Maggie.Domain.Entities;
using Maggie.Domain.Interfaces.Repository;
using Maggie.Dto;

namespace App.Services;

public class BudgetAppService : IBudgetAppService
{

    private readonly IBudgetRepository _budgetRepository;
    private readonly IBudgetToUserRepository _budgetToUserRepository;

    public BudgetAppService(IBudgetRepository budgetRepository, IBudgetToUserRepository budgetToUserRepository)
    {
        _budgetRepository = budgetRepository;
        _budgetToUserRepository = budgetToUserRepository;
    }

    public async Task<PersonalBudgetDto> CreatePersonalBudget(PersonalBudgetDto obj, string userId)
    {
        Guid uuid = Guid.NewGuid(); 
        PersonalBudget personalBudget = new PersonalBudget(
            id: uuid,
            salary: obj.Salario,
            light: obj.Luz,
            water: obj.Agua,
            internet: obj.Internet,
            basicFood: obj.CestaBasica,
            health: obj.Saude,
            leisure: obj.Lazer,
            clothes: obj.Roupas
            );

        Guid userGuid = Guid.Parse(userId);
        await _budgetToUserRepository.LinkBudgetToUser(userGuid, uuid);

        await _budgetRepository.CreateBudget(personalBudget);
        return obj;
    }
}