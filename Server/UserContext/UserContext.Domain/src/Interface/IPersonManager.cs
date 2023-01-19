using SharedKernell.src.Result;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Interface;

public interface IPersonManager
{

    Task<Result<Person>> CreatePerson(Guid account, PersonName name, Gender gender, DateTime birth);
}