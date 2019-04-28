using Application.bbdd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bll.Interface
{
    public interface IUsuarioService
    {

        ApplicationUser Find(Object[] Id);
        IList<ApplicationUser> GetAll();
        IList<ApplicationUser> Get(Expression<Func<ApplicationUser, bool>> where);
    }
}
