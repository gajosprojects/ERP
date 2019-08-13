using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.Empresas
{
    public class DeletedEmpresaEvent : BaseEmpresaEvent
    {
        public DeletedEmpresaEvent(Guid id, Guid usuarioId)
        {
            Id = id;
            UsuarioId = usuarioId;
            AggregateId = Id;
        }
    }
}