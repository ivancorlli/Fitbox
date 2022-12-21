using Domain.src.Entity;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Infrastructure.src.Context;

namespace Infrastructure.src.Repository
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly UserDbContext _UserContext; 
        public UserReadRepository(UserDbContext context)
        {   
            _UserContext = context;
        }

        public Task<User> FindByEmailOrUsername(string access)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid Id)
        {   
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailInUse(Email email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsPhoneInUse(Phone phone)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUsernameInUse(Username username)
        {
            throw new NotImplementedException();
        }
    }
}