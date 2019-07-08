using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ERP.Domain.Core.Contracts;
using ERP.Domain.Core.Models;
using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected GruposEmpresariaisContext _db;
        protected DbSet<TEntity> _dbSet;

        public Repository(GruposEmpresariaisContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual void Save(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public virtual void Delete(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.AsNoTracking().Where(where);
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}