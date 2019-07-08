using System;

namespace ERP.Gerencial.Domain.Usuarios.Commands
{
    public class SaveUsuarioCommand : BaseUsuarioCommand
    {
        public SaveUsuarioCommand(Guid id, string nome, string sobrenome, string email)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataCadastro = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
        }
    }
}
