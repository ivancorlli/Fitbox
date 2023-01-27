using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.PersonAccount.DTO.Input;

namespace UserContext.Application.src.Features.PersonAccount.Command.VerifyEmail
{
    public sealed record VerifyEmailCommand(VerifyEmailInput Input) : ICommand<Result>;

}