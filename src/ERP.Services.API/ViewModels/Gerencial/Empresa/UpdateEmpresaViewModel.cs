using ERP.Services.API.Utils.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels.Gerencial.Empresa
{
    public class UpdateEmpresaViewModel
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

        [Display(Name = "Nome fantasia")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Email")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo {1} caracteres")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }

        [Display(Name = "Site")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Site { get; set; }

        [Display(Name = "Bloqueada")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Bloqueada { get; set; }

        [Display(Name = "Data registro")]
        public DateTime DataRegistro { get; set; }

        [Display(Name = "Logotipo")]
        public byte[] Logotipo { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(11, ErrorMessage = "Tamanho mínimo {1} caracteres")]
        [MaxLength(14, ErrorMessage = "Tamanho máximo {1} caracteres")]
        public string Documento { get; set; }

        [Display(Name = "Tipo identificação")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int TipoIdentificacao { get; set; }

        [Display(Name = "Grupo empresarial")]
        [NotEmptyGuid(ErrorMessage = "Campo obrigatório")]
        public Guid GrupoEmpresarialId { get; set; }

        [NotEmptyGuid(ErrorMessage = "Campo obrigatório")]
        public Guid UsuarioId { get; set; }
    }
}
