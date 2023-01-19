using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using SharedKernell.src.Constant;
using SharedKernell.src.Result;
using UserContext.Domain.src.Utils;

namespace UserContext.Domain.src.ValueObject
{
    public record Email
    {

        public static int MaxLength = 30;
        public static int MinLength = 6;
        public static Regex Reg = new Regex("^[a-zA-Z0-9._]+(?:\\.[a-z0-9._]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

        public string Value { get; init; }

        private Email(string value)
        {
            Value = value.ToLower();
        }

        /// <summary>
        /// Crea email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Result<Email> Create(string email)
        {
            Email newEmail = new(email);
            EmailValidator validator = new();
            ValidationResult result = validator.Validate(newEmail);
            if (!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<Email>(errors[0]);
            }
            return Result.Ok(newEmail);
        }

    }
    internal class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .EmailAddress()
                .Matches(Email.Reg)
                .MinimumLength(Email.MinLength)
                .MaximumLength(Email.MaxLength)
                .WithErrorCode(ErrorTypes.Validation);

        }
    }
}