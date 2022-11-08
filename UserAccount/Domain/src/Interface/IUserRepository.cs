
using Ardalis.Specification;
using Domain.src.Aggregate.UserAggregate;

namespace Domain.src.Interface
{
    public interface IUserRepository
    {
        // Escritura
        Task<User> Add(User user);
        Task<User> Remove(User user); 

        // Lectura
        Task<User> GetById(Guid Id);  
        Task<ICollection<User>> Find();   
        Task<IList<User>> Find(Specification<User> specification);   
    }
}