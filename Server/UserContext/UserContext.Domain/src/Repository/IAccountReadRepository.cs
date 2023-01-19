using System.Runtime.CompilerServices;
using SharedKernell.src.Interface.Repository;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.ValueObject;

[assembly: InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("InternalsVisible.DynamicProxyGenAssembly2")]
namespace UserContext.Domain.src.Repository
{
    public interface IAccountReadRepository : IReadRepository<Account>
    {
        public Task<bool> IsEmailInUseAsync(Email email);
        public Task<bool> IsPhoneInUseAsync(Phone phone);
        public Task<bool> IsUsernameInUseAsync(Username username);
        public Task<List<Account>> FindByEmailOrUsernameAsync(string access);
    }
}