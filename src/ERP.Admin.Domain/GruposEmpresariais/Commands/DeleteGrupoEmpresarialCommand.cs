using System;

namespace ERP.Admin.Domain.GruposEmpresariais.Commands
{
    public class DeleteGrupoEmpresarialCommand : BaseGrupoEmpresarialCommand
    {
        public DeleteGrupoEmpresarialCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}