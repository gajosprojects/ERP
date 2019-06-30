using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events
{
    public class UpdatedGrupoEmpresarialEvent : BaseGrupoEmpresarialEvent
    {
        public UpdatedGrupoEmpresarialEvent(Guid id, string codigo, string descricao, DateTime dataUltimaAtualizacao)
        {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            AggregateId = Id;
        }
    }
}