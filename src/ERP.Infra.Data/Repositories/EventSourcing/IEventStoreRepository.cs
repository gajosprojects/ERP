using System;
using System.Collections.Generic;
using ERP.Domain.Core.Events;

namespace ERP.Infra.Data.Repositories.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}