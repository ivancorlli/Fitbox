
using Domain.src.Aggregate.UserAggregate;

namespace Domain.src.Interface
{
    public interface IUserReadRepository
    {   
        Task<User> GetById(Guid Id);  
        IEnumerable<User> Find();        
    }
}