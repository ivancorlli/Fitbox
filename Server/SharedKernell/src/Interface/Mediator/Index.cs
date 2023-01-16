using MediatR;

namespace SharedKernell.src.Interface.Mediator;

public interface ICommand : IRequest
{

}

public interface ICommand<TResponse> : IRequest<TResponse>
{

}

public interface IHandler<T> : IRequestHandler<T> where T : ICommand
{

}

public interface IHandler<T, R> : IRequestHandler<T, R> where T : ICommand<R>
{

}