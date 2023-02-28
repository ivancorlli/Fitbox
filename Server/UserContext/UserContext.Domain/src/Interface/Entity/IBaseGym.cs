using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Interface.Entity;

internal interface IBaseGym
{
    public GymName Name { get; }
    public Guid AccountId { get; }
    public Address Address { get; }
    public Bio? Bio { get; }
}
