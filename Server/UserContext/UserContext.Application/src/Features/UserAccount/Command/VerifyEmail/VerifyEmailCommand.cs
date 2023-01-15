using Application.src.Features.UserAccount.DTO.Input;
using Shared.src.Error;
using SharedKernell.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.VerifyEmail
{
    public sealed record VerifyEmailCommand(VerifyEmailInput Input):ICommand<Result>;
    
}