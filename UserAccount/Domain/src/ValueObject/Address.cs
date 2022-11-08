using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;

namespace Domain.src.ValueObject
{
    public record Address
    {

        private Address(string country, string city, string state, int postalCode ){
            Country = country;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string Country {get;private set;}
        public string City {get;private set;}
        public string State {get;private set;}
        public dynamic PostalCode {get;private set;}

        public Result Create(string country, string city, string state, int postalCode ){
            if(string.IsNullOrEmpty(country)){
                return Result.Fail("Pais requerido");
            }
            return Result.Ok();
        }
        
        /// <summary>
        /// Cambia el pais
        /// </summary>
        /// <param name="country"></param>
        public Result ChangeCountry(string country){
            Result validCountry = ValidateCountry(country);
            if(validCountry.IsFailed){
                return Result.Fail(validCountry.Errors[0].Message);
            }else{
                Country = country;
                return Result.Ok();
            }
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



        /// <summary>
        /// Valida el campo pais
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        private static Result ValidateCountry(string country){

            return Result.Merge(
                Result.FailIf(string.IsNullOrEmpty(country),"Pais es un campo requerido"),
                Result.FailIf(country.Length > 50,$"{country} no es valido")

            );
        }

        /// <summary>
        /// Valida el campo ciudad
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        private static Result ValidateCity(string city){
            if(string.IsNullOrEmpty(city)){
                return Result.Fail(new Error("City is required"));
            }

            return Result.Ok();
        }

        /// <summary>
        /// Valida campo localidad
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private static Result ValidateState(string state){
            if(string.IsNullOrEmpty(state)){
                return Result.Fail(new Error("State is required"));
            }

            return Result.Ok();
        }

        /// <summary>
        /// Valida codigo postal
        /// </summary>
        /// <param name="postalCode"></param>
        /// <returns></returns>

        private static Result ValidatePostalCode(int postalCode){
            if(postalCode < 0){
                return Result.Fail(new Error("Postal Code is required"));
            }

            return Result.Ok();
        }

    }
}