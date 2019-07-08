using ERP.Services.API.ViewModels.Gerencial.Cnae;
using ERP.Services.API.ViewModels.Gerencial.Empresa;
using ERP.Services.API.ViewModels.Gerencial.Usuario;
using System;

namespace ERP.Services.API.ViewModels.Gerencial.Estabelecimento
{
    public class EstabelecimentoViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string NomeFantasia { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime DataRegistro { get; set; }
        public byte[] Logotipo { get; set; }
        public bool Matriz { get; set; }
        public string Observacao { get; set; }
        public string Documento { get; set; }
        public int TipoIdentificacao { get; set; }
        public EmpresaViewModel Empresa { get; set; }
        public CnaeViewModel Cnae { get; set; }
        public UsuarioViewModel Usuario { get; set; }

        public EstabelecimentoViewModel()
        {
            Empresa = new EmpresaViewModel();
            Cnae = new CnaeViewModel();
            Usuario = new UsuarioViewModel();
        }
    }
}
