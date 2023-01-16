using Domain.src.Error;
using SharedKernell.src.Result;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.Repository;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Domain.src.Service;

public class PersonManager : IPersonManager
{
    private readonly IPersonReadRepository _PersonRepo;

    public PersonManager(IPersonReadRepository personRepo)
    {
        _PersonRepo = personRepo;
    }

    public async Task<Result<Person>> CreatePerson(Guid account, PersonName name, Gender gender, DateTime birth)
    {
        var personExists = await _PersonRepo.GetByIdAsync(account);
        if (personExists != null)
            return Result.Fail<Person>(new PersonExists(personExists.Name.ToString()));
        var newPerson = Person.Create(account, name, gender, birth);
        if (newPerson.IsFailure)
            return Result.Fail<Person>(new ValidationError(newPerson.Error.Message));

        return Result.Ok(newPerson.Value);

    }
}