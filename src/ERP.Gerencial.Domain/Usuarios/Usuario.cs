﻿using ERP.Domain.Core.Models;
using FluentValidation;
using System;

namespace ERP.Gerencial.Domain.Usuarios
{
    public class Usuario : Entity<Usuario>
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }

        private Usuario() { }

        public override bool IsValid()
        {
            RuleFor(usuario => usuario.Nome)
                .NotEmpty().WithMessage("Informe o nome");

            RuleFor(usuario => usuario.Sobrenome)
                .NotEmpty().WithMessage("Informe o sobrenome");

            RuleFor(usuario => usuario.Email)
                .NotEmpty().WithMessage("Informe o e-mail");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public static class UsuarioFactory
        {
            public static Usuario NewUsuario(Guid id, string nome, string sobrenome, string email)
            {
                var usuario = new Usuario()
                {
                    Id = id,
                    Nome = nome,
                    Sobrenome = sobrenome,
                    Email = email
                };

                return usuario;
            }
        }
    }
}