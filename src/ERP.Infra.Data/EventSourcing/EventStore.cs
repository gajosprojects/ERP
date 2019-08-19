using CorrelationId;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Events;
using ERP.Infra.Data.Repositories.EventSourcing;
using Newtonsoft.Json;
using System;

namespace ERP.Infra.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        private readonly ICorrelationContextAccessor _correlationContext;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IUser _user;

        public EventStore(IEventStoreRepository eventStoreRepository, IUser user, ICorrelationContextAccessor correlationContext)
        {
            _correlationContext = correlationContext;
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            _eventStoreRepository.Store(new StoredEvent(theEvent, JsonConvert.SerializeObject(theEvent), _user.GetUserId().ToString(), Guid.Parse(_correlationContext.CorrelationContext.CorrelationId)));
        }
    }
}