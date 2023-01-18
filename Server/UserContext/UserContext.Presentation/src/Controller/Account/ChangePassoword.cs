using MediatR;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.UserAccount.Command.ChangePassword;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Presentation.src.Controller.Account;

public static class ChangePassword
{
    public static async Task<Result> PatchAsync(ISender sender, ChangePasswordInput input)
    {
        var command = new ChangePasswordCommand(input);
        var result = await sender.Send(command);
        return result;
    }
}
