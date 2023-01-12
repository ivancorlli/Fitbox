
using System.Runtime.CompilerServices;
using Domain.src.Entity;
using Domain.src.ValueObject;
using Shared.src.Interface;

[assembly:InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("InternalsVisible.DynamicProxyGenAssembly2")] 
namespace Domain.src.Interface
{
    public interface IAccountReadRepository:IReadRepository<Account>
    {
        public bool IsEmailInUse(Email email);
        public bool IsPhoneInUse(Phone phone);
        public bool IsUsernameInUse(Username username);
        public List<Account> FindByEmailOrUsername(string access);
    }
}