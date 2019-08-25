using FluentValidation;
using FluentValidation.Results;
using System;

namespace ERP.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public abstract bool IsValid();
        public Guid Id { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataUltimaAtualizacao { get; protected set; }
        public bool Excluido { get; protected set; }
        public Guid UsuarioId { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public void Excluir(Guid usuarioId) 
        {
            Excluido = true;
            UsuarioId = usuarioId;
            DataUltimaAtualizacao = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }
    }
}