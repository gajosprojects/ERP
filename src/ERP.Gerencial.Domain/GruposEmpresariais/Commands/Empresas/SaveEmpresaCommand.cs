﻿using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Commands.Empresas
{
    public class SaveEmpresaCommand : BaseEmpresaCommand
    {
        public SaveEmpresaCommand(Guid usuarioId, string codigo, string descricao, string nomeFantasia, string email, string site, bool bloqueada, DateTime dataRegistro, byte[] logotipo, string observacao, string documento, int tipoIdentificacao, Guid grupoEmpresarialId)
        {
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            DataCadastro = DateTime.Now;
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