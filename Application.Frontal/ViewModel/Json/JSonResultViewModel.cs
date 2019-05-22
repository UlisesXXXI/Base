using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Frontal.ViewModel.Json
{
    public class JSonResultViewModel
    {
        public string mensaje { get; set; }
        public bool hayError { get { return mensajeError  != null && mensajeError.Length > 0; } }
        public string mensajeError { get; set; }
        public bool hayRedireccion { get {return UrlRedireccion != null && UrlRedireccion.Length > 0; } }
        public string UrlRedireccion { get; set; }
    }
}