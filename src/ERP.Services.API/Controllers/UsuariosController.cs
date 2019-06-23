using AutoMapper;
using ERP.Domain.Core.Bus;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Notifications;
using ERP.Gerencial.Domain.Usuarios.Commands;
using ERP.Gerencial.Domain.Usuarios.Repositories;
using ERP.Infra.CrossCutting.Identity.Authorization;
using ERP.Infra.CrossCutting.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ERP.Services.API.Controllers
{
    public class UsuariosController : BaseController
    {
        private static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger _logger;
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IMediatorHandler _mediator;
        private readonly TokenDescription _tokenDescription;
        private readonly IMapper _mapper;

        public UsuariosController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILoggerFactory loggerFactory, TokenDescription tokenDescriptor, INotificationHandler<DomainNotification> notifications, IUser user, IUsuariosRepository usuarioRepository, IMediatorHandler mediator, IMapper mapper) : base(notifications, user, mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usuariosRepository = usuarioRepository;
            _mediator = mediator;
            _logger = loggerFactory.CreateLogger<UsuariosController>();
            _tokenDescription = tokenDescriptor;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, false, true);

            if (result.Succeeded)
            {
                _logger.LogInformation(1, $"Usuario {model.Email} logado com sucesso");
                var response = GenerateUserToken(model);
                return Response(response);
            }

            NotificarErro(result.ToString(), "Falha ao realizar o login");
            return Response(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("registro")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model, int version)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Senha);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("ERP", "Visualizar"));

                var usuarioCommand = new SaveUsuarioCommand(Guid.Parse(user.Id), model.Nome, model.Sobrenome, user.Email);
                await _mediator.SendCommand(usuarioCommand);

                if (!OperacaoValida())
                {
                    await _userManager.DeleteAsync(user);
                    return Response(model);
                }

                _logger.LogInformation(1, $"Usuario {model.Nome} criado com sucesso!");
                var response = GenerateUserToken(new LoginViewModel { Email = model.Email, Senha = model.Senha });
                return Response(response);
            }

            AdicionarErrosIdentity(result);
            return Response(model);
        }

        private async Task<object> GenerateUserToken(LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            var userClaims = await _userManager.GetClaimsAsync(user);

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(userClaims);

            var handler = new JwtSecurityTokenHandler();
            var signingConf = new SigningCredentialsConfiguration();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenDescription.Issuer,
                Audience = _tokenDescription.Audience,
                SigningCredentials = signingConf.SigningCredentials,
                Subject = identityClaims,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(_tokenDescription.MinutesValid)
            });

            var encodedJwt = handler.WriteToken(securityToken);
            var usuario = _usuariosRepository.GetById(Guid.Parse(user.Id));

            var response = new
            {
                access_token = encodedJwt,
                expires_in = DateTime.Now.AddMinutes(_tokenDescription.MinutesValid),
                user = new
                {
                    id = user.Id,
                    nome = usuario.Nome,
                    email = usuario.Email,
                    claims = userClaims.Select(c => new { c.Type, c.Value })
                }
            };

            return response;
        }


    }
}
