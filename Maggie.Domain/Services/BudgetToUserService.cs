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
    
    public async Task<BudgetUser> LinkBudgetToUser(Guid userId, Guid budgetId)
    {
        BudgetUser response = await _budgetToUserRepository.LinkBudgetToUser(userId, budgetId);
        return response;
    }
}