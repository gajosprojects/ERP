using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Commands;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.Usuarios.Events;
using ERP.Gerencial.Domain.Usuarios.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Gerencial.Domain.Usuarios.Commands
{
    public class UsuarioCommandHandler : CommandHandler, IRequestHandler<SaveUsuarioCommand, bool>
    {
        private readonly IUsuariosRepository _usuarioRepository;
        private readonly IMediatorHandler _mediator;

        public UsuarioCommandHandler(IUnitOfWork uow, IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications, IUsuariosRepository usuarioRepository) : base(uow, mediator, notifications)
        {
            _usuarioRepository = usuarioRepository;
            _mediator = mediator;
        }

        private bool IsValid(Usuario usuario)
        {
            if (usuario.IsValid()) return true;
            NotificarErrosValidacao(usuario.ValidationResult);
            return false;
        }

        public Task<bool> Handle(SaveUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = Usuario.UsuarioFactory.NewUsuario(request.Id, request.Nome, request.Sobrenome, request.Email);

            if (IsValid(usuario))
            {
                _usuarioRepository.Save(usuario);

                if (Commit())
                {
                    _mediator.RaiseEvent(new SavedUsuarioEvent(usuario.Id, usuario.Nome, usuario.Sobrenome, usuario.Email));
                }

                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
