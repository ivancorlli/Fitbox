using MediatR;

namespace SharedKernell.src.Controller;

public abstract class BaseController
{
    protected readonly IMediator _Mediator;

    public BaseController(IMediator mediator) => _Mediator = mediator;
}
