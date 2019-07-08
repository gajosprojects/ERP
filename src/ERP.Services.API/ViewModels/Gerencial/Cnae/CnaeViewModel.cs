using ERP.Services.API.ViewModels.Gerencial.Usuario;
using System;

namespace ERP.Services.API.ViewModels.Gerencial.Cnae
{
    public class CnaeViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public Guid CnaePai { get; set; }
        public UsuarioViewModel Usuario { get; set; }

        public CnaeViewModel()
        {
            Usuario = new UsuarioViewModel();
        }
    }
}
