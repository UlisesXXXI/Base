using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Frontal.ViewModel.TipoGasto
{
    public class TipoGastoViewModel
    {
        #region Constructor
        public int TipoGastoID { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        #endregion

        #region Metodos logica vista
        public bool RegistroNuevo {
            get {
                   return TipoGastoID == 0;
                }
        }
        #endregion





    }
}