using System;

namespace ERP.Tests.Integration.Gerencial.DTO
{
    public class GetGrupoEmpresarialDTO
    {
        public string id { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataUltimaAtualizacao { get; set; }
        public bool excluido { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public GetUsuarioDTO usuario { get; set; }
    }

    public class GrupoEmpresarialDTO
    {
        public bool success { get; set; }
        public GrupoEmpresarialDataResponse data { get; set; }
    }

    public class GrupoEmpresarialDataResponse
    {
        public bool excluido { get; set; }
        public string id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataUltimaAtualizacao { get; set; }
        public string usuarioId { get; set; }
        public DateTime timestamp { get; set; }
        public string messageType { get; set; }
        public string aggregateId { get; set; }
    }
}
