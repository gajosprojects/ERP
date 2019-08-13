using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.Estabelecimentos
{
    public class SavedEstabelecimentoEvent : BaseEstabelecimentoEvent
    {
        public SavedEstabelecimentoEvent(Guid id, bool ativo, Guid usuarioId, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string codigo, string descricao, string nomeFantasia, string inscricaoEstadual, string inscricaoMunicipal, string email, string site, bool bloqueado, DateTime dataRegistro, byte[] logotipo, bool matriz, string observacao, string documento, int tipoIdentificacao, Guid empresaId, Guid cnaeId)
        {
            Id = id;
            Ativo = ativo;
            UsuarioId = usuarioId;
            DataCadastro = dataCadastro;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            Codigo = codigo;
            Descricao = descricao;
            NomeFantasia = nomeFantasia;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
            Email = email;
            Site = site;
            Bloqueado = bloqueado;
            DataRegistro = dataRegistro;
            Logotipo = logotipo;
            Matriz = matriz;
            Observacao = observacao;
            Documento = documento;
            TipoIdentificacao = tipoIdentificacao;
            EmpresaId = empresaId;
            CnaeId = cnaeId;
            AggregateId = Id;
        }
    }
}