using SharedKernell.src.Result;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Interface;

public interface IPerson
{
    public Guid AccountId { get; init; }
    public PersonName Name { get; }
    public Gender Gender { get; }
    public DateTime Birth { get; }
    public void ChangeName(PersonName name);
    public void ChangeGender(Gender gender);
    public Result ChangeBirth(DateTime birth);
}