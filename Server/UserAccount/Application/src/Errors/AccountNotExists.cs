using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.src.Constant;
using Shared.src.Error;

namespace Application.src.Errors;

public class AccountNotExists : DomainError
{
    public AccountNotExists() : base(ErrorTypes.NotFound, "Cuenta inexistente")
    {
    }

    public AccountNotExists(string type, string message) : base(type, message)
    {
    }
}