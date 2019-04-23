using Application.bbdd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bll.Interface
{
    public interface IRoleService
    {
        IList<ApplicationRole> GetAll();
        ApplicationRole Find(Object[] Id);
        IList<ApplicationRole> Get(Func<ApplicationRole, bool> where);
    }
}
