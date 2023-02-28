
using MediatR;
using SharedKernell.src.Controller;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.PersonAccount.Command.CreateAccount;
using UserContext.Application.src.Features.PersonAccount.Command.CreateProfile;
using UserContext.Application.src.Features.PersonAccount.DTO.Input;
using UserContext.Application.src.Features.PersonAccount.DTO.Output;
using UserContext.Presentation.src.Interface;


namespace UserContext.Presentation.src.Controller.Person;

internal class PersonController : BaseController, IPersonController
{
    public PersonController(IMediator mediator) : base(mediator)
    {
    }

    public async Task<Result<CreateAccountOutput>> CreateAccount(CreateAccountInput Input)
    {
        var command = new CreateAccountCommand(Input);
        var result  = await _Mediator.Send(command);
        if (result.IsFailure)
            return Result.Fail<CreateAccountOutput>(result.Error);
        return Result.Ok(result.Value);
    }

    public async Task<Result<CreateProfileOutput>> CreateProfile(CreateProfileInput Input)
    {
        var command = new CreateProfileCommand(Input);
        var result = await _Mediator.Send(command);
        if (result.IsFailure)
            return Result.Fail<CreateProfileOutput>(result.Error);
        return Result.Ok(result.Value);
    }
}
