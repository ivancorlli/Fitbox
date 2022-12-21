using Application.src.Features.UserAccount.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.ChangePassword
{
    public sealed record ChangePasswordCommand(ChangePasswordInput Input):ICommand<Result>;
}