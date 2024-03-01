using Maggie.Dto;

namespace Maggie.App.Interfaces;

public interface IBudgetAppService
{
    Task<PersonalBudgetDto> CreatePersonalBudget(PersonalBudgetDto obj, string userId);

    Task<PersonalBudgetDto> GetBudgetByUser(string id);

    Task<PersonalBudgetDto> GetBudgetByYear(string userId, int year);
}