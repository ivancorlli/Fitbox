
using Domain.src.Aggregate.UserAggregate;
using MediatR;

namespace Application.src.UserFeature.Query.GetMyAccount
{
    public class GetMyAccountHandler:IRequestHandler<GetMyAccountCommand,Unit>
    {

        private readonly ContextBoundObject _Db; 

        public GetMyAccountHandler(ContextBoundObject db){
            _Db = db;
        }

        Task<Unit> IRequestHandler<GetMyAccountCommand, Unit>.Handle(GetMyAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}