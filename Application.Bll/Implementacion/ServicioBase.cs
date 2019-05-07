using Application.Bll.Interface;
using Application.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bll.Implementacion
{
    public abstract class ServicioBase<T> : IServicioBase<T> where T: class
    {
        IRepositorioGenerico<T> _repositorio;

        #region Constructor
        public ServicioBase(IRepositorioGenerico<T> repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region Metodos Crud
        public void Eliminar(params Object[] Id)
        {
            AntesDeEliminar(Id);
            _repositorio.Eliminar(Id);
            DespuesDeEliminar();
        }

        public T Insertar(T entidad)
        {
            AntesDeInsertar(ref entidad);
            entidad = _repositorio.Insertar(entidad);
            DespuesDeInsertar(ref entidad);
            return entidad;
        }

        public T Modificar(T entidad)
        {
            AntesDeGuardar(ref entidad);
            entidad = _repositorio.Actualizar(entidad);
            DespuesDeGuardar(ref entidad);
            return entidad;

        }
        #endregion

        #region Selectores
        public T Obtener(params object[] Id)
        {
            return _repositorio.Buscar(Id);
        }

        public IList<T> Obtener(Expression<Func<T, bool>> where)
        {
            return _repositorio.Obtener(where);
        }

        public ICollection<T> ObtenerTodos()
        {
            return _repositorio.ObtenerTodas();
        }

        public IList<T> ObtenerTodosInclyendo(params Expression<Func<T, object>>[] propiedades)
        {
            var query = _repositorio.IncluirPropiedades(propiedades);
            return query.ToList();

        }
        #endregion

        #region Metodos Before After (Insert/update/delete)
        public virtual void AntesDeInsertar(ref T entidad)
        {

        }

        public virtual void DespuesDeInsertar(ref T entidad)
        {

        }

        public virtual void AntesDeGuardar(ref T entidad)
        {

        }

        public virtual void DespuesDeGuardar(ref T entidad)
        {

        }

        public virtual void AntesDeEliminar(params Object[] Id)
        {

        }

        public virtual void DespuesDeEliminar()
        {

        }
        #endregion


    }
}
