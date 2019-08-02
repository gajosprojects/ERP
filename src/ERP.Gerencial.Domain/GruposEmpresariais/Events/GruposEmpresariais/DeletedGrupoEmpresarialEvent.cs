using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.GruposEmpresariais
{
    public class DeletedGrupoEmpresarialEvent : BaseGrupoEmpresarialEvent
    {
        public DeletedGrupoEmpresarialEvent(Guid id, Guid usuarioId)
        {
            Id = id;
            UsuarioId = usuarioId;
            AggregateId = Id;
        }
    }
}