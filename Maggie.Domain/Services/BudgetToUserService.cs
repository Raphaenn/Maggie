using Maggie.Domain.Entities;
using Maggie.Domain.Interfaces.Repository;

namespace Maggie.Domain.Services;

public class BudgetToUserService : IBudgetToUserRepository
{
    private readonly IBudgetToUserRepository _budgetToUserRepository;

    public BudgetToUserService(IBudgetToUserRepository budgetToUserRepository)
    {
        _budgetToUserRepository = budgetToUserRepository;
    }
    
    public async Task LinkBudgetToUser(Guid userId, Guid budgetId)
    {
        await _budgetToUserRepository.LinkBudgetToUser(userId, budgetId);
    }
}