using Maggie.Dto;

namespace App.Dto;

public class BudgetCreateDto
{
    public PersonalBudgetDto Budget { get; set; }
    public BudgetToUserDto LinkToUser { get; set; }
}