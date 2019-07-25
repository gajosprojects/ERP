using Bogus;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using ERP.Tests.Integration.Gerencial.DTO;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public GruposEmpresariaisControllerIntegrationTests()
        {
            Environment.CreateServer();
        }

        [Fact, Order(5)]
        public async Task GruposEmpresariaisController_Post_RetornarSucesso()
        {
            var grupoEmpresarialFake = new Faker<SaveGrupoEmpresarialViewModel>("pt_BR")
                .RuleFor(r => r.Codigo, c => c.Company.CompanyName())
                .RuleFor(r => r.Descricao, c => c.Company.CompanyName());

            SaveGrupoEmpresarialViewModel saveGrupoEmpresarialViewModel = grupoEmpresarialFake.Generate();
            saveGrupoEmpresarialViewModel.UsuarioId = Environment.UsuarioId;

            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(request => {
                request.Method = new HttpMethod("Post");
                request.Content = new StringContent(JsonConvert.SerializeObject(saveGrupoEmpresarialViewModel), Encoding.UTF8, "application/json");
            }).PostAsync();
            var grupoEmpresarialDTO = JsonConvert.DeserializeObject<GrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<GrupoEmpresarialDataResponse>(grupoEmpresarialDTO.data);
        }

        [Fact, Order(6)]
        public async Task GruposEmpresariaisController_Put_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var gruposEmpresariaisDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync());
            var grupoEmpresarialDTO = gruposEmpresariaisDTO.FirstOrDefault();

            var updateGrupoEmpresarialViewModel = new UpdateGrupoEmpresarialViewModel
            {
                Id = Guid.Parse(grupoEmpresarialDTO.id),
                Codigo = grupoEmpresarialDTO.codigo,
                Descricao = grupoEmpresarialDTO.descricao,
                UsuarioId = Environment.UsuarioId
            };

            response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(request => {
                request.Content = new StringContent(JsonConvert.SerializeObject(updateGrupoEmpresarialViewModel), Encoding.UTF8, "application/json");
            }).SendAsync("PUT");
            var updatedGrupoEmpresarialDTO = JsonConvert.DeserializeObject<GrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<GrupoEmpresarialDataResponse>(updatedGrupoEmpresarialDTO.data);
            Assert.NotEqual(grupoEmpresarialDTO.dataUltimaAtualizacao, updatedGrupoEmpresarialDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(7)]
        public async Task GruposEmpresariaisController_Delete_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var gruposEmpresariaisDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync());
            var grupoEmpresarialDTO = gruposEmpresariaisDTO.FirstOrDefault();

            response = await Environment.Server.CreateRequest("api/v1/gruposempresariais/" + grupoEmpresarialDTO.id).AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).SendAsync("DELETE");
            var deletedGrupoEmpresarialDTO = JsonConvert.DeserializeObject<GrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<GrupoEmpresarialDataResponse>(deletedGrupoEmpresarialDTO.data);
            Assert.False(deletedGrupoEmpresarialDTO.data.ativo);
            Assert.NotEqual(grupoEmpresarialDTO.dataUltimaAtualizacao, deletedGrupoEmpresarialDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(8)]
        public async Task GruposEmpresariaisController_GetAll_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var gruposEmpresariaisDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            gruposEmpresariaisDTO.Should().HaveCountGreaterThan(0);
        }

        [Fact, Order(9)]
        public async Task GruposEmpresariaisController_Get_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var gruposEmpresariaisDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.Server.CreateRequest("api/v1/gruposempresariais/" + gruposEmpresariaisDTO.FirstOrDefault().id).AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var grupoEmpresariaiDTO = JsonConvert.DeserializeObject<GetGrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            grupoEmpresariaiDTO.Should().BeEquivalentTo(gruposEmpresariaisDTO.FirstOrDefault());
        }
    }
}
