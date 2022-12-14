using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using Domain.src.Utils;
using FluentValidation;
using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.ValueObject
{
    public record Username
    {
        public static int MaxLength = 15;
        public static int MinLegth = 4;
        public static Regex Reg = new Regex("^[a-zA-Z0-9._]+$");
        public string Value {get;}

        private Username(string value){
            Value = value.ToLower();
        }

        /// <summary>
        /// Crea nombre de usuario
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        internal static Result<Username> Create(string username){
            Username newUsername = new(username);
            UsernameValidator validator = new();
            var result = validator.Validate(newUsername); 
            if(!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<Username>(errors[0]);
            }
            return Result.Ok<Username>(newUsername);
        }

    }
    internal class UsernameValidator : AbstractValidator<Username>
    {
        public UsernameValidator()
        {
            RuleFor(x=>x.Value)
                .NotEmpty()
                .Matches(Username.Reg)
                .MaximumLength(Username.MaxLength)
                .MinimumLength(Username.MinLegth)
                .WithErrorCode(ErrorTypes.Validation);
        }
    }
}