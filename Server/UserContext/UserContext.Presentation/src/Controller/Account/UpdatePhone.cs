using MediatR;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.UserAccount.Command.ChangePhone;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Presentation.src.Controller.Account;

public static class UpdatePhone
{
    public static async Task<Result> PatchAsync(ISender sender, ChangePhoneInput input)
    {
        var command = new ChangePhoneCommand(input);
        var result = await sender.Send(command);
        return result;
    }
}
