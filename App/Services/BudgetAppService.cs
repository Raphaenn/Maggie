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
            clothes: obj.Roupas,
            budgetDate: obj.BudgetData,
            homeRent: obj.Aluguel,
            homeTax: obj.Condominio,
            transport: obj.Transporte,
            medicines: obj.Medicamentos,
            education: obj.Educacao,
            homeSpends: obj.DespesasCasa,
            homeFinancing: obj.FinanciamentoCasa,
            carTax: obj.ImpostosCarro,
            carFinancing: obj.FinanciamentoCarro
            );

        Guid userGuid = Guid.Parse(userId);
        await _budgetToUserRepository.LinkBudgetToUser(userGuid, uuid);

        await _budgetRepository.CreateBudget(personalBudget);
        return obj;
    }

    public async Task<PersonalBudgetDto> GetBudgetByUser(string id)
    {
        Guid formatId = Guid.Parse(id);
        PersonalBudget budget = await _budgetRepository.GetBudgetByUserId(formatId);
        PersonalBudgetDto mapperBudget = new PersonalBudgetDto
        {
            Salario = budget.Salary,
            Agua = budget.Water,
            Luz = budget.Light,
            Lazer = budget.Leisure,
            Internet = budget.Internet,
            CestaBasica = budget.BasicFood,
            BudgetData = budget.BudgetDate,
            Saude = budget.Health,
            Roupas = budget.Clothes,
            Transporte = budget.Transport,
            Aluguel = budget.HomeRent,
            Condominio = budget.HomeTax,
        };

        mapperBudget.Balance();
        return mapperBudget;
    }

    public async Task<PersonalBudgetDto> GetBudgetByYear(string userId, int year)
    {
        Guid formatId = Guid.Parse(userId);
        List<PersonalBudget> budgets = await _budgetRepository.GetYearBudget(formatId, year);
        List<PersonalBudgetDto> sumBudget = new List<PersonalBudgetDto>();
        foreach (var budget in budgets)
        {
            sumBudget.Add(new PersonalBudgetDto()
            {
                Luz = budget.Light,
                Agua = budget.Water,
                Internet = budget.Internet,
                CestaBasica = budget.BasicFood,
                Saude = budget.Health,
                Lazer = budget.Leisure,
                Roupas = budget.Clothes,
                Transporte = budget.Transport,
                Aluguel = budget.HomeRent,
                Condominio = budget.HomeTax,
                FinanciamentoCasa = budget.HomeFinancing,
                ImpostosCarro = budget.CarTax,
                FinanciamentoCarro = budget.CarFinancing,
                Medicamentos = budget.Medicines,
                Educacao = budget.Education,
                DespesasCasa = budget.HomeSpends,
                BudgetData = budget.BudgetDate,
                Salario = budget.Salary,
            });
        }

        PersonalBudgetDto response = PersonalBudgetDto.SumBudgets(sumBudget);
        response.Balance();
        return response;

    }
}