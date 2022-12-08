using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using FluentResults;

namespace Domain.src.ValueObject
{
    public record Username
    {
        private static int _Max = 15;
        private static int _Min = 4;
        private static Regex _Reg = new Regex("^[a-zA-Z0-9._]+$");
        public string Value {get;}

        private Username(string value){
            Value = value.ToLower();
        }

        public static Result<Username> Create(string username){
            var validUsername = ValidateUsername(username);

            if (validUsername.IsFailed){
                return Result.Fail(new Error(validUsername.Errors[0].Message));
            }else{
                return  Result.Ok<Username>(new Username(username));
            }

        }


        private static Result ValidateUsername(string username){
                return Result.Merge(
                        Result.FailIf(string.IsNullOrEmpty(username),new Error("El valor del nombre de usuario es requerido")),
                        Result.FailIf(! _Reg.IsMatch(username),new Error("Solo se permiten letras(a-z), numeros(0-9) y puntos(.) o guiones bajo(_)")),
                        Result.FailIf(username.Length > _Max, new Error($"El nombre de usuario no puede tener mas de {_Max} caracteres")),
                        Result.FailIf(username.Length < _Min, new Error($"El nombre de usuario debe tener mas de {_Min} caracteres"))
                );
        }
    }
}