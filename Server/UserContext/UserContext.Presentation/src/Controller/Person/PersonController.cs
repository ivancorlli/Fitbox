
using MediatR;
using SharedKernell.src.Controller;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.PersonAccount.Command.ChangeEmail;
using UserContext.Application.src.Features.PersonAccount.Command.ChangePassword;
using UserContext.Application.src.Features.PersonAccount.Command.ChangePhone;
using UserContext.Application.src.Features.PersonAccount.Command.ChangeUsername;
using UserContext.Application.src.Features.PersonAccount.Command.CreateAccount;
using UserContext.Application.src.Features.PersonAccount.Command.VerifyEmail;
using UserContext.Application.src.Features.PersonAccount.Command.VerifyPhone;
using UserContext.Presentation.src.Interface;
using UserContext.Application.src.Features.PersonAccount.Command.ChangeMedicalInfo;
using UserContext.Application.src.Features.PersonAccount.Command.ChangeContact;
using UserContext.Application.src.Features.PersonAccount.Command.ChangeProfile;
using UserContext.Application.src.Features.PersonAccount.Command.ChangeAddress;
using UserContext.Application.src.Features.PersonAccount.DTO.Input;

namespace UserContext.Presentation.src.Controller.Person;

internal class PersonController : BaseController, IPersonController
{
    public PersonController(IMediator mediator) : base(mediator)
    {
    }

    public async Task<Result> ChangeEmail(ChangeEmailInput input)
    {
        var command = new ChangeEmailCommand(input);
        var result = await _Mediator.Send(command);
        return result;
    }

    public async Task<Result> ChangePassword(ChangePasswordInput input)
    {
        var command = new ChangePasswordCommand(input);
        var result = await _Mediator.Send(command);
        return result;
    }

    public async Task<Result> ChangePhone(ChangePhoneInput input)
    {
        var command = new ChangePhoneCommand(input);
        var result = await _Mediator.Send(command);
        return result;
    }

    public Task<Result> ChangeUsername(ChangeUsernameInput input)
    {
        var command = new ChangeUsernameCommand(input);
        var result = _Mediator.Send(command);
        return result;
    }

    public async Task<Result> CreateAccount(CreateAccountInput input)
    {
        var command = new CreateAccountCommand(input);
        var result = await _Mediator.Send(command);
        return result;
    }

    public async Task<Result> VerifyEmail(VerifyEmailInput input)
    {
        var command = new VerifyEmailCommand(input);
        var result = await _Mediator.Send(command);
        return result;
    }

    public async Task<Result> VerifyPhone(VerifyPhoneInput input)
    {
        var command = new VerifyPhoneCommand(input);
        var result = await _Mediator.Send(command);
        return result;
    }
    public async Task<Result> ChangeContact(ChangeContactInput input)
    {
        var command = new ChangeContactCommand(input);
        var result = await _Mediator.Send(command);
        return result;
    }

    public async Task<Result> ChangeMedicalInfo(ChangeMedicalInfoInput input)
    {
        var command = new ChangeMedicalInfoCommand(input);
        var result = await _Mediator.Send(command);
        return result;
    }

    public async Task<Result> ChangeProfile(ChangeProfileInput input)
    {
        var command = new ChangeProfileCommand(input);
        var result = await _Mediator.Send(command);
        return result;
    }

    public async Task<Result> ChangeAddress(ChangeAddressInput input)
    {
        var command = new ChangeAddressCommand(input);
        var result = await _Mediator.Send(command);
        return result;
    }
}
