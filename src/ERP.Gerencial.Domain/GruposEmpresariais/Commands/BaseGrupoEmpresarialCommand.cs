using System;
using ERP.Domain.Core.Commands;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands
{
    public class BaseGrupoEmpresarialCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Codigo { get; protected set; }
        public string Descricao { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataUltimaAtualizacao { get; protected set; }
    }
}