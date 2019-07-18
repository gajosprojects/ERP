using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.Usuarios;
using ERP.Gerencial.Domain.Usuarios.Commands;
using ERP.Gerencial.Domain.Usuarios.Events;
using ERP.Gerencial.Domain.Usuarios.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace ERP.Tests.Unit.Gerencial.Commands
{
    public class UsuarioCommandHandlerTests
    {
        public UsuarioCommandHandler _usuarioCommandHandler;
        public Mock<DomainNotificationHandler> _mockNotification;
        public Mock<IUsuariosRepository> _mockUsuariosRepository;
        public Mock<IMediatorHandler> _mockMediator;
        public Mock<IUnitOfWork> _mockUoW;

        public UsuarioCommandHandlerTests()
        {
            _mockNotification = new Mock<DomainNotificationHandler>();
            _mockUsuariosRepository = new Mock<IUsuariosRepository>();
            _mockMediator = new Mock<IMediatorHandler>();
            _mockUoW = new Mock<IUnitOfWork>();

            _usuarioCommandHandler = new UsuarioCommandHandler(_mockUoW.Object, _mockMediator.Object, _mockNotification.Object, _mockUsuariosRepository.Object);
        }

        [Fact]
        public void UsuarioCommandHandler_SaveUsuarioCommand_RetornarSucesso()
        {
            var request = new SaveUsuarioCommand(Guid.NewGuid(), "Bar", "Ism", "bar.ism@gmail.com");
            var usuario = Usuario.UsuarioFactory.NewUsuario(request.Id, request.Nome, request.Sobrenome, request.Email, request.DataCadastro, request.DataUltimaAtualizacao);
            var savedEvent = new SavedUsuarioEvent(usuario.Id, usuario.Nome, usuario.Sobrenome, usuario.Email);
            _mockUoW.Setup(m => m.Commit()).Returns(true);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.True(_usuarioCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockUsuariosRepository.Verify(m => m.Save(usuario), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void UsuarioCommandHandler_SaveUsuarioCommand_RetornarEntidadeInvalida()
        {
            var request = new SaveUsuarioCommand(Guid.NewGuid(), string.Empty, string.Empty, string.Empty);
            var usuario = Usuario.UsuarioFactory.NewUsuario(request.Id, request.Nome, request.Sobrenome, request.Email, request.DataCadastro, request.DataUltimaAtualizacao);

            Assert.False(_usuarioCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockUsuariosRepository.Verify(m => m.Save(usuario), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }
    }
}
