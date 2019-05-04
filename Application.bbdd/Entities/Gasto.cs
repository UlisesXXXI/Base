using Application.bbdd.Entities.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.bbdd.Entities
{
    public class Gasto
    {
        #region Propiedades
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoGastoID { get; set; }
        public double Importe { get; set; }
        #endregion

        #region Propiedades Navegacions
        public virtual TipoGasto TipoGasto { get; set; }
        #endregion


    }
}
