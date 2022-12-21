
using Application.src.Features.UserAccount.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.ChangeEmail
{
    public sealed record ChangeEmailCommand(ChangeEmailInput Input):ICommand<Result>;
}