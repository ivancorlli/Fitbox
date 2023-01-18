using MediatR;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Profile.Command.ChangeContact;
using UserContext.Application.src.Features.Profile.Command.ChangeMedicalInfo;
using UserContext.Application.src.Features.Profile.Command.ChangePerson;
using UserContext.Application.src.Features.Profile.Command.CreateAddress;
using UserContext.Application.src.Features.Profile.Command.CreateContact;
using UserContext.Application.src.Features.Profile.Command.CreateMedicalInfo;
using UserContext.Application.src.Features.Profile.Command.CreatePerson;
using UserContext.Application.src.Features.Profile.Command.DeleteContact;
using UserContext.Application.src.Features.Profile.Command.DeleteMedicalInfo;
using UserContext.Application.src.Features.Profile.DTO.Input;
using UserContext.Presentation.src.Interface;

namespace UserContext.Presentation.src.Controller.Profile;

internal class ProfileController : IProfileController
{

    private readonly ISender _Sender;
    public ProfileController(ISender sender) => _Sender = sender;

    public async Task<Result> ChangeContact(ChangeContactInput input)
    {
        var command = new ChangeContactCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public async Task<Result> ChangeMedicalInfo(ChangeMedicalInfoInput input)
    {
        var command = new ChangeMedicalInfoCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public async Task<Result> ChangePerson(ChangePersonInput input)
    {
        var command = new ChangePersonCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public async Task<Result> CreateAddress(CreateAddressInput input)
    {
        var command = new CreateAddressCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public async Task<Result> CreateContact(CreateContactInput input)
    {
        var command = new CreateContactCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public async Task<Result> CreateMedicalInfo(CreateMedicalInfoInput input)
    {
        var command = new CreateMedicalInfoCommand(input);
        var result = await _Sender.Send(command);
        return result; 
    }

    public async Task<Result> CreatePerson(CreatePersonInput input)
    {
        var command = new CreatePersonCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public async Task<Result> DeleteContact(DeleteContactInput input)
    {
        var command = new DeleteContactCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }

    public async Task<Result> DeleteMedicalInfo(DeleteMedicalinfoInput input)
    {
        var command = new DeleteMedicalInfoCommand(input);
        var result = await _Sender.Send(command);
        return result;
    }
}
