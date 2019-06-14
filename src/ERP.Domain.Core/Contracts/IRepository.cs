using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ERP.Domain.Core.Models;

namespace ERP.Domain.Core.Contracts
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Save(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where);
        int SaveChanges();
    }
}