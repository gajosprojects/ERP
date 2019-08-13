using ERP.Gerencial.Domain.GruposEmpresariais.Events.Cnaes;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.Empresas;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.Estabelecimentos;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.GruposEmpresariais;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events
{
    public class GrupoEmpresarialEventHandler : INotificationHandler<SavedGrupoEmpresarialEvent>, INotificationHandler<UpdatedGrupoEmpresarialEvent>, INotificationHandler<DeletedGrupoEmpresarialEvent>, INotificationHandler<SavedCnaeEvent>, INotificationHandler<UpdatedCnaeEvent>, INotificationHandler<DeletedCnaeEvent>, INotificationHandler<SavedEmpresaEvent>, INotificationHandler<UpdatedEmpresaEvent>, INotificationHandler<DeletedEmpresaEvent>, INotificationHandler<SavedEstabelecimentoEvent>, INotificationHandler<UpdatedEstabelecimentoEvent>, INotificationHandler<DeletedEstabelecimentoEvent>
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

        public Task Handle(SavedCnaeEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdatedCnaeEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DeletedCnaeEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(SavedEmpresaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdatedEmpresaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DeletedEmpresaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(SavedEstabelecimentoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UpdatedEstabelecimentoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DeletedEstabelecimentoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}