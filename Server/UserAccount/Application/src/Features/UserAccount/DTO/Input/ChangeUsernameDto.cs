using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.src.Features.UserAccount.DTO.Input
{
    public record ChangeUsernameDto(Guid id, string username);
}