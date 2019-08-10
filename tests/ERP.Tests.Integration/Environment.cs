using Bogus;
using Bogus.Extensions.Brazil;
using ERP.Infra.CrossCutting.Identity.Models;
using ERP.Services.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ERP.Tests.Integration
{
    public class Environment
    {
        public static TestServer Server { get; set; }
        public static HttpClient Client { get; set; }
        public static RegisterViewModel RegisterViewModel { get; set; }
        public static Guid UsuarioId { get; set; }
        public static String TokenUsuario { get; set; }

        public static void CreateServer()
        {
            Server = new TestServer(
                new WebHostBuilder()
                    .UseKestrel()
                    .UseEnvironment("Testing")
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseUrls("http://localhost:9898")
                    .UseStartup<StartupTests>());

            var usuarioFake = new Faker<RegisterViewModel>("pt_BR")
                .RuleFor(r => r.Nome, c => c.Name.FirstName())
                .RuleFor(r => r.Sobrenome, c => c.Name.LastName())
                .RuleFor(r => r.CPF, c => c.Person.Cpf().Replace(".", "").Replace("-", ""))
                .RuleFor(r => r.Email, (f, r) => f.Internet.Email(r.Nome, r.Sobrenome).ToLower());

            if (RegisterViewModel == null)
            {
                RegisterViewModel = usuarioFake.Generate();
                RegisterViewModel.DataNascimento = new DateTime(2000, 1, 1);
                RegisterViewModel.Senha = "P@ssw0rd";
                RegisterViewModel.ConfirmSenha = "P@ssw0rd";
            }

            Client = Server.CreateClient();
        }

        public static Task<HttpResponseMessage> CreateGetRequest(string path) => Server.CreateRequest(path).AddHeader("Authorization", "Bearer " + TokenUsuario).GetAsync();

        public static Task<HttpResponseMessage> CreateRequest(string method, string path, StringContent content) => Server.CreateRequest(path).AddHeader("Authorization", "Bearer " + TokenUsuario).And(r => r.Content = content).SendAsync(method);
    }
}
