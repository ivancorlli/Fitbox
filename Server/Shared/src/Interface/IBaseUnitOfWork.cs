namespace Shared.src.Interface
{
    public interface IBaseUnitOfWork:IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void OutboxMessage();
        void AuditableEntity();
    }
}