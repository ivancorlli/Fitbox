
using SharedKernell.src.Result;
using UserContext.Application.src.Features.PersonAccount.DTO.Input;

namespace UserContext.Presentation.src.Interface;

public interface IPersonController
{
    Task<Result> CreateAccount(CreateAccountInput Input);
}
