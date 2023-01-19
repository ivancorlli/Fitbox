using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Application.src.Features.UserAccount.Command.CreateAccount
{
    public sealed record CreateAccountCommand(CreateAccountInput newAccount) : ICommand<Result>;
}