using Application.src.Features.Authentication.DTO.Input;
using Application.src.Interface;

namespace Application.src.Features.Authentication.Command.CreateAccount
{
    public sealed record CreateAccountCommand(CreateAccountInput newAccount) : ICommand;
}