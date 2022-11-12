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
        private static int _Min = 2;
        private static Regex _Reg = new Regex("^[a-zA-Z ]+$");
        private static int _MaxLoc = 25;

        public string Country {get;private set;}
        public string City {get;private set;}
        public string State {get;private set;}
        public int AreaCode {get;private set;}

        private Address(string country,string city,string state,int areCode){
            Country = country;
            City = city;
            State = state;
            AreaCode =areCode;
        }

        public static Result<Address> Create(string country,string city,string state,int areCode){
            var validAddres = Result.Merge(
                ValidateCountry(country),
                ValidateCity(city),
                ValidateState(state),
                ValidateAreaCode(areCode)
            );


            if(validAddres.IsFailed){
                return Result.Fail(new Error(validAddres.Errors[0].Message));
            }else {
                var newAddress = new Address(
                    Capitalize.Create(country),
                    Capitalize.Create(city),
                    Capitalize.Create(state),
                    areCode);
                return Result.Ok<Address>(newAddress);
            }



        }


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

        private static  Result ValidateAreaCode(int areaCode){
            return Result.Merge(
                Result.FailIf(areaCode <= 0,new Error("El codigo de area no puede ser menor o igaul a 0")),
                Result.FailIf(areaCode.ToString().Length <= 2,new Error("El codigo de area debe tener mas de dos digitos")),
                Result.FailIf(areaCode.ToString().Length >8 ,new Error("El codigo de area no puede tener mas de 8 digitos"))
            );
        }

        public Result ChangeCountry(string country)
        {   
            var validCountry = ValidateCountry(country);

            if(validCountry.IsFailed){
                return Result.Fail(new Error(validCountry.Errors[0].Message));
            }else {
                Country = Capitalize.Create(country);
                return Result.Ok();
            }
        }

        public Result ChangeCity(string city)
        {   
            var validCity = ValidateCity(city);

            if(validCity.IsFailed){
                return Result.Fail(new Error(validCity.Errors[0].Message));
            }else {
                City = Capitalize.Create(city);
                return Result.Ok();
            }
        }

        public Result ChangeState(string state)
        {   
            var validState = ValidateState(state);

            if(validState.IsFailed){
                return Result.Fail(new Error(validState.Errors[0].Message));
            }else {
                State = Capitalize.Create(state);
                return Result.Ok();
            }
        }

         public Result ChangeAreaCode(int area)
        {   
            var validArea = ValidateAreaCode(area);

            if(validArea.IsFailed){
                return Result.Fail(new Error(validArea.Errors[0].Message));
            }else {
                AreaCode = area;
                return Result.Ok();
            }
        }
    }
}