using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.Event;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Entity.Account
{
    public class PersonAccount : BaseAccount
    {
        private PersonAccount() { }
        public Person? Profile { get; private set;}
        private PersonAccount(Username username, Email email, Password password) : base(username, email, password)
        {
        }


        /// <summary>
        /// Crea una cuenta para personas
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal static Result<PersonAccount> Create(Username username, Email email, string password)
        {
            var validPass = ValidPasswordData(username, email, password);
            if (validPass.IsFailure)
                return Result.Fail<PersonAccount>(new ValidationError(validPass.Error.Message));
            var newPass = Password.Create(password);
            if (newPass.IsFailure)
                return Result.Fail<PersonAccount>(new ValidationError(newPass.Error.Message));
            var newAccount = new PersonAccount(username, email, newPass.Value);
            newAccount.RaiseDomainEvent(new AccountCreated());
            return Result.Ok(newAccount);
        }

        /// <summary>
        /// Crea un nuevo perfil
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birth"></param>
        /// <returns></returns>
        public Result AddProfile(PersonName name, Gender gender, DateTime birth)
        {
            if (Profile != null)
            {
                var newPerson = Person.Create(name, gender, birth);
                if (newPerson.IsFailure) return Result.Fail(newPerson.Error);
                Profile = newPerson.Value;
                EntityUpdated();
                return Result.Ok();
            }
            else
            {
                return Result.Fail(new ProfileExists(Username.Value));
            }
        }

    }
}