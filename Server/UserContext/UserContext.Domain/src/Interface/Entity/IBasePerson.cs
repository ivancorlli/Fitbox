using SharedKernell.src.Result;
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
    public void ChangeName(PersonName name);
    public void ChangeGender(Gender gender);
    public Result ChangeBirth(DateTime birth);
    public void ChangeBio(Bio bio);
    public void CreateContact(PersonName name, RelationShip relationShip, ContactPhone phone);
    public void DeleteContact();
    public void CreateMedicalInfo(MedicalInfo medical);
    public void DeleteMedicalInfo();
}