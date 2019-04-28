using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.bbdd.Entities;

namespace Application.Dal.Interface
{
    public interface IRepositorioGenerico<T> where T : class
    {
        T Buscar(params Object[] Id);
        T BuscarConPropiedades(Object[] Id, params Expression<Func<T, bool>>[] propiedades);
        IList<T> ObtenerTodas();
        IList<T> Obtener(Expression<Func<T, bool>> expresion);
        IList<T> ObtenerConPropiedades(Expression<Func<T, bool>> expresion, params Expression<Func<T, bool>>[] propiedades);
        T Insertar(T entidad);
        T Actualizar(T entidad);
        void Eliminar(Object[] Id);
        DbSet<T> IncluirPropiedades(Expression<Func<T, bool>>[] propiedades);
        
    }
}
