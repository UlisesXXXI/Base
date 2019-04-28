using Application.bbdd.Entities;
using Application.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dal.Implementacion
{
    public abstract class RepositorioGenerico<T> : IRepositorioGenerico<T> where T:class
    {
        private DbContext _ctx;

        public RepositorioGenerico(DbContext ctx)
        {
            _ctx = ctx;
        }

        public void Eliminar(object[] Id)
        {
            var entidad = Buscar(Id);
            _ctx.Entry(entidad).State = EntityState.Deleted;
            _ctx.SaveChanges();
            
        }

        public IList<T> Obtener(Expression<Func<T, bool>> expresion)
        {
            return _ctx.Set<T>().Where(expresion).ToList();
        }

    
        public DbSet<T> IncluirPropiedades(Expression<Func<T, bool>>[] propiedades)
        {
            DbSet<T> query =  _ctx.Set<T>();
            foreach(var w in propiedades)
            {
                query.Include(w);
            }
            return query;
        }

        public T Insertar(T entidad)
        {
            _ctx.Entry(entidad).State = EntityState.Added;
            _ctx.SaveChanges();
            return entidad;
        }

        public T Actualizar(T entidad)
        {
            _ctx.Entry(entidad).State = EntityState.Modified;
            _ctx.SaveChanges();
            return entidad;
        }

        public T Buscar(params object[] Id)
        {
            return _ctx.Set<T>().Find(Id);
        }

        public T BuscarConPropiedades(object[] Id, params Expression<Func<T, bool>>[] propiedades)
        {
            var qry = IncluirPropiedades(propiedades);

            return qry.Find(Id);
        }

        public IList<T> ObtenerTodas()
        {
            return _ctx.Set<T>().ToList();
        }

        public IList<T> ObtenerConPropiedades(Expression<Func<T, bool>> expresion, params Expression<Func<T, bool>>[] propiedades)
        {
            var consulta = IncluirPropiedades(propiedades);
            return consulta.Where(expresion).ToList();
        }

    }
}
