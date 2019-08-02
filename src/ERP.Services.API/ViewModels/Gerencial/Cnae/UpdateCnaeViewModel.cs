using ERP.Services.API.Utils.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels.Gerencial.Cnae
{
    public class UpdateCnaeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(1, ErrorMessage = "Tamanho mínimo {1} caracteres")]
        [MaxLength(7, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(1, ErrorMessage = "Tamanho mínimo {1} caracteres")]
        [MaxLength(255, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "CNAE pai")]
        public Guid? CnaePai { get; set; }

        [NotEmptyGuid(ErrorMessage = "Campo obrigatório")]
        public Guid UsuarioId { get; set; }
    }
}
