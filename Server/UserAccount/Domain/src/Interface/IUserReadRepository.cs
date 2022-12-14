
using System.Runtime.CompilerServices;
using Domain.src.Entity;
using Domain.src.ValueObject;
using Shared.src.Interface;

[assembly:InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("InternalsVisible.DynamicProxyGenAssembly2")] 
namespace Domain.src.Interface
{
    public interface IUserReadRepository:IReadRepository<User>
    {
        public Task<bool> IsEmailInUse(Email email);
        public Task<bool> IsPhoneInUse(Phone phone);
        public Task<bool> IsUsernameInUse(Username username);
        public Task<User> GetUserById(Guid Id);
        public Task<User> FindByEmailOrUsername(string access);
    }
}