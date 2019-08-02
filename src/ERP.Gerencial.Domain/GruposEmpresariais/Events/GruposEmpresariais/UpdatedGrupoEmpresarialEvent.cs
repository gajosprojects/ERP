using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.GruposEmpresariais
{
    public class UpdatedGrupoEmpresarialEvent : BaseGrupoEmpresarialEvent
    {
        public UpdatedGrupoEmpresarialEvent(Guid id, string codigo, string descricao, DateTime dataCadastro, DateTime dataUltimaAtualizacao, bool ativo, Guid usuarioId)
        {
            Id = id;
            Ativo = ativo;
            UsuarioId = usuarioId;
            DataCadastro = dataCadastro;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            Codigo = codigo;
            Descricao = descricao;
            AggregateId = Id;
        }
    }
}