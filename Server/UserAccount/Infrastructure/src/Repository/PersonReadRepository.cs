using Domain.src.Entity;
using Domain.src.Interface;
using Infrastructure.src.Context;
using Shared.src.Error;

namespace Infrastructure.src.Repository;

public sealed class PersonReadRepository : IPersonReadRepository
{
    private readonly UserDbContext _PersonContext;

    public PersonReadRepository(UserDbContext personContext) => _PersonContext = personContext;
    public Person? GetById(Guid Id)
    {
        var personFound = _PersonContext.Person.Find(Id);
        return personFound;
    }
}
