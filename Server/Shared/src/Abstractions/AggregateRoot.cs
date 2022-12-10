using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.src.Interface;
using Shared.src.Interface.Event;

namespace Shared.src.Abstractions
{
    public abstract class AggregateRoot : BaseEntity, IAggregateRoot
    {
        private readonly List<IDomainEvent> _DomainEvents = new();
        
        
        protected void RaiseDomainEvent(IDomainEvent DomainEvent){
            _DomainEvents.Add(DomainEvent);
        }
    }
}