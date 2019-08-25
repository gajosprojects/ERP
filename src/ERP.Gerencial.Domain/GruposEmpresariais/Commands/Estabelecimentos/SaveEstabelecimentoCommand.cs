using ERP.Gerencial.Domain.GruposEmpresariais.Types;
using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Estabelecimentos
{
    public class SaveEstabelecimentoCommand : BaseEstabelecimentoCommand
    {
        public SaveEstabelecimentoCommand(Guid usuarioId, string codigo, string descricao, string nomeFantasia, string inscricaoEstadual, string inscricaoMunicipal, string email, string site, DateTime dataRegistro, byte[] logotipo, bool matriz, string observacao, string documento, TipoIdentificacao tipoIdentificacao, Guid empresaId, Guid cnaeId)
        {
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            DataCadastro = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
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