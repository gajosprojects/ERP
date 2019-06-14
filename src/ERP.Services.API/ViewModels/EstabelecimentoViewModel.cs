using System;
using System.ComponentModel.DataAnnotations;
using ERP.Services.API.Utils.Validation;

namespace ERP.Services.API.ViewModels
{
    public class EstabelecimentoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Display(Name = "Data cadastro")]
        public DateTime DataCadastro { get; set; }
        
        [Display(Name = "Data última atualização")]
        public DateTime DataUltimaAtualizacao { get; set; }
        
        [Display(Name = "Excluído")]
        public bool Desativado { get; set; }
        
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(1, ErrorMessage = "Tamanho mínimo {1} caracteres")]
        [MaxLength(30, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Codigo { get; set; }
        
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(1, ErrorMessage = "Tamanho mínimo {1} caracteres")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Descricao { get; set; }
        
        [Display(Name = "Nome fantasia")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string NomeFantasia { get; set; }
        
        [Display(Name = "Inscrição estadual")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string InscricaoEstadual { get; set; }
        
        [Display(Name = "Inscrição municipal")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string InscricaoMunicipal { get; set; }
        
        [Display(Name = "E-mail")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Email { get; set; }
        
        [Display(Name = "Site")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Site { get; set; }
        
        [Display(Name = "Bloqueado")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Bloqueado { get; set; }
        
        [Display(Name = "Data registro")]
        public DateTime DataRegistro { get; set; }
        
        [Display(Name = "Logotipo")]
        public byte[] Logotipo { get; set; }
        
        [Display(Name = "Matriz")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Matriz { get; set; }
        
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        
        [Display(Name = "Documento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(11, ErrorMessage = "Tamanho mínimo {1} caracteres")]
        [MaxLength(14, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Documento { get; set; }
        
        [Display(Name = "Tipo identicação")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int TipoIdentificacao { get; set; }
        
        [Display(Name = "Empresa")]
        [NotEmptyGuid(ErrorMessage = "Campo obrigatório")]
        public Guid EmpresaId { get; set; }
        
        [Display(Name = "CNAE")]
        [NotEmptyGuid(ErrorMessage = "Campo obrigatório")]
        public Guid CnaeId { get; set; }
        
        public EmpresaViewModel Empresa { get; set; }
        
        public CnaeViewModel Cnae { get; set; }

        public EstabelecimentoViewModel()
        {
            Id = new Guid();
            Empresa = new EmpresaViewModel();
            Cnae = new CnaeViewModel();
        }
    }
}