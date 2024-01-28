using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Quizer.Core.Repositories
{
    public interface IRepository<T> 
        where T : class,new()
    {
        IQueryable<T> GetAll(Expression<Func<T,bool>> predicate =null);
        T GetFirst(Expression<Func<T, bool>> predicate = null);
        void Remove(T entity);
        T Add(T entity);
        T Edit(T entity, EntityEntry<T> rules = null);
        int SaveChanges();
    }

    public abstract class Repository<T> : IRepository<T>
        where T : class, new()
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _table;

        public Repository(DbContext db)
        {
            _db=db;
            _table = db.Set<T>();
        }

        protected DbContext Db { get => _db; }
        protected DbSet<T> Table { get => _table; }
        public T Add(T entity)
        {
            _table.Add(entity);
            return entity;
        }

        public T Edit(T entity, EntityEntry<T> rules = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var query = Table.AsQueryable();

            if (predicate!=null)
                return query.Where(predicate);
            return query;
        }

        public T GetFirst(Expression<Func<T, bool>> predicate = null)
        {
            var query = Table.AsQueryable();
            if(predicate!=null)
                query = query.Where(predicate);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _table.Remove(entity);
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}
