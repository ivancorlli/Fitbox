
using MediatR;
using SharedKernell.src.Controller;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.PersonAccount.Command.CreateAccount;
using UserContext.Application.src.Features.PersonAccount.DTO.Input;
using UserContext.Presentation.src.Interface;


namespace UserContext.Presentation.src.Controller.Person;

internal class PersonController : BaseController, IPersonController
{
    public PersonController(IMediator mediator) : base(mediator)
    {
    }

    public async Task<Result> CreateAccount(CreateAccountInput Input)
    {
        var command = new CreateAccountCommand(Input);
        var result  = await _Mediator.Send(command);
        return result;
    }
}
