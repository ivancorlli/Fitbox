using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseFitbox.Src.Interface
{
    public interface IRepository<T> :IBaseRepository<T> where T : class, IAggregateRoot 
    {
        
    }
}