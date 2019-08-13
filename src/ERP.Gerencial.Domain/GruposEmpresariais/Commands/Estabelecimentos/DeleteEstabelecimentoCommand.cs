using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Estabelecimentos
{
    public class DeleteEstabelecimentoCommand : BaseEstabelecimentoCommand
    {
        public DeleteEstabelecimentoCommand(Guid id, Guid usuarioId)
        {
            Id = id;
            DataUltimaAtualizacao = DateTime.Now;
            UsuarioId = usuarioId;
            AggregateId = Id;
        }
    }
}