using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Services.API.ViewModels.Gerencial.Cnae
{
    public class DeleteCnaeViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid Id { get; set; }
    }
}
