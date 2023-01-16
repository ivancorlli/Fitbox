using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Profile.DTO.Input;

namespace UserContext.Application.src.Features.Profile.Command.UpdateMedicalInfo;

public sealed record UpdateMedicalInfoCommand(UpdateMedicalInfoInput Input) : ICommand<Result>;