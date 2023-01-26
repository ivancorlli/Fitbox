using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Person.DTO.Input;

namespace UserContext.Application.src.Features.Person.Command.ChangeEmail
{
    public sealed record ChangeEmailCommand(ChangeEmailInput Input) : ICommand<Result>;
}