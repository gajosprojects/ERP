using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.Empresas
{
    public class SavedEmpresaEvent : BaseEmpresaEvent
    {
        public SavedEmpresaEvent(Guid id, bool ativo, Guid usuarioId, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string codigo, string descricao, string nomeFantasia, string email, string site, bool bloqueada, DateTime dataRegistro, byte[] logotipo, string observacao, string documento, int tipoIdentificacao, Guid grupoEmpresarialId)
        {
            Id = id;
            Ativo = ativo;
            UsuarioId = usuarioId;
            DataCadastro = dataCadastro;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
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