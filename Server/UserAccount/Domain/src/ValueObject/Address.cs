using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.src.Utils;
using FluentResults;

namespace Domain.src.ValueObject
{
    public class Address
    {

        
        private static int _Max = 15;
        private static int _Min = 3;
        private static Regex _Reg = new Regex("^[a-zA-Z ]+$");
        private static int _MaxLoc = 25;

        public string Country {get;init;}
        public string City {get;init;}
        public string State {get;init;}
        public ZipCode ZipCode {get;init;}

        private Address(string country,string city,string state,ZipCode zipCode){
            Country = country;
            City = city;
            State = state;
            ZipCode =zipCode;
        }

        /// <summary>
        /// Crea una direccion
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <returns>Nueva instancia de Address</returns>
        public static Result<Address> Create(string country,string city,string state,ZipCode zipCode){
            var validAddres = Result.Merge(
                ValidateCountry(country),
                ValidateCity(city),
                ValidateState(state)
            );
            if(validAddres.IsFailed){
                return Result.Fail(new Error(validAddres.Errors[0].Message));
            }else {
                var newAddress = new Address(
                    Capitalize.Create(country),
                    Capitalize.Create(city),
                    Capitalize.Create(state),
                    zipCode
                    );
                return Result.Ok<Address>(newAddress);
            }
        }

// ------------------------------------------ Validaciones -------------------------------------------------------
        private static Result ValidateCountry(string country){
            return Result.Merge(
                Result.FailIf(string.IsNullOrEmpty(country),new Error("El nombre de pais es requerido")),
                Result.FailIf(! _Reg.IsMatch(country),new Error("El pais tiene caracteres invalidos")),
                Result.FailIf(country.Length > _Max, new Error("El nombre del pais es demasiado largo")),
                Result.FailIf(country.Length < _Min, new Error($"El nombre del pais debe tener mas de {_Min} caracteres"))
            );
        }

         private static Result ValidateCity(string city){
            return Result.Merge(
                Result.FailIf(string.IsNullOrEmpty(city),new Error("El nombre de la ciudad es requerido")),
                Result.FailIf(! _Reg.IsMatch(city),new Error("La ciudad tiene caracteres invalidos")),
                                Result.FailIf(city.Length > _Max, new Error("El nombre de la ciudad es demasiado largo")),
                Result.FailIf(city.Length < _Min, new Error($"El nombre de la ciudad debe tener mas de {_Min} caracteres"))
            );
        }

         private static Result ValidateState(string state){
            return Result.Merge(
                Result.FailIf(string.IsNullOrEmpty(state),new Error("El nombre de la localidad es requerido")),
                Result.FailIf(! _Reg.IsMatch(state),new Error("La localidad tiene caracteres invalidos")),
                Result.FailIf(state.Length > _MaxLoc, new Error("El nombre de la localidad es demasiado largo")),
                Result.FailIf(state.Length < _Min, new Error($"El nombre de la localidad debe tener mas de {_Min} caracteres"))
            );
        }

        

// --------------------------------------- Metodos ---------------------------------------------------------------

        /// <summary>
        /// Cambia la ciudad,localidad y codigo postal
        /// </summary>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <returns>Nueva instancia de Address</returns>
        public Result<Address> WithCity(string city,string state,ZipCode zipCode)
        {
            var validCity = Result.Merge(
                ValidateCity(city),
                ValidateState(state)
                );
            if(validCity.IsFailed)
                return Result.Fail(new Error(validCity.Errors[0].Message));
            
            var newCity = Capitalize.Create(city);
            var newState = Capitalize.Create(state);
            var newAddres = Address.Create(
                this.Country,
                newCity,
                newState,
                zipCode
            );
                return Result.Ok<Address>(newAddres.Value);
        }

        /// <summary>
        /// Cambia la localidad y codigo postal
        /// </summary>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <returns>Nueva instancia de Address</returns>
        public Result<Address>  WithState(string state,ZipCode zipCode){
            var validState = ValidateState(state);
            if(validState.IsFailed)
                return Result.Fail(new Error(validState.Errors[0].Message));
            var newState = Capitalize.Create(state);
            var newAddres = Address.Create(
                this.Country,
                this.City,
                newState,
                zipCode
            );
                return Result.Ok<Address>(newAddres.Value);
        }

    }
}