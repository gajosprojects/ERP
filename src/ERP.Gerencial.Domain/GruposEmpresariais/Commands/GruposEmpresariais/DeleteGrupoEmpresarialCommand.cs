using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.GruposEmpresariais
{
    public class DeleteGrupoEmpresarialCommand : BaseGrupoEmpresarialCommand
    {
        public DeleteGrupoEmpresarialCommand(Guid id, Guid usuarioId)
        {
            Id = id;
            DataUltimaAtualizacao = DateTime.Now;
            UsuarioId = usuarioId;
            AggregateId = Id;
        }
    }
}