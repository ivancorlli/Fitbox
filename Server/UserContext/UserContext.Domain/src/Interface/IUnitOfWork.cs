using SharedKernell.src.Interface.Repository;

namespace Domain.src.Interface
{
    public interface IUnitOfWork:IBaseUnitOfWork
    {
        IAccountWriteRepository  AccountWriteRepository {get;}
        IAccountReadRepository  AccountReadRepository {get;}
        IPersonReadRepository PersonReadRepository{get;}
        IPersonWriteRepository PersonWriteRepository {get;}
    }
}