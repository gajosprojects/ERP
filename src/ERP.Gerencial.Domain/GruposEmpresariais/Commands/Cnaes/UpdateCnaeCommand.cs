using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Cnaes
{
    public class UpdateCnaeCommand : BaseCnaeCommand
    {
        public UpdateCnaeCommand(Guid id, string codigo, string descricao, Guid? cnaePai, Guid usuarioId)
        {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
            CnaePai = cnaePai;
            DataUltimaAtualizacao = DateTime.Now;
            UsuarioId = usuarioId;
        }
    }
}