using System;
using System.Collections.Generic;
using AutoMapper;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Notifications;
using ERP.Services.API.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Services.API.Controllers
{
    public class GruposEmpresariaisController : BaseController
    {
        private readonly IGruposEmpresariaisRepository _gruposEmpresariaisRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public GruposEmpresariaisController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IGruposEmpresariaisRepository gruposEmpresariaisRepository, IMapper mapper) : base(notifications, mediator)
        {
            _gruposEmpresariaisRepository = gruposEmpresariaisRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("gruposempresariais")]
        public IActionResult Post([FromBody]GrupoEmpresarialViewModel grupoEmpresarialViewModel)
        {
            if (!IsModelStateValid()) return Response();
            var grupoEmpresarialCommand = _mapper.Map<SaveGrupoEmpresarialCommand>(grupoEmpresarialViewModel);
            _mediator.SendCommand(grupoEmpresarialCommand);
            return Response(grupoEmpresarialCommand);
        }

        [HttpPut]
        [Route("gruposempresariais")]
        public IActionResult Put([FromBody]GrupoEmpresarialViewModel grupoEmpresarialViewModel)
        {
            if (!IsModelStateValid()) return Response();
            var grupoEmpresarialCommand = _mapper.Map<UpdateGrupoEmpresarialCommand>(grupoEmpresarialViewModel);
            _mediator.SendCommand(grupoEmpresarialCommand);
            return Response(grupoEmpresarialCommand);
        }

        [HttpDelete]
        [Route("gruposempresariais/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var grupoEmpresarialViewModel = new GrupoEmpresarialViewModel { Id = id };
            var grupoEmpresarialCommand = _mapper.Map<DeleteGrupoEmpresarialCommand>(grupoEmpresarialViewModel);
            _mediator.SendCommand(grupoEmpresarialCommand);
            return Response(grupoEmpresarialCommand);
        }

        [HttpGet]
        [Route("gruposempresariais")]
        public IEnumerable<GrupoEmpresarialViewModel> Get()
        {
            return _mapper.Map<IEnumerable<GrupoEmpresarialViewModel>>(_gruposEmpresariaisRepository.GetAll());
        }

        [HttpGet]
        [Route("gruposempresariais/{id:guid}")]
        public GrupoEmpresarialViewModel Get(Guid id)
        {
            return _mapper.Map<GrupoEmpresarialViewModel>(_gruposEmpresariaisRepository.GetById(id));
        }
    }
}