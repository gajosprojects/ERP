using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.Cnaes
{
    public class DeletedCnaeEvent : BaseCnaeEvent
    {
        public DeletedCnaeEvent(Guid id, Guid usuarioId)
        {
            Id = id;
            UsuarioId = usuarioId;
            AggregateId = Id;
        }
    }
}