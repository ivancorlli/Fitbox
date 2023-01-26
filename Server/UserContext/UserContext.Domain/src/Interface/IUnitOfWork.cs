using SharedKernell.src.Interface.Repository;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.Repository;

namespace UserContext.Domain.src.Interface
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IAccountWriteRepository<Person> PersonWriteRepository { get; }
        IAccountReadRepository<Person> PersonReadRepository { get; }
    }
}