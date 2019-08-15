using ERP.Gerencial.Domain.GruposEmpresariais.Types;
using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Empresas
{
    public class UpdateEmpresaCommand : BaseEmpresaCommand
    {
        public UpdateEmpresaCommand(Guid id, Guid usuarioId, string codigo, string descricao, string nomeFantasia, string email, string site, bool bloqueada, DateTime dataRegistro, byte[] logotipo, string observacao, string documento, TipoIdentificacao tipoIdentificacao, Guid grupoEmpresarialId)
        {
            Id = id;
            UsuarioId = usuarioId;
            DataUltimaAtualizacao = DateTime.Now;
            Codigo = codigo;
            Descricao = descricao;
            NomeFantasia = nomeFantasia;
            Email = email;
            Site = site;
            Bloqueada = bloqueada;
            DataRegistro = dataRegistro;
            Logotipo = logotipo;
            Observacao = observacao;
            Documento = documento;
            TipoIdentificacao = tipoIdentificacao;
            GrupoEmpresarialId = grupoEmpresarialId;
            AggregateId = Id;
        }
    }
}