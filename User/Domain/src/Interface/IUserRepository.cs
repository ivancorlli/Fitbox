
using Domain.src.Aggregate.UserAggregate;

namespace Domain.src.Interface
{
    public interface IUserRepository
    {
        void Add(User user);
        void Remove(User user);
        User GetById(Guid Id);
        IEnumerable<User> Find();        
    }
}