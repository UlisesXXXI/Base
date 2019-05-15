using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infraestructura.EntityFramework
{
    public static class EntityFrameWorkExtensions
    {
        
            public static IQueryable<TEntity> Includes<TEntity>(this IDbSet<TEntity> dbSet,
                                                    params Expression<Func<TEntity, object>>[] includes)
                                                    where TEntity : class
            {
                IQueryable<TEntity> query = null;
                foreach (var include in includes)
                {
                query = dbSet.Include(include);
                }

                return query == null ? dbSet : query;
            }
        
    }
}
