using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Commands;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Cnaes;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Empresas;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Estabelecimentos;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.Cnaes;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.Empresas;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.Estabelecimentos;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands
{
    public class GrupoEmpresarialCommandHandler : CommandHandler, IRequestHandler<SaveGrupoEmpresarialCommand, bool>, IRequestHandler<UpdateGrupoEmpresarialCommand, bool>, IRequestHandler<DeleteGrupoEmpresarialCommand, bool>, IRequestHandler<SaveCnaeCommand, bool>, IRequestHandler<UpdateCnaeCommand, bool>, IRequestHandler<DeleteCnaeCommand, bool>, IRequestHandler<SaveEmpresaCommand, bool>, IRequestHandler<UpdateEmpresaCommand, bool>, IRequestHandler<DeleteEmpresaCommand, bool>, IRequestHandler<SaveEstabelecimentoCommand, bool>, IRequestHandler<UpdateEstabelecimentoCommand, bool>, IRequestHandler<DeleteEstabelecimentoCommand, bool>
    {
        private readonly IGruposEmpresariaisRepository _grupoEmpresarialRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IUser _user;

        public GrupoEmpresarialCommandHandler(IUnitOfWork uow, IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications, IGruposEmpresariaisRepository grupoEmpresarialRepository, IUser user) : base(uow, mediator, notifications)
        {
            _grupoEmpresarialRepository = grupoEmpresarialRepository;
            _mediator = mediator;
            _user = user;
        }

        public Task<bool> Handle(SaveGrupoEmpresarialCommand request, CancellationToken cancellationToken)
        {
            var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.NewGrupoEmpresarial(request.Id, request.Codigo, request.Descricao, request.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId);

            if (IsValid(grupoEmpresarial))
            {
                _grupoEmpresarialRepository.Save(grupoEmpresarial);

                if (Commit())
                {
                    _mediator.RaiseEvent(new SavedGrupoEmpresarialEvent(grupoEmpresarial.Id, grupoEmpresarial.Codigo, grupoEmpresarial.Descricao, grupoEmpresarial.DataCadastro, grupoEmpresarial.DataUltimaAtualizacao, grupoEmpresarial.Ativo, grupoEmpresarial.UsuarioId));
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
                var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.UpdateGrupoEmpresarial(grupoEmpresarialExistente.Id, request.Codigo, request.Descricao, grupoEmpresarialExistente.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId, grupoEmpresarialExistente.Ativo);
                
                if (IsValid(grupoEmpresarial))
                {
                    _grupoEmpresarialRepository.Update(grupoEmpresarial);

                    if (Commit())
                    {
                        _mediator.RaiseEvent(new UpdatedGrupoEmpresarialEvent(grupoEmpresarial.Id, grupoEmpresarial.Codigo, grupoEmpresarial.Descricao, grupoEmpresarial.DataCadastro, grupoEmpresarial.DataUltimaAtualizacao, grupoEmpresarial.Ativo, grupoEmpresarial.UsuarioId));
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
                if (_grupoEmpresarialRepository.ObterQuantidadeDeEmpresasVinculadasAoGrupoEmpresarial(grupoEmpresarialExistente.Id) > 0)
                {
                    _mediator.RaiseEvent(new DomainNotification(request.MessageType, $"Existem empresas vinculadas ao grupo empresarial ({ grupoEmpresarialExistente.Descricao })"));
                    return Task.FromResult(false);
                }

                grupoEmpresarialExistente.Desativar(request.UsuarioId);
                _grupoEmpresarialRepository.Update(grupoEmpresarialExistente);

                if (Commit())
                {
                    _mediator.RaiseEvent(new DeletedGrupoEmpresarialEvent(request.Id, request.UsuarioId));
                }

                return Task.FromResult(true);
            }
        }

        public Task<bool> Handle(SaveCnaeCommand request, CancellationToken cancellationToken)
        {
            var cnae = Cnae.CnaeFactory.NewCnae(request.Id, request.Codigo, request.Descricao, request.CnaePai, request.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId);

            if (IsValid(cnae))
            {
                _grupoEmpresarialRepository.Save(cnae);

                if (Commit())
                {
                    _mediator.RaiseEvent(new SavedCnaeEvent(cnae.Id, cnae.Ativo, cnae.UsuarioId, cnae.DataCadastro, cnae.DataUltimaAtualizacao, cnae.Codigo, cnae.Descricao, cnae.CnaePai));
                }

                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> Handle(UpdateCnaeCommand request, CancellationToken cancellationToken)
        {
            var cnaeExistente = _grupoEmpresarialRepository.GetByCnaeId(request.Id);

            if (cnaeExistente == null)
            {
                _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Este CNAE não existe"));
                return Task.FromResult(false);
            }
            else
            {
                var cnae = Cnae.CnaeFactory.UpdateCnae(cnaeExistente.Id, request.Codigo, request.Descricao, request.CnaePai, cnaeExistente.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId, cnaeExistente.Ativo);

                if (IsValid(cnae))
                {
                    _grupoEmpresarialRepository.Update(cnae);

                    if (Commit())
                    {
                        _mediator.RaiseEvent(new UpdatedCnaeEvent(cnae.Id, cnae.Ativo, cnae.UsuarioId, cnae.DataCadastro, cnae.DataUltimaAtualizacao, cnae.Codigo, cnae.Descricao, cnae.CnaePai));
                    }

                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
        }

        public Task<bool> Handle(DeleteCnaeCommand request, CancellationToken cancellationToken)
        {
            var cnaeExistente = _grupoEmpresarialRepository.GetByCnaeId(request.Id);

            if (cnaeExistente == null)
            {
                _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Este CNAE não existe"));
                return Task.FromResult(false);
            }
            else
            {
                if (_grupoEmpresarialRepository.ObterQuantidadeDeEstabelecimentosVinculadosAoCnae(cnaeExistente.Id) > 0)
                {
                    _mediator.RaiseEvent(new DomainNotification(request.MessageType, $"Existem estabelecimentos vinculados ao CNAE ({ cnaeExistente.Descricao })"));
                    return Task.FromResult(false);
                }

                cnaeExistente.Desativar(request.UsuarioId);
                _grupoEmpresarialRepository.Update(cnaeExistente);

                if (Commit())
                {
                    _mediator.RaiseEvent(new DeletedCnaeEvent(request.Id, request.UsuarioId));
                }

                return Task.FromResult(true);
            }
        }

        public Task<bool> Handle(SaveEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresa = Empresa.EmpresaFactory.NewEmpresa(request.Id, request.Codigo, request.Descricao, request.NomeFantasia, request.Email, request.Site, request.Bloqueada, request.DataRegistro, request.Logotipo, request.Observacao, request.DataCadastro, request.DataUltimaAtualizacao, request.Documento, request.TipoIdentificacao, request.GrupoEmpresarialId, request.UsuarioId);

            if (IsValid(empresa))
            {
                _grupoEmpresarialRepository.Save(empresa);

                if (Commit())
                {
                    _mediator.RaiseEvent(new SavedEmpresaEvent(empresa.Id, empresa.Ativo, empresa.UsuarioId, empresa.DataCadastro, empresa.DataUltimaAtualizacao, empresa.Codigo, empresa.Descricao, empresa.NomeFantasia, empresa.Email, empresa.Site, empresa.Bloqueada, empresa.DataRegistro, empresa.Logotipo, empresa.Observacao, empresa.Documento, empresa.TipoIdentificacao, empresa.GrupoEmpresarialId));
                }

                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresaExistente = _grupoEmpresarialRepository.GetByEmpresaId(request.Id);

            if (empresaExistente == null)
            {
                _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Esta empresa não existe"));
                return Task.FromResult(false);
            }
            else
            {
                var empresa = Empresa.EmpresaFactory.UpdateEmpresa(empresaExistente.Id, request.Codigo, request.Descricao, request.NomeFantasia, request.Email, request.Site, request.Bloqueada, request.DataRegistro, request.Logotipo, request.Observacao, empresaExistente.DataCadastro, request.DataUltimaAtualizacao, request.Documento, request.TipoIdentificacao, request.GrupoEmpresarialId, request.UsuarioId, empresaExistente.Ativo);

                if (IsValid(empresa))
                {
                    _grupoEmpresarialRepository.Update(empresa);

                    if (Commit())
                    {
                        _mediator.RaiseEvent(new UpdatedEmpresaEvent(empresa.Id, empresa.Ativo, empresa.UsuarioId, empresa.DataCadastro, empresa.DataUltimaAtualizacao, empresa.Codigo, empresa.Descricao, empresa.NomeFantasia, empresa.Email, empresa.Site, empresa.Bloqueada, empresa.DataRegistro, empresa.Logotipo, empresa.Observacao, empresa.Documento, empresa.TipoIdentificacao, empresa.GrupoEmpresarialId));
                    }

                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
        }

        public Task<bool> Handle(DeleteEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresaExistente = _grupoEmpresarialRepository.GetByEmpresaId(request.Id);

            if (empresaExistente == null)
            {
                _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Esta empresa não existe"));
                return Task.FromResult(false);
            }
            else
            {
                if (_grupoEmpresarialRepository.ObterQuantidadeDeEstabelecimentosVinculadosAEmpresa(empresaExistente.Id) > 0)
                {
                    _mediator.RaiseEvent(new DomainNotification(request.MessageType, $"Existem estabelecimentos vinculados a empresa ({ empresaExistente.Descricao })"));
                    return Task.FromResult(false);
                }

                empresaExistente.Desativar(request.UsuarioId);
                _grupoEmpresarialRepository.Update(empresaExistente);

                if (Commit())
                {
                    _mediator.RaiseEvent(new DeletedEmpresaEvent(request.Id, request.UsuarioId));
                }

                return Task.FromResult(true);
            }
        }

        public Task<bool> Handle(SaveEstabelecimentoCommand request, CancellationToken cancellationToken)
        {
            var estabelecimento = Estabelecimento.EstabelecimentoFactory.NewEstabelecimento(request.Id, request.Codigo, request.Descricao, request.NomeFantasia, request.InscricaoEstadual, request.InscricaoMunicipal, request.Email, request.Site, request.Bloqueado, request.DataRegistro, request.Logotipo, request.Matriz, request.Observacao, request.DataCadastro, request.DataUltimaAtualizacao, request.Documento, request.TipoIdentificacao, request.EmpresaId, request.CnaeId, request.UsuarioId);

            if (IsValid(estabelecimento))
            {
                _grupoEmpresarialRepository.Save(estabelecimento);

                if (Commit())
                {
                    _mediator.RaiseEvent(new SavedEstabelecimentoEvent(estabelecimento.Id, estabelecimento.Ativo, estabelecimento.UsuarioId, estabelecimento.DataCadastro, estabelecimento.DataUltimaAtualizacao, estabelecimento.Codigo, estabelecimento.Descricao, estabelecimento.NomeFantasia, estabelecimento.InscricaoEstadual, estabelecimento.InscricaoMunicipal, estabelecimento.Email, estabelecimento.Site, estabelecimento.Bloqueado, estabelecimento.DataRegistro, estabelecimento.Logotipo, estabelecimento.Matriz, estabelecimento.Observacao, estabelecimento.Documento, estabelecimento.TipoIdentificacao, estabelecimento.EmpresaId, estabelecimento.CnaeId));
                }

                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> Handle(UpdateEstabelecimentoCommand request, CancellationToken cancellationToken)
        {
            var estabelecimentoExistente = _grupoEmpresarialRepository.GetByEstabelecimentoId(request.Id);

            if (estabelecimentoExistente == null)
            {
                _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Este estabelecimento não existe"));
                return Task.FromResult(false);
            }
            else
            {
                var estabelecimento = Estabelecimento.EstabelecimentoFactory.UpdateEstabelecimento(estabelecimentoExistente.Id, request.Codigo, request.Descricao, request.NomeFantasia, request.InscricaoEstadual, request.InscricaoMunicipal, request.Email, request.Site, request.Bloqueado, request.DataRegistro, request.Logotipo, request.Matriz, request.Observacao, estabelecimentoExistente.DataCadastro, request.DataUltimaAtualizacao, request.Documento, request.TipoIdentificacao, request.EmpresaId, request.CnaeId, request.UsuarioId, estabelecimentoExistente.Ativo);

                if (IsValid(estabelecimento))
                {
                    _grupoEmpresarialRepository.Update(estabelecimento);

                    if (Commit())
                    {
                        _mediator.RaiseEvent(new UpdatedEstabelecimentoEvent(estabelecimento.Id, estabelecimento.Ativo, estabelecimento.UsuarioId, estabelecimento.DataCadastro, estabelecimento.DataUltimaAtualizacao, estabelecimento.Codigo, estabelecimento.Descricao, estabelecimento.NomeFantasia, estabelecimento.InscricaoEstadual, estabelecimento.InscricaoMunicipal, estabelecimento.Email, estabelecimento.Site, estabelecimento.Bloqueado, estabelecimento.DataRegistro, estabelecimento.Logotipo, estabelecimento.Matriz, estabelecimento.Observacao, estabelecimento.Documento, estabelecimento.TipoIdentificacao, estabelecimento.EmpresaId, estabelecimento.CnaeId));
                    }

                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
        }

        public Task<bool> Handle(DeleteEstabelecimentoCommand request, CancellationToken cancellationToken)
        {
            var estabelecimentoExistente = _grupoEmpresarialRepository.GetByEstabelecimentoId(request.Id);

            if (estabelecimentoExistente == null)
            {
                _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Este estabelecimento não existe"));
                return Task.FromResult(false);
            }
            else
            {
                estabelecimentoExistente.Desativar(request.UsuarioId);
                _grupoEmpresarialRepository.Update(estabelecimentoExistente);

                if (Commit())
                {
                    _mediator.RaiseEvent(new DeletedEstabelecimentoEvent(request.Id, request.UsuarioId));
                }

                return Task.FromResult(true);
            }
        }

        private bool IsValid(GrupoEmpresarial grupoEmpresarial)
        {
            if (grupoEmpresarial.IsValid()) return true;
            NotificarErrosValidacao(grupoEmpresarial.ValidationResult);
            return false;
        }

        private bool IsValid(Cnae cnae)
        {
            if (cnae.IsValid()) return true;
            NotificarErrosValidacao(cnae.ValidationResult);
            return false;
        }

        private bool IsValid(Empresa empresa)
        {
            if (empresa.IsValid()) return true;
            NotificarErrosValidacao(empresa.ValidationResult);
            return false;
        }

        private bool IsValid(Estabelecimento estabelecimento)
        {
            if (estabelecimento.IsValid()) return true;
            NotificarErrosValidacao(estabelecimento.ValidationResult);
            return false;
        }
    }
}