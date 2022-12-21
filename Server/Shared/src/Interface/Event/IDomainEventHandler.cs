using MediatR;

namespace Shared.src.Interface.Event
{
    public interface IDomainEventHandler<Event> : INotificationHandler<Event> where Event : IDomainEvent
    {

    }
}