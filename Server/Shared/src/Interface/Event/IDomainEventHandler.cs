using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Shared.src.Interface.Event
{
    public interface IDomainEventHandler<Event> : INotificationHandler<Event> where Event : IDomainEvent
    {

    }
}