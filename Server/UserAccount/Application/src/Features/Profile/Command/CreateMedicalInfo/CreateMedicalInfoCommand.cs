using Application.src.Features.Profile.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.CreateMedicalInfo;

public sealed record CreateMedicalInfoCommand(CreateMedicalInfoInput Input) : ICommand<Result>;
