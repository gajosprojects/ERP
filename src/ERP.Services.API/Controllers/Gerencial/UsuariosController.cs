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

namespace ERP.Services.API.Controllers.Gerencial
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

        /// <summary>
        /// Autenticação do usuário
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>Autentica o usuário, permitindo o uso de todas as ferramentas e serviços disponíveis para o seu perfil. É gerado um token que contém todas as informações e será passado em todas as requisições para o servidor.</remarks>
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
                return Response(await GenerateUserToken(model));
            }

            NotificarErro(result.ToString(), "Falha ao realizar o login");
            return Response(model);
        }

        /// <summary>
        /// Registra as informações do usuário
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>Registra o usuário como usuário padrão e permissão de visualização. Efetua o login na aplicação automaticamente, gerando um token que contém todas as informações e será passado em todas as requisições para o servidor.</remarks>
        [HttpPost]
        [AllowAnonymous]
        [Route("registro")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
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
                await _userManager.AddClaimAsync(user, new Claim("Grupo Empresarial", "Save"));
                await _userManager.AddClaimAsync(user, new Claim("Grupo Empresarial", "Update"));
                await _userManager.AddClaimAsync(user, new Claim("Grupo Empresarial", "Delete"));
                await _userManager.AddClaimAsync(user, new Claim("Grupo Empresarial", "View"));

                await _userManager.AddClaimAsync(user, new Claim("Cnae", "Save"));
                await _userManager.AddClaimAsync(user, new Claim("Cnae", "Update"));
                await _userManager.AddClaimAsync(user, new Claim("Cnae", "Delete"));
                await _userManager.AddClaimAsync(user, new Claim("Cnae", "View"));

                await _userManager.AddClaimAsync(user, new Claim("Empresa", "Save"));
                await _userManager.AddClaimAsync(user, new Claim("Empresa", "Update"));
                await _userManager.AddClaimAsync(user, new Claim("Empresa", "Delete"));
                await _userManager.AddClaimAsync(user, new Claim("Empresa", "View"));

                await _userManager.AddClaimAsync(user, new Claim("Estabelecimento", "Save"));
                await _userManager.AddClaimAsync(user, new Claim("Estabelecimento", "Update"));
                await _userManager.AddClaimAsync(user, new Claim("Estabelecimento", "Delete"));
                await _userManager.AddClaimAsync(user, new Claim("Estabelecimento", "View"));

                var usuarioCommand = new SaveUsuarioCommand(Guid.Parse(user.Id), model.Nome, model.Sobrenome, user.Email);
                await _mediator.SendCommand(usuarioCommand);

                if (!OperacaoValida())
                {
                    await _userManager.DeleteAsync(user);
                    return Response(model);
                }

                _logger.LogInformation(1, $"Usuario {model.Nome} criado com sucesso!");
                return Response(await GenerateUserToken(new LoginViewModel { Email = model.Email, Senha = model.Senha }));
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
