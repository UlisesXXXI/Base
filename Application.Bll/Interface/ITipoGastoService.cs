using Application.bbdd.Entities.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bll.Interface
{
    public interface ITipoGastoService:IServicioBase<TipoGasto>
    {
        TipoGasto MetodoEspecificoIntefaz();
    }
}
