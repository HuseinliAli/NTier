using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Core.Extensions
{
    public static partial class Extension
    {
        public static bool IsEditable(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null || !propertyInfo.CanWrite)
                return false;
            if (propertyInfo.PropertyType == typeof(string))
                return true;
            if (propertyInfo.PropertyType.IsClass || typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
                return false;

            return true;
        }

        public static EntityEntry<TEntity> SetValue<TEntity, TProperty> (this EntityEntry<TEntity> entry, 
            Expression<Func<TEntity, TProperty>> propertyExpression, 
            TProperty value) where TEntity: class
        {
            entry.Property(propertyExpression).IsModified =true;
            entry.Property(propertyExpression).CurrentValue = value;

            return entry;
        }
    }
}
