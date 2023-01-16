using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Repository;
using UserContext.Infrastructure.src.Context;

namespace UserContext.Infrastructure.src.Repository
{
    public sealed class PersonWriteRepository : IPersonWriteRepository
    {
        private readonly UserDbContext _PersonContext;

        public PersonWriteRepository(UserDbContext pContx)
        {
            _PersonContext = pContx;
        }

        public async Task AddAsync(Person Entity)
        {
            var personCreated = await _PersonContext.Person.AddAsync(Entity);
        }

        public void Delete(Person entity)
        {
            var personDeleted = _PersonContext.Person.Remove(entity);
        }

        public void Update(Person entity)
        {
            var personUpdated = _PersonContext.Person.Update(entity);
        }
    }
}
