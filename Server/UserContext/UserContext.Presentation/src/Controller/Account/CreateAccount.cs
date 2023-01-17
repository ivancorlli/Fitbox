using MediatR;
using SharedKernell.src.Result;
using SharedKernell.src.Utils;
using UserContext.Application.src.Features.UserAccount.Command.CreateAccount;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Presentation.src.Controller.Account;

public static class CreateAccount
{
    public static async Task<Result> PostAsync(ISender sender, CreateAccountInput input)
    {

        var command = new CreateAccountCommand(input);
        var result = await sender.Send(command);
        return result;


    }
}
