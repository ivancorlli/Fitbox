using System;
using System.Collections.Generic;
using Domain.src.Utils;
using System.Text.RegularExpressions;
using FluentResults;


namespace Domain.src.ValueObject
{
    public class FullName
    {   

        private static int _Max = 15;
        private static int _Min = 2;
        private static Regex _Reg = new Regex("^[a-zA-Z]+$");

        public string FirstName {get;init;}
        public string LastName {get;init;}

        private FullName(string name,string surname){
            FirstName = name;
            LastName = surname;
        }

        /// <summary>
        /// Crea un nombre completo
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public static Result<FullName> Create(string name, string surname){
            var validFullname = Result.Merge(
                ValidateFirst(name),
                ValidateLast(surname)
            );

            if (validFullname.IsSuccess){
                var newName = new FullName(
                    Capitalize.Create(name),
                    Capitalize.Create(surname)
                );
                return  Result.Ok<FullName>(newName);
            }else {
                return Result.Fail(new Error(validFullname.Errors[0].Message));
            }
        }
 
        private static Result ValidateFirst(string name){
            return Result.Merge(
                Result.FailIf(string.IsNullOrEmpty(name),"Nombre requerido"),
                Result.FailIf(!_Reg.IsMatch(name),new Error("El nombre tienes caracteres invalidos")),
                Result.FailIf(name.Length > _Max,new Error($"Nombre demasiado largo")),
                Result.FailIf(name.Length <= _Min,new Error($"El nombre debe tener mas de {_Min} caracteres"))
            );
        }

        private static Result ValidateLast(string surname){
            return Result.Merge(
                Result.FailIf(string.IsNullOrEmpty(surname),"Apellido requerido"),
                Result.FailIf(!_Reg.IsMatch(surname),new Error("El apellido tienes caracteres invalidos")),
                Result.FailIf(surname.Length > _Max,new Error($"Nombre demasiado largo")),
                Result.FailIf(surname.Length <= _Min,new Error($"El apellido debe tener mas de {_Min} caracteres"))
            );
        }

        /// <summary>
        /// Cambia el nombre
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Nueva instancia de FullName</returns>
        public Result<FullName> WithName(string name){
            var validName = ValidateFirst(name);
            if(validName.IsFailed)
                return Result.Fail(new Error(validName.Errors[0].Message));
            var newName = Capitalize.Create(name);
            var newFullName = FullName.Create(newName,LastName);
            return Result.Ok<FullName>(newFullName.Value);
        }

        public Result<FullName> WithSurname(string surname)
        {
            var validSurname = ValidateLast(surname);
             if(validSurname.IsFailed)
                return Result.Fail(new Error(validSurname.Errors[0].Message));
            var newName = Capitalize.Create(surname);
            var newFullName = FullName.Create(FirstName,newName);
            return Result.Ok<FullName>(newFullName.Value);
        }

    }
}