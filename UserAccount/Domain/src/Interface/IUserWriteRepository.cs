
using Domain.src.Aggregate.UserAggregate;

namespace Domain.src.Interface
{
    public interface IUserWriteRepository
    {
        Task<User> Add(User user);
        Task<User> Remove(User user);   
    }
}