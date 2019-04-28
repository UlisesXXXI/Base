using Application.bbdd.Entities;
using Application.Bll.Interface;
using Application.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Bll.Implementacion
{
    public class RoleService : IRoleService
    {

        #region Private fields
        IRepositorioGenerico<ApplicationRole> _repository;
        #endregion

        #region Constructor
        public RoleService(IRepositorioGenerico<ApplicationRole> repositorio)
        {
            this._repository = repositorio;
        }
        #endregion

        public ApplicationRole Find(object[] Id)
        {
            return _repository.Buscar(Id);
        }

        public IList<ApplicationRole> Get(Expression<Func<ApplicationRole, bool>> where)
        {
            return _repository.Obtener(where);
        }

        public IList<ApplicationRole> Get(Func<ApplicationRole, bool> where)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicationRole> GetAll()
        {
            return _repository.ObtenerTodas();
        }
    }
}
