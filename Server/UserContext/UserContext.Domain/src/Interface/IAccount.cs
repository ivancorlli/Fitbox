using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Interface;

public interface IAccount
{
    public Username Username { get; }
    public Email Email { get; }
    public AccountStatus Status { get; }
    public Password Password { get; }
    public bool IsNew { get; }
    public bool EmailVerified { get; }

}