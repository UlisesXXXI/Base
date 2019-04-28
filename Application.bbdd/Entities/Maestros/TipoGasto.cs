using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.bbdd.Entities.Maestros
{
    public class TipoGasto
    {
        public int TipoGastoID { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
