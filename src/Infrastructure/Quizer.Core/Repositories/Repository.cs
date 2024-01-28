 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quizer.Core.Extensions;
using System.Linq.Expressions;

namespace Quizer.Core.Repositories
{
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

        public T Edit(T entity,Action<EntityEntry<T>> rules = null)
        {
            var entry = _db.Entry(entity);

            if (rules==null)
                goto summary;

            foreach (var propertyInfo in typeof(T).GetProperties().Where(x=>x.IsEditable()))
            {
                entry.Property(propertyInfo.Name).IsModified=false;
            }
            rules(entry);

        summary:
            entry.State=EntityState.Modified;
            return entity;
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
