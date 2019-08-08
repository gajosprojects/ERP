using System;
using ERP.Domain.Core.Models;
using ERP.Gerencial.Domain.Usuarios;
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
        public virtual Usuario Usuario { get; private set; }

        private Estabelecimento() {}

        public override bool IsValid()
        {
            RuleFor(estabeleciamento => estabeleciamento.Codigo)
                .NotEmpty().WithMessage("Código: campo obrigatório")
                .MinimumLength(1).WithMessage("Código: tamanho mínimo requerido de 1 caracter")
                .MaximumLength(30).WithMessage("Código: limite máximo de 30 caracteres atingido");
            
            RuleFor(estabeleciamento => estabeleciamento.Descricao)
                .NotEmpty().WithMessage("Descrição: campo obrigatório")
                .MinimumLength(1).WithMessage("Descrição: tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Descrição: limite máximo de 150 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.NomeFantasia)
                .NotEmpty().WithMessage("Nome fantasia: campo obrigatório")
                .MinimumLength(1).WithMessage("Nome fantasia: tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Nome fantasia: limite máximo de 150 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.InscricaoEstadual)
                .NotEmpty().WithMessage("Inscrição Estadual: campo obrigatório")
                .MinimumLength(20).WithMessage("Inscrição Estadual: tamanho mínimo requerido de 20 caracter")
                .MaximumLength(20).WithMessage("Inscrição Estadual: limite máximo de 20 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.InscricaoMunicipal)
                .NotEmpty().WithMessage("Inscrição Municipal: campo obrigatório")
                .MinimumLength(20).WithMessage("Inscrição Municipal: tamanho mínimo requerido de 20 caracter")
                .MaximumLength(20).WithMessage("Inscrição Municipal: limite máximo de 20 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.Email)
                .NotEmpty().WithMessage("E-mail: campo obrigatório")
                .MinimumLength(1).WithMessage("E-mail: tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("E-mail: limite máximo de 150 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.Site)
                .NotEmpty().WithMessage("Site: campo obrigatório")
                .MinimumLength(1).WithMessage("Site: tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Site: limite máximo de 100 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.DataRegistro)
                .NotEmpty().WithMessage("Data de registro: campo obrigatório");

            RuleFor(estabeleciamento => estabeleciamento.Matriz)
                .NotNull().WithMessage("Matriz: campo obrigatório");

            RuleFor(estabeleciamento => estabeleciamento.Documento)
                .NotEmpty().WithMessage("Documento: campo obrigatório")
                .MinimumLength(11).WithMessage("Documento: tamanho mínimo requerido de 11 caracter")
                .MaximumLength(14).WithMessage("Documento: limite máximo de 14 caracteres atingido");

            RuleFor(estabeleciamento => estabeleciamento.TipoIdentificacao)
                .NotEmpty().WithMessage("Tipo do documento: campo obrigatório");

            RuleFor(estabeleciamento => estabeleciamento.EmpresaId)
                .NotEmpty().WithMessage("EmpresaId: campo obrigatório");

            RuleFor(estabeleciamento => estabeleciamento.CnaeId)
                .NotEmpty().WithMessage("CNAE: campo obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void AtribuirUsuario(Usuario usuario) => Usuario = usuario;

        public void AtribuirCnae(Cnae cnae) => Cnae = cnae;

        public void AtribuirEmpresa(Empresa empresa) => Empresa = empresa;

        public static class EstabelecimentoFactory
        {
            public static Estabelecimento NewEstabelecimento(Guid id, string codigo, string descricao, string nomeFantasia, string inscricaoEstadual, string inscricaoMunicipal, string email, string site, bool bloqueado, DateTime dataRegistro, byte[] logotipo, bool matriz, string observacao, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string documento, int tipoIdentificacao, Guid empresaId, Guid cnaeId, Guid usuarioId)
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
                    CnaeId = cnaeId,
                    UsuarioId = usuarioId
                };

                return estabelecimento;
            }

            public static Estabelecimento UpdateEstabelecimento(Guid id, string codigo, string descricao, string nomeFantasia, string inscricaoEstadual, string inscricaoMunicipal, string email, string site, bool bloqueado, DateTime dataRegistro, byte[] logotipo, bool matriz, string observacao, DateTime dataCadastro, DateTime dataUltimaAtualizacao, string documento, int tipoIdentificacao, Guid empresaId, Guid cnaeId, Guid usuarioId, bool ativo)
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
                    CnaeId = cnaeId,
                    UsuarioId = usuarioId,
                    Ativo = ativo
                };

                return estabelecimento;
            }
        }
    }
}