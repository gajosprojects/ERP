using ERP.Services.API.Utils.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial
{
    public class SaveGrupoEmpresarialViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código: campo obrigatório")]
        [MinLength(1, ErrorMessage = "Código: tamanho mínimo {1} caracteres")]
        [MaxLength(30, ErrorMessage = "Código: tamanho máximo {1} caracteres")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição: campo obrigatório")]
        [MinLength(1, ErrorMessage = "Descrição: tamanho mínimo {1} caracteres")]
        [MaxLength(150, ErrorMessage = "Descrição: tamanho máximo {1} caracteres")]
        public string Descricao { get; set; }

        [NotEmptyGuid(ErrorMessage = "UsuarioId: campo obrigatório")]
        public Guid UsuarioId { get; set; }
    }
}
