using ERP.Gerencial.Domain.GruposEmpresariais.Types;
using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.Empresas
{
    public class SavedEmpresaEvent : BaseEmpresaEvent
    {
        public SavedEmpresaEvent(Guid id, bool excluido, Guid usuarioId, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string codigo, string descricao, string nomeFantasia, string email, string site, DateTime dataRegistro, byte[] logotipo, string observacao, string documento, TipoIdentificacao tipoIdentificacao, Guid grupoEmpresarialId)
        {
            Id = id;
            Excluido = excluido;
            UsuarioId = usuarioId;
            DataCadastro = dataCadastro;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            Codigo = codigo;
            Descricao = descricao;
            NomeFantasia = nomeFantasia;
            Email = email;
            Site = site;
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