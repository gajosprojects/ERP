using ERP.Gerencial.Domain.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Cnaes;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Empresas;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Estabelecimentos;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.GruposEmpresariais;
using System;

namespace ERP.Tests.Unit.Gerencial.Factories
{
    public static class EntityFactory
    {
        public static GrupoEmpresarial NewGrupoEmpresarial(SaveGrupoEmpresarialCommand c)
        {
            return GrupoEmpresarial.GrupoEmpresarialFactory.NewGrupoEmpresarial(c.Id, c.Codigo, c.Descricao, c.DataCadastro, c.DataUltimaAtualizacao, c.UsuarioId);
        }

        public static GrupoEmpresarial UpdateGrupoEmpresarial(UpdateGrupoEmpresarialCommand c)
        {
            return GrupoEmpresarial.GrupoEmpresarialFactory.UpdateGrupoEmpresarial(c.Id, c.Codigo, c.Descricao, c.DataCadastro, c.DataUltimaAtualizacao, c.UsuarioId, true);
        }

        public static GrupoEmpresarial UpdateGrupoEmpresarial(DeleteGrupoEmpresarialCommand c)
        {
            return GrupoEmpresarial.GrupoEmpresarialFactory.UpdateGrupoEmpresarial(c.Id, c.Codigo, c.Descricao, c.DataCadastro, c.DataUltimaAtualizacao, c.UsuarioId, true);
        }

        public static Cnae NewCnae(SaveCnaeCommand c)
        {
            return Cnae.CnaeFactory.NewCnae(c.Id, c.Codigo, c.Descricao, Guid.NewGuid(), c.DataCadastro, c.DataUltimaAtualizacao, c.UsuarioId);
        }

        public static Cnae UpdateCnae(UpdateCnaeCommand c)
        {
            return Cnae.CnaeFactory.UpdateCnae(c.Id, c.Codigo, c.Descricao, c.CnaePai, c.DataCadastro, c.DataUltimaAtualizacao, c.UsuarioId, true);
        }

        public static Cnae UpdateCnae(DeleteCnaeCommand c)
        {
            return Cnae.CnaeFactory.UpdateCnae(c.Id, c.Codigo, c.Descricao, c.CnaePai, c.DataCadastro, c.DataUltimaAtualizacao, c.UsuarioId, true);
        }

        public static Empresa NewEmpresa(SaveEmpresaCommand c)
        {
            return Empresa.EmpresaFactory.NewEmpresa(c.Id, c.Codigo, c.Descricao, c.NomeFantasia, c.Email, c.Site, c.DataRegistro, c.Logotipo, c.Observacao, c.DataCadastro, c.DataUltimaAtualizacao, c.Documento, c.TipoIdentificacao, c.GrupoEmpresarialId, c.UsuarioId);
        }

        public static Empresa UpdateEmpresa(UpdateEmpresaCommand c)
        {
            return Empresa.EmpresaFactory.UpdateEmpresa(c.Id, c.Codigo, c.Descricao, c.NomeFantasia, c.Email, c.Site, c.DataRegistro, c.Logotipo, c.Observacao, c.DataCadastro, c.DataUltimaAtualizacao, c.Documento, c.TipoIdentificacao, c.GrupoEmpresarialId, c.UsuarioId, true);
        }

        public static Empresa UpdateEmpresa(DeleteEmpresaCommand c)
        {
            return Empresa.EmpresaFactory.UpdateEmpresa(c.Id, c.Codigo, c.Descricao, c.NomeFantasia, c.Email, c.Site, c.DataRegistro, c.Logotipo, c.Observacao, c.DataCadastro, c.DataUltimaAtualizacao, c.Documento, c.TipoIdentificacao, c.GrupoEmpresarialId, c.UsuarioId, true);
        }

        public static Estabelecimento NewEstabelecimento(SaveEstabelecimentoCommand c)
        {
            return Estabelecimento.EstabelecimentoFactory.NewEstabelecimento(c.Id, c.Codigo, c.Descricao, c.NomeFantasia, c.InscricaoEstadual, c.InscricaoMunicipal, c.Email, c.Site, c.DataRegistro, c.Logotipo, c.Matriz, c.Observacao, c.DataCadastro, c.DataUltimaAtualizacao, c.Documento, c.TipoIdentificacao, c.EmpresaId, c.CnaeId, c.UsuarioId);
        }

        public static Estabelecimento UpdateEstabelecimento(UpdateEstabelecimentoCommand c)
        {
            return Estabelecimento.EstabelecimentoFactory.UpdateEstabelecimento(c.Id, c.Codigo, c.Descricao, c.NomeFantasia, c.InscricaoEstadual, c.InscricaoMunicipal, c.Email, c.Site, c.DataRegistro, c.Logotipo, c.Matriz, c.Observacao, c.DataCadastro, c.DataUltimaAtualizacao, c.Documento, c.TipoIdentificacao, c.EmpresaId, c.CnaeId, c.UsuarioId, true);
        }

        public static Estabelecimento UpdateEstabelecimento(DeleteEstabelecimentoCommand c)
        {
            return Estabelecimento.EstabelecimentoFactory.UpdateEstabelecimento(c.Id, c.Codigo, c.Descricao, c.NomeFantasia, c.InscricaoEstadual, c.InscricaoMunicipal, c.Email, c.Site, c.DataRegistro, c.Logotipo, c.Matriz, c.Observacao, c.DataCadastro, c.DataUltimaAtualizacao, c.Documento, c.TipoIdentificacao, c.EmpresaId, c.CnaeId, c.UsuarioId, true);
        }
    }
}