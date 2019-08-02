using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Estabelecimentos
{
    public class UpdateEstabelecimentoCommand : BaseEstabelecimentoCommand
    {
        public UpdateEstabelecimentoCommand(Guid id, Guid usuarioId, string codigo, string descricao, string nomeFantasia, string inscricaoEstadual, string inscricaoMunicipal, string email, string site, bool bloqueado, DateTime dataRegistro, byte[] logotipo, bool matriz, string observacao, string documento, int tipoIdentificacao, Guid empresaId, Guid cnaeId)
        {
            Id = id;
            UsuarioId = usuarioId;
            DataUltimaAtualizacao = DateTime.Now;
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
        }
    }
}