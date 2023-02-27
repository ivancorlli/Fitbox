
using SharedKernell.src.Result;
using UserContext.Application.src.Features.PersonAccount.DTO.Input;
using UserContext.Application.src.Features.PersonAccount.DTO.Output;

namespace UserContext.Presentation.src.Interface;

public interface IPersonController
{
    Task<Result<CreateAccountOutput>> CreateAccount(CreateAccountInput Input);
    Task<Result<CreateProfileOutput>> CreateProfile(CreateProfileInput Input);
}
