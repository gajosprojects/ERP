using System;

namespace ERP.Domain.Core.Events
{
    public class StoredEvent : Event
    {
        public Guid Id { get; private set; }
        public Guid TransactionId { get; private set; }
        public string Data { get; private set; }
        public string User { get; private set; }

        protected StoredEvent() { }

        public StoredEvent(Event evento, string data, string user, Guid transactionId)
        {
            Id = Guid.NewGuid();
            TransactionId = transactionId;
            AggregateId = evento.AggregateId;
            MessageType = evento.MessageType;
            Data = data;
            User = user;
        }
    }
}