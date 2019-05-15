using Application.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Application.Infraestructura.EntityFramework;

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

    
        public IQueryable<T> IncluirPropiedades(Expression<Func<T, object>>[] propiedades)
        {
            IQueryable<T> query =  _ctx.Set<T>();
            foreach(var w in propiedades)
            {
                query.Include<T, Object>(w);
            }
            return query;
        }

        public T Insertar(T entidad)
        {
            _ctx.Set<T>().Add(entidad);
            
            _ctx.SaveChanges();
            return entidad;
        }

        public T Actualizar(T entidad)
        {
            _ctx.Set<T>().Add(entidad);
            _ctx.Entry(entidad).State = EntityState.Modified;
            _ctx.SaveChanges();
            return entidad;
        }

        public T Buscar(params object[] Id)
        {
            return _ctx.Set<T>().Find(Id);
        }

        public T BuscarConPropiedades(object[] Id, params Expression<Func<T, object>>[] propiedades)
        {
            return _ctx.Set<T>().Includes(propiedades).First();
        }

        public IList<T> ObtenerTodas()
        {
            return _ctx.Set<T>().ToList();
        }

        public IList<T> ObtenerConPropiedades(Expression<Func<T, bool>> expresion, params Expression<Func<T, object>>[] propiedades)
        {

            return _ctx.Set<T>().Includes(propiedades).Where(expresion).ToList();
        }

        public List<T> ObtenerTodasIncluyendo(params Expression<Func<T, object>>[] propiedades)
        {
           var dbset = _ctx.Set<T>();
            IQueryable<T> query = null;
           foreach(var prop in propiedades)
            {
                query = dbset.Include(prop);
            }

            return query.ToList();
        }
    }
}
