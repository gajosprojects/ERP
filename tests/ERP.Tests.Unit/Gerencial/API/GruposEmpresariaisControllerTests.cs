using AutoMapper;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Cnaes;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using ERP.Gerencial.Domain.Usuarios;
using ERP.Services.API.AutoMapper;
using ERP.Services.API.Controllers.Gerencial;
using ERP.Services.API.ViewModels.Gerencial.Cnae;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using ERP.Services.API.ViewModels.Gerencial.Usuario;
using ERP.Tests.Unit.Gerencial.Factories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace ERP.Tests.Unit.Gerencial.API
{
    public class GruposEmpresariaisControllerTests
    {
        public GruposEmpresariaisController _gruposEmpresariaisController;
        public GruposEmpresariaisController _gruposEmpresariaisControllerRealMapper;
        public Mock<DomainNotificationHandler> _mockNotification;
        public Mock<IUser> _mockUser;
        public Mock<IGruposEmpresariaisRepository> _mockGruposEmpresariaisRepository;
        public Mock<IMapper> _mockMapper;
        public Mock<IMediatorHandler> _mockMediator;

        public GruposEmpresariaisControllerTests()
        {
            _mockNotification = new Mock<DomainNotificationHandler>();
            _mockUser = new Mock<IUser>();
            _mockGruposEmpresariaisRepository = new Mock<IGruposEmpresariaisRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockMediator = new Mock<IMediatorHandler>();

            _gruposEmpresariaisControllerRealMapper = new GruposEmpresariaisController(_mockNotification.Object, _mockUser.Object, _mockMediator.Object, _mockGruposEmpresariaisRepository.Object, new MapperConfiguration(configuration => configuration.AddProfile(new DomainToViewModelMappingProfile())).CreateMapper());
            _gruposEmpresariaisController = new GruposEmpresariaisController(_mockNotification.Object, _mockUser.Object, _mockMediator.Object, _mockGruposEmpresariaisRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public void GruposEmpresariaisController_Post_GrupoEmpresarial_RetornarSucesso()
        {
            var grupoEmpresarialViewModel = new SaveGrupoEmpresarialViewModel();
            var saveGrupoEmpresarialCommand = CommandFactory.GenerateValidSaveGrupoEmpresarialCommand();
            _mockMapper.Setup(m => m.Map<SaveGrupoEmpresarialCommand>(grupoEmpresarialViewModel)).Returns(saveGrupoEmpresarialCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.IsType<OkObjectResult>(_gruposEmpresariaisController.Post(grupoEmpresarialViewModel));
            _mockMediator.Verify(m => m.SendCommand(saveGrupoEmpresarialCommand), Times.Once);
        }

        [Fact]
        public void GruposEmpresariaisController_Post_GrupoEmpresarial_RetornarErrosModelState()
        {
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Model error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _gruposEmpresariaisController.ModelState.AddModelError("Error", "Model error");

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.Post(new SaveGrupoEmpresarialViewModel()));
            _mockMediator.Verify(m => m.SendCommand(It.IsAny<SaveGrupoEmpresarialCommand>()), Times.Never);
        }

        [Fact]
        public void GruposEmpresariaisController_Post_GrupoEmpresarial_RetornarErrosDominio()
        {
            var grupoEmpresarialViewModel = new SaveGrupoEmpresarialViewModel();
            var saveGrupoEmpresarialCommand = CommandFactory.GenerateInvalidSaveGrupoEmpresarialCommand();
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Domain error") };
            _mockMapper.Setup(m => m.Map<SaveGrupoEmpresarialCommand>(grupoEmpresarialViewModel)).Returns(saveGrupoEmpresarialCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.Post(grupoEmpresarialViewModel));
            _mockMediator.Verify(m => m.SendCommand(saveGrupoEmpresarialCommand), Times.Once);
        }

        [Fact]
        public void GruposEmpresariaisController_Put_GrupoEmpresarial_RetornarSucesso()
        {
            var grupoEmpresarialViewModel = new UpdateGrupoEmpresarialViewModel();
            var updateGrupoEmpresarialCommand = CommandFactory.GenerateValidUpdateGrupoEmpresarialCommand();
            _mockMapper.Setup(m => m.Map<UpdateGrupoEmpresarialCommand>(grupoEmpresarialViewModel)).Returns(updateGrupoEmpresarialCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.IsType<OkObjectResult>(_gruposEmpresariaisController.Put(grupoEmpresarialViewModel));
            _mockMediator.Verify(m => m.SendCommand(updateGrupoEmpresarialCommand), Times.Once);
        }

        [Fact]
        public void GruposEmpresariaisController_Put_GrupoEmpresarial_RetornarErrosModelState()
        {
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Model error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _gruposEmpresariaisController.ModelState.AddModelError("Error", "Model error");

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.Put(new UpdateGrupoEmpresarialViewModel()));
            _mockMediator.Verify(m => m.SendCommand(It.IsAny<UpdateGrupoEmpresarialCommand>()), Times.Never);
        }

        [Fact]
        public void GruposEmpresariaisController_Put_GrupoEmpresarial_RetornarErrosDominio()
        {
            var grupoEmpresarialViewModel = new UpdateGrupoEmpresarialViewModel();
            var updateGrupoEmpresarialCommand = CommandFactory.GenerateInvalidUpdateGrupoEmpresarialCommand();
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Domain error") };
            _mockMapper.Setup(m => m.Map<UpdateGrupoEmpresarialCommand>(grupoEmpresarialViewModel)).Returns(updateGrupoEmpresarialCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.Put(grupoEmpresarialViewModel));
            _mockMediator.Verify(m => m.SendCommand(updateGrupoEmpresarialCommand), Times.Once);
        }

        [Fact]
        public void GruposEmpresariaisController_Delete_GrupoEmpresarial_RetornarSucesso()
        {
            var grupoEmpresarialViewModel = new DeleteGrupoEmpresarialViewModel() { Id = Guid.NewGuid(), UsuarioId = Guid.NewGuid() };
            var deleteGrupoEmpresarialCommand = CommandFactory.GenerateValidDeleteGrupoEmpresarialCommand();
            _mockMapper.Setup(m => m.Map<DeleteGrupoEmpresarialCommand>(grupoEmpresarialViewModel)).Returns(deleteGrupoEmpresarialCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.IsType<OkObjectResult>(_gruposEmpresariaisController.DeleteGrupoEmpresarial(grupoEmpresarialViewModel.Id));
        }

        [Fact]
        public void GruposEmpresariaisController_Delete_GrupoEmpresarial_RetornarErrosModelState()
        {
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Model error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _gruposEmpresariaisController.ModelState.AddModelError("Error", "Model error");

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.DeleteGrupoEmpresarial(Guid.NewGuid()));
        }

        [Fact]
        public void GruposEmpresariaisController_Delete_GrupoEmpresarial_RetornarErrosDominio()
        {
            var grupoEmpresarialViewModel = new DeleteGrupoEmpresarialViewModel();
            var deleteGrupoEmpresarialCommand = CommandFactory.GenerateInvalidDeleteGrupoEmpresarialCommand();
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Domain error") };
            _mockMapper.Setup(m => m.Map<DeleteGrupoEmpresarialCommand>(grupoEmpresarialViewModel)).Returns(deleteGrupoEmpresarialCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.DeleteGrupoEmpresarial(Guid.NewGuid()));
        }

        [Fact]
        public void GruposEmpresariaisController_GetAll_GruposEmpresariais_RetornarListaVazia()
        {
            var config = new MapperConfiguration(configuration => configuration.AddProfile(new DomainToViewModelMappingProfile()));
            var gruposEmpresariaisController = new GruposEmpresariaisController(_mockNotification.Object, _mockUser.Object, _mockMediator.Object, _mockGruposEmpresariaisRepository.Object, config.CreateMapper());
            _mockGruposEmpresariaisRepository.Setup(m => m.GetAll()).Returns(new List<GrupoEmpresarial>());
            Assert.Equal(new List<GrupoEmpresarialViewModel>(), gruposEmpresariaisController.GetAll());
        }

        [Fact]
        public void GruposEmpresariaisController_GetAll_GruposEmpresariais_RetornarSucesso()
        {
            DateTime dateTime = DateTime.Now;
            Usuario usuario = Usuario.UsuarioFactory.NewUsuario(Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), "Foo", "Ism", "foo@programming.com", dateTime, dateTime);
            GrupoEmpresarial grupoEmpresarial1 = GrupoEmpresarial.GrupoEmpresarialFactory.NewGrupoEmpresarial(Guid.Parse("f51745d6-d84a-49e6-a9bd-3d712c138b95"), "GE1", "GE1", dateTime, dateTime, Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
            GrupoEmpresarial grupoEmpresarial2 = GrupoEmpresarial.GrupoEmpresarialFactory.UpdateGrupoEmpresarial(Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"), "GE2", "GE2", dateTime, dateTime, Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), false);
            grupoEmpresarial1.AtribuirUsuario(usuario);
            grupoEmpresarial2.AtribuirUsuario(usuario);

            IEnumerable<GrupoEmpresarial> gruposEmpresariais = new List<GrupoEmpresarial> { grupoEmpresarial1, grupoEmpresarial2 };

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel { Id = Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), Nome = "Foo", Sobrenome = "Ism", Email = "foo@programming.com" };

            IEnumerable<GrupoEmpresarialViewModel> expectedValue = new List<GrupoEmpresarialViewModel>
            {
                new GrupoEmpresarialViewModel() { Id = Guid.Parse("f51745d6-d84a-49e6-a9bd-3d712c138b95"), Ativo = true, Codigo = "GE1", Descricao = "GE1", DataCadastro = dateTime, DataUltimaAtualizacao = dateTime, Usuario = usuarioViewModel },
                new GrupoEmpresarialViewModel() { Id = Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"), Ativo = false, Codigo = "GE2", Descricao = "GE2", DataCadastro = dateTime, DataUltimaAtualizacao = dateTime, Usuario = usuarioViewModel }
            };

            _mockGruposEmpresariaisRepository.Setup(m => m.GetAll()).Returns(gruposEmpresariais);
            IEnumerable<GrupoEmpresarialViewModel> actualValue = _gruposEmpresariaisControllerRealMapper.GetAll();
            Assert.Equal(JsonConvert.SerializeObject(expectedValue), JsonConvert.SerializeObject(actualValue));
        }

        [Fact]
        public void GruposEmpresariaisController_GetById_GrupoEmpresarial_RetornarNotFound()
        {
            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.NewGuid())).Returns((GrupoEmpresarial) null);
            Assert.Null(_gruposEmpresariaisControllerRealMapper.Get(Guid.NewGuid()));
        }

        [Fact]
        public void GruposEmpresariaisController_GetById_GrupoEmpresarial_RetornarErrosDominio()
        {
            DateTime dateTime = DateTime.Now;
            Usuario usuario = Usuario.UsuarioFactory.NewUsuario(Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), "Foo", "Ism", "foo@programming.com", dateTime, dateTime);
            GrupoEmpresarial grupoEmpresarial = GrupoEmpresarial.GrupoEmpresarialFactory.UpdateGrupoEmpresarial(Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"), "GE2", "GE2", dateTime, dateTime, Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), true);
            grupoEmpresarial.AtribuirUsuario(usuario);

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel { Id = Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), Nome = "Foo", Sobrenome = "Ism", Email = "foo@programming.com" };
            GrupoEmpresarialViewModel expectedValue = new GrupoEmpresarialViewModel() { Id = Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"), Ativo = true, Codigo = "GE2", Descricao = "GE2", DataCadastro = dateTime, DataUltimaAtualizacao = dateTime, Usuario = usuarioViewModel };

            _mockGruposEmpresariaisRepository.Setup(m => m.GetById(Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"))).Returns(grupoEmpresarial);
            GrupoEmpresarialViewModel actualValue = _gruposEmpresariaisControllerRealMapper.Get(Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"));

            Assert.Equal(JsonConvert.SerializeObject(expectedValue), JsonConvert.SerializeObject(actualValue));
        }

        [Fact]
        public void GruposEmpresariaisController_Post_Cnae_RetornarSucesso()
        {
            var cnaeViewModel = new SaveCnaeViewModel();
            var saveCnaeCommand = CommandFactory.GenerateValidSaveCnaeCommand();
            _mockMapper.Setup(m => m.Map<SaveCnaeCommand>(cnaeViewModel)).Returns(saveCnaeCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.IsType<OkObjectResult>(_gruposEmpresariaisController.Post(cnaeViewModel));
            _mockMediator.Verify(m => m.SendCommand(saveCnaeCommand), Times.Once);
        }

        [Fact]
        public void GruposEmpresariaisController_Post_Cnae_RetornarErrosModelState()
        {
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Model error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _gruposEmpresariaisController.ModelState.AddModelError("Error", "Model error");

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.Post(new SaveCnaeViewModel()));
            _mockMediator.Verify(m => m.SendCommand(It.IsAny<SaveCnaeCommand>()), Times.Never);
        }

        [Fact]
        public void GruposEmpresariaisController_Post_Cnae_RetornarErrosDominio()
        {
            var cnaeViewModel = new SaveCnaeViewModel();
            var saveCnaeCommand = CommandFactory.GenerateInvalidSaveCnaeCommand();
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Domain error") };
            _mockMapper.Setup(m => m.Map<SaveCnaeCommand>(cnaeViewModel)).Returns(saveCnaeCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.Post(cnaeViewModel));
            _mockMediator.Verify(m => m.SendCommand(saveCnaeCommand), Times.Once);
        }

        [Fact]
        public void GruposEmpresariaisController_Put_Cnae_RetornarSucesso()
        {
            var cnaeViewModel = new UpdateCnaeViewModel();
            var updateCnaeCommand = CommandFactory.GenerateValidUpdateCnaeCommand();
            _mockMapper.Setup(m => m.Map<UpdateCnaeCommand>(cnaeViewModel)).Returns(updateCnaeCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.IsType<OkObjectResult>(_gruposEmpresariaisController.Put(cnaeViewModel));
            _mockMediator.Verify(m => m.SendCommand(updateCnaeCommand), Times.Once);
        }

        [Fact]
        public void GruposEmpresariaisController_Put_Cnae_RetornarErrosModelState()
        {
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Model error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _gruposEmpresariaisController.ModelState.AddModelError("Error", "Model error");

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.Put(new UpdateCnaeViewModel()));
            _mockMediator.Verify(m => m.SendCommand(It.IsAny<UpdateCnaeCommand>()), Times.Never);
        }

        [Fact]
        public void GruposEmpresariaisController_Put_Cnae_RetornarErrosDominio()
        {
            var cnaeViewModel = new UpdateCnaeViewModel();
            var updateCnaeCommand = CommandFactory.GenerateInvalidUpdateCnaeCommand();
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Domain error") };
            _mockMapper.Setup(m => m.Map<UpdateCnaeCommand>(cnaeViewModel)).Returns(updateCnaeCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.Put(cnaeViewModel));
            _mockMediator.Verify(m => m.SendCommand(updateCnaeCommand), Times.Once);
        }

        [Fact]
        public void GruposEmpresariaisController_Delete_Cnae_RetornarSucesso()
        {
            var cnaeViewModel = new DeleteCnaeViewModel() { Id = Guid.NewGuid(), UsuarioId = Guid.NewGuid() };
            var deleteCnaeCommand = CommandFactory.GenerateValidDeleteCnaeCommand();
            _mockMapper.Setup(m => m.Map<DeleteCnaeCommand>(cnaeViewModel)).Returns(deleteCnaeCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());

            Assert.IsType<OkObjectResult>(_gruposEmpresariaisController.DeleteCnae(cnaeViewModel.Id));
        }

        [Fact]
        public void GruposEmpresariaisController_Delete_Cnae_RetornarErrosModelState()
        {
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Model error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _gruposEmpresariaisController.ModelState.AddModelError("Error", "Model error");

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.DeleteCnae(Guid.NewGuid()));
        }

        [Fact]
        public void GruposEmpresariaisController_Delete_Cnae_RetornarErrosDominio()
        {
            var cnaeViewModel = new DeleteCnaeViewModel();
            var deleteCnaeCommand = CommandFactory.GenerateInvalidDeleteCnaeCommand();
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Domain error") };
            _mockMapper.Setup(m => m.Map<DeleteCnaeCommand>(cnaeViewModel)).Returns(deleteCnaeCommand);
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);

            Assert.IsType<BadRequestObjectResult>(_gruposEmpresariaisController.DeleteCnae(Guid.NewGuid()));
        }

        [Fact]
        public void GruposEmpresariaisController_GetAll_Cnaes_RetornarListaVazia()
        {
            var config = new MapperConfiguration(configuration => configuration.AddProfile(new DomainToViewModelMappingProfile()));
            var gruposEmpresariaisController = new GruposEmpresariaisController(_mockNotification.Object, _mockUser.Object, _mockMediator.Object, _mockGruposEmpresariaisRepository.Object, config.CreateMapper());
            _mockGruposEmpresariaisRepository.Setup(m => m.GetAllCnaes()).Returns(new List<Cnae>());
            Assert.Equal(new List<CnaeViewModel>(), gruposEmpresariaisController.GetAllCnaes());
        }

        [Fact]
        public void GruposEmpresariaisController_GetAll_Cnaes_RetornarSucesso()
        {
            DateTime dateTime = DateTime.Now;
            Usuario usuario = Usuario.UsuarioFactory.NewUsuario(Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), "Foo", "Ism", "foo@programming.com", dateTime, dateTime);
            Cnae cnae1 = Cnae.CnaeFactory.NewCnae(Guid.Parse("f51745d6-d84a-49e6-a9bd-3d712c138b95"), "GE1", "GE1", null, dateTime, dateTime, Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
            Cnae cnae2 = Cnae.CnaeFactory.UpdateCnae(Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"), "GE2", "GE2", null, dateTime, dateTime, Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), false);
            cnae1.AtribuirUsuario(usuario);
            cnae2.AtribuirUsuario(usuario);

            IEnumerable<Cnae> cnaes = new List<Cnae> { cnae1, cnae2 };

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel { Id = Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), Nome = "Foo", Sobrenome = "Ism", Email = "foo@programming.com" };

            IEnumerable<CnaeViewModel> expectedValue = new List<CnaeViewModel>
            {
                new CnaeViewModel() { Id = Guid.Parse("f51745d6-d84a-49e6-a9bd-3d712c138b95"), Ativo = true, Codigo = "GE1", Descricao = "GE1", CnaePai = null, DataCadastro = dateTime, DataUltimaAtualizacao = dateTime, Usuario = usuarioViewModel },
                new CnaeViewModel() { Id = Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"), Ativo = false, Codigo = "GE2", Descricao = "GE2", CnaePai = null, DataCadastro = dateTime, DataUltimaAtualizacao = dateTime, Usuario = usuarioViewModel }
            };

            _mockGruposEmpresariaisRepository.Setup(m => m.GetAllCnaes()).Returns(cnaes);
            IEnumerable<CnaeViewModel> actualValue = _gruposEmpresariaisControllerRealMapper.GetAllCnaes();
            Assert.Equal(JsonConvert.SerializeObject(expectedValue), JsonConvert.SerializeObject(actualValue));
        }

        [Fact]
        public void GruposEmpresariaisController_GetById_Cnae_RetornarNotFound()
        {
            _mockGruposEmpresariaisRepository.Setup(m => m.GetByCnaeId(Guid.NewGuid())).Returns((Cnae)null);
            Assert.Null(_gruposEmpresariaisControllerRealMapper.Get(Guid.NewGuid()));
        }

        [Fact]
        public void GruposEmpresariaisController_GetById_Cnae_RetornarErrosDominio()
        {
            DateTime dateTime = DateTime.Now;
            Usuario usuario = Usuario.UsuarioFactory.NewUsuario(Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), "Foo", "Ism", "foo@programming.com", dateTime, dateTime);
            Cnae cnae = Cnae.CnaeFactory.UpdateCnae(Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"), "GE2", "GE2", null, dateTime, dateTime, Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), true);
            cnae.AtribuirUsuario(usuario);

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel { Id = Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"), Nome = "Foo", Sobrenome = "Ism", Email = "foo@programming.com" };
            CnaeViewModel expectedValue = new CnaeViewModel() { Id = Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"), Ativo = true, Codigo = "GE2", Descricao = "GE2", CnaePai = null, DataCadastro = dateTime, DataUltimaAtualizacao = dateTime, Usuario = usuarioViewModel };

            _mockGruposEmpresariaisRepository.Setup(m => m.GetByCnaeId(Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"))).Returns(cnae);
            CnaeViewModel actualValue = _gruposEmpresariaisControllerRealMapper.GetCnae(Guid.Parse("4131468b-adb9-4805-b1ea-1ae7d5e38cf4"));

            Assert.Equal(JsonConvert.SerializeObject(expectedValue), JsonConvert.SerializeObject(actualValue));
        }
    }
}
