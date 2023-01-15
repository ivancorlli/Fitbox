using Domain.src.Abstractions;
using Domain.src.Error;
using Domain.src.Event;
using Domain.src.ValueObject;
using Shared.src.Error;

namespace Domain.src.Entity
{
    public class Account:BaseAccount
    {
        private Account(){}
        private Account(Username username, Email email, Password password) : base(username, email, password)
        {
        }


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
        
    }
}