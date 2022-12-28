
using Application.src.Features.Profile.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.DeleteMedicalInfo;

public sealed record DeleteMedicalInfoCommand(DeleteMedicalinfoInput Input):ICommand<Result> ;
