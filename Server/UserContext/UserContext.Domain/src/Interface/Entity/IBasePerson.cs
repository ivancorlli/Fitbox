using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Interface.Entity;

public interface IBasePerson
{
    public PersonName Name { get; }
    public Gender Gender { get; }
    public DateTime Birth { get; }
    public EmergencyContact? EmergencyContact { get; }
    public Bio? Bio { get; }
    public MedicalInfo? Medical { get;}
}