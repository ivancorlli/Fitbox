

using System.Runtime.CompilerServices;
using SharedKernell.src.Interface.Repository;
using UserContext.Domain.src.Entity;

[assembly: InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("InternalsVisible.DynamicProxyGenAssembly2")]
namespace UserContext.Domain.src.Repository
{
    public interface IPersonReadRepository : IReadRepository<Person>
    {

    }
}