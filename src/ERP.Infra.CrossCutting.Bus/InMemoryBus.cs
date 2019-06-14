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

        public async Task RaiseEvent<T>(T evento) where T : Event
        {
            if (!evento.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(evento);

            await _mediator.Publish(evento);
        }
    }
}