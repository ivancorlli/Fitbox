﻿using Domain.src.Entity;
using Domain.src.Interface;
using Infrastructure.src.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.src.Repository
{
    public sealed class PersonWriteRepository : IPersonWriteRepository
    {
        private readonly UserDbContext _PersonContext;

        public PersonWriteRepository(UserDbContext pContx)
        {
            _PersonContext = pContx;
        }

        public void Add(Person Entity)
        {
            var personCreated = _PersonContext.Person.Add(Entity);
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
