using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.ValueObject
{
    public record Username
    {
        public Username(string value){
            Value = value;
        }
        public string Value {get;}
    }
}