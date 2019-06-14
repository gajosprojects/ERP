using System.Threading;
using System.Threading.Tasks;
using ERP.Admin.Domain.GruposEmpresariais.Events;
using ERP.Admin.Domain.GruposEmpresariais.Repositories;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Commands;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using MediatR;

namespace ERP.Admin.Domain.GruposEmpresariais.Commands
{
    public class GrupoEmpresarialCommandHandler : CommandHandler, IRequestHandler<SaveGrupoEmpresarialCommand, bool>, IRequestHandler<UpdateGrupoEmpresarialCommand, bool>, IRequestHandler<DeleteGrupoEmpresarialCommand, bool>
    {
        private readonly IGruposEmpresariaisRepository _grupoEmpresarialRepository;
        private readonly IMediatorHandler _mediator;

        public GrupoEmpresarialCommandHandler(IUnitOfWork uow, IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications, IGruposEmpresariaisRepository grupoEmpresarialRepository) : base(uow, mediator, notifications)
        {
            _grupoEmpresarialRepository = grupoEmpresarialRepository;
            _mediator = mediator;
        }

        private bool IsValid(GrupoEmpresarial grupoEmpresarial)
        {
            if (grupoEmpresarial.IsValid()) return true;
            NotificarErrosValidacao(grupoEmpresarial.ValidationResult);
            return false;
        }

        public Task<bool> Handle(SaveGrupoEmpresarialCommand request, CancellationToken cancellationToken)
        {
            var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.NewGrupoEmpresarial(request.Id, request.Codigo, request.Descricao, request.DataCadastro, request.DataUltimaAtualizacao);

            if (IsValid(grupoEmpresarial))
            {
                _grupoEmpresarialRepository.Save(grupoEmpresarial);

                if (Commit())
                {
                    _mediator.RaiseEvent(new SavedGrupoEmpresarialEvent(grupoEmpresarial.Id, grupoEmpresarial.Codigo, grupoEmpresarial.Descricao, grupoEmpresarial.DataCadastro, grupoEmpresarial.DataUltimaAtualizacao));
                }

                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> Handle(UpdateGrupoEmpresarialCommand request, CancellationToken cancellationToken)
        {
            var grupoEmpresarialExistente = _grupoEmpresarialRepository.GetById(request.Id);

            if (grupoEmpresarialExistente == null)
            {
                _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Este grupo empresarial não existe"));
                return Task.FromResult(false);
            }
            else 
            {
                var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.NewGrupoEmpresarial(request.Id, request.Codigo, request.Descricao, request.DataCadastro, request.DataUltimaAtualizacao);
                
                if (IsValid(grupoEmpresarial))
                {
                    _grupoEmpresarialRepository.Update(grupoEmpresarial);

                    if (Commit())
                    {
                        _mediator.RaiseEvent(new UpdatedGrupoEmpresarialEvent(grupoEmpresarial.Id, grupoEmpresarial.Codigo, grupoEmpresarial.Descricao, grupoEmpresarial.DataCadastro, grupoEmpresarial.DataUltimaAtualizacao));
                    }

                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
        }

        public Task<bool> Handle(DeleteGrupoEmpresarialCommand request, CancellationToken cancellationToken)
        {
            var grupoEmpresarialExistente = _grupoEmpresarialRepository.GetById(request.Id);

            if (grupoEmpresarialExistente == null)
            {
                _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Este grupo empresarial não existe"));
                return Task.FromResult(false);
            }
            else 
            {
                grupoEmpresarialExistente.Desativar();
                _grupoEmpresarialRepository.Update(grupoEmpresarialExistente);

                if (Commit())
                {
                    _mediator.RaiseEvent(new DeletedGrupoEmpresarialEvent(request.Id));
                }

                return Task.FromResult(true);
            }
        }
    }
}