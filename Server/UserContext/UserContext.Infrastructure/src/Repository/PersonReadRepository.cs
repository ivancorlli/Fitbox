using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Repository;
using UserContext.Infrastructure.src.Context;

namespace UserContext.Infrastructure.src.Repository;

public sealed class PersonReadRepository : IPersonReadRepository
{
    private readonly UserDbContext _PersonContext;

    public PersonReadRepository(UserDbContext personContext) => _PersonContext = personContext;
    public async Task<Person?> GetByIdAsync(Guid Id)
    {
        var personFound = await _PersonContext.Person.FindAsync(Id);
        return personFound;
    }
}
