using System;
using ERP.Domain.Core.Events;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events
{
    public class BaseGrupoEmpresarialEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Codigo { get; protected set; }
        public string Descricao { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataUltimaAtualizacao { get; protected set; }
    }
}