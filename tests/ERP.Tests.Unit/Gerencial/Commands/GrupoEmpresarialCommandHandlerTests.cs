using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using ERP.Tests.Unit.Gerencial.Factories;
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
            var request = CommandFactory.GenerateValidSaveGrupoEmpresarialCommand();
            var grupoEmpresarial = EntityFactory.NewGrupoEmpresarial(request);
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
            var request = CommandFactory.GenerateInvalidSaveGrupoEmpresarialCommand();
            var grupoEmpresarial = EntityFactory.NewGrupoEmpresarial(request);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Save(grupoEmpresarial), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateGrupoEmpresarialCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidUpdateGrupoEmpresarialCommand();
            var grupoEmpresarial = EntityFactory.UpdateGrupoEmpresarial(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"))).Returns(grupoEmpresarial);

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(grupoEmpresarial), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateGrupoEmpresarialCommand_RetornarNotFound()
        {
            var request = CommandFactory.GenerateInvalidUpdateGrupoEmpresarialCommand();
            var grupoEmpresarial = EntityFactory.UpdateGrupoEmpresarial(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.NewGuid())).Returns((GrupoEmpresarial) null);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(grupoEmpresarial), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateGrupoEmpresarialCommand_EntidadeInvalida()
        {
            var request = CommandFactory.GenerateInvalidUpdateGrupoEmpresarialCommand();
            var grupoEmpresarial = EntityFactory.UpdateGrupoEmpresarial(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.NewGuid())).Returns(grupoEmpresarial);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(grupoEmpresarial), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_DeleteGrupoEmpresarialCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidDeleteGrupoEmpresarialCommand();
            var grupoEmpresarial = EntityFactory.UpdateGrupoEmpresarial(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"))).Returns(grupoEmpresarial);

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(grupoEmpresarial), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_DeleteGrupoEmpresarialCommand_RetornarNotFound()
        {
            var request = CommandFactory.GenerateInvalidDeleteGrupoEmpresarialCommand();
            var grupoEmpresarial = EntityFactory.UpdateGrupoEmpresarial(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.NewGuid())).Returns((GrupoEmpresarial)null);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(grupoEmpresarial), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_SaveCnaeCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidSaveCnaeCommand();
            var cnae = EntityFactory.NewCnae(request);
            _mockUoW.Setup(m => m.Commit()).Returns(true);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Save(cnae), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_SaveCnaeCommand_RetornarEntidadeInvalida()
        {
            var request = CommandFactory.GenerateInvalidSaveCnaeCommand();
            var cnae = EntityFactory.NewCnae(request);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Save(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateCnaeCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidUpdateCnaeCommand();
            var cnae = EntityFactory.UpdateCnae(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByCnaeId(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"))).Returns(cnae);

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateCnaeCommand_RetornarNotFound()
        {
            var request = CommandFactory.GenerateInvalidUpdateCnaeCommand();
            var cnae = EntityFactory.UpdateCnae(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByCnaeId(Guid.NewGuid())).Returns((Cnae)null);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateCnaeCommand_EntidadeInvalida()
        {
            var request = CommandFactory.GenerateInvalidUpdateCnaeCommand();
            var cnae = EntityFactory.UpdateCnae(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByCnaeId(Guid.NewGuid())).Returns(cnae);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_DeleteCnaeCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidDeleteCnaeCommand();
            var cnae = EntityFactory.UpdateCnae(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByCnaeId(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"))).Returns(cnae);

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_DeleteCnaeCommand_RetornarNotFound()
        {
            var request = CommandFactory.GenerateInvalidDeleteCnaeCommand();
            var cnae = EntityFactory.UpdateCnae(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByCnaeId(Guid.NewGuid())).Returns((Cnae)null);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_SaveEmpresaCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidSaveEmpresaCommand();
            var cnae = EntityFactory.NewEmpresa(request);
            _mockUoW.Setup(m => m.Commit()).Returns(true);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Save(cnae), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_SaveEmpresaCommand_RetornarEntidadeInvalida()
        {
            var request = CommandFactory.GenerateInvalidSaveEmpresaCommand();
            var cnae = EntityFactory.NewEmpresa(request);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Save(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateEmpresaCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidUpdateEmpresaCommand();
            var cnae = EntityFactory.UpdateEmpresa(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByEmpresaId(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"))).Returns(cnae);

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateEmpresaCommand_RetornarNotFound()
        {
            var request = CommandFactory.GenerateInvalidUpdateEmpresaCommand();
            var cnae = EntityFactory.UpdateEmpresa(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByEmpresaId(Guid.NewGuid())).Returns((Empresa)null);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateEmpresaCommand_EntidadeInvalida()
        {
            var request = CommandFactory.GenerateInvalidUpdateEmpresaCommand();
            var cnae = EntityFactory.UpdateEmpresa(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByEmpresaId(Guid.NewGuid())).Returns(cnae);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_DeleteEmpresaCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidDeleteEmpresaCommand();
            var cnae = EntityFactory.UpdateEmpresa(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByEmpresaId(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"))).Returns(cnae);

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_DeleteEmpresaCommand_RetornarNotFound()
        {
            var request = CommandFactory.GenerateInvalidDeleteEmpresaCommand();
            var cnae = EntityFactory.UpdateEmpresa(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByEmpresaId(Guid.NewGuid())).Returns((Empresa)null);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_SaveEstabelecimentoCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidSaveEstabelecimentoCommand();
            var cnae = EntityFactory.NewEstabelecimento(request);
            _mockUoW.Setup(m => m.Commit()).Returns(true);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Save(cnae), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_SaveEstabelecimentoCommand_RetornarEntidadeInvalida()
        {
            var request = CommandFactory.GenerateInvalidSaveEstabelecimentoCommand();
            var cnae = EntityFactory.NewEstabelecimento(request);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Save(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateEstabelecimentoCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidUpdateEstabelecimentoCommand();
            var cnae = EntityFactory.UpdateEstabelecimento(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByEstabelecimentoId(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"))).Returns(cnae);

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateEstabelecimentoCommand_RetornarNotFound()
        {
            var request = CommandFactory.GenerateInvalidUpdateEstabelecimentoCommand();
            var cnae = EntityFactory.UpdateEstabelecimento(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByEstabelecimentoId(Guid.NewGuid())).Returns((Estabelecimento)null);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_UpdateEstabelecimentoCommand_EntidadeInvalida()
        {
            var request = CommandFactory.GenerateInvalidUpdateEstabelecimentoCommand();
            var cnae = EntityFactory.UpdateEstabelecimento(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByEstabelecimentoId(Guid.NewGuid())).Returns(cnae);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_DeleteEstabelecimentoCommand_RetornarSucesso()
        {
            var request = CommandFactory.GenerateValidDeleteEstabelecimentoCommand();
            var cnae = EntityFactory.UpdateEstabelecimento(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByEstabelecimentoId(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"))).Returns(cnae);

            Assert.True(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Once);
            _mockMediator.Verify(m => m.RaiseEvent(new DomainNotification("Commit", "Error on save")), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Once);
        }

        [Fact]
        public void GrupoEmpresarialCommandHandler_DeleteEstabelecimentoCommand_RetornarNotFound()
        {
            var request = CommandFactory.GenerateInvalidDeleteEstabelecimentoCommand();
            var cnae = EntityFactory.UpdateEstabelecimento(request);
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByEstabelecimentoId(Guid.NewGuid())).Returns((Estabelecimento)null);

            Assert.False(_grupoEmpresarialCommandHandler.Handle(request, new CancellationToken()).Result);
            _mockGruposEmpresariaisRepository.Verify(m => m.Update(cnae), Times.Never);
            _mockUoW.Verify(m => m.Commit(), Times.Never);
        }
    }
}
