using Domain.src.Utils;
using FluentValidation;
using Shared.src.Constant;
using Shared.src.Error;
using System.Text.RegularExpressions;


namespace Domain.src.ValueObject
{
    public class PersonName
    {   

        public static int MaxLength = 15;
        public static int MinLength = 2;
        public static Regex Reg = new Regex("^[a-zA-Z]+$");

        public string FirstName {get;}
        public string LastName {get;}

        private PersonName(string name,string surname){
            FirstName = Capitalize.Create(name);
            LastName = Capitalize.Create(surname);
        }

        /// <summary>
        /// Crea un nombre completo
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public static Result<PersonName> Create(string name, string surname){
            PersonName fullName = new(name,surname);
            PersonaNameValidator validator = new();
            var result = validator.Validate(fullName);
            if(!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<PersonName>(errors[0]);
            }
            return Result.Ok<PersonName>(fullName);
        }
 
       

    }
    internal class PersonaNameValidator : AbstractValidator<PersonName>
    {
        public PersonaNameValidator()
        {
            RuleFor(x=>x.FirstName)
                .NotEmpty()
                .Matches(PersonName.Reg)
                .MaximumLength(PersonName.MaxLength)
                .MinimumLength(PersonName.MinLength)
                .WithErrorCode(ErrorTypes.Validation);
            RuleFor(x=>x.LastName)
                .NotEmpty()
                .Matches(PersonName.Reg)
                .MaximumLength(PersonName.MaxLength)
                .MinimumLength(PersonName.MinLength)
                .WithErrorCode(ErrorTypes.Validation);
        }
    }
}