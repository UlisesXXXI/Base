using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dal.Interface
{
    public interface IRepositorioGenerico<T>
    {
        T Find(Object[] Id);
        IList<T> GetAll();
        IList<T> Get(Func<T, bool> where);
        T Save(T entity);
        T Update(T entity);
        void Delete(Object[] Id);
        
    }
}
