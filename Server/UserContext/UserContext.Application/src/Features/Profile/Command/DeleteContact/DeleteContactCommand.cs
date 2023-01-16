using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Profile.DTO.Input;

namespace UserContext.Application.src.Features.Profile.Command.DeleteContact;

public sealed record DeleteContactCommand(DeleteContactInput Input) : ICommand<Result>;