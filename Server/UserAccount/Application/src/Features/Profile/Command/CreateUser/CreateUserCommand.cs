using Application.src.Features.Profile.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Profile.Command.CreateUser;

public sealed record CreateUserCommand(CreateUserInput Input) : ICommand<Result>;
