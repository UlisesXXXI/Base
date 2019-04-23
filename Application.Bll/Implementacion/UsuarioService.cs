using System;
using System.Collections.Generic;
using Application.bbdd.Entities;
using Application.Bll.Interface;
using Application.Dal.Interface;

namespace Application.Bll.Implementacion
{
    public class UsuarioService:IUsuarioService
    {
        #region Private Fields
        IRepositorioGenerico<ApplicationUser> _repository;
        #endregion
        #region Constructor
        public UsuarioService(IRepositorioGenerico<ApplicationUser> repository)
        {
            this._repository = repository;
        }
        #endregion
        #region Public methods
        public ApplicationUser Find(object[] Id)
        {
            return _repository.Find(Id);
        }

        public IList<ApplicationUser> Get(Func<ApplicationUser, bool> where)
        {
            return _repository.Get(where);
        }

        public IList<ApplicationUser> GetAll()
        {
            return _repository.GetAll();
        }
        #endregion


    }
}
