using FluentValidation;
using SharedKernell.src.Constant;
using SharedKernell.src.Result;
using System.Text.RegularExpressions;
using UserContext.Domain.src.Utils;


namespace UserContext.Domain.src.ValueObject
{
    public partial record PersonName
    {
        private PersonName() { }
        public const int MaxLength = 15;
        public const int MinLength = 2;
        public static Regex Reg = MyRegex();

        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;

        private PersonName(string name, string surname)
        {
            FirstName = Capitalize.Create(name);
            LastName = Capitalize.Create(surname);
        }

        /// <summary>
        /// Crea un nombre completo
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public static Result<PersonName> Create(string name, string surname)
        {
            PersonName fullName = new(name, surname);
            PersonaNameValidator validator = new();
            var result = validator.Validate(fullName);
            if (!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<PersonName>(errors[0]);
            }
            return Result.Ok(fullName);
        }

        [GeneratedRegex("^[a-zA-Z]+$")]
        private static partial Regex MyRegex();
    }
    internal class PersonaNameValidator : AbstractValidator<PersonName>
    {
        public PersonaNameValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Matches(PersonName.Reg)
                .MaximumLength(PersonName.MaxLength)
                .MinimumLength(PersonName.MinLength)
                .WithErrorCode(ErrorTypes.Validation);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .Matches(PersonName.Reg)
                .MaximumLength(PersonName.MaxLength)
                .MinimumLength(PersonName.MinLength)
                .WithErrorCode(ErrorTypes.Validation);
        }
    }
}