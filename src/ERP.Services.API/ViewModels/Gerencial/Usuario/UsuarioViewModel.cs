using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels.Gerencial.Usuario
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome: campo obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Sobrenome: campo obrigatório")]
        public string Sobrenome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail: campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }
    }
}
