using FluentValidation;
using SharedKernell.src.Constant;
using SharedKernell.src.Result;
using UserContext.Domain.src.Utils;

namespace UserContext.Domain.src.ValueObject
{
    public record ContactPhone
    {
        private ContactPhone() { }
        public long Number { get; init; } = default!;
        public int AreaCode { get; init; } = default!;
        public string? CountryPrefix { get; init; }

        private ContactPhone(int areaCode, long number)
        {
            Number = number;
            AreaCode = areaCode;
        }

        private ContactPhone(int areaCode, long number, string country)
        {
            Number = number;
            AreaCode = areaCode;
            CountryPrefix = country.ToUpper();
        }

        /// <summary>
        /// Crea numero de telefono
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Result<ContactPhone> Create(int areaCode, long number)
        {
            ContactPhone phone = new(areaCode, number);
            PhoneContactValidator validator = new();
            var result = validator.Validate(phone, options => options.IncludeRuleSets("Phone"));
            if (!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<ContactPhone>(errors[0]);
            }
            return Result.Ok(phone);
        }

        /// <summary>
        /// Crea numero de telefono
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="number"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static Result<ContactPhone> Create(int areaCode, long number, string prefix)
        {
            ContactPhone phone = new(areaCode, number, prefix);
            PhoneContactValidator validator = new();
            var result = validator.Validate(phone, options => options.IncludeAllRuleSets());
            if (!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<ContactPhone>(errors[0]);
            }
            return Result.Ok(phone);
        }

        public override string ToString()
        {
            return $"{AreaCode} {Number}";
        }

    }

    internal class PhoneContactValidator : AbstractValidator<ContactPhone>
    {
        public PhoneContactValidator()
        {
            RuleSet("Phone", () =>
            {
                RuleFor(x => x.AreaCode)
                    .NotEmpty()
                    .GreaterThan(6)
                    .LessThan(2)
                    .WithErrorCode(ErrorTypes.Validation);
                RuleFor(x => x.Number)
                    .NotEmpty()
                    .GreaterThan(12)
                    .LessThan(5)
                    .WithErrorCode(ErrorTypes.Validation);
            });
            RuleSet("Prefix", () =>
            {
                RuleFor(x => x.CountryPrefix)
                    .NotEmpty()
                    .MaximumLength(3)
                    .MinimumLength(1)
                    .WithErrorCode(ErrorTypes.Validation);
            });

        }
    }
}