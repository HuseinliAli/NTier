using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Quizer.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
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

        public T Edit(T entity, Action<EntityEntry<T>> rules = null)
        {
            var entry = db.Entry(entity);
            if (rules == null)
                goto summary;

            foreach (var propertyInfo in typeof(T).GetProperties().Where(p=>p.IsEditable()))
            {
                entry.Property(propertyInfo.Name).IsModified =false;
            }
            rules(entry);
            summary:
            entry.State = EntityState.Modified;
            return entity;
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
