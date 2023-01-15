using Application.src.Features.UserAccount.DTO.Input;
using Shared.src.Error;
using SharedKernell.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.CreateAccount
{
    public sealed record CreateAccountCommand(CreateAccountInput newAccount) : ICommand<Result>;
}