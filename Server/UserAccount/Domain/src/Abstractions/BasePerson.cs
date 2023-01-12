using Domain.src.Enum;
using Domain.src.Error;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Abstractions;
using Shared.src.Error;

namespace Domain.src.Abstractions
{
    public abstract class BasePerson : AggregateRoot, IPerson
    {
        public Guid AccountId { get; init; }
        public PersonName Name { get; protected set;}
        public Gender Gender { get; protected set;}
        public DateTime Birth { get; protected set;}
        public Address? Address { get; protected set;}

        /// <summary>
        /// Create a base person
        /// </summary>
        /// <param name="account"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birth"></param>
        protected BasePerson(Guid account, PersonName name, Gender gender, DateTime birth)
        {
            AccountId = account;
            Name = name;
            Gender = gender;
            Birth = birth;
        }
        //

        /// <summary>
        /// Change name and surname
        /// </summary>
        /// <param name="name"></param>
        public void ChangeName(PersonName name)
        {
            Name = name;
            EntityUpdated();
        }

        /// <summary>
        /// Change gender
        /// </summary>
        /// <param name="gender"></param>
        public void ChangeGender(Gender gender)
        {
            Gender = gender;
            EntityUpdated();
        }

        /// <summary>
        /// Change Birth
        /// </summary>
        /// <param name="birth"></param>
        /// <returns></returns>
        public Result ChangeBirth(DateTime birth)
        {
            var isValid = ValidateBirth(birth);
            if (isValid.IsFailure)
            {
                return Result.Fail(isValid.Error);
            }
            else
            {
                Birth = birth;
                EntityUpdated();
                return Result.Ok();
            }

        }

        /// <summary>
        /// Create Adress
        /// </summary>
        /// <param name="address"></param>
        public void CreateAddress(Address address)
        {
            Address = address;
            EntityUpdated();
        }

        /// <summary>
        /// Delete Address
        /// </summary>
        public void DeleteAddress()
        {
            Address = null;
            EntityUpdated();
        }
        // ================================================================================================================ //      

        /// <summary>
        /// Validate a person age, It needs to be 13 years older
        /// </summary>
        /// <param name="birth"></param>
        /// <returns></returns>
        public static Result ValidateBirth(DateTime birth)
        {
            var isLegal = (DateTime.UtcNow - birth).TotalDays / 365;

            if (birth > DateTime.Now)
            {
                return Result.Fail(new ValidationError("La fecha de nacimiento no puede ser mayor a la fecha de hoy"));

            }
            if (isLegal < 13)
            {
                return Result.Fail(new ValidationError("No puedes continuar, eres menor de 13 años"));
            }
            return Result.Ok();

        }
    }

}