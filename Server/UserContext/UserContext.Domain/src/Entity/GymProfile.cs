using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Entity;

public class GymProfile : IGymProfile
{
    private GymProfile() { }
    private GymProfile(GymName name, Address address) : base(name, address)
    {
    }
}