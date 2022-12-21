
using Application.src.Features.UserAccount.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.UserAccount.Command.VerifyPhone;

public sealed record VerifyPhoneCommand(VerifyPhoneInput Input):ICommand<Result>;