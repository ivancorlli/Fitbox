using UserContext.Domain.src.Interface;
using UserContext.Domain.src.Repository;
using UserContext.Infrastructure.src.Context;
using UserContext.Infrastructure.src.Repository;

namespace UserContext.Infrastructure.src.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _Context;

        public UnitOfWork(UserDbContext context)
        {
            _Context = context;
        }

        public IAccountWriteRepository AccountWriteRepository => new AccountWriteRepository(_Context);

        public IAccountReadRepository AccountReadRepository => new AccountReadRepository(_Context);

        public IPersonReadRepository PersonReadRepository => new PersonReadRepository(_Context);

        public IPersonWriteRepository PersonWriteRepository => new PersonWriteRepository(_Context);

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