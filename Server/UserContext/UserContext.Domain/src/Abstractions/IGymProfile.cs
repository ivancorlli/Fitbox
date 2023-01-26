using SharedKernell.src.Entity;
using UserContext.Domain.src.Interface.Entity;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Abstractions;

public abstract class IGymProfile : BaseEntity, IBaseGym
{
    protected IGymProfile() { }
    public GymName Name { get; protected set; }
    public Address Address { get; protected set; }
    public Bio? Bio {get; protected set; }

    protected IGymProfile(GymName name, Address address)
    {
        Name = name;
        Address = address;
    }

    public void ChangeAddres(Address address)
    {
        throw new NotImplementedException();
    }

    public void ChangeName(GymName name)
    {
        throw new NotImplementedException();
    }
}
