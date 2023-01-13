
using Domain.src.Abstractions;
using Domain.src.Entity;
using Domain.src.ValueObject;
using Shared.src.Error;

namespace Domain.src.Interface
{
    public interface IAccountManager
    {
        Task<Result<Account>> CreateAccount(Username username, Email email, string password);
        Task<Result> ChangePhone(BaseAccount account,Phone phone);
        Task<Result> ChangeEmail(BaseAccount account, Email email);
        Task<Result> ChangeUsername(BaseAccount account, Username username);
         
    }
}