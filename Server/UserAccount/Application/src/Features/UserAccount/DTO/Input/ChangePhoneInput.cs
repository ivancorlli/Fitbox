using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.src.Features.UserAccount.DTO.Input
{
    public sealed record ChangePhoneInput(Guid id, int area,long number, string? prefix);
    
}