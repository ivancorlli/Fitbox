using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.ValueObject
{
    public record FullName
    {   

        public FullName(string name,  string surname){
            Name = name;
            Surname = surname;
        }
       public string Name {get;}
       public string Surname {get;} 
    }
}