using Application.Bll.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Frontal.Controllers
{
    public class GastoController : Controller
    {
        private IGastoService _service;
        public GastoController(IGastoService service)
        {
            _service = service;
        }
        // GET: Gasto
        public ActionResult Index()
        {
            var lista = _service.ObtenerTodos();
            return View();
        }
    }
}