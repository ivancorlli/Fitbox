using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Interface.Entity;

internal interface IBaseGym
{
    public GymName Name { get; }
    public Address Address { get; }
    public List<OperatingTime> Hours { get; }
    public List<Guid>? Trainings { get; }
    public Bio? Bio { get; }

    public void ChangeName(GymName name);
    public void ChangeAddres(Address address);
    public void AddTrainning(Guid trainingId);
    public void AddTrainings(List<Guid> trainingsids);
    public void AdjustHours(OperatingTime time);
}
