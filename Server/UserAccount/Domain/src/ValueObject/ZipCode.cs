using System.Text.RegularExpressions;
using Domain.src.Utils;
using FluentValidation;
using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.ValueObject
{
    public record ZipCode
    {
        public static int MinLength = 3;
        public static int MaxLength = 8; 
        public static Regex Reg = new Regex("^[a-zA-Z0-9- ]+$");

        public string Value {get;init;}

        private ZipCode(string zipCode){
            Value =zipCode;
        }

        /// <summary>
        /// Crea codigo postal
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public static Result<ZipCode> Create(string zipCode){
            ZipCode zip = new(zipCode);
            ZipCodeValidator validator = new();
            var result = validator.Validate(zip);
            if(!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<ZipCode>(errors[0]);
            }
            return Result.Ok<ZipCode>(zip);
        }
        
    }
    internal class ZipCodeValidator : AbstractValidator<ZipCode>
    {
        public ZipCodeValidator()
        {
            RuleFor(x=>x.Value)
                .NotEmpty()
                .Matches(ZipCode.Reg)
                .MaximumLength(ZipCode.MaxLength)
                .MinimumLength(ZipCode.MinLength)
                .WithErrorCode(ErrorTypes.Validation);
        }
    }
}