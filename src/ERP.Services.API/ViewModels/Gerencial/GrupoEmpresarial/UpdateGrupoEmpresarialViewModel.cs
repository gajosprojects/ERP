using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial
{
    public class UpdateGrupoEmpresarialViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Data última atualização")]
        public DateTime DataUltimaAtualizacao { get; set; }

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

        public UpdateGrupoEmpresarialViewModel()
        {
            DataUltimaAtualizacao = DateTime.Now;
        }
    }
}
