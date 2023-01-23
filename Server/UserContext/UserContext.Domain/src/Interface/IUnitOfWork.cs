using SharedKernell.src.Interface.Repository;
using UserContext.Domain.src.Repository;

namespace UserContext.Domain.src.Interface
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IAccountWriteRepository AccountWriteRepository { get; }
        IAccountReadRepository AccountReadRepository { get; }
    }
}