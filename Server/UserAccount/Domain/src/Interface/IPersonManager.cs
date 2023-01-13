
using Domain.src.Entity;
using Domain.src.Enum;
using Domain.src.ValueObject;
using Shared.src.Error;

namespace Domain.src.Interface;

public interface IPersonManager
{

    Task<Result<Person>> CreatePerson(Guid account, PersonName name, Gender gender, DateTime birth);    
}