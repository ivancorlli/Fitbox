using MediatR;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.UserAccount.Command.VerifyEmail;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Presentation.src.Controller.Account;

public static class VerifyEmail
{
    public static async Task<Result> PatchAsync(ISender sender, VerifyEmailInput input)
    {
        var command = new VerifyEmailCommand(input);
        var result = await sender.Send(command);
        return result;
    }
}
