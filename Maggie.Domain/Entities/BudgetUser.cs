namespace Maggie.Domain.Entities;

public class BudgetUser
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BudgetId { get; set; }

    public BudgetUser(Guid id, Guid userId, Guid budgetId)
    {
        Id = id;
        UserId = userId;
        BudgetId = budgetId;
    }
}