using System.Threading.Tasks;
using ERP.Domain.Core.Commands;
using ERP.Domain.Core.Events;

namespace ERP.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}