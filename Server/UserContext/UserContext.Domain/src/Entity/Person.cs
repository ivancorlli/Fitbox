using System.Runtime.CompilerServices;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;
using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;

[assembly: InternalsVisibleTo("Tests")]
namespace UserContext.Domain.src.Entity
{

    public class Person : BasePerson
    {
        private Person() { }
        private Person(PersonName name, Gender gender, DateTime birth) : base(name, gender, birth)
        {
        }

        internal static Result<Person> Create( PersonName name, Gender gender, DateTime birth)
        {
            var isValid = ValidateBirth(birth);
            if (isValid.IsFailure)
                return Result.Fail<Person>(isValid.Error);

            var newUser = new Person(name, gender, birth);
            return Result.Ok(newUser);
        }

        // ================================== PROPERTIES  METHODS ========================================= //

        
    }
}
