using Maggie.Domain.Entities;

namespace Maggie.Domain.Interfaces.Repository;

public interface IRespositoryBase<TEntity> where TEntity : class
{
    Task<TEntity> Add(TEntity obj);

    Task<TEntity> GetById(string id);

    Task<IEnumerable<TEntity>> GetAll();

    Task Update(TEntity obj);

    Task Remove(TEntity obj);
}