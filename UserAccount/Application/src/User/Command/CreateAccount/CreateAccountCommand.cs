using Application.src.User.Dto.Input;
using MediatR;

namespace Application.src.User.Command.CreateAccount
{
    public record CreateAccountCommand(CreateAccountDto newAccount):IRequest;
}