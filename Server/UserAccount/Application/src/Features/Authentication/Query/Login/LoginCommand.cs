using Application.src.Features.Authentication.DTO.Input;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Authentication.Query.Login
{
    public record LoginCommand(LoginInput Login):ICommand<Result>;
    
}