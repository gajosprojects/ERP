using ERP.Domain.Core.Commands;
using ERP.Gerencial.Domain.GruposEmpresariais.Types;
using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Estabelecimentos
{
    public class BaseEstabelecimentoCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid UsuarioId { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataUltimaAtualizacao { get; protected set; }
        public string Codigo { get; protected set; }
        public string Descricao { get; protected set; }
        public string NomeFantasia { get; protected set; }
        public string InscricaoEstadual { get; protected set; }
        public string InscricaoMunicipal { get; protected set; }
        public string Email { get; protected set; }
        public string Site { get; protected set; }
        public DateTime DataRegistro { get; protected set; }
        public byte[] Logotipo { get; protected set; }
        public bool Matriz { get; protected set; }
        public string Observacao { get; protected set; }
        public string Documento { get; protected set; }
        public TipoIdentificacao TipoIdentificacao { get; protected set; }
        public Guid EmpresaId { get; protected set; }
        public Guid CnaeId { get; protected set; }
    }
}