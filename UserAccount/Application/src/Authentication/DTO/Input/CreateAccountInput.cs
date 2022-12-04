using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.src.Authentication.DTO.Input
{
    public record CreateAccountInput(
        string username, 
        string email, 
        string password)
        {}
}