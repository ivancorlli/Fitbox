
using MediatR;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.UserAccount.Command.ChangeEmail;
using UserContext.Application.src.Features.UserAccount.Command.ChangePassword;
using UserContext.Application.src.Features.UserAccount.Command.ChangePhone;
using UserContext.Application.src.Features.UserAccount.Command.ChangeUsername;
using UserContext.Application.src.Features.UserAccount.Command.CreateAccount;
using UserContext.Application.src.Features.UserAccount.Command.VerifyEmail;
using UserContext.Application.src.Features.UserAccount.Command.VerifyPhone;
using UserContext.Application.src.Features.UserAccount.DTO.Input;
using UserContext.Presentation.src.Interface;

namespace UserContext.Presentation.src.Controller.Account;

internal class AccountController:IAccountController
{
    private readonly ISender _Sender;
    public AccountController(ISender sender)
    {
        _Sender = sender;
    }

    public async Task<Result> ChangeEmail(ChangeEmailInput input)
    {
        var command = new ChangeEmailCommand(input);
        var result = await _Sender.Send(command);
        return result; 
    }

    public async Task<Result> ChangePassword(ChangePasswordInput input)
    {
        var command = new ChangePasswordCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public async Task<Result> ChangePhone(ChangePhoneInput input)
    {
        var command = new ChangePhoneCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public Task<Result> ChangeUsername(ChangeUsernameInput input)
    {
        var command = new ChangeUsernameCommand(input);
        var result = _Sender.Send(command);
        return result;
    }

    public async Task<Result> CreateAccount(CreateAccountInput input)
    {
        var command = new CreateAccountCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public async Task<Result> VerifyEmail(VerifyEmailInput input)
    {
        var command = new VerifyEmailCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public async Task<Result> VerifyPhone(VerifyPhoneInput input)
    {
        var command = new VerifyPhoneCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }
}
