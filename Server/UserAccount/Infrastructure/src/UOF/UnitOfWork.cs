using Domain.src.Interface;

namespace Infrastructure.src.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserWriteRepository UserWriteRepository => throw new NotImplementedException();

        public void AuditableEntity()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void OutboxMessage()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}