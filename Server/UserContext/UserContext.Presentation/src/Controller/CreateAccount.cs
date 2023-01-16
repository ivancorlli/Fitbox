
using Application.src.Features.UserAccount.Command.CreateAccount;
using Application.src.Features.UserAccount.DTO.Input;
using MediatR;

namespace UserContext.Presentation.src.Controller;

public static class CreateAccount
{
    public static async Task PostAsync(ISender sender, CreateAccountInput input)
    {
        var command = new CreateAccountCommand(input);
        await sender.Send(command);
    }
}
