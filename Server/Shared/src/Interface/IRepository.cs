
using Shared.src.Error;

namespace Shared.src.Interface
{
    public interface IReadRepository<TEntity> where TEntity:IAggregateRoot
    {
        Task<Result<TEntity>> GetById(Guid Id);
    }

    public interface IWriteRepository<TEntity> where TEntity:IAggregateRoot
    {
        Task Add(TEntity Entity);
        Task Update(TEntity Entity);
        Task Delete(TEntity Entity);
    }
}