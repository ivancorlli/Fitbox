using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.ValueObject
{
    public record Name
    {   

        public Name(string name,  string surname){
            FirstName = name;
            LastName = surname;
        }
       public string FirstName {get;private set;}
       public string LastName {get;private set;}

        /// <summary>
        /// Acutailiza el nombre y apellido
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
       public void UpdateName(string? name, string? surname){
            if(!string.IsNullOrEmpty(name)){
                FirstName = name;
            }

            if (!string.IsNullOrEmpty(surname)){
                 LastName = surname;   
            }
       } 
    }
}