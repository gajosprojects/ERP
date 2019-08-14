using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.GruposEmpresariais
{
    public class SaveGrupoEmpresarialCommand : BaseGrupoEmpresarialCommand
    {
        public SaveGrupoEmpresarialCommand(string codigo, string descricao, Guid usuarioId)
        {
            Id = Guid.NewGuid();
            Codigo = codigo;
            Descricao = descricao;
            DataCadastro = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            UsuarioId = usuarioId;
            AggregateId = Id;
        }
    }
}