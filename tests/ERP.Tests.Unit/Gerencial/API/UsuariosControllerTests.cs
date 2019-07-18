using AutoMapper;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.Usuarios.Repositories;
using ERP.Infra.CrossCutting.Identity.Authorization;
using ERP.Services.API.Controllers.Gerencial;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ERP.Tests.Unit.Gerencial.API
{
    public class UsuariosControllerTests
    {
        public UsuariosController _usuariosController;
        public Mock<UserManager<IdentityUser>> _mockUserManager;
        public Mock<SignInManager<IdentityUser>> _mockSignInManager;
        public Mock<ILoggerFactory> _mockLogger;
        public Mock<TokenDescription> _mockTokenDescription;
        public Mock<DomainNotificationHandler> _mockNotification;
        public Mock<IUser> _mockUser;
        public Mock<IUsuariosRepository> _mockUsuariosRepository;
        public Mock<IMapper> _mockMapper;
        public Mock<IMediatorHandler> _mockMediator;


        public UsuariosControllerTests()
        {
            _mockUserManager = new Mock<UserManager<IdentityUser>>();
            _mockSignInManager = new Mock<SignInManager<IdentityUser>>();
            _mockLogger = new Mock<ILoggerFactory>();
            _mockTokenDescription = new Mock<TokenDescription>();
            _mockNotification = new Mock<DomainNotificationHandler>();
            _mockUser = new Mock<IUser>();
            _mockUsuariosRepository = new Mock<IUsuariosRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockMediator = new Mock<IMediatorHandler>();

            _usuariosController = new UsuariosController(_mockUserManager.Object, _mockSignInManager.Object, _mockLogger.Object, _mockTokenDescription.Object, _mockNotification.Object, _mockUser.Object, _mockUsuariosRepository.Object, _mockMediator.Object, _mockMapper.Object);
        }

        [Fact]
        public void UsuariosController_Login_RetornarSucesso()
        {

        }

        [Fact]
        public void UsuariosController_Login_RetornarUsuarioSenhaInvalidos()
        {

        }

        [Fact]
        public void UsuariosController_Register_RetornarSucesso()
        {

        }

        [Fact]
        public void UsuariosController_Register_RetornarErroCadastro()
        {

        }
    }
}
