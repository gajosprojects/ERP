using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.GruposEmpresariais
{
    public class UpdatedGrupoEmpresarialEvent : BaseGrupoEmpresarialEvent
    {
        public UpdatedGrupoEmpresarialEvent(Guid id, string codigo, string descricao, DateTime dataCadastro, DateTime dataUltimaAtualizacao, bool excluido, Guid usuarioId)
        {
            Id = id;
            Excluido = excluido;
            UsuarioId = usuarioId;
            DataCadastro = dataCadastro;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            Codigo = codigo;
            Descricao = descricao;
            AggregateId = Id;
        }
    }
}