using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.GruposEmpresariais
{
    public class UpdateGrupoEmpresarialCommand : BaseGrupoEmpresarialCommand
    {
        public UpdateGrupoEmpresarialCommand(Guid id, string codigo, string descricao, Guid usuarioId)
        {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
            DataUltimaAtualizacao = DateTime.Now;
            UsuarioId = usuarioId;
        }
    }
}