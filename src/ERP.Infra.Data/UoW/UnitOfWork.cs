using ERP.Domain.Core.Contracts;
using ERP.Infra.Data.Context;

namespace ERP.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GruposEmpresariaisContext _context;

        public UnitOfWork(GruposEmpresariaisContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}