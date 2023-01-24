using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Interface.Entity;

public interface IBaseAccount
{
    public Username Username { get; }
    public Email Email { get; }
    public Password Password { get; }
    public AccountStatus Status { get;}
    public AccountType? AccountType { get;}
    public bool IsNew { get; }
    public bool EmailVerified { get; }
    public bool PhoneVerified { get; }
    public Phone? Phone { get; }

}