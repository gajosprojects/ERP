using ERP.Services.API.Utils.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels.Gerencial.Cnae
{
    public class DeleteCnaeViewModel
    {
        [Required(ErrorMessage = "Id: campo obrigatório")]
        public Guid Id { get; set; }

        [NotEmptyGuid(ErrorMessage = "UsuarioId: campo obrigatório")]
        public Guid UsuarioId { get; set; }
    }
}
