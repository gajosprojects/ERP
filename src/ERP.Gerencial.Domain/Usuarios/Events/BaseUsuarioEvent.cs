using ERP.Domain.Core.Events;
using System;

namespace ERP.Gerencial.Domain.Usuarios.Events
{
    public class BaseUsuarioEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public string Email { get; protected set; }
    }
}
