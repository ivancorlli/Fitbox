using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Account.DTO.Input;

namespace UserContext.Application.src.Features.Account.Command.CreateAddress;

public sealed record ChangeAddressCommand(ChangeAddressInput Input) : ICommand<Result>;