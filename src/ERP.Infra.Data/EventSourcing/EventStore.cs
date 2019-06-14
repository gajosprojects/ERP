using ERP.Domain.Core.Events;
using ERP.Infra.Data.Repositories.EventSourcing;
using Newtonsoft.Json;

namespace ERP.Infra.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public EventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            _eventStoreRepository.Store(new StoredEvent(theEvent, JsonConvert.SerializeObject(theEvent), "usuário que efetuou o evento"));
        }
    }
}