using ERP.Admin.Domain.GruposEmpresariais;
using ERP.Admin.Domain.GruposEmpresariais.Repositories;
using ERP.Infra.Data.Context;

namespace ERP.Infra.Data.Repositories.Admin
{
    public class GruposEmpresariaisRepository : Repository<GrupoEmpresarial>, IGruposEmpresariaisRepository
    {
        public GruposEmpresariaisRepository(GruposEmpresariaisContext db) : base(db)
        {
        }

        public override void Delete(GrupoEmpresarial obj) 
        {
            var grupoEmpresarial = GetById(obj.Id);
            grupoEmpresarial.Desativar();
            Update(grupoEmpresarial);
        }
    }
}