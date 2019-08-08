using ERP.Services.API.ViewModels.Gerencial.Empresa;
using ERP.Services.API.ViewModels.Gerencial.Estabelecimento;
using System;

namespace ERP.Tests.Integration.Gerencial.DTO
{
    public static class ConvertDTOTo
    {
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
                Bloqueada = dto.bloqueada,
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
                Bloqueado = dto.bloqueado,
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

    public class GetEmpresaDTO
    {
        public string id { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataUltimaAtualizacao { get; set; }
        public bool ativo { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string nomeFantasia { get; set; }
        public string email { get; set; }
        public string site { get; set; }
        public bool bloqueada { get; set; }
        public DateTime dataRegistro { get; set; }
        public string logotipo { get; set; }
        public object observacao { get; set; }
        public string documento { get; set; }
        public int tipoIdentificacao { get; set; }
        public GetGrupoEmpresarialDTO grupoEmpresarial { get; set; }
        public GetUsuarioDTO usuario { get; set; }
    }

    public class EmpresaDTO
    {
        public bool success { get; set; }
        public EmpresaDataResponse data { get; set; }
    }

    public class EmpresaDataResponse
    {
        public string id { get; set; }
        public bool ativo { get; set; }
        public string usuarioId { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataUltimaAtualizacao { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string nomeFantasia { get; set; }
        public string email { get; set; }
        public string site { get; set; }
        public bool bloqueada { get; set; }
        public DateTime dataRegistro { get; set; }
        public string logotipo { get; set; }
        public object observacao { get; set; }
        public string documento { get; set; }
        public int tipoIdentificacao { get; set; }
        public string grupoEmpresarialId { get; set; }
        public DateTime timestamp { get; set; }
        public string messageType { get; set; }
        public string aggregateId { get; set; }
    }

}