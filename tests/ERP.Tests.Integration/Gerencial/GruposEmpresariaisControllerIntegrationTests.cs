using ERP.Services.API.ViewModels.Gerencial.Cnae;
using ERP.Services.API.ViewModels.Gerencial.Empresa;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using ERP.Tests.Integration.Gerencial.DTO;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Services.API.ViewModels.Gerencial.Estabelecimento;
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
        public async Task GruposEmpresariaisController_Post_GrupoEmpresarial_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("POST", "api/v1/gruposempresariais", ViewModelGen.GenerateSaveGrupoEmpresarialViewModel()).PostAsync();
            var grupoEmpresarialDTO = JsonConvert.DeserializeObject<GrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<GrupoEmpresarialDataResponse>(grupoEmpresarialDTO.data);
        }

        [Fact, Order(6)]
        public async Task GruposEmpresariaisController_Put_GrupoEmpresarial_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/gruposempresariais", null).GetAsync();
            var grupoEmpresarialDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();
            var updateGrupoEmpresarialViewModel = new UpdateGrupoEmpresarialViewModel { Id = Guid.Parse(grupoEmpresarialDTO.id), Codigo = grupoEmpresarialDTO.codigo, Descricao = grupoEmpresarialDTO.descricao, UsuarioId = Environment.UsuarioId };

            response = await Environment.CreateRequest("PUT", "api/v1/gruposempresariais", updateGrupoEmpresarialViewModel).SendAsync("PUT");
            var updatedGrupoEmpresarialDTO = JsonConvert.DeserializeObject<GrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<GrupoEmpresarialDataResponse>(updatedGrupoEmpresarialDTO.data);
            Assert.NotEqual(grupoEmpresarialDTO.dataUltimaAtualizacao, updatedGrupoEmpresarialDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(7)]
        public async Task GruposEmpresariaisController_GetAll_GrupoEmpresarial_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/gruposempresariais", null).GetAsync();
            var gruposEmpresariaisDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            gruposEmpresariaisDTO.Should().HaveCountGreaterThan(0);
        }

        [Fact, Order(8)]
        public async Task GruposEmpresariaisController_Get_GrupoEmpresarial_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/gruposempresariais", null).GetAsync();
            var gruposEmpresariaisDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.CreateRequest("GET", "api/v1/gruposempresariais/" + gruposEmpresariaisDTO.FirstOrDefault().id, null).GetAsync();
            var grupoEmpresarialDTO = JsonConvert.DeserializeObject<GetGrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            grupoEmpresarialDTO.Should().BeEquivalentTo(gruposEmpresariaisDTO.FirstOrDefault());
        }

        [Fact, Order(9)]
        public async Task GruposEmpresariaisController_Post_Cnae_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("POST", "api/v1/cnaes", ViewModelGen.GenerateSaveCnaeViewModel()).PostAsync();
            var cnaeDTO = JsonConvert.DeserializeObject<CnaeDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<CnaeDataResponse>(cnaeDTO.data);
        }

        [Fact, Order(10)]
        public async Task GruposEmpresariaisController_Put_Cnae_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/cnaes", null).GetAsync();
            var cnaeDTO = JsonConvert.DeserializeObject<IEnumerable<GetCnaeDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();
            var updateCnaeViewModel = new UpdateCnaeViewModel { Id = Guid.Parse(cnaeDTO.id), Codigo = cnaeDTO.codigo, Descricao = cnaeDTO.descricao, UsuarioId = Environment.UsuarioId };

            response = await Environment.CreateRequest("PUT", "api/v1/cnaes", updateCnaeViewModel).SendAsync("PUT");
            var updatedCnaeDTO = JsonConvert.DeserializeObject<CnaeDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<CnaeDataResponse>(updatedCnaeDTO.data);
            Assert.NotEqual(cnaeDTO.dataUltimaAtualizacao, updatedCnaeDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(11)]
        public async Task GruposEmpresariaisController_GetAll_Cnae_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/cnaes", null).GetAsync();
            var cnaesDTO = JsonConvert.DeserializeObject<IEnumerable<GetCnaeDTO>>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            cnaesDTO.Should().HaveCountGreaterThan(0);
        }

        [Fact, Order(12)]
        public async Task GruposEmpresariaisController_Get_Cnae_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/cnaes", null).GetAsync();
            var cnaesDTO = JsonConvert.DeserializeObject<IEnumerable<GetCnaeDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.CreateRequest("GET", "api/v1/cnaes" + cnaesDTO.FirstOrDefault().id, null).GetAsync();
            var cnaeDTO = JsonConvert.DeserializeObject<GetGrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            cnaeDTO.Should().BeEquivalentTo(cnaesDTO.FirstOrDefault());
        }

        [Fact, Order(13)]
        public async Task GruposEmpresariaisController_Post_Empresa_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/gruposempresariais", null).GetAsync();
            var gruposEmpresariaisDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.CreateRequest("POST", "api/v1/empresas", ViewModelGen.GenerateSaveEmpresaViewModel(gruposEmpresariaisDTO.First().id)).PostAsync();
            var empresaDTO = JsonConvert.DeserializeObject<CnaeDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<EmpresaDataResponse>(empresaDTO.data);
        }

        [Fact, Order(14)]
        public async Task GruposEmpresariaisController_Put_Empresa_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/empresas").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var empresaDTO = JsonConvert.DeserializeObject<IEnumerable<GetEmpresaDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();
            var updateEmpresaViewModel = new UpdateEmpresaViewModel { Id = Guid.Parse(empresaDTO.id), Codigo = empresaDTO.codigo, Descricao = empresaDTO.descricao, UsuarioId = Environment.UsuarioId };

            response = await Environment.CreateRequest("PUT", "api/v1/empresas", updateEmpresaViewModel).SendAsync("PUT");
            var updatedEmpresaDTO = JsonConvert.DeserializeObject<EmpresaDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<EmpresaDataResponse>(updatedEmpresaDTO.data);
            Assert.NotEqual(empresaDTO.dataUltimaAtualizacao, updatedEmpresaDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(15)]
        public async Task GruposEmpresariaisController_GetAll_Empresa_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/empresas", null).GetAsync();
            var empresasDTO = JsonConvert.DeserializeObject<IEnumerable<GetEmpresaDTO>>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            empresasDTO.Should().HaveCountGreaterThan(0);
        }

        [Fact, Order(16)]
        public async Task GruposEmpresariaisController_Get_Empresa_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/empresas", null).GetAsync();
            var empresasDTO = JsonConvert.DeserializeObject<IEnumerable<GetEmpresaDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.CreateRequest("GET", "api/v1/empresas" + empresasDTO.FirstOrDefault().id, null).GetAsync();
            var empresaDTO = JsonConvert.DeserializeObject<GetGrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            empresaDTO.Should().BeEquivalentTo(empresasDTO.FirstOrDefault());
        }

        [Fact, Order(17)]
        public async Task GruposEmpresariaisController_Post_Estabelecimento_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/empresas", null).GetAsync();
            var empresasDTO = JsonConvert.DeserializeObject<IEnumerable<GetEmpresaDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.CreateRequest("GET", "api/v1/cnaes", null).GetAsync();
            var cnaesDTO = JsonConvert.DeserializeObject<IEnumerable<GetCnaeDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.CreateRequest("POST", "api/v1/estabelecimentos", ViewModelGen.GenerateSaveEstabelecimentoViewModel(empresasDTO.First().id, cnaesDTO.First().id)).PostAsync();
            var estabelecimentoDTO = JsonConvert.DeserializeObject<EstabelecimentoDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<EstabelecimentoDataResponse>(estabelecimentoDTO.data);
        }

        [Fact, Order(18)]
        public async Task GruposEstabelecimentoriaisController_Put_Estabelecimento_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/estabelecimentos", null).GetAsync();
            var estabelecimentoDTO = JsonConvert.DeserializeObject<IEnumerable<GetEstabelecimentoDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();
            var updateEstabelecimentoViewModel = new UpdateEstabelecimentoViewModel { Id = Guid.Parse(estabelecimentoDTO.id), Codigo = estabelecimentoDTO.codigo, Descricao = estabelecimentoDTO.descricao, UsuarioId = Environment.UsuarioId };

            response = await Environment.CreateRequest("PUT", "api/v1/estabelecimentos", updateEstabelecimentoViewModel).SendAsync("PUT");
            var updatedEstabelecimentoDTO = JsonConvert.DeserializeObject<EstabelecimentoDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<EstabelecimentoDataResponse>(updatedEstabelecimentoDTO.data);
            Assert.NotEqual(estabelecimentoDTO.dataUltimaAtualizacao, updatedEstabelecimentoDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(19)]
        public async Task GruposEstabelecimentoriaisController_GetAll_Estabelecimento_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/estabelecimentos", null).GetAsync();
            var estabelecimentosDTO = JsonConvert.DeserializeObject<IEnumerable<GetEstabelecimentoDTO>>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            estabelecimentosDTO.Should().HaveCountGreaterThan(0);
        }

        [Fact, Order(20)]
        public async Task GruposEstabelecimentoriaisController_Get_Estabelecimento_RetornarSucesso()
        {
            var response = await Environment.CreateRequest("GET", "api/v1/estabelecimentos", null).GetAsync();
            var estabelecimentosDTO = JsonConvert.DeserializeObject<IEnumerable<GetEstabelecimentoDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.CreateRequest("GET", "api/v1/estabelecimentos" + estabelecimentosDTO.FirstOrDefault().id, null).GetAsync();
            var estabelecimentoDTO = JsonConvert.DeserializeObject<GetEstabelecimentoDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            estabelecimentoDTO.Should().BeEquivalentTo(estabelecimentosDTO.FirstOrDefault());
        }
    }
}
