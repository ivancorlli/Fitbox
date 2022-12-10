
using Domain.src.ValueObject;
using Shared.src.Error;

namespace Domain.src.Interface
{
    public interface IUserManager
    {
        Task<Result<Username>> CreateUsername(string username); 
        Task<Result<Email>> CreateEmail(string email);
        Task<Result<Phone>> CreatePhone(int areaCode, long number, string? prefix);
         
    }
}