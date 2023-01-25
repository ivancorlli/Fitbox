using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.Repository;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Service
{
    public abstract class AccountManager<T> :IAccountManager<T> where T : IAccount 
    {
        protected readonly IAccountReadRepository<T> _AccountRepo;

        public AccountManager(IAccountReadRepository<T> repo)
        {
            _AccountRepo = repo;
        }


        public abstract Task<Result<T>> CreateAccount(Username username, Email email, string password);

        /// <summary>
        /// Cambia el telefono, verifica que no existan duplicados
        /// </summary>
        /// <param name="account"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<Result> ChangePhone(T account, Phone phone)
        {
            var phoneExists = await _AccountRepo.IsPhoneInUseAsync(phone);
            if (phoneExists)
                return Result.Fail(new PhoneAlreadyInUse(phone.ToString()));
            account.ChangePhone(phone);
            return Result.Ok();

        }

        /// <summary>
        /// Cambia el email, verifica que no existan duplicados
        /// </summary>
        /// <param name="account"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Result> ChangeEmail(T account, Email email)
        {
            var emailExists = await _AccountRepo.IsEmailInUseAsync(email);
            if (emailExists)
                return Result.Fail(new EmailAlreadyInUse(email.Value.ToString()));
            account.ChangeEmail(email);
            return Result.Ok();
        }

        /// <summary>
        /// Cambia el nombre de usuario, verifica que no existan duplicados
        /// </summary>
        /// <param name="account"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<Result> ChangeUsername(T account, Username username)
        {
            var emailExists = await _AccountRepo.IsUsernameInUseAsync(username);
            if (emailExists)
                return Result.Fail(new EmailAlreadyInUse(username.Value.ToString()));
            account.ChangeUsername(username);
            return Result.Ok();
        }
    }
}