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

        public override void AntesDeInsertar(ref TipoGasto entidad)
        {
            base.AntesDeInsertar(ref entidad);
            TodoAMayusculas(ref entidad);
        }

        private void TodoAMayusculas(ref TipoGasto entidad)
        {
            entidad.Descripcion = entidad.Descripcion.ToUpper();
        }
    }
}
