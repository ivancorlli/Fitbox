using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;

namespace Domain.src.ValueObject
{
    public record Phone
    {
        public long PhoneNumber {get;private set;}
        public int AreaCode {get;private set;}
        public bool IsVerified {get;private set;}
        public string? CountryPrefix {get;private set;}

        private Phone(long number,int areaCode,string? country){
            PhoneNumber = number;
            AreaCode = areaCode;
            IsVerified = false;
            CountryPrefix = country?.ToUpper();
        }

        public static Result<Phone> Create(long number,int areaCode,string? prefix){

                var validPhone = Result.Merge(
                    ValidateNumber(number)
                );

                if (!string.IsNullOrEmpty(prefix)){
                    validPhone = Result.Merge(
                    ValidateNumber(number),
                    ValidatePrefix(prefix)
                );
                }

                if(validPhone.IsFailed){
                    return Result.Fail(new Error(validPhone.Errors[0].Message));
                }else {
                    Phone phone =  new Phone(number,areaCode,prefix);
                    return Result.Ok<Phone>(phone);
                }
        }

        public Result ChangeNumber(long number){
            var validNumber = ValidateNumber(number);
            if(validNumber.IsSuccess){
                PhoneNumber = number;
                return Result.Ok();
            }else {
                return Result.Fail(new Error(validNumber.Errors[0].Message));
            }
        }

        public Result ChangeAreaCode(int areaCode){
            var validAreaCode = ValidateAreaCode(areaCode);
            if(validAreaCode.IsSuccess){
                AreaCode = areaCode;
                return Result.Ok();
            }else {
                return Result.Fail(new Error(validAreaCode.Errors[0].Message));
            }
        }

         public Result ChangePrefix(string prefix){
            var validPrefix = ValidatePrefix(prefix);
            if(validPrefix.IsSuccess){
                CountryPrefix = prefix.ToUpper();
                return Result.Ok();
            }else {
                return Result.Fail(new Error(validPrefix.Errors[0].Message));
            }
        }

        public void VerifyPhone(){
            IsVerified = true;
        }

        public void UnVerifyPhone(){
            IsVerified = false;
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
    }
}