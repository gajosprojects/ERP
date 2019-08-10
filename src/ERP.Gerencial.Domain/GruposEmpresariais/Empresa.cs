using ERP.Domain.Core.Models;
using ERP.Gerencial.Domain.Usuarios;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace ERP.Gerencial.Domain.GruposEmpresariais
{
    public class Empresa : Entity<Empresa>
    {
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Email { get; private set; }
        public string Site { get; private set; }
        public bool Bloqueada { get; private set; }
        public DateTime DataRegistro { get; private set; }
        public byte[] Logotipo { get; private set; }
        public string Observacao { get; private set; }
        public string Documento { get; private set; }
        public int TipoIdentificacao { get; private set; }
        public Guid GrupoEmpresarialId { get; private set; }
        public virtual GrupoEmpresarial GrupoEmpresarial { get; private set; }
        public virtual ICollection<Estabelecimento> Estabelecimentos { get; set; }
        public virtual Usuario Usuario { get; private set; }

        private Empresa() {}

        public override bool IsValid()
        {
            RuleFor(empresa => empresa.Codigo)
                .NotEmpty().WithMessage("Código: campo obrigatório")
                .MinimumLength(1).WithMessage("Código: tamanho mínimo requerido de 1 caracter")
                .MaximumLength(30).WithMessage("Código: limite máximo de 30 caracteres atingido");
            
            RuleFor(empresa => empresa.Descricao)
                .NotEmpty().WithMessage("Descrição: campo obrigatório")
                .MinimumLength(1).WithMessage("Descrição: tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Descrição: limite máximo de 150 caracteres atingido");

            RuleFor(empresa => empresa.NomeFantasia)
                .NotEmpty().WithMessage("Nome fantasia: campo obrigatório")
                .MinimumLength(1).WithMessage("Nome fantasia: tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Nome fantasia: limite máximo de 150 caracteres atingido");

            RuleFor(empresa => empresa.Email)
                .NotEmpty().WithMessage("E-mail: campo obrigatório")
                .MinimumLength(1).WithMessage("E-mail: tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("E-mail: limite máximo de 150 caracteres atingido");

            RuleFor(empresa => empresa.Site)
                .NotEmpty().WithMessage("Site: campo obrigatório")
                .MinimumLength(1).WithMessage("Site: tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Site: limite máximo de 100 caracteres atingido");

            RuleFor(empresa => empresa.DataRegistro)
                .NotEmpty().WithMessage("Data de registro: campo obrigatório");

            RuleFor(empresa => empresa.Documento)
                .NotEmpty().WithMessage("Documento: campo obrigatório")
                .MinimumLength(11).WithMessage("Documento: tamanho mínimo requerido de 11 caracter")
                .MaximumLength(14).WithMessage("Documento: limite máximo de 14 caracteres atingido");

            RuleFor(empresa => empresa.TipoIdentificacao)
                .NotEmpty().WithMessage("Tipo do documento: campo obrigatório");

            RuleFor(empresa => empresa.GrupoEmpresarialId)
                .NotEmpty().WithMessage("GrupoEmpresarialId: campo obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void AtribuirUsuario(Usuario usuario) => Usuario = usuario;

        public void AtribuirGrupoEmpresarial(GrupoEmpresarial grupoEmpresarial) => GrupoEmpresarial = grupoEmpresarial;

        public static class EmpresaFactory
        {
            public static Empresa NewEmpresa(Guid id, string codigo, string descricao, string nomeFantasia, string email, string site, bool bloqueada, DateTime dataRegistro, byte[] logotipo, string observacao, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string documento, int tipoIdentificacao, Guid grupoEmpresarialId, Guid usuarioId)
            {
                var empresa = new Empresa()
                {
                    Id = id,
                    Codigo = codigo,
                    Descricao = descricao,
                    NomeFantasia = nomeFantasia,
                    Email = email,
                    Site = site,
                    Bloqueada = bloqueada,
                    DataRegistro = dataRegistro,
                    Logotipo = logotipo,
                    Observacao = observacao,
                    DataCadastro = dataCadastro,
                    DataUltimaAtualizacao = dataUltimaAtualizacao,
                    Documento = documento,
                    TipoIdentificacao = tipoIdentificacao,
                    GrupoEmpresarialId = grupoEmpresarialId,
                    UsuarioId = usuarioId
                };

                return empresa;
            }

            public static Empresa UpdateEmpresa(Guid id, string codigo, string descricao, string nomeFantasia, string email, string site, bool bloqueada, DateTime dataRegistro, byte[] logotipo, string observacao, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string documento, int tipoIdentificacao, Guid grupoEmpresarialId, Guid usuarioId, bool ativo)
            {
                var empresa = new Empresa()
                {
                    Id = id,
                    Codigo = codigo,
                    Descricao = descricao,
                    NomeFantasia = nomeFantasia,
                    Email = email,
                    Site = site,
                    Bloqueada = bloqueada,
                    DataRegistro = dataRegistro,
                    Logotipo = logotipo,
                    Observacao = observacao,
                    DataCadastro = dataCadastro,
                    DataUltimaAtualizacao = dataUltimaAtualizacao,
                    Documento = documento,
                    TipoIdentificacao = tipoIdentificacao,
                    GrupoEmpresarialId = grupoEmpresarialId,
                    UsuarioId = usuarioId,
                    Ativo = ativo
                };

                return empresa;
            }
        }
    }
}