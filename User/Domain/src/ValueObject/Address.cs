using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.ValueObject
{
    public record Address
    {
        public Address(string country, string city, string state, int postalCode ){
            Country = country;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string Country {get;private set;}
        public string City {get;}
        public string State {get;}
        public dynamic PostalCode {get;}
        
    }
}