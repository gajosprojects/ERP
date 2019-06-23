using ERP.Domain.Core.Commands;
using System;

namespace ERP.Gerencial.Domain.Usuarios.Commands
{
    public class BaseUsuarioCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public string Email { get; protected set; }
    }
}
