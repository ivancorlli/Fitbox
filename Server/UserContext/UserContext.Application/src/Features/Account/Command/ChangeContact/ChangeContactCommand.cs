using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Account.DTO.Input;

namespace UserContext.Application.src.Features.Account.Command.ChangeContact;

public sealed record ChangeContactCommand(ChangeContactInput Input) : ICommand<Result>;
