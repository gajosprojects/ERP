using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events
{
    public class GrupoEmpresarialEventHandler : INotificationHandler<SavedGrupoEmpresarialEvent>, INotificationHandler<UpdatedGrupoEmpresarialEvent>, INotificationHandler<DeletedGrupoEmpresarialEvent>
    {
        public Task Handle(SavedGrupoEmpresarialEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdatedGrupoEmpresarialEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DeletedGrupoEmpresarialEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}