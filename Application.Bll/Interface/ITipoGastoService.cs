using Application.bbdd.Entities.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bll.Interface
{
    public interface ITipoGastoService
    {
        TipoGasto Find(Object[] Id);
        IList<TipoGasto> GetAll();
        IList<TipoGasto> Get(Func<TipoGasto, bool> where);
        TipoGasto Save(TipoGasto entity);
        TipoGasto Update(TipoGasto entity);
        void Delete(Object[] Id);
    }
}
