using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseFitbox.Src.ValueObject
{
    public record Id
    {
        public Guid Value {get;private set;}

        public Id(){
            Value = Guid.NewGuid();
        }
    }
}