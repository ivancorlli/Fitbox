

using System.Runtime.CompilerServices;
using Domain.src.Entity;
using SharedKernell.src.Interface.Repository;

[assembly:InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("InternalsVisible.DynamicProxyGenAssembly2")] 
namespace Domain.src.Interface
{
    public interface IPersonReadRepository:IReadRepository<Person>
    {

    }
}