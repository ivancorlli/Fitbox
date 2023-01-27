using System.Runtime.CompilerServices;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;
using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity.Account;

[assembly: InternalsVisibleTo("Tests")]
namespace UserContext.Domain.src.Entity
{

    public class PersonProfile : IPersonProfile
    {
        private PersonProfile() { }
        private PersonProfile(PersonName name, Gender gender, DateTime birth,Person account) : base(name, gender, birth,account)
        {
        }

        internal static Result<PersonProfile> Create( PersonName name, Gender gender, DateTime birth,Person account)
        {
            var isValid = ValidateBirth(birth);
            if (isValid.IsFailure)
                return Result.Fail<PersonProfile>(isValid.Error);

            var newUser = new PersonProfile(name, gender, birth,account);
            return Result.Ok(newUser);
        }

        // ================================== PROPERTIES  METHODS ========================================= //

        
    }
}
