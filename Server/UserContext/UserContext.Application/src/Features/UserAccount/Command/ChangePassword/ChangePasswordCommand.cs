using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Application.src.Features.UserAccount.Command.ChangePassword
{
    public sealed record ChangePasswordCommand(ChangePasswordInput Input) : ICommand<Result>;
}