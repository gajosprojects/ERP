using ERP.Domain.Core.Commands;
using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Empresas
{
    public class BaseEmpresaCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid UsuarioId { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataUltimaAtualizacao { get; protected set; }
        public string Codigo { get; protected set; }
        public string Descricao { get; protected set; }
        public string NomeFantasia { get; protected set; }
        public string Email { get; protected set; }
        public string Site { get; protected set; }
        public bool Bloqueada { get; protected set; }
        public DateTime DataRegistro { get; protected set; }
        public byte[] Logotipo { get; protected set; }
        public string Observacao { get; protected set; }
        public string Documento { get; protected set; }
        public int TipoIdentificacao { get; protected set; }
        public Guid GrupoEmpresarialId { get; protected set; }
    }
}