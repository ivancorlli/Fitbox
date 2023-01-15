using Domain.src.Entity;
using Domain.src.Enum;
using Domain.src.Error;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;

namespace Domain.src.Service;

public class PersonManager:IPersonManager
{
    private readonly IPersonReadRepository _PersonRepo;

    public PersonManager(IPersonReadRepository personRepo)
    {
        _PersonRepo = personRepo;
    }

    public async Task<Result<Person>> CreatePerson(Guid account, PersonName name, Gender gender, DateTime birth)
    {
        var personExists = await _PersonRepo.GetByIdAsync(account);
        if(personExists != null)
            return Result.Fail<Person>(new PersonExists(personExists.Name.ToString()));
        var newPerson = Person.Create(account,name,gender,birth);
        if(newPerson.IsFailure)
            return Result.Fail<Person>(new ValidationError(newPerson.Error.Message));

            return Result.Ok<Person>(newPerson.Value);
        
    }
}