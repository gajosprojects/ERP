using ERP.Services.API.Utils.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels.Gerencial.Cnae
{
    public class SaveCnaeViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código: campo obrigatório")]
        [MinLength(1, ErrorMessage = "Código: tamanho mínimo {1} caracteres")]
        [MaxLength(7, ErrorMessage = "Código: tamanho máximo {1} caracteres")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição: campo obrigatório")]
        [MinLength(1, ErrorMessage = "Descrição: tamanho mínimo {1} caracteres")]
        [MaxLength(255, ErrorMessage = "Descrição: tamanho máximo {1} caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "CNAE pai")]
        public Guid? CnaePai { get; set; }

        [NotEmptyGuid(ErrorMessage = "UsuarioId: campo obrigatório")]
        public Guid UsuarioId { get; set; }
    }
}
