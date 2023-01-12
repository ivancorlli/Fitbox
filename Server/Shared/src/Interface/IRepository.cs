using System.ComponentModel;

using Shared.src.Error;

namespace Shared.src.Interface
{
    public interface IReadRepository<TEntity> where TEntity:IAggregateRoot
    {
        TEntity? GetById(Guid Id);
    }

    public interface IWriteRepository<TEntity> where TEntity:IAggregateRoot
    {
        void Add(TEntity Entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
    }
}