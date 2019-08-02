using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Empresas
{
    public class DeleteEmpresaCommand : BaseEmpresaCommand
    {
        public DeleteEmpresaCommand(Guid id, Guid usuarioId)
        {
            Id = id;
            DataUltimaAtualizacao = DateTime.Now;
            UsuarioId = usuarioId;
            AggregateId = Id;
        }
    }
}