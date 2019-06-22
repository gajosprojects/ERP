using ERP.Gerencial.Domain.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using ERP.Infra.Data.Context;

namespace ERP.Infra.Data.Repositories.Gerencial
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