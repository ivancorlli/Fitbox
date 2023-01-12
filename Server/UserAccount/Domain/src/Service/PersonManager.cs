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

    public async Task<Result<IPerson>> CreatePerson(Guid account, PersonName name, Gender gender, DateTime birth)
    {
        var personExists = await _PersonRepo.GetById(account);
        if(personExists.IsSuccess)
            return Result.Fail<IPerson>(new PersonExists(personExists.Value.Name.ToString()));
        var newPerson = Person.Create(account,name,gender,birth);
        if(newPerson.IsFailure)
            return Result.Fail<IPerson>(new ValidationError(newPerson.Error.Message));

            return Result.Ok<IPerson>(newPerson.Value);
    }
}