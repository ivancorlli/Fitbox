
using Application.src.Features.Profile.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.CreateAddress;

public sealed record CreateAddressCommand(CreateAddressInput Input):ICommand<Result>;