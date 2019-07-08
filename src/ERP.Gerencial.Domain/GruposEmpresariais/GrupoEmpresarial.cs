using System;
using System.Collections.Generic;
using ERP.Domain.Core.Models;
using ERP.Gerencial.Domain.Usuarios;
using FluentValidation;

namespace ERP.Gerencial.Domain.GruposEmpresariais
{
    public class GrupoEmpresarial : Entity<GrupoEmpresarial>
    {
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual Usuario Usuario { get; private set; }

        private GrupoEmpresarial() { }
        
        public override bool IsValid()
        {
            RuleFor(grupoEmpresarial => grupoEmpresarial.Codigo)
                .NotEmpty().WithMessage("Informe o código")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(30).WithMessage("Limite máximo de 30 caracteres atingido");
            
            RuleFor(grupoEmpresarial => grupoEmpresarial.Descricao)
                .NotEmpty().WithMessage("Informe a descrição")
                .MinimumLength(1).WithMessage("Tamanho mínimo requerido de 1 caracter")
                .MaximumLength(150).WithMessage("Limite máximo de 150 caracteres atingido");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void AtribuirUsuario(Usuario usuario)
        {
            Usuario = usuario;
        }

        public static class GrupoEmpresarialFactory
        {
            public static GrupoEmpresarial NewGrupoEmpresarial(Guid id, string codigo, string descricao, DateTime dataCadastro, DateTime dataUltimaAtualizacao, Guid usuarioId)
            {
                var grupoEmpresarial = new GrupoEmpresarial()
                {
                    Id = id,
                    Codigo = codigo,
                    Descricao = descricao,
                    DataCadastro = dataCadastro,
                    DataUltimaAtualizacao = dataUltimaAtualizacao,
                    UsuarioId = usuarioId
                };

                return grupoEmpresarial;
            }

            public static GrupoEmpresarial UpdateGrupoEmpresarial(Guid id, string codigo, string descricao, DateTime dataCadastro, DateTime dataUltimaAtualizacao, Guid usuarioId, bool ativo)
            {
                var grupoEmpresarial = new GrupoEmpresarial()
                {
                    Id = id,
                    Codigo = codigo,
                    Descricao = descricao,
                    DataCadastro = dataCadastro,
                    DataUltimaAtualizacao = dataUltimaAtualizacao,
                    UsuarioId = usuarioId,
                    Ativo = ativo
                };

                return grupoEmpresarial;
            }
        }
    }
}