
using Domain.src.Error;
using Domain.src.Utils;
using FluentValidation;
using Shared.src.Error;

namespace Domain.src.ValueObject
{
    public record Password
    {
        public static int MinLenght = 7;
        public static int MaxLength = 25;     

        public string Value {get;private set;} = default!;   
        private Password(){}
        private Password(string password){
            Value = password;
        }

         /// <summary>
        /// Encirpta la contraseña
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private Password EncryptPassword(){
            var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            var passEncrypted = BCrypt.Net.BCrypt.HashPassword(Value,salt);
            return new Password(passEncrypted);
        }

        /// <summary>
        /// Crea contrasenia
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        internal static Result<Password> Create(string password){
            Password newPassword = new(password);
            PasswordValidator validator = new();
            var result = validator.Validate(newPassword);
            if(!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<Password>(errors[0]);
            }
            return Result.Ok<Password>(newPassword.EncryptPassword());
        }
        /// <summary>
        /// Verifica la contrasenia ingresada
        /// </summary>
        /// <param name="inputPassword"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool VerifyPassword(string inputPassword){
            var verified = BCrypt.Net.BCrypt.Verify(inputPassword,Value);
            return verified;
        }
    }

    internal class PasswordValidator : AbstractValidator<Password>
    {
        internal PasswordValidator()
        {
            RuleFor(x=>x.Value)
                .NotEmpty()
                .Must(value => !value.StartsWith("1234"))
                .Must(value => !value.StartsWith("qwer"))
                .Must(value => !value.StartsWith("QWER"))
                .Must(value => !value.StartsWith("asdf"))
                .Must(value => !value.StartsWith("ASDF"))
                .MaximumLength(Password.MaxLength)
                .MinimumLength(Password.MinLenght);
        }
    }
}