using System.Text.RegularExpressions;
using FluentValidation;
using SharedKernell.src.Constant;
using SharedKernell.src.Result;
using UserContext.Domain.src.Utils;

namespace UserContext.Domain.src.ValueObject
{
    public class Address
    {
        private Address() { }

        public const int MaxLength = 15;
        public const int MinLength = 3;
        public const int StateMaxLength = 25;
#pragma warning disable 
        public static readonly Regex Reg = new("^[a-zA-Z ]+$");
#pragma warning restore

        public string Country { get; init; } = default!;
        public string City { get; init; } = default!;
        public string State { get; init; } = default!;
        public ZipCode ZipCode { get; init; } = default!;
        public string? Street { get; private set; }
        public int? StreetNumber { get; private set; }


        private Address(string country, string city, string state, ZipCode zipCode)
        {
            Country = Capitalize.Create(country);
            City = Capitalize.Create(city);
            State = Capitalize.Create(state);
            ZipCode = zipCode;
        }

        private Address(string country, string city, string state, ZipCode zipCode,string street, int streetNumber)
        {
            Country = Capitalize.Create(country);
            City = Capitalize.Create(city);
            State = Capitalize.Create(state);
            ZipCode = zipCode;
            Street = Capitalize.Create(street);
            StreetNumber = streetNumber;
        }

        /// <summary>
        /// Crea una direccion
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <returns>Nueva instancia de Address</returns>
        public static Result<Address> Create(string country, string city, string state, ZipCode zipCode)
        {
            Address address = new Address(
                country,
                city,
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
            return Result.Ok(address);
        }

        /// <summary>
        /// Crea una direccion especifica
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="street"></param>
        /// <param name="streetNum"></param>
        /// <returns></returns>
        public static Result<Address> Create(string country, string city, string state, ZipCode zipCode, string street,int streetNum)
        {
            Address address = new Address(
                    country,
                    city,
                    state,
                    zipCode,
                    street,
                    streetNum
                    );
            AddressValidator validator = new AddressValidator();
            var result = validator.Validate(address);
            if (!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<Address>(errors[0]);
            }
            return Result.Ok(address);
        }
    }


    internal sealed class AddressValidator : AbstractValidator<Address>
    {
        internal AddressValidator()
        {
            RuleFor(x => x.Country)
                    .NotEmpty()
                    .MinimumLength(Address.MinLength)
                    .MaximumLength(Address.MaxLength)
                    .Matches(Address.Reg)
                    .WithErrorCode(ErrorTypes.Validation);
            RuleFor(x => x.City)
                    .NotEmpty()
                    .MinimumLength(Address.MinLength)
                    .MaximumLength(Address.MaxLength)
                    .Matches(Address.Reg)
                    .WithErrorCode(ErrorTypes.Validation);
            RuleFor(x => x.State)
                    .NotEmpty()
                    .MinimumLength(Address.MinLength)
                    .MaximumLength(Address.StateMaxLength)
                    .Matches(Address.Reg)
                    .WithErrorCode(ErrorTypes.Validation);
        }
    }
}