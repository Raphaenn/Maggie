using Maggie.Domain.Entities;

namespace Maggie.Domain.Interfaces.Repository;

public interface IBudgetToUserRepository
{
    Task<BudgetUser> LinkBudgetToUser(Guid userId, Guid budgetId);
}