using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.DomainError;
using FluentResults;

namespace Domain.src.ValueObject
{
    public record Password
    {
        private static int _Min_Pass = 7;
        private static int _Max_Pass = 25;     

        public string Value {get; init;}   

        private Password(string password){
            Value = password;
        }

         internal static Result<Password> Create(string password){
            var validPass = ValidatePassword(password);
            if(validPass.IsSuccess){
                return Result.Ok<Password>(new Password(EncryptPassword(password)));
            }else {
                return Result.Fail(new Error(validPass.Errors[0].Message));
            }
        }
        /// <summary>
        /// Verifica la contrasenia ingresada
        /// </summary>
        /// <param name="inputPassword"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public Result<bool> VerifyPassword(string inputPassword,string hash){
            var verified = BCrypt.Net.BCrypt.Verify(inputPassword,hash);

            if(!verified)
                return Result.Fail(new IncorrectPassword());

            return Result.Ok(verified);
        }

        /// <summary>
        /// Valida la contrasenia
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        private static Result ValidatePassword(string pass){
            return Result.Merge(
                Result.FailIf(pass.StartsWith("1234"),new Error("Contraseña insegura, no puede iniciar con 1234")),
                Result.FailIf(pass.StartsWith("qwer"),new Error("Contraseña insegura, no puede iniciar con qwer")),
                Result.FailIf(pass.StartsWith("QWER"),new Error("Contraseña insegura, no puede iniciar con qwer")),
                Result.FailIf(pass.StartsWith("asdf"), new Error("Contraseña insegura, no puede iniciar con asdf")),
                Result.FailIf(pass.StartsWith("ASDF"), new Error("Contraseña insegura, no puede iniciar con asdf")),
                Result.FailIf(pass.Length > _Max_Pass,new Error("Contraseña demasiado larga")),
                Result.FailIf(pass.Length < _Min_Pass,new Error($"La contraseña debe tener mas de {_Min_Pass} caracteres"))
            );
        }
        /// <summary>
        /// Encirpta la contraseña
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string EncryptPassword(string password){
            var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            var passEncrypted = BCrypt.Net.BCrypt.HashPassword(password,salt);
            return passEncrypted;
        }
    }
}