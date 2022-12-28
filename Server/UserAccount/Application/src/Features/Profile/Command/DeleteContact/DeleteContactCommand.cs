using Application.src.Features.Profile.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.DeleteContact;

public sealed record DeleteContactCommand(DeleteContactInput Input):ICommand<Result>;