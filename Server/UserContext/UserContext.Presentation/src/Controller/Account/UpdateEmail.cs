using MediatR;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.UserAccount.Command.ChangeEmail;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Presentation.src.Controller.Account;

public static class UpdateEmail
{
    public static async Task<Result> PatchAsync(ISender sender, ChangeEmailInput input)
    {
        var command = new ChangeEmailCommand(input);
        var result = await sender.Send(command);
        return result;
    }

}
