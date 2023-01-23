using SharedKernell.src.Result;
using UserContext.Application.src.Features.Account.DTO.Input;

namespace UserContext.Presentation.src.Interface;

public interface IAccountController
{
    Task<Result> CreateAccount(CreateAccountInput input);
    Task<Result> ChangeEmail(ChangeEmailInput input);
    Task<Result> ChangeUsername(ChangeUsernameInput input);
    Task<Result> ChangePhone(ChangePhoneInput input);
    Task<Result> ChangePassword(ChangePasswordInput input);
    Task<Result> VerifyEmail(VerifyEmailInput input);
    Task<Result> VerifyPhone(VerifyPhoneInput input);
    Task<Result> ChangeProfile(ChangeProfileInput input);
    Task<Result> ChangeAddress(ChangeAddressInput input);
    Task<Result> ChangeContact(ChangeContactInput input);
    Task<Result> ChangeMedicalInfo(ChangeMedicalInfoInput input);
}
