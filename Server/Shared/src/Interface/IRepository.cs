using System.ComponentModel;

using Shared.src.Error;

namespace Shared.src.Interface
{
    public interface IReadRepository<TEntity> where TEntity:IAggregateRoot
    {
        Task<Result<TEntity>> GetById(Guid Id);
    }

    public interface IWriteRepository<TEntity> where TEntity:IAggregateRoot
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity Entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity Entity);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity Entity);
        
    }
}