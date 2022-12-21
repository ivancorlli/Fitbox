using Shared.src.Interface;
using Shared.src.Interface.Event;

namespace Shared.src.Abstractions
{
    public abstract class AggregateRoot : BaseEntity, IAggregateRoot
    {
        private readonly List<IDomainEvent> _DomainEvents = new();

        protected List<IDomainEvent> Events { get => _DomainEvents;}

        protected void RaiseDomainEvent(IDomainEvent DomainEvent){
            _DomainEvents.Add(DomainEvent);
        }
    }
}