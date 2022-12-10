using Application.src.Features.Account.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Account.Command.VerifyEmail
{
    public sealed record VerifyEmailCommand(VerifyEmailInput verifyEmail) : ICommand<Result>;
}