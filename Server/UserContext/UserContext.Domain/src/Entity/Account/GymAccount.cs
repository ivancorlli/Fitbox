using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Entity.Account;

public class GymAccount : BaseAccount
{
    private GymAccount() { }
    public Guid GymCreator { get; init;}
    public Gym? GymProfile { get; private set; }
    private GymAccount(Username username, Email email, Password password,Guid creator) : base(username, email, password)
    {
        GymCreator= creator;
    }
}
