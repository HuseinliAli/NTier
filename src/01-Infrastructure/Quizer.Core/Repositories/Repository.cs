using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly DbContext db;
        protected readonly DbSet<T> table;

        public Repository(DbContext db)
        {
            this.db = db;
            this.table = db.Set<T>();
        }

        public DbContext Db { get => this.Db; }
        public DbSet<T> Table { get => this.table; }

        public T Add(T entity)
        {
            this.table.Add(entity);
            return entity;
        }

        public T Edit(T entity, EntityEntry<T> rules = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            var query = this.table.AsQueryable();

            if(expression != null)
            {
                query = query.Where(expression);
            }

            return query;
        }

        public T GetFirst(Expression<Func<T, bool>> expression = null)
        {

            var query = this.table.AsQueryable();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            this.table.Remove(entity);
        }

        public int Save()
        {
            return this.db.SaveChanges();
        }
    }
}
