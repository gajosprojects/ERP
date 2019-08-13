using Bogus;
using Bogus.Extensions.Brazil;
using ERP.Services.API.ViewModels.Gerencial.Cnae;
using ERP.Services.API.ViewModels.Gerencial.Empresa;
using ERP.Services.API.ViewModels.Gerencial.Estabelecimento;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace ERP.Tests.Integration.Gerencial
{
    public static class ViewModelGen
    {
        public static StringContent ConvertViewModelToStringContent(object viewModel)
        {
            return new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
        }

        public static StringContent GenerateSaveGrupoEmpresarialViewModel()
        {
            return new StringContent(JsonConvert.SerializeObject(
                new Faker<SaveGrupoEmpresarialViewModel>("pt_BR")
                .RuleFor(r => r.Codigo, c => c.Company.CompanyName())
                .RuleFor(r => r.Descricao, c => c.Company.CompanyName())
                .RuleFor(r => r.UsuarioId, Environment.UsuarioId)
                .Generate()), Encoding.UTF8, "application/json");
        }

        public static StringContent GenerateSaveCnaeViewModel()
        {
            return new StringContent(JsonConvert.SerializeObject(
                new Faker<SaveCnaeViewModel>("pt_BR")
                    .RuleFor(r => r.Codigo, c => c.Person.Cpf().Replace(".", "").Replace("-", "").Substring(0,6))
                    .RuleFor(r => r.Descricao, c => c.Company.CompanyName())
                    .RuleFor(r => r.UsuarioId, Environment.UsuarioId)
                    .Generate()), Encoding.UTF8, "application/json");
        }

        public static StringContent GenerateSaveEmpresaViewModel(string gruposEmpresariaisId)
        {
            return new StringContent(JsonConvert.SerializeObject(
                new Faker<SaveEmpresaViewModel>("pt_BR")
                    .RuleFor(r => r.Codigo, c => c.Company.CompanyName().Substring(0, 6))
                    .RuleFor(r => r.Descricao, c => c.Company.CompanyName())
                    .RuleFor(r => r.NomeFantasia, c => c.Company.CompanyName())
                    .RuleFor(r => r.Email, c => c.Person.Email)
                    .RuleFor(r => r.Site, c => c.Person.Website)
                    .RuleFor(r => r.Bloqueada, false)
                    .RuleFor(r => r.DataRegistro, c => c.Person.DateOfBirth)
                    .RuleFor(r => r.Documento, c => c.Company.Cnpj().Replace(".", "").Replace("-", "").Replace("/", ""))
                    .RuleFor(r => r.TipoIdentificacao, 2)
                    .RuleFor(r => r.GrupoEmpresarialId, Guid.Parse(gruposEmpresariaisId))
                    .RuleFor(r => r.UsuarioId, Environment.UsuarioId)
                    .Generate()), Encoding.UTF8, "application/json");
        }

        public static StringContent GenerateSaveEstabelecimentoViewModel(string empresaId, string cnaeId)
        {
            return new StringContent(JsonConvert.SerializeObject(
                new Faker<SaveEstabelecimentoViewModel>("pt_BR")
                    .RuleFor(r => r.Codigo, c => c.Company.CompanyName().Substring(0, 6))
                    .RuleFor(r => r.Descricao, c => c.Company.CompanyName())
                    .RuleFor(r => r.NomeFantasia, c => c.Company.CompanyName())
                    .RuleFor(r => r.Email, c => c.Person.Email)
                    .RuleFor(r => r.Site, c => c.Person.Website)
                    .RuleFor(r => r.Bloqueado, false)
                    .RuleFor(r => r.DataRegistro, c => c.Person.DateOfBirth)
                    .RuleFor(r => r.Documento, c => c.Company.Cnpj().Replace(".", "").Replace("-", "").Replace("/", ""))
                    .RuleFor(r => r.TipoIdentificacao, 2)
                    .RuleFor(r => r.InscricaoEstadual, c => c.Person.Cpf().Replace(".", "").Replace("-", "").Substring(0, 9) + c.Person.Cpf().Replace(".", "").Replace("-", ""))
                    .RuleFor(r => r.InscricaoMunicipal, c => c.Person.Cpf().Replace(".", "").Replace("-", "").Substring(0, 9) + c.Person.Cpf().Replace(".", "").Replace("-", ""))
                    .RuleFor(r => r.CnaeId, Guid.Parse(cnaeId))
                    .RuleFor(r => r.EmpresaId, Guid.Parse(empresaId))
                    .RuleFor(r => r.UsuarioId, Environment.UsuarioId)
                    .Generate()), Encoding.UTF8, "application/json");
        }
    }
}