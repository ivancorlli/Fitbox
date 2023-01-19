using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserContext.Application.src.Features.UserAccount.DTO.Input
{
    public sealed record ChangeEmailInput(Guid Id, string Email);
}