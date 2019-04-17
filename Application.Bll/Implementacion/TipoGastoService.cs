using Application.bbdd.Entities.Maestros;
using Application.Bll.Interface;
using Application.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bll.Implementacion
{
    public class TipoGastoService : ITipoGastoService
    {
        #region Campos Privados
        private IRepositorioGenerico<TipoGasto> _repositorio;
        #endregion


        #region Constructor
        public TipoGastoService(IRepositorioGenerico<TipoGasto> repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion


        public void Delete(object[] Id)
        {
            _repositorio.Delete(Id);
        }

        public TipoGasto Find(object[] Id)
        {
            return _repositorio.Find(Id);
        }

        public IList<TipoGasto> Get(Func<TipoGasto, bool> where)
        {
            return _repositorio.Get(where);
        }

        public IList<TipoGasto> GetAll()
        {
            return _repositorio.GetAll();
        }

        public TipoGasto Save(TipoGasto entity)
        {
            return _repositorio.Save(entity);
        }

        public TipoGasto Update(TipoGasto entity)
        {
            return _repositorio.Update(entity);
        }
    }
}
