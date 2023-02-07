using SharedKernell.src.Interface.Entity;

namespace SharedKernell.src.Interface.Repository;

    public interface IBaseUnitOfWork:IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void OutboxMessage();
        void AuditableEntity();
    }

    public interface IReadRepository<TEntity> where TEntity:IAggregateRoot
    {
        Task<TEntity?> GetByIdAsync(Guid Id);
    }

    public interface IWriteRepository<TEntity> where TEntity:IAggregateRoot
    {
        Task AddAsync(TEntity Entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        
    }