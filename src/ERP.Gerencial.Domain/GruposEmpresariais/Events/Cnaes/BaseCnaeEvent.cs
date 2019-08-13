using ERP.Domain.Core.Events;
using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.Cnaes
{
    public class BaseCnaeEvent : Event
    {
        public Guid Id { get; protected set; }
        public bool Ativo { get; protected set; }
        public Guid UsuarioId { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataUltimaAtualizacao { get; protected set; }
        public string Codigo { get; protected set; }
        public string Descricao { get; protected set; }
        public Guid? CnaePai { get; protected set; }
    }
}