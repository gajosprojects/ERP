using ERP.Services.API.ViewModels.Gerencial.Usuario;
using System;

namespace ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial
{
    public class GrupoEmpresarialViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public bool Desativado { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public UsuarioViewModel Usuario { get; set; }

        public GrupoEmpresarialViewModel()
        {
            Usuario = new UsuarioViewModel();
        }
    }
}
