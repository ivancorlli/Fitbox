using SharedKernell.src.Result;
using UserContext.Application.src.Features.Profile.DTO.Input;

namespace UserContext.Presentation.src.Interface;

public interface IProfileController
{
    Task<Result> CreatePerson(CreatePersonInput input);
    Task<Result> CreateAddress(CreateAddressInput input);
    Task<Result> CreateContact(CreateContactInput input);
    Task<Result> CreateMedicalInfo(CreateMedicalInfoInput input);
    Task<Result> DeleteContact(DeleteContactInput input);
    Task<Result> DeleteMedicalInfo(DeleteMedicalinfoInput input);
    Task<Result> ChangeMedicalInfo(ChangeMedicalInfoInput input);
    Task<Result> ChangeContact(ChangeContactInput input);
    Task<Result> ChangePerson(ChangePersonInput input);
}
