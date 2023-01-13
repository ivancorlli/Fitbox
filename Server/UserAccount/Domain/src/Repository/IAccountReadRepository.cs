
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
        public Task<bool> IsEmailInUseAsync(Email email);
        public Task<bool> IsPhoneInUseAsync(Phone phone);
        public Task<bool> IsUsernameInUseAsync(Username username);
        public Task<List<Account>> FindByEmailOrUsernameAsync(string access);
    }
}