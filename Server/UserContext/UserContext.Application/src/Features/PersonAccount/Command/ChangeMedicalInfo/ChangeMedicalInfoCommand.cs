using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Person.DTO.Input;

namespace UserContext.Application.src.Features.Person.Command.ChangeMedicalInfo;

public sealed record ChangeMedicalInfoCommand(ChangeMedicalInfoInput Input) : ICommand<Result>;
