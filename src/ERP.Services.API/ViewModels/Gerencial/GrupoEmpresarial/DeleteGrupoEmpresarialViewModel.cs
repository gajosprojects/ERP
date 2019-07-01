using ERP.Services.API.Utils.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial
{
    public class DeleteGrupoEmpresarialViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid Id { get; set; }

        [NotEmptyGuid(ErrorMessage = "Campo obrigatório")]
        public Guid UsuarioId { get; set; }
    }
}
