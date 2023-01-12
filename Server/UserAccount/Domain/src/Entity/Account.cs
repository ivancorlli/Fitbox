using Domain.src.Abstractions;
using Domain.src.Error;
using Domain.src.Event;
using Domain.src.ValueObject;
using Shared.src.Error;

namespace Domain.src.Entity
{
    public class Account:BaseAccount
    {
        private Account(Username username, Email email, Password password) : base(username, email, password)
        {
        }

        public bool PhoneVerified {get;private set;}
        public Phone? Phone {get;private set;}

        internal static Result<Account> Create(Username username, Email email, string password)
        { 
            var validPass = ValidPasswordData(username,email,password);
            if (validPass.IsFailure)
                return Result.Fail<Account>(new ValidationError(validPass.Error.Message));
            var newPass = Password.Create(password);
            if (newPass.IsFailure)
                return Result.Fail<Account>(new ValidationError(newPass.Error.Message));
            var newAccount = new Account(username,email,newPass.Value);
            newAccount.RaiseDomainEvent(new AccountCreated());
            return Result.Ok<Account>(newAccount);
        }

        /// <summary>
        /// Cambia el numero de telefono
        /// </summary>
        /// <param name="phone"></param>
        public void ChangePhone(Phone phone){
            Phone = phone;
            UnverifyPhone();
            EntityUpdated();
        }

        /// <summary>
        /// Verifica el telefono
        /// </summary>
        public void VerifyPhone(){
            PhoneVerified = true;
            EntityUpdated();
        }

        /// <summary>
        /// Desverifica el telefono
        /// </summary>
        private void  UnverifyPhone(){
            PhoneVerified = false;
            EntityUpdated();
        }  
        
    }
}