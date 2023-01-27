using System.Runtime.CompilerServices;
using SharedKernell.src.Interface.Repository;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Interface.Entity;

[assembly: InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("InternalsVisible.DynamicProxyGenAssembly2")]
namespace UserContext.Domain.src.Repository
{
    public interface IAccountWriteRepository<T> : IWriteRepository<T> where T : IAccount
    {
        Task AddAsync(IAccount account);
    }
}