using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bll.Interface
{
    public interface IServicioBase<T>
    {
        [OperationContract]
        T Obtener(params Object[] Id);
        ICollection<T> ObtenerTodos();
        IList<T> Obtener(Expression<Func<T, bool>> where);
        IList<T> ObtenerTodosInclyendo(params Expression<Func<T, object>>[] propiedades);
        T Insertar(T entidad);
        T Modificar(T entidad);
        void Eliminar(params Object[] Id);

    }
}
