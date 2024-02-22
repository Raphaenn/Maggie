using Maggie.Dto;

namespace Maggie.App.Interfaces;

public interface IBudgetAppService
{
    Task<PersonalBudgetDto> CreatePersonalBudget(PersonalBudgetDto obj, string userId);   
    // Task<PersonalBudgetDto> GerarBudget(PersonalBudgetDto obj, LocalCoefficientDto local);   
}