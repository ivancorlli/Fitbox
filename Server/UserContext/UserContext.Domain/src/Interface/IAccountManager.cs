using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Interface
{
    public interface IAccountManager
    {
        Task<Result<Account>> CreateAccount(Username username, Email email, string password);
        Task<Result> ChangePhone(BaseAccount account, Phone phone);
        Task<Result> ChangeEmail(BaseAccount account, Email email);
        Task<Result> ChangeUsername(BaseAccount account, Username username);

    }
}