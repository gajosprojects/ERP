using ERP.Services.API.ViewModels.Gerencial.Cnae;
using ERP.Services.API.ViewModels.Gerencial.Empresa;
using ERP.Services.API.ViewModels.Gerencial.Estabelecimento;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using System;

namespace ERP.Tests.Integration.Gerencial.DTO
{
    public static class ConvertDTOTo
    {
        public static UpdateGrupoEmpresarialViewModel UpdateGrupoEmpresarialViewModel(GetGrupoEmpresarialDTO dto)
        {
            return new UpdateGrupoEmpresarialViewModel
            {
                Id = Guid.Parse(dto.id),
                Codigo = dto.codigo,
                Descricao = dto.descricao,
                UsuarioId = Guid.Parse(dto.usuario.id)
            };
        }

        public static UpdateCnaeViewModel UpdateCnaeViewModel(GetCnaeDTO dto)
        {
            return new UpdateCnaeViewModel
            {
                Id = Guid.Parse(dto.id),
                Codigo = dto.codigo,
                Descricao = dto.descricao,
                UsuarioId = Guid.Parse(dto.usuario.id)
            };
        }

        public static UpdateEmpresaViewModel UpdateEmpresaViewModel(GetEmpresaDTO dto)
        {
            return new UpdateEmpresaViewModel
            {
                Id = Guid.Parse(dto.id),
                UsuarioId = Guid.Parse(dto.usuario.id),
                GrupoEmpresarialId = Guid.Parse(dto.grupoEmpresarial.id),
                DataRegistro = dto.dataRegistro,
                TipoIdentificacao = dto.tipoIdentificacao,
                NomeFantasia = dto.nomeFantasia,
                Site = dto.site,
                Email = dto.email,
                Codigo = dto.codigo,
                Descricao = dto.descricao,
                Observacao = dto.observacao?.ToString(),
                Documento = dto.documento
            };
        }

        public static UpdateEstabelecimentoViewModel UpdateEstabelecimentoViewModel(GetEstabelecimentoDTO dto)
        {
            return new UpdateEstabelecimentoViewModel
            {
                Id = Guid.Parse(dto.id),
                UsuarioId = Guid.Parse(dto.usuario.id),
                EmpresaId = Guid.Parse(dto.empresa.id),
                CnaeId = Guid.Parse(dto.cnae.id),
                DataRegistro = dto.dataRegistro,
                TipoIdentificacao = dto.tipoIdentificacao,
                NomeFantasia = dto.nomeFantasia,
                Site = dto.site,
                Email = dto.email,
                Codigo = dto.codigo,
                Descricao = dto.descricao,
                Observacao = dto.observacao?.ToString(),
                Documento = dto.documento,
                Matriz = dto.matriz,
                InscricaoMunicipal = dto.inscricaoMunicipal,
                InscricaoEstadual = dto.inscricaoEstadual
            };
        }
    }
}