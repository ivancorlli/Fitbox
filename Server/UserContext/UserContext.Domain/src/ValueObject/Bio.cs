using FluentValidation;
using FluentValidation.Results;
using Shared.src.Constant;
using Shared.src.Error;
using Domain.src.Utils;

namespace Domain.src.ValueObject
{
    public record Bio
    {   
        public static int MaxLength = 300;

        public string Value {get;init;}

        private Bio(string value){
            Value = value;
        }

        /// <summary>
        /// Crea biografia
        /// </summary>
        /// <param name="bio"></param>
        /// <returns></returns>
        public static Result<Bio> Create(string bio){
           Bio newBio = new(bio);
           BioValidator validator = new();
           ValidationResult result = validator.Validate(newBio);
           if(!result.IsValid)
           {
            var errors = ConvertDomainError.Convert(result);
            return Result.Fail<Bio>(errors[0]);
           }

           return Result.Ok<Bio>(newBio);
        }
        
    }
    internal class BioValidator:AbstractValidator<Bio>
    {   
        public BioValidator(){
            RuleFor(x=>x.Value)
                .MaximumLength(Bio.MaxLength)
                .WithErrorCode(ErrorTypes.Validation);
        }

    }
}