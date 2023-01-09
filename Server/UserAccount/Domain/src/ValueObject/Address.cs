using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Domain.src.Error;
using Domain.src.Utils;
using FluentValidation;
using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.ValueObject
{
    public class Address
    {
        private Address(){}
        
        public static int MaxLength = 15;
        public static int MinLength = 3;
        public static int StateMaxLength => 25;
        public static  Regex Reg = new Regex("^[a-zA-Z ]+$");

        public string Country {get;init;} = default!;
        public string City {get;init;} = default!;
        public string State {get;init;} = default!;
        public ZipCode ZipCode {get;init;} = default!;

        private Address(string country,string city,string state,ZipCode zipCode){
            Country = Capitalize.Create(country);
            City = Capitalize.Create(city);
            State = Capitalize.Create(state);
            ZipCode =zipCode;
        }

        /// <summary>
        /// Crea una direccion
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <returns>Nueva instancia de Address</returns>
        public static Result<Address> Create(string country,string city,string state,ZipCode zipCode){
            Address address = new Address(
                country,
                country,
                state,
                zipCode
                );
            AddressValidator validator = new AddressValidator();
            var result = validator.Validate(address);
            if (!result.IsValid)
            {
               var errors = ConvertDomainError.Convert(result);
               return Result.Fail<Address>(errors[0]);
            }
            return Result.Ok<Address>(address);
        }

    }

    internal sealed class AddressValidator:AbstractValidator<Address>
    {
        internal AddressValidator()
        {
            RuleFor(x => x.Country)
                    .NotEmpty()
                    .MinimumLength(Address.MinLength)
                    .MaximumLength(Address.MaxLength)
                    .Matches(Address.Reg)
                    .WithErrorCode(ErrorTypes.Validation);
            RuleFor(x=>x.City)
                    .NotEmpty()
                    .MinimumLength(Address.MinLength)
                    .MaximumLength(Address.MaxLength)
                    .Matches(Address.Reg)
                    .WithErrorCode(ErrorTypes.Validation);
            RuleFor(x=>x.State)
                    .NotEmpty()
                    .MinimumLength(Address.MinLength)
                    .MaximumLength(Address.StateMaxLength)
                    .Matches(Address.Reg)
                    .WithErrorCode(ErrorTypes.Validation);
        }
    }
}