using ERP.Gerencial.Domain.Usuarios;
using ERP.Gerencial.Domain.Usuarios.Repositories;
using ERP.Infra.Data.Context;

namespace ERP.Infra.Data.Repositories.Gerencial
{
    public class UsuariosRepository : Repository<Usuario>, IUsuariosRepository
    {
        public UsuariosRepository(GruposEmpresariaisContext db) : base(db)
        {
        }
    }
}
