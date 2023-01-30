using SharedKernell.src.Entity;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.Interface.Entity;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Abstractions;

public abstract class IGymProfile : BaseEntity, IBaseGym
{
    protected IGymProfile() { }
    public GymName Name { get; protected set; } = default!;
    public Address Address { get; protected set; } = default!;
    public Guid AccountId { get; init; } = default!;
    public Gym Account { get; init; } = default!;
    public Bio? Bio {get; protected set; }


    protected IGymProfile(GymName name, Address address, Gym account)
    {
        Name = name;
        Address = address;
        Account = account;
        AccountId = account.Id;
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
