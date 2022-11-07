using Application.src.User.Dto.Input;
using MediatR;

namespace Application.src.User.Command.ChangeUsername
{
    public record ChangeUsernameCommand(ChangeUsernameDto username):IRequest;
}