using System;
using System.Collections.Generic;
using ERP.Domain.Core.Models;
using FluentValidation;

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

        private Empresa() {}

        public override bool IsValid()
        {
            RuleFor(empresa => empresa.Codigo)
                .NotEmpty().WithMessage("Informe o código")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(30).WithMessage("Limite máximo de 30 caracteres atingido");
            
            RuleFor(empresa => empresa.Descricao)
                .NotEmpty().WithMessage("Informe a descrição")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Limite máximo de 150 caracteres atingido");

            RuleFor(empresa => empresa.NomeFantasia)
                .NotEmpty().WithMessage("Informe o nome fantasia")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Limite máximo de 150 caracteres atingido");

            RuleFor(empresa => empresa.Email)
                .NotEmpty().WithMessage("Informe o e-mail")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Limite máximo de 150 caracteres atingido");

            RuleFor(empresa => empresa.Site)
                .NotEmpty().WithMessage("Informe o site")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Limite máximo de 100 caracteres atingido");

            RuleFor(empresa => empresa.DataRegistro)
                .NotEmpty().WithMessage("Informe a data de registro");

            RuleFor(empresa => empresa.Documento)
                .NotEmpty().WithMessage("Informe o documento")
                .MinimumLength(11).WithMessage("Tamanho mínimo requerido de 11 caracter")
                .MaximumLength(14).WithMessage("Limite máximo de 14 caracteres atingido");

            RuleFor(empresa => empresa.TipoIdentificacao)
                .NotEmpty().WithMessage("Informe o tipo do documento");

            RuleFor(empresa => empresa.GrupoEmpresarialId)
                .NotEmpty().WithMessage("Uma empresa precisa estar vinculada a um grupo empresarial");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
            

        public static class EmpresaFactory
        {
            public static Empresa NewEmpresa(Guid id, string codigo, string descricao, string nomeFantasia, string email, string site, bool bloqueada, DateTime dataRegistro, byte[] logotipo, string observacao, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string documento, int tipoIdentificacao, Guid grupoEmpresarialId)
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
                    GrupoEmpresarialId = grupoEmpresarialId
                };

                return empresa;
            }

            public static Empresa UpdateEmpresa(Guid id, string codigo, string descricao, string nomeFantasia, string email, string site, bool bloqueada, DateTime dataRegistro, byte[] logotipo, string observacao, DateTime dataUltimaAtualizacao, string documento, int tipoIdentificacao, Guid grupoEmpresarialId)
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
                    DataUltimaAtualizacao = dataUltimaAtualizacao,
                    Documento = documento,
                    TipoIdentificacao = tipoIdentificacao,
                    GrupoEmpresarialId = grupoEmpresarialId
                };

                return empresa;
            }
        }
    }
}