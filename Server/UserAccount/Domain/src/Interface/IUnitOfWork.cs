using Shared.src.Interface;

namespace Domain.src.Interface
{
    public interface IUnitOfWork:IBaseUnitOfWork
    {
        IAccountWriteRepository  AccountWriteRepository {get;}
        IAccountReadRepository  AccountReadRepository {get;}
    }
}