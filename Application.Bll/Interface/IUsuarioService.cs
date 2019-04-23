using Application.bbdd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bll.Interface
{
    public interface IUsuarioService
    {

        ApplicationUser Find(Object[] Id);
        IList<ApplicationUser> GetAll();
        IList<ApplicationUser> Get(Func<ApplicationUser, bool> where);
    }
}
