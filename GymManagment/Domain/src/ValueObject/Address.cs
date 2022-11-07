using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.ValueObject
{
    public record Address
    {
        public string Country {get;private set;}
        public string City {get;private set;}
        public string State {get;private set;}
        public dynamic PostalCode {get;private set;}
        public string Street {get;private set;}
        public int StreetNumber {get;private set;}
        public string? Localization {get;private set;}

        /// <summary>
        /// Crea una nueva direccion
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="postalCode"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        public Address(string country,string city,string state,dynamic postalCode,string street, int streetNumber){
            Country = country;
            City = city;
            State = state;
            PostalCode = postalCode;
            Street = street;
            StreetNumber = streetNumber;
        }
    }
}