using MediatR;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.UserAccount.Command.VerifyPhone;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Presentation.src.Controller.Account;

public static class VerifyPhone
{
    public static async Task<Result> PatchAsync(ISender sender, VerifyPhoneInput input)
    {
        var command = new VerifyPhoneCommand(input);
        var result = await sender.Send(command);
        return result;
    }
}
