using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels
{
    public class GrupoEmpresarialViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Data cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data última atualização")]
        public DateTime DataUltimaAtualizacao { get; set; }

        [Display(Name = "Desativado")]
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

        public GrupoEmpresarialViewModel()
        {
            Id = new Guid();
        }
    }
}