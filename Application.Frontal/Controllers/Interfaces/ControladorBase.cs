using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Frontal.Controllers.Interfaces
{
    public abstract class ControladorBase:Controller
    {
        public ActionResult Error(string mensaje = null)
        {
            return View("Error",mensaje);
        }
    }
}