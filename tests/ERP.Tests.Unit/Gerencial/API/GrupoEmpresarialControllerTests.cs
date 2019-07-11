using AutoMapper;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using ERP.Services.API.Controllers.Gerencial;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ERP.Tests.Unit.Gerencial.API
{
    public class GrupoEmpresarialControllerTests
    {
        public GruposEmpresariaisController _gruposEmpresariaisController;
        public Mock<DomainNotificationHandler> _mockNotification;
        public Mock<IUser> _mockUser;
        public Mock<IGruposEmpresariaisRepository> _mockGruposEmpresariaisRepository;
        public Mock<IMapper> _mockMapper;
        public Mock<IMediatorHandler> _mockMediator;

        public GrupoEmpresarialControllerTests()
        {
            _mockNotification = new Mock<DomainNotificationHandler>();
            _mockUser = new Mock<IUser>();
            _mockGruposEmpresariaisRepository = new Mock<IGruposEmpresariaisRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockMediator = new Mock<IMediatorHandler>();
            _gruposEmpresariaisController = new GruposEmpresariaisController(_mockNotification.Object, _mockUser.Object, _mockMediator.Object, _mockGruposEmpresariaisRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public void GruposEmpresariaisController_Post_RetornarSucesso()
        {
            var grupoEmpresarialViewModel = new SaveGrupoEmpresarialViewModel();
            var saveGrupoEmpresarialCommand = new SaveGrupoEmpresarialCommand("01", "GE01", Guid.NewGuid());
            _mockMapper.Setup(m => m.Map<SaveGrupoEmpresarialCommand>(grupoEmpresarialViewModel)).Returns(saveGrupoEmpresarialCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.IsType<OkObjectResult>(_gruposEmpresariaisController.Post(grupoEmpresarialViewModel));
            _mockMediator.Verify(m => m.SendCommand(saveGrupoEmpresarialCommand), Times.Once);
        }
    }
}
