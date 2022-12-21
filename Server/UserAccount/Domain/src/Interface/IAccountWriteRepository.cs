
using System.Runtime.CompilerServices;
using Domain.src.Entity;
using Shared.src.Interface;

[assembly:InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("InternalsVisible.DynamicProxyGenAssembly2")] 
namespace Domain.src.Interface
{
    public interface IAccountWriteRepository:IWriteRepository<Account>
    {
        public Task AddAccount(Account account);
        public Task Update(Account account);
        
    }
}