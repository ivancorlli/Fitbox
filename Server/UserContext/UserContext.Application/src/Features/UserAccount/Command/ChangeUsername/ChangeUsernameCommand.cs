using Application.src.Features.UserAccount.DTO.Input;
using Shared.src.Error;
using SharedKernell.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.ChangeUsername
{
    public sealed record ChangeUsernameCommand(ChangeUsernameInput input) :ICommand<Result>;
}