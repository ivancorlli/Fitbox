using Shared.src.Interface;

namespace Domain.src.Interface
{
    public interface IUnitOfWork:IBaseUnitOfWork
    {
        IUserWriteRepository  UserWriteRepository {get;}
    }
}