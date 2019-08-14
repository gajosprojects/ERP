using ERP.Gerencial.Domain.GruposEmpresariais.Types;
using ERP.Services.API.Utils.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels.Gerencial.Estabelecimento
{
    public class UpdateEstabelecimentoViewModel
    {
        [Key]
        public Guid Id { get; set; }

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

        [Display(Name = "Nome fantasia")]
        [MaxLength(150, ErrorMessage = "Nome fantasia: tamanho máximo {1} caracteres")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Inscrição estadual")]
        [MaxLength(20, ErrorMessage = "Inscrição estadual: tamanho máximo {1} caracteres")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Inscrição municipal")]
        [MaxLength(20, ErrorMessage = "Inscrição municipal: tamanho máximo {1} caracteres")]
        public string InscricaoMunicipal { get; set; }

        [Display(Name = "E-mail")]
        [MaxLength(150, ErrorMessage = "E-mail: tamanho máximo {1} caracteres")]
        [EmailAddress(ErrorMessage = "E-mail: formato inválido")]
        public string Email { get; set; }

        [Display(Name = "Site")]
        [MaxLength(100, ErrorMessage = "Site: tamanho máximo {1} caracteres")]
        public string Site { get; set; }

        [Display(Name = "Bloqueado")]
        [Required(ErrorMessage = "Bloqueado: campo obrigatório")]
        public bool Bloqueado { get; set; }

        [Display(Name = "Data registro")]
        public DateTime DataRegistro { get; set; }

        [Display(Name = "Logotipo")]
        public byte[] Logotipo { get; set; }

        [Display(Name = "Matriz")]
        [Required(ErrorMessage = "Matriz: campo obrigatório")]
        public bool Matriz { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "Documento: campo obrigatório")]
        [MinLength(11, ErrorMessage = "Documento: tamanho mínimo {1} caracteres")]
        [MaxLength(14, ErrorMessage = "Documento: tamanho máximo {1} caracteres")]
        public string Documento { get; set; }

        [Display(Name = "Tipo identicação")]
        [Required(ErrorMessage = "Tipo identicação: campo obrigatório")]
        public TipoIdentificacao TipoIdentificacao { get; set; }

        [NotEmptyGuid(ErrorMessage = "EmpresaId: campo obrigatório")]
        public Guid EmpresaId { get; set; }

        [NotEmptyGuid(ErrorMessage = "CnaeId: campo obrigatório")]
        public Guid CnaeId { get; set; }

        [NotEmptyGuid(ErrorMessage = "UsuarioId: campo obrigatório")]
        public Guid UsuarioId { get; set; }
    }
}
