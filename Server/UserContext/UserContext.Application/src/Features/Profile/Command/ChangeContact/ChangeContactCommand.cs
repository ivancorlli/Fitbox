using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Profile.DTO.Input;

namespace UserContext.Application.src.Features.Profile.Command.ChangeContact;

public sealed record ChangeContactCommand(ChangeContactInput Input) : ICommand<Result>;