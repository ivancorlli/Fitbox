using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Person.DTO.Input;

namespace UserContext.Application.src.Features.Person.Command.ChangeAddress;

public sealed record ChangeAddressCommand(ChangeAddressInput Input) : ICommand<Result>;