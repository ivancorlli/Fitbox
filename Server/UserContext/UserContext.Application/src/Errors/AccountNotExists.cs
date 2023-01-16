using SharedKernell.src.Constant;
using SharedKernell.src.Error;

namespace UserContext.Application.src.Errors;

public class AccountNotExists : DomainError
{
    public AccountNotExists() : base(ErrorTypes.NotFound, "Cuenta inexistente")
    {
    }

    public AccountNotExists(string type, string message) : base(type, message)
    {
    }
}