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
using ERP.Services.API.ViewModels.Gerencial.Cnae;
using ERP.Services.API.ViewModels.Gerencial.Empresa;
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
            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(r => r.Content = ViewModelGen.GenerateSaveGrupoEmpresarialViewModel()).PostAsync();
            var grupoEmpresarialDTO = JsonConvert.DeserializeObject<GrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<GrupoEmpresarialDataResponse>(grupoEmpresarialDTO.data);
        }

        [Fact, Order(6)]
        public async Task GruposEmpresariaisController_Put_GrupoEmpresarial_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var grupoEmpresarialDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();
            var updateGrupoEmpresarialViewModel = new UpdateGrupoEmpresarialViewModel { Id = Guid.Parse(grupoEmpresarialDTO.id), Codigo = grupoEmpresarialDTO.codigo, Descricao = grupoEmpresarialDTO.descricao, UsuarioId = Environment.UsuarioId };

            response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(r => r.Content = ViewModelGen.ConvertViewModelToStringContent(updateGrupoEmpresarialViewModel)).SendAsync("PUT");
            var updatedGrupoEmpresarialDTO = JsonConvert.DeserializeObject<GrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<GrupoEmpresarialDataResponse>(updatedGrupoEmpresarialDTO.data);
            Assert.NotEqual(grupoEmpresarialDTO.dataUltimaAtualizacao, updatedGrupoEmpresarialDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(7)]
        public async Task GruposEmpresariaisController_GetAll_GrupoEmpresarial_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var gruposEmpresariaisDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            gruposEmpresariaisDTO.Should().HaveCountGreaterThan(0);
        }

        [Fact, Order(8)]
        public async Task GruposEmpresariaisController_Get_GrupoEmpresarial_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var gruposEmpresariaisDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.Server.CreateRequest("api/v1/gruposempresariais/" + gruposEmpresariaisDTO.FirstOrDefault().id).AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var grupoEmpresarialDTO = JsonConvert.DeserializeObject<GetGrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            grupoEmpresarialDTO.Should().BeEquivalentTo(gruposEmpresariaisDTO.FirstOrDefault());
        }

        [Fact, Order(9)]
        public async Task GruposEmpresariaisController_Post_Cnae_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/cnaes").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(r => r.Content = ViewModelGen.GenerateSaveCnaeViewModel()).PostAsync();
            var cnaeDTO = JsonConvert.DeserializeObject<CnaeDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<CnaeDataResponse>(cnaeDTO.data);
        }

        [Fact, Order(10)]
        public async Task GruposEmpresariaisController_Put_Cnae_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/cnaes").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var cnaeDTO = JsonConvert.DeserializeObject<IEnumerable<GetCnaeDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();
            var updateCnaeViewModel = new UpdateCnaeViewModel { Id = Guid.Parse(cnaeDTO.id), Codigo = cnaeDTO.codigo, Descricao = cnaeDTO.descricao, UsuarioId = Environment.UsuarioId };

            response = await Environment.Server.CreateRequest("api/v1/cnaes").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(r => r.Content = ViewModelGen.ConvertViewModelToStringContent(updateCnaeViewModel)).SendAsync("PUT");
            var updatedCnaeDTO = JsonConvert.DeserializeObject<CnaeDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<CnaeDataResponse>(updatedCnaeDTO.data);
            Assert.NotEqual(cnaeDTO.dataUltimaAtualizacao, updatedCnaeDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(11)]
        public async Task GruposEmpresariaisController_GetAll_Cnae_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/cnaes").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var cnaesDTO = JsonConvert.DeserializeObject<IEnumerable<GetCnaeDTO>>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            cnaesDTO.Should().HaveCountGreaterThan(0);
        }

        [Fact, Order(12)]
        public async Task GruposEmpresariaisController_Get_Cnae_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/cnaes").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var cnaesDTO = JsonConvert.DeserializeObject<IEnumerable<GetCnaeDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.Server.CreateRequest("api/v1/cnaes/" + cnaesDTO.FirstOrDefault().id).AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var cnaeDTO = JsonConvert.DeserializeObject<GetCnaeDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            cnaeDTO.Should().BeEquivalentTo(cnaesDTO.FirstOrDefault());
        }

        [Fact, Order(13)]
        public async Task GruposEmpresariaisController_Post_Empresa_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var gruposEmpresariaisDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.Server.CreateRequest("api/v1/empresas").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(r => r.Content = ViewModelGen.GenerateSaveEmpresaViewModel(gruposEmpresariaisDTO.First().id)).PostAsync();
            var empresaDTO = JsonConvert.DeserializeObject<EmpresaDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<EmpresaDataResponse>(empresaDTO.data);
        }

        [Fact, Order(14)]
        public async Task GruposEmpresariaisController_Put_Empresa_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/empresas").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var empresaDTO = JsonConvert.DeserializeObject<IEnumerable<GetEmpresaDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();

            response = await Environment.Server.CreateRequest("api/v1/empresas").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(r => r.Content = ViewModelGen.ConvertViewModelToStringContent(ConvertDTOTo.UpdateEmpresaViewModel(empresaDTO))).SendAsync("PUT");
            var updatedEmpresaDTO = JsonConvert.DeserializeObject<EmpresaDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<EmpresaDataResponse>(updatedEmpresaDTO.data);
            Assert.NotEqual(empresaDTO.dataUltimaAtualizacao, updatedEmpresaDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(15)]
        public async Task GruposEmpresariaisController_GetAll_Empresa_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/empresas").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var empresasDTO = JsonConvert.DeserializeObject<IEnumerable<GetEmpresaDTO>>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            empresasDTO.Should().HaveCountGreaterThan(0);
        }

        [Fact, Order(16)]
        public async Task GruposEmpresariaisController_Get_Empresa_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/empresas").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var empresasDTO = JsonConvert.DeserializeObject<IEnumerable<GetEmpresaDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.Server.CreateRequest("api/v1/empresas/" + empresasDTO.FirstOrDefault().id).AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var empresaDTO = JsonConvert.DeserializeObject<GetEmpresaDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            empresaDTO.Should().BeEquivalentTo(empresasDTO.FirstOrDefault());
        }

        [Fact, Order(17)]
        public async Task GruposEmpresariaisController_Post_Estabelecimento_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/empresas").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var empresasDTO = JsonConvert.DeserializeObject<IEnumerable<GetEmpresaDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.Server.CreateRequest("api/v1/cnaes").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var cnaesDTO = JsonConvert.DeserializeObject<IEnumerable<GetCnaeDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.Server.CreateRequest("api/v1/estabelecimentos").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(r => r.Content = ViewModelGen.GenerateSaveEstabelecimentoViewModel(empresasDTO?.FirstOrDefault()?.id, cnaesDTO?.FirstOrDefault()?.id)).PostAsync();
            var estabelecimentoDTO = JsonConvert.DeserializeObject<EstabelecimentoDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<EstabelecimentoDataResponse>(estabelecimentoDTO.data);
        }

        [Fact, Order(18)]
        public async Task GruposEmpresariaisController_Put_Estabelecimento_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/estabelecimentos").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var estabelecimentoDTO = JsonConvert.DeserializeObject<IEnumerable<GetEstabelecimentoDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();

            response = await Environment.Server.CreateRequest("api/v1/estabelecimentos").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).And(r => r.Content = ViewModelGen.ConvertViewModelToStringContent(ConvertDTOTo.UpdateEstabelecimentoViewModel(estabelecimentoDTO))).SendAsync("PUT");
            var updatedEstabelecimentoDTO = JsonConvert.DeserializeObject<EstabelecimentoDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<EstabelecimentoDataResponse>(updatedEstabelecimentoDTO.data);
            Assert.NotEqual(estabelecimentoDTO.dataUltimaAtualizacao, updatedEstabelecimentoDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(19)]
        public async Task GruposEmpresariaisController_GetAll_Estabelecimento_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/estabelecimentos").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var estabelecimentosDTO = JsonConvert.DeserializeObject<IEnumerable<GetEstabelecimentoDTO>>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            estabelecimentosDTO.Should().HaveCountGreaterThan(0);
        }

        [Fact, Order(20)]
        public async Task GruposEmpresariaisController_Get_Estabelecimento_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/estabelecimentos").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var estabelecimentosDTO = JsonConvert.DeserializeObject<IEnumerable<GetEstabelecimentoDTO>>(await response.Content.ReadAsStringAsync());

            response = await Environment.Server.CreateRequest("api/v1/estabelecimentos/" + estabelecimentosDTO.FirstOrDefault().id).AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var estabelecimentoDTO = JsonConvert.DeserializeObject<GetEstabelecimentoDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            estabelecimentoDTO.Should().BeEquivalentTo(estabelecimentosDTO.FirstOrDefault());
        }

        [Fact, Order(21)]
        public async Task GruposEmpresariaisController_Delete_GrupoEmpresarial_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/gruposempresariais").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var grupoEmpresarialDTO = JsonConvert.DeserializeObject<IEnumerable<GetGrupoEmpresarialDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();

            response = await Environment.Server.CreateRequest("api/v1/gruposempresariais/" + grupoEmpresarialDTO.id).AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).SendAsync("DELETE");
            var deletedGrupoEmpresarialDTO = JsonConvert.DeserializeObject<GrupoEmpresarialDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<GrupoEmpresarialDataResponse>(deletedGrupoEmpresarialDTO.data);
            Assert.False(deletedGrupoEmpresarialDTO.data.ativo);
            Assert.NotEqual(grupoEmpresarialDTO.dataUltimaAtualizacao, deletedGrupoEmpresarialDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(22)]
        public async Task GruposEmpresariaisController_Delete_Cnae_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/cnaes").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var cnaeDTO = JsonConvert.DeserializeObject<IEnumerable<GetCnaeDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();

            response = await Environment.Server.CreateRequest("api/v1/cnaes/" + cnaeDTO.id).AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).SendAsync("DELETE");
            var deletedCnaeDTO = JsonConvert.DeserializeObject<CnaeDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<CnaeDataResponse>(deletedCnaeDTO.data);
            Assert.False(deletedCnaeDTO.data.ativo);
            Assert.NotEqual(cnaeDTO.dataUltimaAtualizacao, deletedCnaeDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(23)]
        public async Task GruposEmpresariaisController_Delete_Empresa_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/empresas").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var empresaDTO = JsonConvert.DeserializeObject<IEnumerable<GetEmpresaDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();

            response = await Environment.Server.CreateRequest("api/v1/empresas/" + empresaDTO.id).AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).SendAsync("DELETE");
            var deletedEmpresaDTO = JsonConvert.DeserializeObject<EmpresaDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<EmpresaDataResponse>(deletedEmpresaDTO.data);
            Assert.False(deletedEmpresaDTO.data.ativo);
            Assert.NotEqual(empresaDTO.dataUltimaAtualizacao, deletedEmpresaDTO.data.dataUltimaAtualizacao);
        }

        [Fact, Order(24)]
        public async Task GruposEmpresariaisController_Delete_Estabelecimento_RetornarSucesso()
        {
            var response = await Environment.Server.CreateRequest("api/v1/estabelecimentos").AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).GetAsync();
            var estabelecimentoDTO = JsonConvert.DeserializeObject<IEnumerable<GetEstabelecimentoDTO>>(await response.Content.ReadAsStringAsync()).FirstOrDefault();

            response = await Environment.Server.CreateRequest("api/v1/estabelecimentos/" + estabelecimentoDTO.id).AddHeader("Authorization", "Bearer " + Environment.TokenUsuario).SendAsync("DELETE");
            var deletedEstabelecimentoDTO = JsonConvert.DeserializeObject<EstabelecimentoDTO>(await response.Content.ReadAsStringAsync());

            response.EnsureSuccessStatusCode();
            Assert.IsType<EstabelecimentoDataResponse>(deletedEstabelecimentoDTO.data);
            Assert.False(deletedEstabelecimentoDTO.data.ativo);
            Assert.NotEqual(estabelecimentoDTO.dataUltimaAtualizacao, deletedEstabelecimentoDTO.data.dataUltimaAtualizacao);
        }
    }
}
