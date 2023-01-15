using Application.src.Features.Profile.DTO.Input;
using Shared.src.Error;
using SharedKernell.src.Interface.Command;
namespace Application.src.Features.Profile.Command.UpdateMedicalInfo;

public sealed record UpdateMedicalInfoCommand(UpdateMedicalInfoInput Input):ICommand<Result>;