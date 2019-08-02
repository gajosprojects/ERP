using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Cnaes
{
    public class DeleteCnaeCommand : BaseCnaeCommand
    {
        public DeleteCnaeCommand(Guid id, Guid usuarioId)
        {
            Id = id;
            DataUltimaAtualizacao = DateTime.Now;
            UsuarioId = usuarioId;
            AggregateId = Id;
        }
    }
}