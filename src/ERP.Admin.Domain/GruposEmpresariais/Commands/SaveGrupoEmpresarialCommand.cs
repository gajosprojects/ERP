using System;

namespace ERP.Admin.Domain.GruposEmpresariais.Commands
{
    public class SaveGrupoEmpresarialCommand : BaseGrupoEmpresarialCommand
    {
        public SaveGrupoEmpresarialCommand(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
            DataCadastro = DateTime.Now;
        }
    }
}