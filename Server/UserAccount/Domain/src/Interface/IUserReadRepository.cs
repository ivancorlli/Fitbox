
using System.Runtime.CompilerServices;
using Domain.src.Entity;
using Domain.src.ValueObject;

[assembly:InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("InternalsVisible.DynamicProxyGenAssembly2")] 
namespace Domain.src.Interface
{
    public interface IUserReadRepository
    {
        internal Task<User> GetUserById(Guid Id);
        internal Task<User> GetUserByEmail(Email email);
        internal Task<User> GetUserByUsername(Username username);
        internal Task<User> GetUserByPhone(Phone phone);
    }
}