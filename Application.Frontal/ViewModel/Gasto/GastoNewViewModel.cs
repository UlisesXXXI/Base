using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.bbdd.Entities.Maestros;

namespace Application.Frontal.ViewModel.Gasto
{
    public class GastoNewViewModel
    {

        #region Propiedades
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoGastoID { get; set; }
        public double Importe { get; set; }
        #endregion

        #region Propiedades Navegacions
        public Application.bbdd.Entities.Maestros.TipoGasto TipoGasto { get; set; }
        #endregion

        #region Logica
        public List<SelectListItem> ComboTipos;

        public bool NuevaEntidad
        {
           get
           {
             return Id == 0;
           }
        }
        #endregion
    }
}