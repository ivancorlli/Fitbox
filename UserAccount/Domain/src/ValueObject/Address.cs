using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.ValueObject
{
    public record Address
    {
        /// <summary>
        /// Crea una nueva direccion
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="postalCode"></param>
        public Address(string country, string city, string state, int postalCode ){
            Country = country;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string Country {get;private set;}
        public string City {get;private set;}
        public string State {get;private set;}
        public dynamic PostalCode {get;private set;}
        
        /// <summary>
        /// Cambia el pais
        /// </summary>
        /// <param name="country"></param>
        public void ChangeCountry(string country){
            Country = country;
        }

        /// <summary>
        /// Cambia la ciudad
        /// </summary>
        /// <param name="city"></param>
        public void ChangeCity(string city){
            City = city;
        }

        /// <summary>
        /// Cambia la localidad
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(string state){
            State = state;
        }

        /// <summary>
        /// Cambia el codigo postal
        /// </summary>
        /// <param name="postalCode"></param>
        public void ChangePostalCode(dynamic postalCode){
            PostalCode = postalCode;
        }

    }
}