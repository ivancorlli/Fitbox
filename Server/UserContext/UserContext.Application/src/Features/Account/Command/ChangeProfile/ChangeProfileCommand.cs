using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Account.DTO.Input;

namespace UserContext.Application.src.Features.Account.Command.CreatePerson;

public sealed record ChangeProfileCommand(ChangeProfileInput Input) : ICommand<Result>;
