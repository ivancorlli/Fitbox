using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Account.DTO.Input;

namespace UserContext.Application.src.Features.Account.Command.ChangePhone
{
    public sealed record ChangePhoneCommand(ChangePhoneInput input) : ICommand<Result>;

}