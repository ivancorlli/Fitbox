using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Entity.Account
{
    public class Person : IAccount
    {
        private Person() { }
        public PersonProfile? Profile { get; private set;}
        private Person(Email email) : base(email)
        {
            AccountType = AccountType.Personal;
        }
        private Person(Username username,Email email,Password password) : base(email)
        {
            Username = username;
            AccountType = AccountType.Personal;
            Password = password;
        }

        internal static Result<Person> Create(Email email)
        {
            Person newAccount = new(email);
            return Result.Ok(newAccount);
        }

        /// <summary>
        /// Crea una cuenta para personas
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal static Result<Person> Create(Username username, Email email, string password)
        {
            var validPass = ValidPasswordData(email, password);
            if (validPass.IsFailure)
                return Result.Fail<Person>(new ValidationError(validPass.Error.Message));
            var newPass = Password.Create(password);
            if (newPass.IsFailure)
                return Result.Fail<Person>(new ValidationError(newPass.Error.Message));
            Person newAccount = new (username,email,newPass.Value);
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
            if (this.Profile == null)
            {
                var newPerson = PersonProfile.Create(name, gender, birth,this);
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