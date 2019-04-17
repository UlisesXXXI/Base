using Application.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dal.Implementacion
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T:class
    {
        private DbContext _ctx;

        public RepositorioGenerico(DbContext ctx)
        {
            _ctx = ctx;
        }

        public void Delete(object[] Id)
        {
            var entity = Find(Id);
            _ctx.Entry(entity).State = EntityState.Deleted;
            _ctx.SaveChanges();
            
        }

        public T Find(object[] Id)
        {
           return  _ctx.Set<T>().Find(Id);
        }

        public IList<T> Get(Func<T, bool> where)
        {
            return _ctx.Set<T>().Where(where).ToList();
        }

        public IList<T> GetAll()
        {
            return _ctx.Set<T>().ToList();
        }

        public T Save(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Added;
            _ctx.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
            return entity;
        }
    }
}
