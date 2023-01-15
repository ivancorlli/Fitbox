
using Application.src.Features.UserAccount.DTO.Input;
using Shared.src.Error;
using SharedKernell.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.ChangePhone
{
    public sealed record ChangePhoneCommand(ChangePhoneInput input):ICommand<Result>;
    
}