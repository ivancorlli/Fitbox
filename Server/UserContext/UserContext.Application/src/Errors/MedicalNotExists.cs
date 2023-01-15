using Shared.src.Constant;
using SharedKernell.src.Error;

namespace Application.src.Errors;

public class MedicalNotExists : DomainError
{
    public MedicalNotExists() : base(ErrorTypes.NotFound, "No existe un registro medico asociado a esta cuenta")
    {
    }

    public MedicalNotExists(string type, string message) : base(type, message)
    {
    }
}