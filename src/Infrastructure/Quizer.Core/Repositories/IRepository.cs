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
        T GetFirst(Expression<Func<T, bool>> predicate = null, bool throwException = true);
        void Remove(T entity);
        T Add(T entity);
        T Edit(T entity, Action<EntityEntry<T>> rules = null);
        int SaveChanges();
    }
}
