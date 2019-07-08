using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Gerencial.Domain.Usuarios.Events
{
    public class UsuarioEventHandler : INotificationHandler<SavedUsuarioEvent>
    {
        public Task Handle(SavedUsuarioEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
