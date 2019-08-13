using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Cnaes
{
    public class SaveCnaeCommand : BaseCnaeCommand
    {
        public SaveCnaeCommand(string codigo, string descricao, Guid? cnaePai, Guid usuarioId)
        {
            Id = Guid.NewGuid();
            Codigo = codigo;
            Descricao = descricao;
            CnaePai = cnaePai;
            DataCadastro = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            UsuarioId = usuarioId;
        }
    }
}