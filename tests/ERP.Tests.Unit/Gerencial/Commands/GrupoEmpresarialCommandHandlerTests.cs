using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Events.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace ERP.Tests.Unit.Gerencial.Commands
{
    public class GrupoEmpresarialCommandHandlerTests
    {
        public GrupoEmpresarialCommandHandler _grupoEmpresarialCommandHandler;
        public Mock<DomainNotificationHandler> _mockNotification;
        public Mock<IUser> _mockUser;
        public Mock<IGruposEmpresariaisRepository> _mockGruposEmpresariaisRepository;
        public Mock<IMediatorHandler> _mockMediator;
        public Mock<IUnitOfWork> _mockUoW;

        public GrupoEmpresarialCommandHandlerTests()
        {
            _mockNotification = new Mock<DomainNotificationHandler>();
            _mockUser = new Mock<IUser>();
            _mockGruposEmpresariaisRepository = new Mock<IGruposEmpresariaisRepository>();
            _mockMediator = new Mock<IMediatorHandler>();
            _mockUoW = new Mock<IUnitOfWork>();

            _grupoEmpresarialCommandHandler = new GrupoEmpresarialCommandHandler(_mockUoW.Object, _mockMediator.Object, _mockNotification.Object, _mockGruposEmpresariaisRepository.Object, _mockUser.Object);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_SaveGrupoEmpresarialCommand_RetornarSucesso()
        {
            var request = new SaveGrupoEmpresarialCommand("GE01", "GE01", Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
            var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.NewGrupoEmpresarial(request.Id, request.Codigo, request.Descricao, request.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId);
            var savedEvent = new SavedGrupoEmpresarialEvent(grupoEmpresarial.Id, grupoEmpresarial.Codigo, grupoEmpresarial.Descricao, grupoEmpresarial.DataCadastro, grupoEmpresarial.DataUltimaAtualizacao, grupoEmpresarial.Ativo, grupoEmpresarial.UsuarioId);
            _mockUoW.Setup(m => m.Commit()).Returns(true);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Save(grupoEmpresarial), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_SaveGrupoEmpresarialCommand_RetornarEntidadeInvalida()
        {
            var request = new SaveGrupoEmpresarialCommand("0123456789012345678901234567890123456789", "GE01", Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
            var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.NewGrupoEmpresarial(request.Id, request.Codigo, request.Descricao, request.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Save(grupoEmpresarial), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateGrupoEmpresarialCommand_RetornarSucesso()
        {
            var request = new UpdateGrupoEmpresarialCommand(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"), "GE01", "GE01", Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
            var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.UpdateGrupoEmpresarial(request.Id, request.Codigo, request.Descricao, request.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId, true);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"))).Returns(grupoEmpresarial);

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(grupoEmpresarial), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateGrupoEmpresarialCommand_RetornarNotFound()
        {
            var request = new UpdateGrupoEmpresarialCommand(Guid.NewGuid(), "0123456789012345678901234567890123456789", "GE01", Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
            var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.UpdateGrupoEmpresarial(request.Id, request.Codigo, request.Descricao, request.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId, true);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.NewGuid())).Returns((GrupoEmpresarial) null);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(grupoEmpresarial), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateGrupoEmpresarialCommand_EntidadeInvalida()
        {
            var request = new UpdateGrupoEmpresarialCommand(Guid.NewGuid(), "0123456789012345678901234567890123456789", "GE01", Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
            var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.UpdateGrupoEmpresarial(request.Id, request.Codigo, request.Descricao, request.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId, true);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.NewGuid())).Returns(grupoEmpresarial);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(grupoEmpresarial), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_DeleteGrupoEmpresarialCommand_RetornarSucesso()
        {
            var request = new DeleteGrupoEmpresarialCommand(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"), Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
            var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.UpdateGrupoEmpresarial(request.Id, request.Codigo, request.Descricao, request.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId, true);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"))).Returns(grupoEmpresarial);

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(grupoEmpresarial), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_DeleteGrupoEmpresarialCommand_RetornarNotFound()
        {
            var request = new DeleteGrupoEmpresarialCommand(Guid.NewGuid(), Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
            var grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.UpdateGrupoEmpresarial(request.Id, request.Codigo, request.Descricao, request.DataCadastro, request.DataUltimaAtualizacao, request.UsuarioId, true);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.NewGuid())).Returns((GrupoEmpresarial)null);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(grupoEmpresarial), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }
    }
}
