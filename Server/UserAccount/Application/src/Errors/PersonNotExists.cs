using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.src.Constant;
using Shared.src.Error;

namespace Application.src.Errors;

public class PersonNotExists : DomainError
{
    public PersonNotExists() : base(ErrorTypes.NotFound, "No existe un perfil asociado a esta cuenta")
    {
    }

    public PersonNotExists(string type, string message) : base(type, message)
    {
    }
}