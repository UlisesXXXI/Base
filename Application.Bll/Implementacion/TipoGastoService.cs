using Application.bbdd.Entities.Maestros;
using Application.Bll.Interface;
using Application.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bll.Implementacion
{
    public class TipoGastoService : ServicioBase<TipoGasto> ,ITipoGastoService
    {

        public TipoGastoService(ITipoGastoRepositorio _repositorio):base(_repositorio)
        {

        }
        public TipoGasto MetodoEspecificoIntefaz()
        {
            return new TipoGasto();
        }

       

        
    }
}
