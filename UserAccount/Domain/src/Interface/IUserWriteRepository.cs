
using System.Runtime.CompilerServices;
using Domain.src.Entity;

[assembly:InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("InternalsVisible.DynamicProxyGenAssembly2")] 
namespace Domain.src.Interface
{
    public interface IUserWriteRepository
    {
        internal Task Create(User user);
        
    }
}