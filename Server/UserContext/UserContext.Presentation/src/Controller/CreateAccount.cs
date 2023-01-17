using MediatR;
using UserContext.Application.src.Features.UserAccount.Command.CreateAccount;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Presentation.src.Controller;

public static class CreateAccount
{
    public static async Task PostAsync(ISender sender, CreateAccountInput input)
    {
        var command = new CreateAccountCommand(input);
        await sender.Send(command);
    }
}
