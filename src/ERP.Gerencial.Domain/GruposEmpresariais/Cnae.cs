using System;
using System.Collections.Generic;
using ERP.Domain.Core.Models;
using ERP.Gerencial.Domain.Usuarios;
using FluentValidation;

namespace ERP.Gerencial.Domain.GruposEmpresariais
{
    public class Cnae : Entity<Cnae>
    {
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public Guid? CnaePai { get; private set; }
        public virtual ICollection<Estabelecimento> Estabelecimentos { get; set; }
        public virtual Usuario Usuario { get; private set; }

        private Cnae() { }
        
        public override bool IsValid()
        {
            RuleFor(cnae => cnae.Codigo)
                .NotEmpty().WithMessage("Informe o código")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(7).WithMessage("Limite máximo de 7 caracteres atingido");
            
            RuleFor(cnae => cnae.Descricao)
                .NotEmpty().WithMessage("Informe a descrição")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(255).WithMessage("Limite máximo de 255 caracteres atingido");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public static class CnaeFactory
        {
            public static Cnae NewCnae(Guid id, string codigo, string descricao, Guid? cnaePai, DateTime dataCadastro, DateTime dataUltimaAtualizacao, Guid usuarioId)
            {
                var cnae = new Cnae()
                {
                    Id = id,
                    Codigo = codigo,
                    Descricao = descricao,
                    CnaePai = cnaePai,
                    DataCadastro = dataCadastro,
                    DataUltimaAtualizacao = dataUltimaAtualizacao,
                    UsuarioId = usuarioId
                };

                return cnae;
            }

            public static Cnae UpdateCnae(Guid id, string codigo, string descricao, Guid? cnaePai, DateTime dataCadastro, DateTime dataUltimaAtualizacao, Guid usuarioId, bool ativo)
            {
                var cnae = new Cnae()
                {
                    Id = id,
                    Codigo = codigo,
                    Descricao = descricao,
                    CnaePai = cnaePai,
                    DataCadastro = dataCadastro,
                    DataUltimaAtualizacao = dataUltimaAtualizacao,
                    UsuarioId = usuarioId,
                    Ativo = ativo
                };

                return cnae;
            }
        }
    }
}