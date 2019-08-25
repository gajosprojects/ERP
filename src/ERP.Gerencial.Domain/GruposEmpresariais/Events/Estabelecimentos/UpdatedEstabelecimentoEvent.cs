using ERP.Gerencial.Domain.GruposEmpresariais.Types;
using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.Estabelecimentos
{
    public class UpdatedEstabelecimentoEvent : BaseEstabelecimentoEvent
    {
        public UpdatedEstabelecimentoEvent(Guid id, bool excluido, Guid usuarioId, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string codigo, string descricao, string nomeFantasia, string inscricaoEstadual, string inscricaoMunicipal, string email, string site, DateTime dataRegistro, byte[] logotipo, bool matriz, string observacao, string documento, TipoIdentificacao tipoIdentificacao, Guid empresaId, Guid cnaeId)
        {
            Id = id;
            Excluido = excluido;
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