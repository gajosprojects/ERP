using System;

namespace ERP.Admin.Domain.GruposEmpresariais.Events
{
    public class UpdatedGrupoEmpresarialEvent : BaseGrupoEmpresarialEvent
    {
        public UpdatedGrupoEmpresarialEvent(Guid id, string codigo, string descricao, DateTime dataCadastro, DateTime dataUltimaAtualizacao)
        {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
            DataCadastro = dataCadastro;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            AggregateId = Id;
        }
    }
}