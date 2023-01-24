using SharedKernell.src.Entity;
using UserContext.Domain.src.Interface.Entity;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Abstractions;

public abstract class BaseGym : BaseEntity, IBaseGym
{
    protected BaseGym() { }
    public GymName Name { get; protected set; }
    public Address Address {get; protected set; }
    public List<OperatingTime> Hours {get; protected set; }
    public List<Guid>? Trainings {get; protected set; }
    public Bio? Bio {get; protected set; }

    protected BaseGym(GymName name, Address address, List<OperatingTime> hours)
    {
        Name = name;
        Address = address;
        Hours = hours;
    }

    public void AddTrainings(List<Guid> trainingsids)
    {
        throw new NotImplementedException();
    }

    public void AddTrainning(Guid trainingId)
    {
        throw new NotImplementedException();
    }

    public void AdjustHours(OperatingTime time)
    {
        throw new NotImplementedException();
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
