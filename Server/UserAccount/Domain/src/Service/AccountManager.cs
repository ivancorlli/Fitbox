using Domain.src.Abstractions;
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

        /// <summary>
        /// Create new account with valid credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Result<BaseAccount>> CreateAccount(Username username, Email email, string password)
        {
            var emailExists = await _AccountRepo.IsEmailInUse(email);
            if(emailExists)
                return Result.Fail<BaseAccount>(new EmailAlreadyInUse(email.Value.ToString()));
            var usernameExists = await _AccountRepo.IsUsernameInUse(username);
            if(usernameExists)
                return Result.Fail<BaseAccount>(new UsernameAlreadyInUse(username.Value.ToString()));
            var newAccount = Account.Create(username,email,password);
            if(newAccount.IsFailure)
                return Result.Fail<BaseAccount>(new ValidationError(newAccount.Error.Message));
            
            return Result.Ok<BaseAccount>(newAccount.Value);
        }

        public async Task<Result> ChangePhone(BaseAccount account, Phone phone)
        {
            var phoneExists = await _AccountRepo.IsPhoneInUse(phone);
            if(phoneExists)
                return Result.Fail<Phone>(new PhoneAlreadyInUse(phone.ToString()));
            account.ChangePhone(phone);
            return Result.Ok();

        }
    }
}