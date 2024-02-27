using Maggie.Domain.Interfaces.Repository;

namespace Maggie.Domain.Services;


#region Comment
// Portanto, a classe ServiceBase<TEntity> é uma classe abstrata que fornece uma base para serviços (possivelmente serviços relacionados a entidades no contexto de um domínio de negócios). Ela espera que a entidade com a qual está interagindo seja uma classe de referência e deve fornecer implementações para as operações definidas na interface IRepositoryBase<T>. A implementação real dessas operações será fornecida por classes derivadas.
#endregion

public abstract class ServiceBase<TEntity> : IRepositoryBase<TEntity> where TEntity: class
{
    private readonly IRepositoryBase<TEntity> _repository;

    public ServiceBase(IRepositoryBase<TEntity> repository)
    {
        _repository = repository;
    }


    public virtual async Task<TEntity> Add(TEntity obj)
    {
        return await _repository.Add(obj);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _repository.GetAll();
    }
    
    public Task<TEntity> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task Update(TEntity obj)
    {
        throw new NotImplementedException();
    }

    public Task Remove(TEntity obj)
    {
        throw new NotImplementedException();
    }
}