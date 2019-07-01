using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands
{
    public class SaveGrupoEmpresarialCommand : BaseGrupoEmpresarialCommand
    {
        public SaveGrupoEmpresarialCommand(string codigo, string descricao, Guid usuarioId)
        {
            Codigo = codigo;
            Descricao = descricao;
            DataCadastro = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            UsuarioId = usuarioId;
        }
    }
}