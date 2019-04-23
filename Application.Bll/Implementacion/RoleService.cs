using Application.bbdd.Entities;
using Application.Bll.Interface;
using Application.Dal.Interface;
using System;
using System.Collections.Generic;

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
            return _repository.Find(Id);
        }

        public IList<ApplicationRole> Get(Func<ApplicationRole, bool> where)
        {
            return _repository.Get(where);
        }

        public IList<ApplicationRole> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
