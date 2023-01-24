using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Entity;

public class Gym : BaseGym
{
    private Gym() { }
    private Gym(GymName name, Address address, List<OperatingTime> hours) : base(name, address, hours)
    {
    }
}