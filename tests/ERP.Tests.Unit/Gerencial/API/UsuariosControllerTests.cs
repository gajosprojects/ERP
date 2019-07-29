using AutoMapper;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.Usuarios;
using ERP.Gerencial.Domain.Usuarios.Commands;
using ERP.Gerencial.Domain.Usuarios.Repositories;
using ERP.Infra.CrossCutting.Identity.Authorization;
using ERP.Infra.CrossCutting.Identity.Models;
using ERP.Services.API.Controllers.Gerencial;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace ERP.Tests.Unit.Gerencial.API
{
    public class UsuariosControllerTests
    {
        public UsuariosController _usuariosController;
        public Mock<UserManager<IdentityUser>> _mockUserManager;
        public Mock<SignInManager<IdentityUser>> _mockSignInManager;
        public Mock<TokenDescription> _mockTokenDescription;
        public Mock<DomainNotificationHandler> _mockNotification;
        public Mock<IUser> _mockUser;
        public Mock<IUsuariosRepository> _mockUsuariosRepository;
        public Mock<IMapper> _mockMapper;
        public Mock<IMediatorHandler> _mockMediator;


        public UsuariosControllerTests()
        {
            _mockUserManager = new Mock<UserManager<IdentityUser>>(new Mock<IUserStore<IdentityUser>>().Object, new Mock<IOptions<IdentityOptions>>().Object, new Mock<IPasswordHasher<IdentityUser>>().Object, new IUserValidator<IdentityUser>[0], new IPasswordValidator<IdentityUser>[0], new Mock<ILookupNormalizer>().Object, new Mock<IdentityErrorDescriber>().Object, new Mock<IServiceProvider>().Object, new Mock<ILogger<UserManager<IdentityUser>>>().Object);
            _mockSignInManager = new Mock<SignInManager<IdentityUser>>(_mockUserManager.Object, new Mock<IHttpContextAccessor>().Object, new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object, new Mock<IOptions<IdentityOptions>>().Object, new Mock<ILogger<SignInManager<IdentityUser>>>().Object, new Mock<IAuthenticationSchemeProvider>().Object);
            _mockTokenDescription = new Mock<TokenDescription>();
            _mockNotification = new Mock<DomainNotificationHandler>();
            _mockUser = new Mock<IUser>();
            _mockUsuariosRepository = new Mock<IUsuariosRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockMediator = new Mock<IMediatorHandler>();
            var _loggerFactory = new ServiceCollection().AddLogging().BuildServiceProvider().GetService<ILoggerFactory>();

            _usuariosController = new UsuariosController(_mockUserManager.Object, _mockSignInManager.Object, _loggerFactory, _mockTokenDescription.Object, _mockNotification.Object, _mockUser.Object, _mockUsuariosRepository.Object, _mockMediator.Object, _mockMapper.Object);
        }

        [Fact]
        public void UsuariosController_Register_RetornarSucesso()
        {
            IList<Claim> claims = new List<Claim>();
            var registerViewModel = new RegisterViewModel { Nome = "Foo", Sobrenome = "Ism", Email = "foo.ism@gmail.com", CPF = "12345678909", Senha = "P@ssw0rd", ConfirmSenha = "P@ssw0rd", DataNascimento = DateTime.Now };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());
            _mockUserManager.Setup(m => m.CreateAsync(It.Is<IdentityUser>(u => u.UserName == registerViewModel.Email), registerViewModel.Senha)).Returns(Task.FromResult(IdentityResult.Success));
            _mockUserManager.Setup(m => m.FindByEmailAsync("foo.ism@gmail.com")).Returns(Task.FromResult(new IdentityUser { Email = "foo.ism@gmail.com" }));
            _mockUserManager.Setup(m => m.GetClaimsAsync(It.IsAny<IdentityUser>())).Returns(Task.FromResult(claims));
            _mockUsuariosRepository.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(Usuario.UsuarioFactory.NewUsuario(Guid.NewGuid(), "Foo", "Ism", "foo.ism@gmail.com", DateTime.Now, DateTime.Now));

            Assert.IsType<OkObjectResult>(_usuariosController.Register(registerViewModel).Result);
            _mockUserManager.Verify(m => m.AddClaimAsync(It.IsAny<IdentityUser>(), It.IsAny<Claim>()), Times.Exactly(4));
            _mockMediator.Verify(m => m.SendCommand(It.IsAny<SaveUsuarioCommand>()), Times.Once);
        }

        [Fact]
        public void UsuariosController_Register_RetornarErrosModelState()
        {
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Model error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _usuariosController.ModelState.AddModelError("Error", "Model error");

            Assert.IsType<BadRequestObjectResult>(_usuariosController.Register(new RegisterViewModel()).Result);
            _mockUserManager.Verify(m => m.CreateAsync(new IdentityUser(), ""), Times.Never);
        }

        [Fact]
        public void UsuariosController_Register_RetornarErrosIdentity()
        {
            var registerViewModel = new RegisterViewModel { Nome = "", Sobrenome = "", Email = "", CPF = "", Senha = "", ConfirmSenha = "", DataNascimento = DateTime.Now };
            var user = new IdentityUser { UserName = registerViewModel.Email, Email = registerViewModel.Email };
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Domain error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _mockUserManager.Setup(m => m.CreateAsync(It.Is<IdentityUser>(u => u.UserName == user.UserName), registerViewModel.Senha)).Returns(Task.FromResult(IdentityResult.Failed(new IdentityError { Code = "01", Description = "User already exists" })));

            Assert.IsType<BadRequestObjectResult>(_usuariosController.Register(registerViewModel).Result);
            _mockUserManager.Verify(m => m.AddClaimAsync(It.IsAny<IdentityUser>(), It.IsAny<Claim>()), Times.Never);
            _mockMediator.Verify(m => m.SendCommand(It.IsAny<SaveUsuarioCommand>()), Times.Never);
        }

        [Fact]
        public void UsuariosController_Register_RetornarErrosDominio()
        {
            var registerViewModel = new RegisterViewModel { Nome = "", Sobrenome = "", Email = "", CPF = "", Senha = "", ConfirmSenha = "", DataNascimento = DateTime.Now };
            var user = new IdentityUser { UserName = registerViewModel.Email, Email = registerViewModel.Email };
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Domain error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _mockUserManager.Setup(m => m.CreateAsync(It.Is<IdentityUser>(u => u.UserName == user.UserName), registerViewModel.Senha)).Returns(Task.FromResult(IdentityResult.Success));

            Assert.IsType<BadRequestObjectResult>(_usuariosController.Register(registerViewModel).Result);
            _mockUserManager.Verify(m => m.AddClaimAsync(It.IsAny<IdentityUser>(), It.IsAny<Claim>()), Times.Exactly(4));
        }

        [Fact]
        public void UsuariosController_Login_RetornarSucesso()
        {
            IList<Claim> claims = new List<Claim>();
            var loginViewModel = new LoginViewModel { Email = "foo.ism@gmail.com", Senha = "P@ssw0rd" };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());
            _mockSignInManager.Setup(m => m.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Senha, false, true)).Returns(Task.FromResult(Microsoft.AspNetCore.Identity.SignInResult.Success));
            _mockUserManager.Setup(m => m.FindByEmailAsync("foo.ism@gmail.com")).Returns(Task.FromResult(new IdentityUser { Email = "foo.ism@gmail.com" }));
            _mockUserManager.Setup(m => m.GetClaimsAsync(It.IsAny<IdentityUser>())).Returns(Task.FromResult(claims));
            _mockUsuariosRepository.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(Usuario.UsuarioFactory.NewUsuario(Guid.NewGuid(), "Foo", "Ism", "foo.ism@gmail.com", DateTime.Now, DateTime.Now));

            Assert.IsType<OkObjectResult>(_usuariosController.Login(loginViewModel).Result);
        }

        [Fact]
        public void UsuariosController_Login_RetornarErrosModelState()
        {
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Model error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _usuariosController.ModelState.AddModelError("Error", "Model error");

            Assert.IsType<BadRequestObjectResult>(_usuariosController.Login(new LoginViewModel()).Result);
            _mockSignInManager.Verify(m => m.PasswordSignInAsync("", "", false, true), Times.Never);
        }

        [Fact]
        public void UsuariosController_Login_RetornarErrosIdentity()
        {
            var notificationList = new List<DomainNotification> { new DomainNotification("Error", "Domain error") };
            _mockNotification.Setup(m => m.GetNotifications()).Returns(notificationList);
            _mockNotification.Setup(m => m.HasNotifications()).Returns(true);
            _mockSignInManager.Setup(m => m.PasswordSignInAsync("", "", false, true)).Returns(Task.FromResult(Microsoft.AspNetCore.Identity.SignInResult.Failed));

            Assert.IsType<BadRequestObjectResult>(_usuariosController.Login(new LoginViewModel { Email = "", Senha = "" }).Result);
            _mockSignInManager.Verify(m => m.PasswordSignInAsync("", "", false, true), Times.Once);
        }
    }
}
