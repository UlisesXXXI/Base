using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.bbdd.Entities
{
    public class ApplicationRole:IdentityRole
    {
        public bool Active { get; set; }

        
    }
}
