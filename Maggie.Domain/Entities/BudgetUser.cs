namespace Maggie.Domain.Entities;

public class BudgetUser
{
    public Guid Id { get; private set; }
    public Guid UserId { get; set; }
    public Guid BudgetId { get; set; }

    public BudgetUser(Guid id, Guid userId, Guid budgetId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        BudgetId = budgetId;
    }
}