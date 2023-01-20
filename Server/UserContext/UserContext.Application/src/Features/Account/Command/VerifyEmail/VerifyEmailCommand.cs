using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Account.DTO.Input;

namespace UserContext.Application.src.Features.Account.Command.VerifyEmail
{
    public sealed record VerifyEmailCommand(VerifyEmailInput Input) : ICommand<Result>;

}