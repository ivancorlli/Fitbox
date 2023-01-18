using MediatR;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.UserAccount.Command.ChangeUsername;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Presentation.src.Controller.Account;

public static class ChangeUsername
{

    public static async Task<Result> PatchAsync(ISender sender, ChangeUsernameInput input)
    {
        var command = new ChangeUsernameCommand(input);
        var result = await sender.Send(command);
        return result;
    }
}
