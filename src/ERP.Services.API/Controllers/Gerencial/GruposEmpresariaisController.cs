using AutoMapper;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
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
        /// <remarks>Emite um comando que cria uma instância de grupo empresarial e salva no banco de dados caso esteja válida.</remarks>
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
        /// <remarks>Emite um comando que obtém por ID uma instância de um grupo empresarial já existente, atualiza os atributos que foram editados na interface e salva no banco de dados caso esteja válida.</remarks>
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
        /// <remarks>Emite um comando que obtém por ID uma instância de um grupo empresarial já existente e a deleta.</remarks>
        [HttpDelete]
        [Route("gruposempresariais/{id:guid}")]
        [Authorize(Policy = "DeleteGrupoEmpresarial")]
        public IActionResult Delete(Guid id)
        {
            if (!IsModelStateValid()) return Response();
            var grupoEmpresarialCommand = _mapper.Map<DeleteGrupoEmpresarialCommand>(new DeleteGrupoEmpresarialViewModel { Id = id, UsuarioId = UsuarioId });
            _mediator.SendCommand(grupoEmpresarialCommand);
            return Response(grupoEmpresarialCommand);
        }

        /// <summary>
        /// Obtém uma lista de grupos empresariais
        /// </summary>
        /// <returns>Lista de grupos empresariais</returns>
        /// <remarks>Lista de grupos empresariais, ordenada pela descrição e excluindo os inativos.</remarks>
        [HttpGet]
        [Route("gruposempresariais")]
        [Authorize(Policy = "ViewGrupoEmpresarial")]
        public IEnumerable<GrupoEmpresarialViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<GrupoEmpresarialViewModel>>(_gruposEmpresariaisRepository.GetAll());
        }

        /// <summary>
        /// Obtém um grupo empresarial por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Grupo empresarial</returns>
        [HttpGet]
        [Route("gruposempresariais/{id:guid}")]
        [Authorize(Policy = "ViewGrupoEmpresarial")]
        public GrupoEmpresarialViewModel Get(Guid id)
        {
            return _mapper.Map<GrupoEmpresarialViewModel>(_gruposEmpresariaisRepository.GetById(id));
        }
    }
}