using Domain.src.Error;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Shared.src.Error;

namespace Domain.src.Service
{
    public sealed class UserManager:IUserManager
    {
        private readonly IUserReadRepository _UserRepo;

        public UserManager(IUserReadRepository repo){
            _UserRepo = repo;
        }

        public async Task<Result<Email>> CreateEmail(string email)
        {
            var newEmail = Email.Create(email);
            if(newEmail.IsFailure)
                return Result.Fail<Email>(newEmail.Error);
            var emailExists = await _UserRepo.IsEmailInUse(newEmail.Value);
            if(emailExists)
                return Result.Fail<Email>(new EmailAlreadyInUse(newEmail.Value.Value));
            return Result.Ok<Email>(newEmail.Value);   
        }

        public async Task<Result<Phone>> CreatePhone(int areaCode, long number, string? prefix)
        {
            var newPhone = Phone.Create(areaCode,number);
            if(!string.IsNullOrEmpty(prefix)){
                newPhone = Phone.Create(areaCode,number,prefix);
            }
            if(newPhone.IsFailure)
                return Result.Fail<Phone>(newPhone.Error);
            var phoneExists = await _UserRepo.IsPhoneInUse(newPhone.Value);
            if(phoneExists)
                return Result.Fail<Phone>(new PhoneAlreadyInUse(newPhone.Value.ToString()));
            return Result.Ok<Phone>(newPhone.Value);

        }

        public async Task<Result<Username>> CreateUsername(string username)
        {
            var newUsername = Username.Create(username);
            if(newUsername.IsFailure)
                return Result.Fail<Username>(newUsername.Error);
            var usernameExists = await _UserRepo.IsUsernameInUse(newUsername.Value);
            if(usernameExists)
                return Result.Fail<Username>(new UsernameAlreadyInUse(newUsername.Value.Value));
            return Result.Ok<Username>(newUsername.Value);
        }
    }
}