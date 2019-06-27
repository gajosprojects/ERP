using System;

namespace ERP.Gerencial.Domain.Usuarios.Events
{
    public class SavedUsuarioEvent : BaseUsuarioEvent
    {
        public SavedUsuarioEvent(Guid id, string nome, string sobrenome, string email)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
        }
    }
}
