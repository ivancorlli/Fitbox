using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.src.Interface
{
    public interface IBaseUnitOfWork:IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void OutboxMessage();
        void AuditableEntity();
    }
}