using Maggie.Dto;

namespace App.Dto;

public class BudgetCalculationRequestDto
{
    public PersonalBudgetDto Items { get; set; }
    public LocalCoefficientDto Local { get; set; }
}