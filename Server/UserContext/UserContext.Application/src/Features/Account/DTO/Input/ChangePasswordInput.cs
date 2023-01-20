using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserContext.Application.src.Features.Account.DTO.Input
{
    public sealed record ChangePasswordInput(Guid Id, string Password);
}