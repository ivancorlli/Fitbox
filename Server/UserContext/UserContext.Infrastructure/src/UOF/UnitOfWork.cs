using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.Repository;
using UserContext.Infrastructure.src.Context;

namespace UserContext.Infrastructure.src.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _Context;
        private readonly IAccountReadRepository<Person> _PersonReadRepository;
        private readonly IAccountWriteRepository<Person> _PersonWriteRepository;

        public UnitOfWork(UserDbContext context,IAccountReadRepository<Person> readRepo, IAccountWriteRepository<Person> writeRepo)
        {
            _Context = context;
            _PersonReadRepository = readRepo;
            _PersonWriteRepository = writeRepo;
        }

        public IAccountWriteRepository<Person> PersonWriteRepository => _PersonWriteRepository;

        public IAccountReadRepository<Person> PersonReadRepository => _PersonReadRepository;

        public void AuditableEntity()
        {
            throw new NotImplementedException();
        }

        public void Dispose() => _Context.Dispose();

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