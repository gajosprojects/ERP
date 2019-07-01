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

namespace ERP.Services.API.Controllers
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

        [HttpDelete]
        [Route("gruposempresariais/{id:guid}")]
        [Authorize(Policy = "DeleteGrupoEmpresarial")]
        public IActionResult Delete(Guid id)
        {
            var grupoEmpresarialCommand = _mapper.Map<DeleteGrupoEmpresarialCommand>(new DeleteGrupoEmpresarialViewModel { Id = id, UsuarioId = UsuarioId });
            _mediator.SendCommand(grupoEmpresarialCommand);
            return Response(grupoEmpresarialCommand);
        }

        [HttpGet]
        [Route("gruposempresariais")]
        [Authorize(Policy = "ViewGrupoEmpresarial")]
        public IEnumerable<GrupoEmpresarialViewModel> Get()
        {
            return _mapper.Map<IEnumerable<GrupoEmpresarialViewModel>>(_gruposEmpresariaisRepository.GetAll());
        }

        [HttpGet]
        [Route("gruposempresariais/{id:guid}")]
        [Authorize(Policy = "ViewGrupoEmpresarial")]
        public GrupoEmpresarialViewModel Get(Guid id)
        {
            return _mapper.Map<GrupoEmpresarialViewModel>(_gruposEmpresariaisRepository.GetById(id));
        }
    }
}