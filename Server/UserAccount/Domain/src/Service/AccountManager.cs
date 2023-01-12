using Domain.src.Entity;
using Domain.src.Error;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;

namespace Domain.src.Service
{
    public sealed class AccountManager:IAccountManager
    {
        private readonly IAccountReadRepository _AccountRepo;

        public AccountManager(IAccountReadRepository repo){
            _AccountRepo = repo;
        }

        public async Task<Result<IAccount>> CreateAccount(Username username, Email email, Password password)
        {
            var emailExists = await _AccountRepo.IsEmailInUse(email);
            if(emailExists)
                return Result.Fail<IAccount>(new EmailAlreadyInUse(email.Value.ToString()));
            var usernameExists = await _AccountRepo.IsUsernameInUse(username);
            if(usernameExists)
                return Result.Fail<IAccount>(new UsernameAlreadyInUse(username.Value.ToString()));
            var newAccount = Account.Create(username,email,password.Value);
            if(newAccount.IsFailure)
                return Result.Fail<IAccount>(new ValidationError(newAccount.Error.Message));
            
            return Result.Ok<IAccount>(newAccount.Value);
        }

        public async Task<Result<Phone>> CreatePhone(int areaCode, long number, string? prefix)
        {
            var newPhone = Phone.Create(areaCode,number);
            if(!string.IsNullOrEmpty(prefix)){
                newPhone = Phone.Create(areaCode,number,prefix);
            }
            if(newPhone.IsFailure)
                return Result.Fail<Phone>(newPhone.Error);
            var phoneExists = await _AccountRepo.IsPhoneInUse(newPhone.Value);
            if(phoneExists)
                return Result.Fail<Phone>(new PhoneAlreadyInUse(newPhone.Value.ToString()));
            return Result.Ok<Phone>(newPhone.Value);

        }
    }
}