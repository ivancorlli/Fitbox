using MediatR;
using Domain.src.Aggregate.UserAggregate;

namespace Application.src.UserFeature.Query.GetMyAccount
{
    public record GetMyAccountCommand(Guid Id):IRequest<Unit>;
}