using Application.src.Features.Profile.DTO.Input;
using Shared.src.Error;
using SharedKernell.src.Interface.Command;
namespace Application.src.Features.Profile.Command.CreateContact;

public sealed record CreateContactCommand(CreateContactInput Input) : ICommand<Result>;
