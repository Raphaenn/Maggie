using Maggie.App.Interfaces;
using Maggie.Domain.Entities;
using Maggie.Domain.Interfaces.Repository;
using Maggie.Dto;

namespace App.Services;

public class BudgetAppService : IBudgetAppService
{

    private readonly IBudgetRepository _budgetRepository;

    public BudgetAppService(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public async Task<PersonalBudgetDto> CreatePersonalBudget(PersonalBudgetDto obj)
    {

        // if (obj.Salario < 0)
        // {
        //     throw new ArgumentException("Invalid Salary");
        // }
        
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

        await _budgetRepository.CreateBudget(personalBudget);
        return obj;
    }

    // public async Task<PersonalBudgetDto> GerarBudget(PersonalBudgetDto obj, LocalCoefficientDto localData)
    // {
    //     PersonalBudget personalBudget = new PersonalBudget();
    //
    //     LocalCoefficient local = new LocalCoefficient()
    //     {
    //         factory = localData.factory,
    //         Cep = localData.Cep,
    //         City = localData.City,
    //         Id = localData.Id,
    //         State = localData.State
    //     };
    //
    //     var result = await _budgetRepository.GenerateBudget(personalBudget, local);
    //     return obj;
    // }
}