using SharedKernell.src.Result;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Interface
{
    public interface IAccountManager<T> where T : IAccount
    {
        abstract Task<Result<IAccount>> CreateAccount(Email email);
        abstract Task<Result<IAccount>> CreateAccount(Username username, Email email, string password);
        Task<Result> ChangePhone(T account, Phone phone);
        Task<Result> ChangeEmail(T account, Email email);
        Task<Result> ChangeUsername(T account, Username username);

    }
}