using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Profile.DTO.Input;

namespace UserContext.Application.src.Features.Profile.Command.ChangeMedicalInfo;

public sealed record ChangeMedicalInfoCommand(ChangeMedicalInfoInput Input) : ICommand<Result>;