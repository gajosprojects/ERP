using AutoMapper;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Cnaes;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Empresas;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Estabelecimentos;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using ERP.Services.API.ViewModels.Gerencial.Cnae;
using ERP.Services.API.ViewModels.Gerencial.Empresa;
using ERP.Services.API.ViewModels.Gerencial.Estabelecimento;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ERP.Services.API.Controllers.Gerencial
{
    public class GruposEmpresariaisController : BaseController
    {
        private readonly IGruposEmpresariaisRepository _gruposEmpresariaisRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public GruposEmpresariaisController(INotificationHandler<DomainNotification> notifications, IUser user, IMediatorHandler mediator, IGruposEmpresariaisRepository gruposEmpresariaisRepository, IMapper mapper) : base(notifications, user, mediator)
        {
            _gruposEmpresariaisRepository = gruposEmpresariaisRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Salva um novo grupo empresarial
        /// </summary>
        /// <param name="grupoEmpresarialViewModel"></param>
        /// <returns>Grupo Empresarial</returns>
        /// <remarks>Emite um comando que cria uma instancia de um grupo empresarial, e caso a mesma esteja valida, salva no banco de dados.</remarks>
        [HttpPost]
        [Route("gruposempresariais")]
        [Authorize(Policy = "SaveGrupoEmpresarial")]
        public IActionResult Post([FromBody]SaveGrupoEmpresarialViewModel grupoEmpresarialViewModel)
        {
            if (!IsModelStateValid()) return Response();
            var grupoEmpresarialCommand = _mapper.Map<SaveGrupoEmpresarialCommand>(grupoEmpresarialViewModel);
            _mediator.SendCommand(grupoEmpresarialCommand);
            return Response(grupoEmpresarialCommand);
        }

        /// <summary>
        /// Atualiza um grupo empresarial existente
        /// </summary>
        /// <param name="grupoEmpresarialViewModel"></param>
        /// <returns>Grupo Empresarial</returns>
        /// <remarks>Emite um comando que obtem por ID uma instancia de um grupo empresarial ja existente, atualiza os atributos que foram editados pelo usuario, e caso esteja valida, salva no banco de dados.</remarks>
        [HttpPut]
        [Route("gruposempresariais")]
        [Authorize(Policy = "UpdateGrupoEmpresarial")]
        public IActionResult Put([FromBody]UpdateGrupoEmpresarialViewModel grupoEmpresarialViewModel)
        {
            if (!IsModelStateValid()) return Response();
            var grupoEmpresarialCommand = _mapper.Map<UpdateGrupoEmpresarialCommand>(grupoEmpresarialViewModel);
            _mediator.SendCommand(grupoEmpresarialCommand);
            return Response(grupoEmpresarialCommand);
        }

        /// <summary>
        /// Deleta um grupo empresarial
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean</returns>
        /// <remarks>Emite um comando que obtem por ID uma instancia de um grupo empresarial existente e a deleta/desativa.</remarks>
        [HttpDelete]
        [Route("gruposempresariais/{id:guid}")]
        [Authorize(Policy = "DeleteGrupoEmpresarial")]
        public IActionResult DeleteGrupoEmpresarial(Guid id)
        {
            if (!IsModelStateValid()) return Response();
            var grupoEmpresarialCommand = _mapper.Map<DeleteGrupoEmpresarialCommand>(new DeleteGrupoEmpresarialViewModel { Id = id, UsuarioId = UsuarioId });
            _mediator.SendCommand(grupoEmpresarialCommand);
            return Response(grupoEmpresarialCommand);
        }

        /// <summary>
        /// Obtem uma lista de grupos empresariais
        /// </summary>
        /// <returns>Lista de grupos empresariais</returns>
        /// <remarks>Lista de grupos empresariais, ordenada pela descricao e excluindo os inativos.</remarks>
        [HttpGet]
        [Route("gruposempresariais")]
        [Authorize(Policy = "ViewGrupoEmpresarial")]
        public IEnumerable<GrupoEmpresarialViewModel> GetAll() => _mapper.Map<IEnumerable<GrupoEmpresarialViewModel>>(_gruposEmpresariaisRepository.GetAll());

        /// <summary>
        /// Obtem um grupo empresarial por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Grupo empresarial</returns>
        [HttpGet]
        [Route("gruposempresariais/{id:guid}")]
        [Authorize(Policy = "ViewGrupoEmpresarial")]
        public GrupoEmpresarialViewModel Get(Guid id) => _mapper.Map<GrupoEmpresarialViewModel>(_gruposEmpresariaisRepository.GetById(id));

        /// <summary>
        /// Salva um novo CNAE
        /// </summary>
        /// <param name="cnaeViewModel"></param>
        /// <returns>CNAE</returns>
        /// <remarks>Emite um comando que cria uma instancia de um CNAE, e caso a mesma esteja valida, salva no banco de dados.</remarks>
        [HttpPost]
        [Route("cnaes")]
        [Authorize(Policy = "SaveCnae")]
        public IActionResult Post([FromBody]SaveCnaeViewModel cnaeViewModel)
        {
            if (!IsModelStateValid()) return Response();
            var cnaeCommand = _mapper.Map<SaveCnaeCommand>(cnaeViewModel);
            _mediator.SendCommand(cnaeCommand);
            return Response(cnaeCommand);
        }

        /// <summary>
        /// Atualiza um CNAE existente
        /// </summary>
        /// <param name="cnaeViewModel"></param>
        /// <returns>CNAE</returns>
        /// <remarks>Emite um comando que obtem por ID uma instancia de um CNAE ja existente, atualiza os atributos que foram editados pelo usuario, e caso esteja valida, salva no banco de dados.</remarks>
        [HttpPut]
        [Route("cnaes")]
        [Authorize(Policy = "UpdateCnae")]
        public IActionResult Put([FromBody]UpdateCnaeViewModel cnaeViewModel)
        {
            if (!IsModelStateValid()) return Response();
            var cnaeCommand = _mapper.Map<UpdateCnaeCommand>(cnaeViewModel);
            _mediator.SendCommand(cnaeCommand);
            return Response(cnaeCommand);
        }

        /// <summary>
        /// Deleta um CNAE
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean</returns>
        /// <remarks>Emite um comando que obtem por ID uma instancia de um CNAE existente e a deleta/desativa.</remarks>
        [HttpDelete]
        [Route("cnaes/{id:guid}")]
        [Authorize(Policy = "DeleteCnae")]
        public IActionResult DeleteCnae(Guid id)
        {
            if (!IsModelStateValid()) return Response();
            var cnaeCommand = _mapper.Map<DeleteCnaeCommand>(new DeleteCnaeViewModel { Id = id, UsuarioId = UsuarioId });
            _mediator.SendCommand(cnaeCommand);
            return Response(cnaeCommand);
        }

        /// <summary>
        /// Obtem uma lista de CNAEs
        /// </summary>
        /// <returns>Lista de CNAEs</returns>
        /// <remarks>Lista de CNAEs, ordenada pela descricao e excluindo os inativos.</remarks>
        [HttpGet]
        [Route("cnaes")]
        [Authorize(Policy = "ViewCnae")]
        public IEnumerable<CnaeViewModel> GetAllCnaes() => _mapper.Map<IEnumerable<CnaeViewModel>>(_gruposEmpresariaisRepository.GetAllCnaes());

        /// <summary>
        /// Obtem um CNAE por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CNAE</returns>
        [HttpGet]
        [Route("cnaes/{id:guid}")]
        [Authorize(Policy = "ViewCnae")]
        public CnaeViewModel GetCnae(Guid id) => _mapper.Map<CnaeViewModel>(_gruposEmpresariaisRepository.GetByCnaeId(id));

        /// <summary>
        /// Salva uma nova empresa
        /// </summary>
        /// <param name="empresaViewModel"></param>
        /// <returns>Empresa</returns>
        /// <remarks>Emite um comando que cria uma instancia de uma empresa, e caso a mesma esteja valida, salva no banco de dados.</remarks>
        [HttpPost]
        [Route("empresas")]
        [Authorize(Policy = "SaveEmpresa")]
        public IActionResult Post([FromBody]SaveEmpresaViewModel empresaViewModel)
        {
            if (!IsModelStateValid()) return Response();
            var empresaCommand = _mapper.Map<SaveEmpresaCommand>(empresaViewModel);
            _mediator.SendCommand(empresaCommand);
            return Response(empresaCommand);
        }

        /// <summary>
        /// Atualiza uma empresa existente
        /// </summary>
        /// <param name="empresaViewModel"></param>
        /// <returns>Empresa</returns>
        /// <remarks>Emite um comando que obtem por ID uma instancia de uma empresa ja existente, atualiza os atributos que foram editados pelo usuario, e caso esteja valida, salva no banco de dados.</remarks>
        [HttpPut]
        [Route("empresas")]
        [Authorize(Policy = "UpdateEmpresa")]
        public IActionResult Put([FromBody]UpdateEmpresaViewModel empresaViewModel)
        {
            if (!IsModelStateValid()) return Response();
            var empresaCommand = _mapper.Map<UpdateEmpresaCommand>(empresaViewModel);
            _mediator.SendCommand(empresaCommand);
            return Response(empresaCommand);
        }

        /// <summary>
        /// Deleta uma empresa
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean</returns>
        /// <remarks>Emite um comando que obtem por ID uma instancia de uma empresa existente e a deleta/desativa.</remarks>
        [HttpDelete]
        [Route("empresas/{id:guid}")]
        [Authorize(Policy = "DeleteEmpresa")]
        public IActionResult DeleteEmpresa(Guid id)
        {
            if (!IsModelStateValid()) return Response();
            var empresaCommand = _mapper.Map<DeleteEmpresaCommand>(new DeleteEmpresaViewModel { Id = id, UsuarioId = UsuarioId });
            _mediator.SendCommand(empresaCommand);
            return Response(empresaCommand);
        }

        /// <summary>
        /// Obtem uma lista de empresas
        /// </summary>
        /// <returns>Lista de empresas</returns>
        /// <remarks>Lista de empresas, ordenada pela descricao e excluindo os inativos.</remarks>
        [HttpGet]
        [Route("empresas")]
        [Authorize(Policy = "ViewEmpresa")]
        public IEnumerable<EmpresaViewModel> GetAllEmpresas() => _mapper.Map<IEnumerable<EmpresaViewModel>>(_gruposEmpresariaisRepository.GetAllEmpresas());

        /// <summary>
        /// Obtem uma empresa por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Empresa</returns>
        [HttpGet]
        [Route("empresas/{id:guid}")]
        [Authorize(Policy = "ViewEmpresa")]
        public EmpresaViewModel GetEmpresa(Guid id) => _mapper.Map<EmpresaViewModel>(_gruposEmpresariaisRepository.GetByEmpresaId(id));

        /// <summary>
        /// Salva um novo estabelecimento
        /// </summary>
        /// <param name="estabelecimentoViewModel"></param>
        /// <returns>Estabelecimento</returns>
        /// <remarks>Emite um comando que cria uma instancia de um estabelecimento, e caso a mesma esteja valida, salva no banco de dados.</remarks>
        [HttpPost]
        [Route("estabelecimentos")]
        [Authorize(Policy = "SaveEstabelecimento")]
        public IActionResult Post([FromBody]SaveEstabelecimentoViewModel estabelecimentoViewModel)
        {
            if (!IsModelStateValid()) return Response();
            var estabelecimentoCommand = _mapper.Map<SaveEstabelecimentoCommand>(estabelecimentoViewModel);
            _mediator.SendCommand(estabelecimentoCommand);
            return Response(estabelecimentoCommand);
        }

        /// <summary>
        /// Atualiza uma estabelecimento existente
        /// </summary>
        /// <param name="estabelecimentoViewModel"></param>
        /// <returns>Estabelecimento</returns>
        /// <remarks>Emite um comando que obtem por ID uma instancia de um estabelecimento ja existente, atualiza os atributos que foram editados pelo usuario, e caso esteja valida, salva no banco de dados.</remarks>
        [HttpPut]
        [Route("estabelecimentos")]
        [Authorize(Policy = "UpdateEstabelecimento")]
        public IActionResult Put([FromBody]UpdateEstabelecimentoViewModel estabelecimentoViewModel)
        {
            if (!IsModelStateValid()) return Response();
            var estabelecimentoCommand = _mapper.Map<UpdateEstabelecimentoCommand>(estabelecimentoViewModel);
            _mediator.SendCommand(estabelecimentoCommand);
            return Response(estabelecimentoCommand);
        }

        /// <summary>
        /// Deleta um estabelecimento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean</returns>
        /// <remarks>Emite um comando que obtem por ID uma instancia de um estabelecimento existente e a deleta/desativa.</remarks>
        [HttpDelete]
        [Route("estabelecimentos/{id:guid}")]
        [Authorize(Policy = "DeleteEstabelecimento")]
        public IActionResult DeleteEstabelecimento(Guid id)
        {
            if (!IsModelStateValid()) return Response();
            var estabelecimentoCommand = _mapper.Map<DeleteEstabelecimentoCommand>(new DeleteEstabelecimentoViewModel { Id = id, UsuarioId = UsuarioId });
            _mediator.SendCommand(estabelecimentoCommand);
            return Response(estabelecimentoCommand);
        }

        /// <summary>
        /// Obtem uma lista de estabelecimentos
        /// </summary>
        /// <returns>Lista de estabelecimentos</returns>
        /// <remarks>Lista de estabelecimentos, ordenada pela descricao e excluindo os inativos.</remarks>
        [HttpGet]
        [Route("estabelecimentos")]
        [Authorize(Policy = "ViewEstabelecimento")]
        public IEnumerable<EstabelecimentoViewModel> GetAllEstabelecimentos() => _mapper.Map<IEnumerable<EstabelecimentoViewModel>>(_gruposEmpresariaisRepository.GetAllEstabelecimentos());

        /// <summary>
        /// Obtem um estabelecimento por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Estabelecimento</returns>
        [HttpGet]
        [Route("estabelecimentos/{id:guid}")]
        [Authorize(Policy = "ViewEstabelecimento")]
        public EstabelecimentoViewModel GetEstabelecimento(Guid id) => _mapper.Map<EstabelecimentoViewModel>(_gruposEmpresariaisRepository.GetByEstabelecimentoId(id));
    }
}