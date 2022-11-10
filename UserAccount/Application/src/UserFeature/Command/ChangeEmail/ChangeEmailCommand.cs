using Application.src.UserFeature.Dto.Input;
using MediatR;

namespace Application.src.UserFeature.Command.ChangeEmail
{
    public record ChangeEmailCommand(ChangeEmailDto email):IRequest;

}