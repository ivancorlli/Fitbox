using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.ValueObject
{
    public record Biography
    {
        public Biography(string value){
            Value = value;
        }
        public string Value {get;}
    }
}