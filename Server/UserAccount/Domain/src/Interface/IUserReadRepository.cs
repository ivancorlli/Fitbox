
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
        internal Task<bool> IsEmailInUse(Email email);
        internal Task<bool> IsPhoneInUse(Phone phone);
        internal Task<bool> IsUsernameInUse(Username username);
        public Task<User> GetUserById(Guid Id);
    }
}