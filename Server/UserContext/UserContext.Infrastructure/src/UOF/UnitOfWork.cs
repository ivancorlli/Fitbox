using UserContext.Domain.src.Interface;
using UserContext.Domain.src.Repository;
using UserContext.Infrastructure.src.Context;
using UserContext.Infrastructure.src.Repository;

namespace UserContext.Infrastructure.src.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _Context;
        private readonly IAccountReadRepository _AccountReadRepository;
        private readonly IAccountWriteRepository _AccountWriteRepository;

        public UnitOfWork(UserDbContext context,IAccountReadRepository readRepo, IAccountWriteRepository writeRepo)
        {
            _Context = context;
            _AccountReadRepository = readRepo;
            _AccountWriteRepository = writeRepo;
        }

        public IAccountWriteRepository AccountWriteRepository => _AccountWriteRepository;

        public IAccountReadRepository AccountReadRepository => _AccountReadRepository;

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