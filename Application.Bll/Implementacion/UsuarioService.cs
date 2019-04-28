using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            return _repository.Buscar(Id);
        }

        public IList<ApplicationUser> Get(Expression<Func<ApplicationUser, bool>> where)
        {
            return _repository.Obtener(where);
        }

        public IList<ApplicationUser> GetAll()
        {
            return _repository.ObtenerTodas();
        }
        #endregion


    }
}
