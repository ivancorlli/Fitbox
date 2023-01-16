using Domain.src.Error;
using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.Repository;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Service
{
    public sealed class AccountManager : IAccountManager
    {
        private readonly IAccountReadRepository _AccountRepo;

        public AccountManager(IAccountReadRepository repo)
        {
            _AccountRepo = repo;
        }

        /// <summary>
        /// Create new account with valid credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Result<Account>> CreateAccount(Username username, Email email, string password)
        {
            var emailExists = await _AccountRepo.IsEmailInUseAsync(email);
            if (emailExists)
                return Result.Fail<Account>(new EmailAlreadyInUse(email.Value.ToString()));
            var usernameExists = await _AccountRepo.IsUsernameInUseAsync(username);
            if (usernameExists)
                return Result.Fail<Account>(new UsernameAlreadyInUse(username.Value.ToString()));
            var newAccount = Account.Create(username, email, password);
            if (newAccount.IsFailure)
                return Result.Fail<Account>(new ValidationError(newAccount.Error.Message));

            return Result.Ok(newAccount.Value);
        }

        public async Task<Result> ChangePhone(BaseAccount account, Phone phone)
        {
            var phoneExists = await _AccountRepo.IsPhoneInUseAsync(phone);
            if (phoneExists)
                return Result.Fail(new PhoneAlreadyInUse(phone.ToString()));
            account.ChangePhone(phone);
            return Result.Ok();

        }

        public async Task<Result> ChangeEmail(BaseAccount account, Email email)
        {
            var emailExists = await _AccountRepo.IsEmailInUseAsync(email);
            if (emailExists)
                return Result.Fail(new EmailAlreadyInUse(email.Value.ToString()));
            account.ChangeEmail(email);
            return Result.Ok();
        }

        public async Task<Result> ChangeUsername(BaseAccount account, Username username)
        {
            var emailExists = await _AccountRepo.IsUsernameInUseAsync(username);
            if (emailExists)
                return Result.Fail(new EmailAlreadyInUse(username.Value.ToString()));
            account.ChangeUsername(username);
            return Result.Ok();
        }
    }
}