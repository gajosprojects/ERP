using System.Threading.Tasks;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Commands;
using ERP.Domain.Core.Events;
using MediatR;

namespace ERP.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IMediator mediator, IEventStore eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }
        
        public async Task SendCommand<T>(T command) where T : Command
        {
            await _mediator.Send<bool>(command);
        }

        public async Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            await _mediator.Publish(@event);
        }
    }
}