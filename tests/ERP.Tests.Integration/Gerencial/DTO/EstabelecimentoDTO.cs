using ERP.Gerencial.Domain.GruposEmpresariais.Types;
using System;

namespace ERP.Tests.Integration.Gerencial.DTO
{
    public class GetEstabelecimentoDTO
    {
        public string id { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataUltimaAtualizacao { get; set; }
        public bool excluido { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string nomeFantasia { get; set; }
        public string inscricaoEstadual { get; set; }
        public string inscricaoMunicipal { get; set; }
        public string email { get; set; }
        public string site { get; set; }
        public DateTime dataRegistro { get; set; }
        public string logotipo { get; set; }
        public bool matriz { get; set; }
        public object observacao { get; set; }
        public string documento { get; set; }
        public TipoIdentificacao tipoIdentificacao { get; set; }
        public GetEmpresaDTO empresa { get; set; }
        public GetCnaeDTO cnae { get; set; }
        public GetUsuarioDTO usuario { get; set; }
    }

    public class EstabelecimentoDTO
    {
        public bool success { get; set; }
        public EstabelecimentoDataResponse data { get; set; }
    }

    public class EstabelecimentoDataResponse
    {
        public string id { get; set; }
        public bool excluido { get; set; }
        public string usuarioId { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataUltimaAtualizacao { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string nomeFantasia { get; set; }
        public string inscricaoEstadual { get; set; }
        public string inscricaoMunicipal { get; set; }
        public string email { get; set; }
        public string site { get; set; }
        public DateTime dataRegistro { get; set; }
        public string logotipo { get; set; }
        public bool matriz { get; set; }
        public object observacao { get; set; }
        public string documento { get; set; }
        public int tipoIdentificacao { get; set; }
        public string empresaId { get; set; }
        public string cnaeId { get; set; }
        public DateTime timestamp { get; set; }
        public string messageType { get; set; }
        public string aggregateId { get; set; }
    }

}