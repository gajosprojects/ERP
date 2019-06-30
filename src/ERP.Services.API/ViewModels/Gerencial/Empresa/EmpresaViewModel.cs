using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using System;

namespace ERP.Services.API.ViewModels.Gerencial.Empresa
{
    public class EmpresaViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public bool Desativado { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public bool Bloqueada { get; set; }
        public DateTime DataRegistro { get; set; }
        public byte[] Logotipo { get; set; }
        public string Observacao { get; set; }
        public string Documento { get; set; }
        public int TipoIdentificacao { get; set; }
        public Guid GrupoEmpresarialId { get; set; }
        public GrupoEmpresarialViewModel GrupoEmpresarial { get; set; }
    }
}
