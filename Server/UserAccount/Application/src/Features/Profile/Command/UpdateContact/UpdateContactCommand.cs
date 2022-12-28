using System.Windows.Input;
using Application.src.Features.Profile.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.UpdateContact;

public sealed record UpdateContactCommand(UpdateContactInput Input):ICommand<Result>;