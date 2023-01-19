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
            _Context.Dispose();
        }

        public void OutboxMessage()
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _Context.SaveChangesAsync(cancellationToken);
        }
    }
}