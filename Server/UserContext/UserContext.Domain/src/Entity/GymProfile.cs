using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Entity;

public class GymProfile : IGymProfile
{
    private GymProfile() { }
    public GymProfile(GymName name, Address address, Gym account) : base(name, address, account)
    {
    }
}