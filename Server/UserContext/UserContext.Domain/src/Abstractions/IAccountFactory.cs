using SharedKernell.src.Result;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Abstractions;

public abstract class IAccountFactory
{
    public abstract Result<IAccount> CreateAccount(Username username, Email email, string password);
}
