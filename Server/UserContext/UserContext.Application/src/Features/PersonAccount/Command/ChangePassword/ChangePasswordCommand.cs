using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Person.DTO.Input;

namespace UserContext.Application.src.Features.Person.Command.ChangePassword
{
    public sealed record ChangePasswordCommand(ChangePasswordInput Input) : ICommand<Result>;
}