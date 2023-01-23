using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Application.src.Errors;

public class ProfileNotExists : DomainError
{
    public ProfileNotExists() : base(ErrorTypes.NotFound, "No existe un perfil asociado a esta cuenta")
    {
    }

    public ProfileNotExists(string type, string message) : base(type, message)
    {
    }
}