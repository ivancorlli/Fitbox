using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;


namespace Domain.src.ValueObject
{
    public record Email
    {   

        private static int _Max = 30;
        private static int _Min = 6;
        private static Regex _Reg = new Regex("^[a-zA-Z0-9._]+(?:\\.[a-z0-9._]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

        public string Value {get;}

        private Email(string value){
            Value = value.ToLower();
        }

        public static Result<Email> Create(string email){
            var validEmail = ValidateEmail(email);
            if(validEmail.IsSuccess){
                return Result.Ok(new Email(email));
            }else{
                return Result.Fail(validEmail.Errors[0].Message);
            }
        } 

        private static Result ValidateEmail(string email){
            return Result.Merge(
                Result.FailIf(string.IsNullOrEmpty(email), new Error("Valor de email requerido")),
                Result.FailIf(! _Reg.IsMatch(email), new Error("Solo se permiten letras(a-z), numeros(0-9) y puntos(.) o guiones bajo(_)")),
                Result.FailIf(email.Length > _Max, new Error($"El email no puede ser mayor a {_Max} caracteres")),
                Result.FailIf(email.Length < _Min, new Error($"El email debe tener mas de {_Min} caracteres"))
            );
        }


    }
}