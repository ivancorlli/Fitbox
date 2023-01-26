using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserContext.Application.src.Features.Person.DTO.Input
{
    public sealed record ChangePhoneInput(Guid id, int area, long number, string? prefix);

}