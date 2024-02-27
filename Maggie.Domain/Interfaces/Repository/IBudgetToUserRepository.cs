using Maggie.Domain.Entities;

namespace Maggie.Domain.Interfaces.Repository;

public interface IBudgetToUserRepository
{
    Task LinkBudgetToUser(Guid userId, Guid budgetId);
}