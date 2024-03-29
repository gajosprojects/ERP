﻿using System;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Events.Cnaes
{
    public class SavedCnaeEvent : BaseCnaeEvent
    {
        public SavedCnaeEvent(Guid id, bool excluido, Guid usuarioId, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string codigo, string descricao, Guid? cnaePai)
        {
            Id = id;
            Excluido = excluido;
            UsuarioId = usuarioId;
            DataCadastro = dataCadastro;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            Codigo = codigo;
            Descricao = descricao;
            CnaePai = cnaePai;
            AggregateId = Id;
        }
    }
}