using MediatR;

namespace SharedKernell.src.Interface.DomainEvent;

    public interface IDomainEvent : INotification
    {

    }

    public interface IDomainEventHandler<Event> : INotificationHandler<Event> where Event : IDomainEvent
    {

    }