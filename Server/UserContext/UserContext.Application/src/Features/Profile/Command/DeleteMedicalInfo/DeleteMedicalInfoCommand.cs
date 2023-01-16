using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.Profile.DTO.Input;

namespace UserContext.Application.src.Features.Profile.Command.DeleteMedicalInfo;

public sealed record DeleteMedicalInfoCommand(DeleteMedicalinfoInput Input) : ICommand<Result>;
