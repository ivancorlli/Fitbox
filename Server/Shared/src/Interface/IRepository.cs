using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.src.Interface
{
    public interface IReadRepository<TEntity> where TEntity:IAggregateRoot
    {
        
    }

    public interface IWriteRepository<TEntity> where TEntity:IAggregateRoot
    {
        
    }
}