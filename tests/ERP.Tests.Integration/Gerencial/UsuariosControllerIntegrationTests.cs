using ERP.Infra.CrossCutting.Identity.Models;
using ERP.Tests.Integration.Gerencial.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace ERP.Tests.Integration.Gerencial
{
    [Order(1)]
    public class UsuariosControllerIntegrationTests
    {
        public UsuariosControllerIntegrationTests()
        {
            Environment.CreateServer();
        }

        [Fact, Order(2)]
        public async Task UsuariosController_Register_RetornarSucesso()
        {
            var postContent = new StringContent(JsonConvert.SerializeObject(Environment.RegisterViewModel), Encoding.UTF8, "application/json");
            var response = await Environment.Client.PostAsync("api/v1/registro", postContent);
            var usuarioDTO = JsonConvert.DeserializeObject<UsuarioDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.NotEmpty(usuarioDTO.data.access_token);
        }

        [Fact, Order(3)]
        public async Task UsuariosController_Login_RetornarSucesso()
        {
            var loginViewModel = new LoginViewModel
            {
                Email = Environment.RegisterViewModel.Email,
                Senha = Environment.RegisterViewModel.Senha,
                RememberMe = false
            };

            var postContent = new StringContent(JsonConvert.SerializeObject(loginViewModel), Encoding.UTF8, "application/json");
            var response = await Environment.Client.PostAsync("api/v1/login", postContent);
            var usuarioDTO = JsonConvert.DeserializeObject<UsuarioDTO>(await response.Content.ReadAsStringAsync());
            Environment.TokenUsuario = usuarioDTO.data.access_token;
            Environment.UsuarioId = Guid.Parse(usuarioDTO.data.user.id);

            response.EnsureSuccessStatusCode();
            Assert.NotEmpty(usuarioDTO.data.access_token);
        }
    }
}
