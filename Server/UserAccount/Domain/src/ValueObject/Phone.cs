

using Domain.src.Utils;
using FluentValidation;
using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.ValueObject
{
    public record Phone
    {   
        private Phone(){}
        public long PhoneNumber {get;init;} = default!;
        public int AreaCode {get;init;} = default!;
        public string? CountryPrefix {get;init;}

        private Phone(int areaCode,long number){
            PhoneNumber = number;
            AreaCode = areaCode;
        }

        private Phone(int areaCode,long number,string country){
            PhoneNumber = number;
            AreaCode = areaCode;
            CountryPrefix = country.ToUpper();
        }

        /// <summary>
        /// Crea numero de telefono
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Result<Phone> Create(int areaCode,long number){
            Phone phone = new(areaCode,number);
            PhoneValidator validator = new();
            var result = validator.Validate(phone,options=>options.IncludeRuleSets("Phone"));
            if(!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<Phone>(errors[0]);
            }
            return Result.Ok<Phone>(phone);
        }

       /// <summary>
       /// Crea numero de telefono
       /// </summary>
       /// <param name="areaCode"></param>
       /// <param name="number"></param>
       /// <param name="prefix"></param>
       /// <returns></returns>
        public static Result<Phone> Create(int areaCode,long number,string prefix){
            Phone phone = new(areaCode,number,prefix);
            PhoneValidator validator = new();
            var result = validator.Validate(phone,options=>options.IncludeAllRuleSets());
            if(!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<Phone>(errors[0]);
            }
            return Result.Ok<Phone>(phone);      
        }

        public override string ToString(){
            return $"{AreaCode} {PhoneNumber}";
        }
        
    }

    internal class PhoneValidator : AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
        RuleSet("Phone",()=>{
            RuleFor(x=>x.AreaCode)
                .NotEmpty()
                .GreaterThan(6)
                .LessThan(2)
                .WithErrorCode(ErrorTypes.Validation);
            RuleFor(x=>x.PhoneNumber)
                .NotEmpty()
                .GreaterThan(12)
                .LessThan(5)
                .WithErrorCode(ErrorTypes.Validation);
        });
        RuleSet("Prefix",()=>{
            RuleFor(x=>x.CountryPrefix)
                .NotEmpty()
                .MaximumLength(3)
                .MinimumLength(1)
                .WithErrorCode(ErrorTypes.Validation);
        });

        }
    }
}