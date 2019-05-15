using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.bbdd.Entities.Interfaces
{
    public interface ISoftDelete
    {
         bool Deleted { get; set; }
    }
}
