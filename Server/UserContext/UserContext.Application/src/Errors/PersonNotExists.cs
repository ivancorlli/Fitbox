using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Application.src.Errors;

public class PersonNotExists : DomainError
{
    public PersonNotExists() : base(ErrorTypes.NotFound, "No existe un perfil asociado a esta cuenta")
    {
    }

    public PersonNotExists(string type, string message) : base(type, message)
    {
    }
}