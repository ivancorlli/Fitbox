using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;

namespace Domain.src.ValueObject
{
    public record Phone
    {
        public long PhoneNumber {get;init;}
        public int AreaCode {get;init;}
        public string? CountryPrefix {get;init;}

        private Phone(long number,int areaCode){
            PhoneNumber = number;
            AreaCode = areaCode;
        }

        private Phone(long number,int areaCode,string country){
            PhoneNumber = number;
            AreaCode = areaCode;
            CountryPrefix = country.ToUpper();
        }

        /// <summary>
        /// Crea numero de telefono
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Result<Phone> Create(int areaCode,long number){

                var validPhone = Result.Merge(
                    ValidateNumber(number),
                    ValidateAreaCode(areaCode)
                );

                if(validPhone.IsFailed){
                    return Result.Fail(new Error(validPhone.Errors[0].Message));
                }else {
                    var phone =  new Phone(number,areaCode);
                    return Result.Ok<Phone>(phone);
                }
        }

       /// <summary>
       /// Crea numero de telefono
       /// </summary>
       /// <param name="areaCode"></param>
       /// <param name="number"></param>
       /// <param name="prefix"></param>
       /// <returns></returns>
        public static Result<Phone> Create(int areaCode,long number,string prefix){
                    var validPhone = Result.Merge(
                    ValidateNumber(number),
                    ValidateAreaCode(areaCode),
                    ValidatePrefix(prefix));
                

                if(validPhone.IsFailed){
                    return Result.Fail(new Error(validPhone.Errors[0].Message));
                }else {
                    Phone phone =  new Phone(number,areaCode,prefix);
                    return Result.Ok<Phone>(phone);
                }
        }
        
        private static Result ValidateNumber(long number){
            return Result.Merge(
                Result.FailIf(number <= 0, new Error("El numero de telefono no puede ser menor o igual a 0")),
                Result.FailIf(number.ToString().Length > 10, new Error("El numero de telefono no puede tenr mas de 10 digitos")),
                Result.FailIf(number.ToString().Length < 4, new Error("El numero de telefono debe tener mas de 4 ditigos"))
            );
        }

         private static Result ValidateAreaCode(int number){
            return Result.Merge(
                Result.FailIf(number <= 0, new Error("El codigo de area no puede ser menor o igual a 0")),
                Result.FailIf(number.ToString().Length > 5, new Error("El codigo de area no puede tenr mas de 5 digitos")),
                Result.FailIf(number.ToString().Length < 2, new Error("El codigo de area debe tener mas de 2 ditigos"))
            );
        }

        private static Result ValidatePrefix(string prefix){
            return Result.Merge(
                Result.FailIf(string.IsNullOrEmpty(prefix), new Error("Debes indicar el prefijo del numero de telefono")),
                Result.FailIf(prefix.Length > 3, new Error("El prefijo de pais no puede tener mas de 3 caracteres")),
                Result.FailIf(prefix.Length <=1, new Error("El prefijo de pais debe tener mas de un caracter"))
            );
        }

        public Result<Phone> WithNumber(long number){
            var validNumber = ValidateNumber(number);
            if(validNumber.IsFailed)
                return Result.Fail(new Error(validNumber.Errors[0].Message));

            if(string.IsNullOrEmpty(CountryPrefix)){
                var newPhone = Phone.Create(AreaCode,number);
                return Result.Ok<Phone>(newPhone.Value);
            }else{
                var newPhone = Phone.Create(AreaCode,number,CountryPrefix);
                return Result.Ok<Phone>(newPhone.Value);
            }

        }
    }
}