using Application.bbdd.Entities;
using Application.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dal.Implementacion
{
    public class GastoRepository:RepositorioGenerico<Gasto>, IGastoRepository
    {
        public GastoRepository(DbContext ctx):base(ctx)
        {
            
        }

    }
}
