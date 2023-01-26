using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserContext.Application.src.Features.Person.DTO.Input
{
    public record ChangeUsernameInput(Guid id, string username);
}