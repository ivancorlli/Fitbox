using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.PersonAccount.DTO.Input;

namespace UserContext.Application.src.Features.PersonAccount.Command.ChangeUsername
{
    public sealed record ChangeUsernameCommand(ChangeUsernameInput input) : ICommand<Result>;
}