using ERP.Domain.Core.Commands;
using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Cnaes
{
    public class BaseCnaeCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid UsuarioId { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataUltimaAtualizacao { get; protected set; }
        public string Codigo { get; protected set; }
        public string Descricao { get; protected set; }
        public Guid? CnaePai { get; protected set; }
    }
}