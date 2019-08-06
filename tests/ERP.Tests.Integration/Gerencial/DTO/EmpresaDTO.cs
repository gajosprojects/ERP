using System;

namespace ERP.Tests.Integration.Gerencial.DTO
{
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
        public object grupoEmpresarial { get; set; }
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