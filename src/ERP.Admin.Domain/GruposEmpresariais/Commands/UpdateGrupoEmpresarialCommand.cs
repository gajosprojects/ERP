using System;

namespace ERP.Admin.Domain.GruposEmpresariais.Commands
{
    public class UpdateGrupoEmpresarialCommand : BaseGrupoEmpresarialCommand
    {
        public UpdateGrupoEmpresarialCommand(Guid id, string codigo, string descricao)
        {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
            DataUltimaAtualizacao = DateTime.Now;
        }
    }
}