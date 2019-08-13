using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.Estabelecimentos
{
    public class DeletedEstabelecimentoEvent : BaseEstabelecimentoEvent
    {
        public DeletedEstabelecimentoEvent(Guid id, Guid usuarioId)
        {
            Id = id;
            UsuarioId = usuarioId;
            AggregateId = Id;
        }
    }
}