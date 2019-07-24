using Bogus;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using ERP.Tests.Integration.Gerencial.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace ERP.Tests.Integration.Gerencial
{
    [Order(4)]
    public class GruposEmpresariaisControllerIntegrationTests
    {
        public GrupoEmpresarialDTO SavedGrupoEmpresarial { get; set; }

        public GruposEmpresariaisControllerIntegrationTests()
        {
            Environment.CreateServer();
        }

        [Fact, Order(5)]
        public async Task GruposEmpresariaisController_Save_RetornarSucesso()
        {
            var grupoEmpresarialFake = new Faker<SaveGrupoEmpresarialViewModel>("pt_BR")
                .RuleFor(r => r.Codigo, c => c.Company.CompanyName())
                .RuleFor(r => r.Descricao, c => c.Company.CompanyName());

            SaveGrupoEmpresarialViewModel saveGrupoEmpresarialViewModel = grupoEmpresarialFake.Generate();
            saveGrupoEmpresarialViewModel.UsuarioId = Environment.UsuarioId;

            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(request => request.Content = new StringContent(JsonConvert.SerializeObject(saveGrupoEmpresarialViewModel), Encoding.UTF8, "application/json")).PostAsync();
            var grupoEmpresarialDTO = JsonConvert.DeserializeObject<GrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());
            SavedGrupoEmpresarial = grupoEmpresarialDTO;

            response.EnsureSuccessStatusCode();
            Assert.IsType<GrupoEmpresarialDataResponse>(grupoEmpresarialDTO.data);
        }
    }
}
