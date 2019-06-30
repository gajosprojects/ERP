using System;
using ERP.Domain.Core.Models;
using FluentValidation;

namespace ERP.Gerencial.Domain.GruposEmpresariais
{
    public class Estabelecimento : Entity<Estabelecimento>
    {
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string NomeFantasia { get; private set; }
        public string InscricaoEstadual { get; private set; }
        public string InscricaoMunicipal { get; private set; }
        public string Email { get; private set; }
        public string Site { get; private set; }
        public bool Bloqueado { get; private set; }
        public DateTime DataRegistro { get; private set; }
        public byte[] Logotipo { get; private set; }
        public bool Matriz { get; private set; }
        public string Observacao { get; private set; }
        public string Documento { get; private set; }
        public int TipoIdentificacao { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Guid CnaeId { get; private set; }
        public virtual Empresa Empresa { get; private set; }
        public virtual Cnae Cnae { get; private set; }

        private Estabelecimento() {}

        public override bool IsValid()
        {
            RuleFor(estabeleciamento => estabeleciamento.Codigo)
                .NotEmpty().WithMessage("Informe o código")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(30).WithMessage("Limite máximo de 30 caracteres atingido");
            
            RuleFor(estabeleciamento => estabeleciamento.Descricao)
                .NotEmpty().WithMessage("Informe a descrição")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Limite máximo de 150 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.NomeFantasia)
                .NotEmpty().WithMessage("Informe o nome fantasia")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Limite máximo de 150 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.InscricaoEstadual)
                .NotEmpty().WithMessage("Informe a inscrição estadual")
                .MinimumLength(20).WithMessage("Tamanho mínimo requerido de 20 caracter")
                .MaximumLength(20).WithMessage("Limite máximo de 20 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.InscricaoMunicipal)
                .NotEmpty().WithMessage("Informe a inscrição municipal")
                .MinimumLength(20).WithMessage("Tamanho mínimo requerido de 20 caracter")
                .MaximumLength(20).WithMessage("Limite máximo de 20 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.Email)
                .NotEmpty().WithMessage("Informe o e-mail")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Limite máximo de 150 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.Site)
                .NotEmpty().WithMessage("Informe o site")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Limite máximo de 100 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.DataRegistro)
                .NotEmpty().WithMessage("Informe a data de registro");

            RuleFor(estabeleciamento => estabeleciamento.Matriz)
                .NotEmpty().WithMessage("Informe se o estabelecimento é a matriz");

            RuleFor(estabeleciamento => estabeleciamento.Documento)
                .NotEmpty().WithMessage("Informe o documento")
                .MinimumLength(11).WithMessage("Tamanho mínimo requerido de 11 caracter")
                .MaximumLength(14).WithMessage("Limite máximo de 14 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.TipoIdentificacao)
                .NotEmpty().WithMessage("Informe o tipo do documento");

            RuleFor(estabeleciamento => estabeleciamento.EmpresaId)
                .NotEmpty().WithMessage("Uma estabelecimento precisa estar vinculado a uma empresa");

            RuleFor(estabeleciamento => estabeleciamento.CnaeId)
                .NotEmpty().WithMessage("Uma estabelecimento precisa estar vinculado a um cnae");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public static class EstabelecimentoFactory
        {
            public static Estabelecimento NewEstabelecimento(Guid id, string codigo, string descricao, string nomeFantasia, string inscricaoEstadual, string inscricaoMunicipal, string email, string site, bool bloqueado, DateTime dataRegistro, byte[] logotipo, bool matriz, string observacao, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string documento, int tipoIdentificacao, Guid empresaId, Guid cnaeId)
            {
                var estabelecimento = new Estabelecimento()
                {
                    Id = id,
                    Codigo = codigo,
                    Descricao = descricao,
                    NomeFantasia = nomeFantasia,
                    InscricaoEstadual = inscricaoEstadual,
                    InscricaoMunicipal = inscricaoMunicipal,
                    Email = email,
                    Site = site,
                    Bloqueado = bloqueado,
                    DataRegistro = dataRegistro,
                    Logotipo = logotipo,
                    Matriz = matriz,
                    DataCadastro = dataCadastro,
                    DataUltimaAtualizacao = dataUltimaAtualizacao,
                    Observacao = observacao,
                    Documento = documento,
                    TipoIdentificacao = tipoIdentificacao,
                    EmpresaId = empresaId,
                    CnaeId = cnaeId
                };

                return estabelecimento;
            }

            public static Estabelecimento UpdateEstabelecimento(Guid id, string codigo, string descricao, string nomeFantasia, string inscricaoEstadual, string inscricaoMunicipal, string email, string site, bool bloqueado, DateTime dataRegistro, byte[] logotipo, bool matriz, string observacao, DateTime dataUltimaAtualizacao, string documento, int tipoIdentificacao, Guid empresaId, Guid cnaeId)
            {
                var estabelecimento = new Estabelecimento()
                {
                    Id = id,
                    Codigo = codigo,
                    Descricao = descricao,
                    NomeFantasia = nomeFantasia,
                    InscricaoEstadual = inscricaoEstadual,
                    InscricaoMunicipal = inscricaoMunicipal,
                    Email = email,
                    Site = site,
                    Bloqueado = bloqueado,
                    DataRegistro = dataRegistro,
                    Logotipo = logotipo,
                    Matriz = matriz,
                    DataUltimaAtualizacao = dataUltimaAtualizacao,
                    Observacao = observacao,
                    Documento = documento,
                    TipoIdentificacao = tipoIdentificacao,
                    EmpresaId = empresaId,
                    CnaeId = cnaeId
                };

                return estabelecimento;
            }
        }
    }
}