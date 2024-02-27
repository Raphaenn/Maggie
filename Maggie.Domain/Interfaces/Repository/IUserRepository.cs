using Maggie.Domain.Entities;

namespace Maggie.Domain.Interfaces.Repository;

public interface IUserRepository : IRepositoryBase<Users>
{
    Task<bool> CheckEmailUsage(string email);
}