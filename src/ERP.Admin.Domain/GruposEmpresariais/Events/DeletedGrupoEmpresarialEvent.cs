using System;

namespace ERP.Admin.Domain.GruposEmpresariais.Events
{
    public class DeletedGrupoEmpresarialEvent : BaseGrupoEmpresarialEvent
    {
        public DeletedGrupoEmpresarialEvent(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}