using MediatR;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.UserAccount.Command.CreateAccount;
using UserContext.Application.src.Features.UserAccount.DTO.Input;

namespace UserContext.Presentation.src.Controller.Account;

public class CreateAccount
{
    private static ISender _Sender;
    public static async Task<Result> Exec(CreateAccountInput input)
    {

        var command = new CreateAccountCommand(input);
        var result = await _Sender.Send(command);
        return result;


    }
}
