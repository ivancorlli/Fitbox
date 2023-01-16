using SharedKernell.src.Interface.DomainEvent;
using SharedKernell.src.Interface.Entity;
using SharedKernell.src.ValueObject;

namespace SharedKernell.src.Entity;

public abstract class BaseEntity :IBaseEntity
    {

        public Guid Id {get;private init;}
        public TimeStamps TimeStamps {get;private set;} 
        protected BaseEntity(){
            Id = Guid.NewGuid();
            TimeStamps = new TimeStamps();
        }

        protected void EntityUpdated(){
            TimeStamps = TimeStamps.Updated();
        }

    }

    public abstract class AggregateRoot : BaseEntity, IAggregateRoot
    {
        private readonly List<IDomainEvent> _DomainEvents = new();

        protected List<IDomainEvent> Events { get => _DomainEvents;}

        protected void RaiseDomainEvent(IDomainEvent DomainEvent){
            _DomainEvents.Add(DomainEvent);
        }
    }