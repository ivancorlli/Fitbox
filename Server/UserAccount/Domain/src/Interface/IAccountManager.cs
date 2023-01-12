
using Domain.src.ValueObject;
using Shared.src.Error;

namespace Domain.src.Interface
{
    public interface IAccountManager
    {
        Task<Result<IAccount>> CreateAccount(Username username, Email email, Password password);
        Task<Result<Phone>> CreatePhone(int areaCode, long number, string? prefix);
         
    }
}