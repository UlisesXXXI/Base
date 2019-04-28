using Application.bbdd.Entities.Maestros;
using Application.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dal.Implementacion
{
    public class TipoGastoRepositorio:RepositorioGenerico<TipoGasto>, ITipoGastoRepositorio 
    {
        public TipoGastoRepositorio(DbContext ctx) : base(ctx)
        {

        }

    }
}
